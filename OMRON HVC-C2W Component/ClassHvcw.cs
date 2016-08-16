using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HVCW {
    namespace CameraControl {
    
        /// <summary >
        /// OKAO function flag
        /// </summary >
        public enum HVCW_OkaoFunction {
            HVCW_OkaoFunction_Body = 0,           /*  0=Human Body Detection      */
            HVCW_OkaoFunction_Hand,               /*  1=Hand Detection            */
            HVCW_OkaoFunction_Pet,                /*  2=Pet Detection             */
            HVCW_OkaoFunction_Face,               /*  3=Face Detection            */
            HVCW_OkaoFunction_Direction,          /*  4=Face Direction Estimation */
            HVCW_OkaoFunction_Age,                /*  5=Age Estimation            */
            HVCW_OkaoFunction_Gender,             /*  6=Gender Estimation         */
            HVCW_OkaoFunction_Gaze,               /*  7=Gaze Estimation           */
            HVCW_OkaoFunction_Blink,              /*  8=Blink Estimation          */
            HVCW_OkaoFunction_Expression,         /*  9=Expression Estimation     */
            HVCW_OkaoFunction_Recognition,        /* 10=Face Recognition          */
            HVCW_OkaoFunction_Max
        };

        /// <summary >
        /// Wrap HVCW API
        /// </summary >
        public unsafe class ClassHvcw {
            /** Application ID */
            //static int APP_ID = 26801; // 100 (fixed) for developers

            /* SDK Error Code */
            // SDKエラーコードの初期化
            public static int HVCW_SUCCESS = 1;                 /* Process success                 */
            public static int HVCW_INVALID_PARAM = 2;           /* Invalid parameters              */
            public static int HVCW_NOT_READY = 3;               /* Process preparation not done    */
            public static int HVCW_BUSY = 4;                    /* Process cannot be accepted      */
            public static int HVCW_NOT_SUPPORT = 5;             /* Requested process not supported */
            public static int HVCW_TIMEOUT = 6;                 /* Timeout                         */
            public static int HVCW_NOT_FOUND = 7;               /* Process target not found        */
            public static int HVCW_FAILURE = 8;                 /* Other error (none of above)     */
            public static int HVCW_NOT_INITIALIZE = 11;         /* SDK not initialized             */
            public static int HVCW_DISCONNECTED = 12;           /* Camera disconnected             */
            public static int HVCW_NOHANDLE = 20;               /* Handle error                    */
            public static int HVCW_NO_FACE = 30;                /* No face detected                */
            public static int HVCW_PLURAL_FACES = 31;           /* Multiple faces detected         */
            public static int HVCW_INVALID_RECEIVEDATA = 40;    /* Incorrect data received         */
            public static int HVCW_NOFILE = 50;                 /* File does not exist             */
            public static int HVCW_SD_NOT_INSERT = 61;          /* SD card not present             */
            public static int HVCW_SD_READ = 62;                /* SD card read error              */

            /// <summary >
            /// Create HVCW handle
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_CreateHandle();

            /// <summary >
            /// Delete HVCQ handle
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_DeleteHandle(int hHVC);

            /// <summary >
            /// Connect camera function
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_Connect(int hHVC, byte* pucCameraId, byte* pucAccessToken);

            /// <summary >
            /// Disconnect camera function
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_Disconnect(int hHVC);

            /// <summary >
            /// Generate pairing sound file
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_GenerateDataSoundFile(byte* pucTargetFile, byte* pucSSID, byte* pucPassword, byte* pusAccessToken);

            /// <summary >
            /// Set application ID
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_SetAppID(int hHVC, int nAppID, byte* pucReturnStatus);

            /// <summary >
            /// Execute OKAO
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_OKAO_Execute(int hHVC, int* pnUseFunction, int* pResult, byte* pucReturnStatus);
            /// <summary >
            /// Register Album
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_ALBUM_Register(int hHVC, int nUserID, int nDataID, int* pFaceResult, int* pFileInfo, byte* pucReturnStatus);
            /// <summary >
            /// Change user name
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_ALBUM_SetUserName(int hHVC, int nUserID, byte* pUserName, byte* pucReturnStatus);
            /// <summary >
            /// Get user name
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_ALBUM_GetUserName(int hHVC, int nUserID, byte* pUserName, byte* pucReturnStatus);

            /// <summary >
            /// Get OKAO image size
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_GetLastOkaoImageSize(int hHVC, int* pnImgBufSize, byte* pucReturnStatus);
            /// <summary >
            /// Get OKAO image
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_GetLastOkaoImage(int hHVC, int nImgBufSize, byte* pucImgBuffer, byte* pucReturnStatus);

            /// <summary >
            /// Set threshold value
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_OKAO_SetThreshold(int hHVC, int* pThreshold, byte* pucReturnStatus);
            /// <summary >
            /// Get threshold value
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_OKAO_GetThreshold(int hHVC, int* pThreshold, byte* pucReturnStatus);
            /// <summary >
            /// Set detection size
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_OKAO_SetSizeRange(int hHVC, int* pSizeRange, byte* pucReturnStatus);
            /// <summary >
            /// Get detection size
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_OKAO_GetSizeRange(int hHVC, int* pSizeRange, byte* pucReturnStatus);

            /// <summary >
            /// Set live streaming image buffer
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_SetReceiveStream(int hHVC, byte* pucRecvBuffer);
            /// <summary >
            /// Get live streaming image
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_GetReceiveStream(int hHVC, int* pnWidth, int* pnHeight);
            /// <summary >
            /// Start live streaming function
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_StartStreaming(int hHVC);
            /// <summary >
            /// Stop live streaming function
            /// </summary >
            [DllImport("WrapHvcw.dll")]
            static extern int stdHVCW_StopStreaming(int hHVC);

            // 各種静的変数定義
            public static int HVCW_OKAO_RESULT_BODYS_DETECTION_SIZE = 4;            /* Body result data byte number */
            public static int HVCW_OKAO_RESULT_BODYS_nCount = 0;                    /* Result count (body) storage location */
            public static int HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nX = 1;        /* X coordinates storage location */
            public static int HVCW_OKAO_RESULT_BODYS_DETECTION_POINT_nY = 2;        /* Y coordinates storage location */
            public static int HVCW_OKAO_RESULT_BODYS_DETECTION_nSize = 3;           /* Size storage location */
            public static int HVCW_OKAO_RESULT_BODYS_DETECTION_nConfidence = 4;     /* Degree of confidence storage location */

            public static int HVCW_OKAO_RESULT_HANDS_DETECTION_SIZE = 4;                        /* Hand result data byte number */
            public static int HVCW_OKAO_RESULT_HANDS_nCount = (1 + 4 * 35);                     /* Result count (hand) storage location */
            public static int HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nX = 1 + (1 + 4 * 35);     /* X coordinates storage location */
            public static int HVCW_OKAO_RESULT_HANDS_DETECTION_POINT_nY = 2 + (1 + 4 * 35);     /* Y coordinates storage location */
            public static int HVCW_OKAO_RESULT_HANDS_DETECTION_nSize = 3 + (1 + 4 * 35);        /* Size storage location */
            public static int HVCW_OKAO_RESULT_HANDS_DETECTION_nConfidence = 4 + (1 + 4 * 35);  /* Degree of confidence storage location */

            public static int HVCW_OKAO_RESULT_PETS_DETECTION_SIZE = 5;                                     /* Pet result data byte number */
            public static int HVCW_OKAO_RESULT_PETS_nCount = (1 + 4 * 35 + 1 + 4 * 35);                     /* Result count (pet) storage location */
            public static int HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nX = 1 + (1 + 4 * 35 + 1 + 4 * 35);     /* X coordinates storage location */
            public static int HVCW_OKAO_RESULT_PETS_DETECTION_POINT_nY = 2 + (1 + 4 * 35 + 1 + 4 * 35);     /* Y coordinates storage location */
            public static int HVCW_OKAO_RESULT_PETS_DETECTION_nSize = 3 + (1 + 4 * 35 + 1 + 4 * 35);        /* Size storage location */
            public static int HVCW_OKAO_RESULT_PETS_DETECTION_nConfidence = 4 + (1 + 4 * 35 + 1 + 4 * 35);  /* Degree of confidence storage location */
            public static int HVCW_OKAO_RESULT_PETS_DETECTION_nPetType = 5 + (1 + 4 * 35 + 1 + 4 * 35);     /* Pet type storage location */

            public static int HVCW_OKAO_RESULT_FACES_DETECTION_SIZE = 24;                                                           /* Face result data byte number */
            public static int HVCW_OKAO_RESULT_FACES_nCount = (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);                               /* Result count (face) storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX = 1 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);               /* X coordinates storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nY = 2 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);               /* Y coordinates storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_nSize = 3 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);                  /* Size storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_nConfidence = 4 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);            /* Degree of confidence storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nLR = 5 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);          /* Yaw angle storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nUD = 6 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);          /* Pitch angle storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nRoll = 7 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);        /* Roll angle storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_DIRECTION_nConfidence = 8 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);  /* Angle degree of confidence storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_AEG_nAge = 9 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);               /* Age storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_AEG_nConfidence = 10 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);       /* Age degree of confidence storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_GENDER_nGender = 11 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);        /* Gender storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_GENDER_nConfidence = 12 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);    /* Gender degree of confidence storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nLR = 13 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);              /* Gaze yaw angle storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_GAZE_nUD = 14 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);              /* Gaze pitch angle storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nLeftEye = 15 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);        /* Left eye blink degree storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_BLINK_nRightEye = 16 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);       /* Right eye blink degree storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Neutral = 17 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);    /* Neutral expression score storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Happiness = 18 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);  /* Happiness score storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Surprise = 19 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);   /* Surprise score storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Anger = 20 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);      /* Anger score storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_Sadness = 21 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);    /* Sadness score storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_EXPRESSION_nDegree = 22 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);    /* Expression degree (neg./pos.) storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_RECOGNITION_nUID = 23 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);      /* User ID storage location */
            public static int HVCW_OKAO_RESULT_FACES_DETECTION_RECOGNITION_nScore = 24 + (1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10);    /* Recognition score storage location */

            public static int HVCW_OKAO_RESULT_DETECTION_SIZE = 1 + 4 * 35 + 1 + 4 * 35 + 1 + 5 * 10 + 1 + 24 * 35;                 /* Result data total byte number */

            public static int HVCW_GENDER_FEMALE = 0;               /* Estimated gender: female */
            public static int HVCW_GENDER_MALE = 1;                 /* Estimated gender: male */

            public static int HVCW_OKAO_THRESHOLD_nBody = 0;                        /* Threshold value (body) storage location        */
            public static int HVCW_OKAO_THRESHOLD_nHand = 1;                        /* Threshold value (hand) storage detection       */
            public static int HVCW_OKAO_THRESHOLD_nPet = 2;                         /* Threshold value (pet) storage location         */
            public static int HVCW_OKAO_THRESHOLD_nFace = 3;                        /* Threshold value (face) storage location        */
            public static int HVCW_OKAO_THRESHOLD_nRecognition = 4;                 /* Threshold value (recognition) storage location */

            public static int HVCW_OKAO_SIZE_RANGE_body_nMin = 0;                   /* Minimum detection size (body) storage location */
            public static int HVCW_OKAO_SIZE_RANGE_body_nMax = 1;                   /* Maximum detection size (body) storage location */
            public static int HVCW_OKAO_SIZE_RANGE_hand_nMin = 2;                   /* Minimum detection size (hand) storage location */
            public static int HVCW_OKAO_SIZE_RANGE_hand_nMax = 3;                   /* Maximum detection size (hand) storage location */
            public static int HVCW_OKAO_SIZE_RANGE_pet_nMin = 4;                    /* Minimum detection size (pet) storage location  */
            public static int HVCW_OKAO_SIZE_RANGE_pet_nMax = 5;                    /* Maximum detection size (pet) storage location  */
            public static int HVCW_OKAO_SIZE_RANGE_face_nMin = 6;                   /* Minimum detection size (face) storage location */
            public static int HVCW_OKAO_SIZE_RANGE_face_nMax = 7;                   /* Maximum detection size (face) storage location */

            int hHVC = 0;
            bool bLive = false;

            // Live streaming image buffer 
            // ストリーミングの1フレーム分のバッファー
            // 解像度1280×720で1pxRGBの3バイトなので以下のサイズになる
            public byte[] liveBuffer = new byte[1280 * 720 * 3];

            /** OKAO function flag */
            public int[] execFlag = new int[(int)HVCW_OkaoFunction.HVCW_OkaoFunction_Max];
            /** OKAO function result value storage */
            public int[] resultData = new int[HVCW_OKAO_RESULT_DETECTION_SIZE];

            /** Parameter value storage */
            public int[] threshold = new int[5];
            public int[] sizeRange = new int[8];

            /** Pairing sound file */
            // ペアリング用の音声ファイル名 ※音声ペアリングしないとSDK使えないらしい
            public string SoundFile = "SoundFile.pcm";

            /// <summary>
            /// カメラとの接続を切断します。
            /// </summary>
            public void Disconnect() {
                if (hHVC != 0) {
                    if (bLive) {
                        StopLive();
                    }
                    stdHVCW_Disconnect(hHVC);
                    stdHVCW_DeleteHandle(hHVC);
                    hHVC = 0;
                }
            }

            // ***** Connect camera *****
            /// <summary>
            /// カメラIDとアクセストークンを使ってカメラに接続する
            /// ※結局このためにAPIキー
            /// </summary>
            /// <param name="app_id">オムロンから配布されたアプリID</param>
            /// <param name="uuid">オムロンから配布されたカメラID</param>
            /// <param name="token">アクセストークン</param>
            /// <returns></returns>
            unsafe public bool Connect(int app_id, string uuid, string token) {
                if (hHVC == 0) {
                    hHVC = stdHVCW_CreateHandle();
                }
                if (hHVC == 0) {
                    return (false);
                }

                if (uuid.Length <= 0 || token.Length <= 0) {
                    return (false);
                }

                byte[] byUUID = Encoding.UTF8.GetBytes(uuid);
                byte[] byToken = Encoding.UTF8.GetBytes(token);
                fixed (byte* pUUID = &byUUID[0])
                {
                    fixed (byte* pToken = &byToken[0])
                    {
                        if (stdHVCW_Connect(hHVC, pUUID, pToken) != HVCW_SUCCESS) {
                            Disconnect();
                            return (false);
                        }
                    }
                }
                byte status;
                stdHVCW_SetAppID(hHVC, app_id, &status);
                return (true);
            }

            /// <summary>
            /// 音声ペアリング用のサウンドファイルを生成します。
            /// </summary>
            /// <param name="ssid">無線LANSSID</param>
            /// <param name="password">無線LANパスワード</param>
            /// <param name="token">アクセストークン</param>
            /// <returns></returns>
            unsafe public bool GenerateSound(string ssid, string password, string token) {
                if (hHVC == 0) {
                    hHVC = stdHVCW_CreateHandle();
                }
                if (hHVC == 0) {
                    return (false);
                }

                if (ssid.Length <= 0 || password.Length <= 0 || token.Length <= 0) {
                    return (false);
                }

                byte[] byFile = Encoding.UTF8.GetBytes(SoundFile);
                byte[] bySSID = Encoding.UTF8.GetBytes(ssid);
                byte[] byPassword = Encoding.UTF8.GetBytes(password);
                byte[] byToken = Encoding.UTF8.GetBytes(token);

                fixed (byte* pFile = &byFile[0])
                {
                    fixed (byte* pSSID = &bySSID[0])
                    {
                        fixed (byte* pPW = &byPassword[0])
                        {
                            fixed (byte* pToken = &byToken[0])
                            {
                                int ret = stdHVCW_GenerateDataSoundFile(pFile, pSSID, pPW, pToken);
                                if (ret != HVCW_SUCCESS) {
                                    return (false);
                                }
                            }
                        }
                    }
                }
                return (true);
            }

            /// <summary>
            /// OKAO処理を実行する
            /// </summary>
            /// <returns></returns>
            unsafe public int Execute() {
                int ret;
                byte status;

                if (hHVC != 0) {
                    fixed (int* pFlag = &execFlag[0])
                    {
                        fixed (int* pResult = &resultData[0])
                        {
                            // Execute OKAO
                            ret = stdHVCW_OKAO_Execute(hHVC, pFlag, pResult, &status);
                        }
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            /// <summary>
            /// ユーザー名を設定します。
            /// </summary>
            /// <param name="username">設定するユーザー名</param>
            /// <returns></returns>
            unsafe public int SetUserName(string username) {
                int ret;
                byte status;
                byte[] bUserName = new byte[44];

                int n = 0;
                byte[] data = Encoding.ASCII.GetBytes(username);
                for (n = 0; (n < data.Length) && (n < 43); n++)
                    bUserName[n] = data[n];
                for (; n < 44; n++)
                    bUserName[n] = 0;

                if (hHVC != 0) {
                    fixed (byte* pUserName = &bUserName[0])
                    {
                        ret = stdHVCW_ALBUM_SetUserName(hHVC, 0, pUserName, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            /// <summary>
            ///        Get user name (recognition) *****
            /// </summary>
            /// <param name="strUserName">ユーザー名が設定される変数</param>
            /// <param name="userID">取得するユーザー名のユーザーID</param>
            /// <returns></returns>
            unsafe public int GetUserName(string strUserName, int userID) {
                int ret;
                byte status;
                byte[] userName = new byte[44];

                if (hHVC != 0) {
                    fixed (byte* pUserName = &userName[0])
                    {

                        ret = stdHVCW_ALBUM_GetUserName(hHVC, userID, pUserName, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    strUserName = Encoding.UTF8.GetString(userName, 0, 40);
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            // ***** Register Album (recognition) *****
            unsafe public int Register(PictureBox pict) {
                int ret;
                byte status;
                int[] fileInfo = new int[10 + 1 + 1];

                if (hHVC != 0) {
                    fixed (int* pFaceResult = &resultData[HVCW_OKAO_RESULT_FACES_DETECTION_POINT_nX])
                    {
                        fixed (int* pFileInfo = &fileInfo[0])
                        {
                            // Register Album
                            ret = stdHVCW_ALBUM_Register(hHVC, 0, 0, pFaceResult, pFileInfo, &status);
                        }
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            // ***** Set OKAO parameter value *****
            unsafe public int SetParams() {
                int ret;
                byte status;

                if (hHVC != 0) {
                    fixed (int* pThreshold = &threshold[0])
                    {
                        /* Set threshold value */
                        ret = stdHVCW_OKAO_SetThreshold(hHVC, pThreshold, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    fixed (int* pSizeRange = &sizeRange[0])
                    {
                        /* Set detection size */
                        ret = stdHVCW_OKAO_SetSizeRange(hHVC, pSizeRange, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            // ***** Get OKAO parameter value *****
            unsafe public int GetParams() {
                int ret;
                byte status;

                if (hHVC != 0) {
                    fixed (int* pThreshold = &threshold[0])
                    {
                        /* Get threshold value */
                        ret = stdHVCW_OKAO_GetThreshold(hHVC, pThreshold, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    fixed (int* pSizeRange = &sizeRange[0])
                    {
                        /* Get detection size */
                        ret = stdHVCW_OKAO_GetSizeRange(hHVC, pSizeRange, &status);
                    }
                    if ((ret != HVCW_SUCCESS) || (status != 0)) {
                        return HVCW_FAILURE;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            // ***** Get live streaming image *****
            unsafe public int GetLive(int[] nWidth, int[] nHeight) {
                int ret;

                if (hHVC != 0) {
                    if (!bLive) {
                        return HVCW_FAILURE;
                    }
                    fixed (int* pW = &nWidth[0])
                    {
                        fixed (int* pH = &nHeight[0])
                        {
                            // Wait to get image
                            ret = stdHVCW_GetReceiveStream(hHVC, pW, pH);
                        }
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            /// <summary>
            /// ライブストリーミング処理を開始します
            /// </summary>
            /// <returns>リターンコード</returns>
            unsafe public int StartLive() {
                if (hHVC != 0) {
                    if (bLive) {
                        return HVCW_SUCCESS;
                    }
                    int ret = stdHVCW_StartStreaming(hHVC);
                    if (ret == HVCW_SUCCESS) {
                        bLive = true;
                        fixed (byte* pLive = &liveBuffer[0])
                        {
                            // Set image buffer
                            stdHVCW_SetReceiveStream(hHVC, pLive);
                        }
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }

            /// <summary>
            /// ライブストリーミング処理を停止します。
            /// </summary>
            /// <returns>リターンコード</returns>
            unsafe public int StopLive() {
                if (hHVC != 0) {
                    if (!bLive) {
                        return HVCW_SUCCESS;
                    }
                    int ret = stdHVCW_StopStreaming(hHVC);
                    if (ret == HVCW_SUCCESS) {
                        bLive = false;
                    }
                    return ret;
                }
                return HVCW_NOHANDLE;
            }
        }
    }
}