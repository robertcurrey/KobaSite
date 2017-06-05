<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountActivation.aspx.cs" Inherits="KobaSite.AccountActivation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/LoginCSS.css" rel="stylesheet" />
    <link href="Content/parallax.css" rel="stylesheet" />
    <link href="Content/VideoBG.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <title>Activate Your Account</title>

    <script>
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div class="parallax-group">--%>           <%--  <img class="back" src="KobaSiteLoginWallpaper.png" />--%>
        <div class="video-background">
            <div class="video-foreground">
                <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen></iframe>
            </div>
        </div>    

           <div class="lblWelcome text-center">
               <asp:Label ID="lblActivate" runat="server" Text="Activate Account" Font-Bold="False" Font-Names="Yu Gothic UI Light" Font-Size="35pt" ForeColor="White"></asp:Label>
           </div>

            <div id="MasterLogin" class="jumbotron loginForm" runat="server">
                <div id="divLogin" class="text-center" runat="server">

                    <div class="lblWelcome text-center">
                        <asp:Label ID="lblPleaseEnterCode" runat="server" Text="Almost there! Just activate your account using the code in the email we sent you." Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                    </div>
                    
                    <asp:Label ID="lblActivationCode" runat="server" Text="Activation Code:" Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="150px"></asp:Label>
                    <asp:TextBox ID="txtActivationCode" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="255" placeholder="Enter your activation code..." TextMode="Number" required="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" Font-Names="Yu Gothic UI Light" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnLogin" class="loginButtons" runat="server" Text="Login" ForeColor="White" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" Visible="false" OnClick="btnLogin_Click"/>
                    <asp:Button ID="btnActivate" class="loginButtons" runat="server" Text="Activate" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnActivate_Click"/>
                    &emsp;<asp:Button ID="btnResendEmail" class="createUserBtn" runat="server" Text="Resend Activation Email" ForeColor="White" Width="300px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnResendEmail_Click"/>

                </div>
            </div>
        <%--</div>--%>

        

        
    </form>

</body>
</html>
