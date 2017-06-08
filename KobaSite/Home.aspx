<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KobaSite.Home" MaintainScrollPositionOnPostback="False"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="Content/LoginCSS.css" rel="stylesheet" />
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Content/DescriptionAnimation.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="sm"></asp:ScriptManager>
        <div class="bs-example bs-navbar-top-example navStuff" data-example-id="navbar-fixed-to-top">
            <nav class="navbar navbar-inverse navbar-fixed-top">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <button type="button" class="collapsed navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-6" aria-expanded="false"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                        <a class="navbar-brand">Koba Radio</a>
                    </div>
                    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-6">
                        <ul class="nav navbar-nav navbar-right">
                            <li><a href="#">My Profile</a></li>
                            <li><a href="Welcome.aspx">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </div>

        <div class="container">
            <div id="welcomePanel" class="row greetingBG">
                <div id="greeting" class="text-center col-xs-12">
                    <br />
                    <br />
                    <asp:Label ID="lblGreeting" runat="server" Text="Welcome to Koba Radio" Font-Names="Yu Gothic UI Light" Font-Size="XX-Large" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <asp:Label ID="lblSubgreeting" runat="server" Text="Let's listen to some music." Font-Names="Yu Gothic UI Light" Font-Size="X-Large" ForeColor="White"></asp:Label>
                    <br />
                    <br />
                    <asp:Image ID="kobaLogo" runat="server" ImageUrl="Content/kobaLogo.png" Height="100" Width="100" />
                </div>
            </div>
        </div>

        <div class="container-fluid">
            <div id="genrePanel" class="row">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">

                    <ContentTemplate>
                        <div id="genreField" class="jumbotron text-left col-xs-12">
                            <asp:Label ID="lblGenre" runat="server" Text="Select a Genre:" Font-Names="Yu Gothic UI Light" Font-Size="X-Large" ForeColor="White"></asp:Label>
                            <br />
                            <br />
                            <asp:ImageButton ID="btnEDM" runat="server" Text="Dance/EDM" Width="175" Height="175" ImageUrl="Genres/edm.png" OnClick="btnEDM_Click1" />
                            &emsp;&emsp;<asp:ImageButton ID="btnSoundtrack" runat="server" Text="Soundtrack" Width="175" Height="175" ImageUrl="Genres/soundtrack.png" OnClick="btnSoundtrack_Click" />
                            <br />
                            <br />
                            <asp:ImageButton ID="btnLoFi" runat="server" Text="LoFi" Width="175" Height="175" ImageUrl="Genres/lofi.png" OnClick="btnLoFi_Click1" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div id="stationPanel" class="row">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="radioList" runat="server" class="jumbotron col-xs-12" visible="false">
                            <asp:Label ID="lblStationBox" runat="server" Text="Select a Radio Station:" CssClass="text-left" Font-Names="Yu Gothic UI Light" Font-Size="X-Large" ForeColor="White"></asp:Label>
                            <br />
                            <br />

                            <div id="edmRadioList" runat="server" visible="false">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnRadio2" class="stationButtons" runat="server" Text="DJ JeNy" OnClick="btnRadio2_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnStaySee" class="stationButtons" runat="server" Text="Stay See" OnClick="btnStaySee_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnPixl" class="stationButtons" runat="server" Text="Pixl" OnClick="btnPixl_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnEDM" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                            <div id="lofiRadioList" runat="server" visible="false">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnRadio1" class="stationButtons" runat="server" Text="Nourish" OnClick="btnRadio1_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnChillhopCafe" class="stationButtons" runat="server" Text="Chillhop Cafe" OnClick="btnChillhopCafe_Click" />
                                        <br />
                                        <br />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnLoFi" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            
                            <div id="soundtrackRadioList" runat="server" visible="false">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btnSoulCandle" class="stationButtons" runat="server" Text="Soul Candle" OnClick="btnSoulCandle_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnEpicMusic" class="stationButtons" runat="server" Text="Epic Music" OnClick="btnEpicMusic_Click" />
                                        <br />
                                        <br />
                                        <asp:Button ID="btnFalloutRadio" class="stationButtons" runat="server" Text="Fallout Radio" OnClick="btnFalloutRadio_Click" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnSoundtrack" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnEDM" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnLoFi" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSoundtrack" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

            <div id="descriptionPanel" class="row">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div id="descriptionField" runat="server" class="jumbotron col-xs-12" visible="false">
                            <asp:Label ID="lblDescription" runat="server" Text="Description:" CssClass="text-left" Font-Names="Yu Gothic UI Light" Font-Size="X-Large" ForeColor="White"></asp:Label>
                            <br />
                            <br />
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:ImageButton ID="btnPlay" runat="server" Text="Play" ImageUrl="Other Buttons/playButtonImg.png" Width="100" Height="100" OnClick="btnPlay_Click1" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <asp:Label ID="lblRadioDescription" runat="server" ForeColor="White" CssClass="text-left" Font-Names="Yu Gothic UI Light" Font-Size="Large"></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnRadio1" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnRadio2" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnChillhopCafe" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnStaySee" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnPixl" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSoulCandle" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnEpicMusic" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnFalloutRadio" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

        <div id="backgroundVideo" class="container" runat="server">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="videoBG" runat="server" visible="false">
                    <div class="video-background">
                        <div class="video-foreground">
                            <iframe id="bgVidLink" runat="server" width="1920" height="1080"></iframe>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnPlay" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
