<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KobaSite.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/LoginCSS.css" rel="stylesheet" />
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="video-background">
                <div class="video-foreground">
                    <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen ></iframe>
                </div>
            </div>

            <div id="greeting" class="jumbotron loginForm">
                <div class="text-center">
                    <h1>Hi!</h1>
                    <p>This is a test of the video background. Exciting, isn't it :)</p>
                </div>
            </div>
            <asp:Button ID="btnLogout" class="loginButtons text-center" Font-Names="Yu Gothic UI Light" Font-Size="Medium" runat="server" Text="Logout"  OnClick="btnLogout_Click" />
        </div>
    </form>
</body>
</html>
