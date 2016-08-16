using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

namespace HVCW {
    namespace Auth {

        /// <summary >
        /// Wrap Web API
        /// </summary >
        public class ClassWebAPI {
            // 無線LAN関係のクラス
            WlanAPI wlanAPI = new WlanAPI();

            /** Get API key from OMRON */
            //static string API_KEY = ""; // Change to obtained key

            // オムロンWebAPIのURL
            static string SERVICE_URL = "https://developer.hvc.omron.com/c2w/api/v1/";

            // SSID 
            public string ssid = "";
            /** Access token */
            public string accessToken = "";

            /** Camera list */
            public List<JsonHandler.CameraList> cameraList;

            // ***** New registration *****
            /// <summary>
            /// ユーザー登録を行います。
            /// </summary>
            /// <param name="api_key">事前申請で取得したAPIキー</param>
            /// <param name="mail">ユーザー識別のためのメールアドレス</param>
            /// <returns></returns>
            public bool signup(string api_key, string mail) {
                // POST URL
                string url = SERVICE_URL + "signup.php";
                // POST method parameter
                string param = "";

                // Dictionary object
                var dic = new Dictionary<string, string>();
                dic["apiKey"] = api_key;
                dic["email"] = mail;

                // Create POST method parameter
                foreach (string key in dic.Keys)
                    param += String.Format("{0}={1}&", key, dic[key]);


                // Encode param in ASCII
                byte[] data = Encoding.ASCII.GetBytes(param.Substring(0, param.Length - 1));
                return HttpReqRes(url, data);
            }

            /// <summary>
            /// オムロンサーバーにログインしてアクセストークンを取得します。
            /// </summary>
            /// <param name="api_key">事前申請で取得したAPIキー</param>
            /// <param name="mail">ユーザー識別のためのメールアドレス</param>
            /// <param name="password">確認メールにあるパスワード</param>
            /// <returns></returns>
            public bool login(string api_key, string mail, string password) {
                if (accessToken != "") {
                    return true;
                }

                // Get wireless LAN info
                wlanAPI.EnumerateNICs();
                // Hold SSID
                ssid = wlanAPI.ssid;

                // POST URL
                string url = SERVICE_URL + "login.php";
                // POST method parameter
                string param = "";

                // Dictionary object
                var dic = new Dictionary<string, string>();
                dic["apiKey"] = api_key;

                dic["osType"] = "1";
                if (wlanAPI.macad.Length > 0) {
                    // Set MAC address
                    dic["deviceId"] = wlanAPI.macad;
                } else {
                    // Set dummy value (when MAC address cannot be obtained)
                    dic["deviceId"] = "00-00-00-00-00-00-00-00";
                }
                dic["email"] = mail;
                dic["password"] = password;

                // Create POST method parameter
                foreach (string key in dic.Keys)
                    param += String.Format("{0}={1}&", key, dic[key]);

                // 
                string fixedParam = param.Substring(0, param.Length - 1);

                // Encode param in ASCII
                byte[] data = Encoding.ASCII.GetBytes(param);
                return HttpReqRes(url, data);
            }

            // ***** Logout *****
            public bool logout() {
                if (accessToken == "") {
                    return true;
                }

                // POST URL
                string url = SERVICE_URL + "logout.php";
                // POST method parameter
                string param = "";

                // Encode param in ASCII
                byte[] data = Encoding.ASCII.GetBytes(param);
                if (HttpReqRes(url, data) == true) {
                    accessToken = "";
                    return true;
                }
                return false;
            }

            // ***** Get camera list from server *****
            public bool getCameraList() {
                if (accessToken == "") {
                    return false;
                }

                // POST URL
                string url = SERVICE_URL + "getCameraList.php";
                // POST method parameter
                string param = "";

                // Encode param in ASCII
                byte[] data = Encoding.ASCII.GetBytes(param);
                return HttpReqRes(url, data);
            }

            // ***** Contact server and obtain response data *****
            bool HttpReqRes(string url, byte[] data) {
                bool bRet = false;

                // Create request
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                if (accessToken != "") {
                    // For request requiring access token
                    request.Headers.Add("Authorization", "Bearer " + accessToken);
                }
                request.ContentLength = data.Length;

                System.Net.HttpWebResponse response = null;
                try {
                    // Write POST data in request
                    using (System.IO.Stream reqStream = request.GetRequestStream())
                        reqStream.Write(data, 0, data.Length);

                    // Get response レスポンスを受けれない
                    response = (System.Net.HttpWebResponse)request.GetResponse();

                    // Read result
                    JsonHandler.ResponseData resData;
                    using (System.IO.Stream resStream = response.GetResponseStream())
                        resData = (JsonHandler.ResponseData)JsonHandler.getObjectFromJson(resStream, typeof(JsonHandler.ResponseData));

                    // Hold camera info
                    cameraList = resData.cameraList;

                    // Output result
                    string htmlString = resData.result.code + ":" + resData.result.msg;
                    Console.WriteLine(htmlString);
                    if (resData.result.code != "W2C00000") {
                        MessageBox.Show("Web API error. Error code below.\n" + htmlString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        if (resData.access != null) {
                            // Hold access token
                            accessToken = resData.access.token;
                        }
                        // Normal end
                        bRet = true;
                    }
                } catch (System.Net.WebException ex) {
                    // Check if http protocol error
                    if (ex.Status == System.Net.WebExceptionStatus.ProtocolError) {
                        // Get HttpWebResponse
                        System.Net.HttpWebResponse errres = (System.Net.HttpWebResponse)ex.Response;
                        // Display response status code
                        string err = string.Format("{0}:{1}", errres.StatusCode, errres.StatusDescription);
                        MessageBox.Show("Web API error. Error code below.\n" + err, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Console.WriteLine(ex.Message);
                        MessageBox.Show("Web API error. Error code below.\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } finally {
                    // Close
                    if (response != null) {
                        response.Close();
                    }
                }
                return bRet;
            }
        }

        /// <summary >
        /// JSONパーサークラス
        /// </summary >
        public class JsonHandler {
            /// <summary>
            /// Return JSON value as object
            /// </summary>
            /// <param name="resStream"></param>
            /// <param name="t"></param>
            /// <returns></returns>
            public static object getObjectFromJson(System.IO.Stream resStream, Type t) {
                var serializer = new DataContractJsonSerializer(t);
                return serializer.ReadObject(resStream);
            }

            /// <summary>
            /// WebAPI結果データまとめ
            /// </summary>
            [DataContract]
            public class ResponseData {
                // Result member
                [DataMember(Name = "result")]
                public ResultData result { get; set; }
                // Access member
                [DataMember(Name = "access")]
                public AccessData access { get; set; }
                // cameraList member
                [DataMember(Name = "cameraList")]
                public List<CameraList> cameraList { get; set; }
            }

            /// <summary>
            /// WebAPI結果データ（エラーメッセージやコード）
            /// </summary>
            [DataContract]
            public class ResultData {
                // Code
                [DataMember(Name = "code")]
                public string code { get; set; }
                // Message
                [DataMember(Name = "msg")]
                public string msg { get; set; }
            }

            /// <summary>
            /// WebAPI結果データ（トークンなどの認証情報）
            /// </summary>
            [DataContract]
            public class AccessData {
                // Token
                [DataMember(Name = "token")]
                public string token { get; set; }
                // Valid period
                [DataMember(Name = "expiresIn")]
                public int expiresIn { get; set; }
            }

            /// <summary>
            /// WebAPI結果データ（カメラ情報）
            /// </summary>
            [DataContract]
            public class CameraList {
                // Camera ID
                [DataMember(Name = "cameraId")]
                public string cameraId { get; set; }
                // Camera name
                [DataMember(Name = "cameraName")]
                public string cameraName { get; set; }
                // Camera MAC address
                [DataMember(Name = "cameraMacAddr")]
                public string cameraMacAddr { get; set; }
                // Application ID
                [DataMember(Name = "appId")]
                public int appId { get; set; }
                // Owner type
                [DataMember(Name = "ownerType")]
                public int ownerType { get; set; }
                // Owner email address
                [DataMember(Name = "ownerEmail")]
                public string ownerEmail { get; set; }
            }
        }
    }
}