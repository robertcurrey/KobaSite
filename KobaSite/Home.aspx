<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KobaSite.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/LoginCSS.css" rel="stylesheet" />
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        
            <div class="video-background">
                <div class="video-foreground">
                    <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen></iframe>
                </div>
            </div>
        </div>
        

        <div class="container">
            <div id="radioPanel" class="row">
                <div id="radioList" class="jumbotron col-xs-4">
                    <asp:Button ID="btnRadio1" class="loginButtons" runat="server" Text="Nourish" OnClick="btnRadio1_Click"/>
                </div>
                <div id="descriptionField" runat="server" class="jumbotron col-xs-offset-1 col-xs-7" Visible="false">
                    <asp:Label ID="lblRadioDescription" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnPlay" class="loginButtons" runat="server" Text="Play" OnClick="btnPlay_Click"/>
                </div>
            </div>
        </div>

        <br />
        <br />
        <asp:Button ID="btnLogout" class="loginButtons" Font-Names="Yu Gothic UI Light" Font-Size="Medium" runat="server" Text="Logout" OnClick="btnLogout_Click" />

    </form>
</body>
</html>
