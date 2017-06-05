<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="KobaSite.CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/LoginCSS.css" rel="stylesheet" />
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <title>Welcome</title>

    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div class="parallax-group">--%>
           <%--  <img class="back" src="KobaSiteLoginWallpaper.png" />--%>
        <div class="video-background">
                <div class="video-foreground">
                    <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen ></iframe>
                </div>
            </div>    

           <div class="lblWelcome text-center">
               <asp:Label ID="lblWelcome" runat="server" Text="Welcome" Font-Bold="False" Font-Names="Yu Gothic UI Light" Font-Size="35pt" ForeColor="White"></asp:Label>
           </div>

            <div id="MasterLogin" class="jumbotron loginForm" runat="server">
                <div id="divLogin" class="text-center" runat="server">

                    <div class="lblWelcome text-center">
                        <asp:Label ID="lblPleaseLogin" runat="server" Text="Let's get you set up." Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                    </div>
                    
                    <asp:Label ID="lblUsername" runat="server" Text="Email: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtUsername" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="255" placeholder="Enter your email address..." required="true" TextMode="Email"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Password: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="50" placeholder="Enter your password..." type="password" required="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword2" runat="server" Text="Re-enter password: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px" style="margin-left: 0px"></asp:Label>
                    <asp:TextBox ID="txtPassword2" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="50" placeholder="Re-enter your password..." type="password" required="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" Font-Names="Yu Gothic UI Light" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnCreateAccount" class="loginButtons" runat="server" Text="Create Account" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnCreateAccount_Click"/>
                </div>
            </div>
        <%--</div>--%>

        

        
    </form>

</body>
</html>

