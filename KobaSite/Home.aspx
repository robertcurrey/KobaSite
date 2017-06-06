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
        <asp:ScriptManager runat="server" ID="sm"></asp:ScriptManager>
        <div class="bs-example bs-navbar-top-example navStuff" data-example-id="navbar-fixed-to-top">
            <nav class="navbar navbar-inverse bg-inverse navbar-fixed-top">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="collapsed navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-6" aria-expanded="false"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                        <a class="navbar-brand">Koba Radio</a> </div>
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="#">My Profile</a></li>
                            <li><a href="Welcome.aspx">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div id="videoBG" runat="server" visible="false">
                    <div class="video-background">
                        <div class="video-foreground">
                            <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen></iframe>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnPlay" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>




        <div class="container">
            
            <div id="radioPanel" class="row">
                <div id="radioList" class="jumbotron col-xs-4">
                    <asp:Label ID="lblStationBox" runat="server" Text="Select a Radio Station:" CssClass="text-left" Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnRadio1" class="loginButtons" runat="server" Text="Nourish" OnClick="btnRadio1_Click" />
                            <br />
                            <br />
                            <asp:Button ID="btnRadio2" class="loginButtons" runat="server" Text="DJ JeNy" OnClick="btnRadio2_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="descriptionField" runat="server" class="jumbotron col-xs-offset-1 col-xs-7" visible="false">
                            <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="text-left" Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblRadioDescription" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Button ID="btnPlay" class="loginButtons" runat="server" Text="Play" OnClick="btnPlay_Click" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRadio1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnRadio2" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                

            </div>
        </div>
    </form>
</body>
</html>
