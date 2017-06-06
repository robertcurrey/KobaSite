<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="KobaSite.Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/LoginCSS.css" rel="stylesheet" type="text/css"/>
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" type="text/css"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <title>Welcome</title>

    
</head>
<body>
    <form id="form1" runat="server">
        <%--<div class="parallax-group">--%>
        <%--<img class="back" src="KobaSiteLoginWallpaper.png" />--%>

        <!--
            <div class="video-background">
                <div class="video-foreground">
                <iframe id="bgVidLink" runat="server" src="https://www.youtube.com/embed/fpViZkhpPHk?controls=0&iv_load_policy=3&showinfo=0&rel=0&autoplay=1&loop=1&modestbranding=0&playlist=fpViZkhpPHk" frameborder="0" allowfullscreen></iframe>
                </div>
            </div>
        </div> -->

        <div class="lblWelcome text-center">
            <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Font-Bold="False" Font-Names="Yu Gothic UI Light" Font-Size="35pt" ForeColor="White"></asp:Label>
        </div>

        <div class="jumbotron">
            <div id="MasterLogin" class="loginForm" runat="server">
            <div id="divLogin" class="text-center" runat="server">

                    <div class="lblWelcome text-center">
                        <asp:Label ID="lblPleaseLogin" runat="server" Text="Please Login" Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                    </div>
                    
                    <asp:Label ID="lblUsername" runat="server" Text="Email: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="255" placeholder="Enter your email address..." TextMode="Email"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Password: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="50" placeholder="Enter your password..." type="password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" Font-Names="Yu Gothic UI Light" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnSubmit" class="loginButtons" runat="server" Text="Login" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnSubmit_Click" />
                    &emsp;<asp:Button ID="btnCreateUser" class="createUserBtn" runat="server" Text="Create Account" ForeColor="White" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnCreateUser_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnForgotPassword" class="createUserBtn" runat="server" Text="Forgot Your Password?" ForeColor="White" Width="340px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnForgotPassword_Click" />

                </div>
            </div>
        </div>
        
        <%--</div>--%>   
    </form>
    
</body>
</html>
