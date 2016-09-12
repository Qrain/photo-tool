<%@ Page Language="VB" CodeFile="~/Test.aspx.vb" Inherits="Test" %>

<html>
<head>
    <title>テストページ</title>
    <style>
        table {
            border-collapse: collapse;
        }

            table tr {
                text-align: left;
            }

            table th, td {
                padding: 3px 6px;
                border: 1px solid;
            }

        .message {
            border-bottom: double 3px red;
            color: red;
            width: 80%;
        }

        h1 {
            font-size: 1.5rem;
        }
    </style>
</head>
<body>
    <h1>取得IPアドレス情報</h1>
    <table>
        <tr>
            <th>HTTP_X_FORWARDED_FOR</th>
            <td><% OriginalGIP() %></td>
        </tr>
        <tr>
            <th>REMOTE_ADDR</th>
            <td><% ProxyGIP() %></td>
        </tr>
    </table>
    <br />
    <br />
    <h1>メッセージ</h1>
    <p class="message"><% Message() %></p>
    <br />
    <br />
    <h1>全HTTPヘッダ情報</h1>
    <% AllHeaders() %>
</body>
</html>
