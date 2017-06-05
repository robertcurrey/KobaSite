<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="KobaSite.ChangePassword" %>

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
        <%--<div class="parallax-group">--%><%--  <img class="back" src="KobaSiteLoginWallpaper.png" />--%>
        <div class="video-background">
                <div class="video-foreground">
                    <iframe id="bgVidLink" runat="server" frameborder="0" allowfullscreen ></iframe>
                </div>
            </div>    

           <div class="lblWelcome text-center">
               <asp:Label ID="lblChangePassHeader" runat="server" Text="Change Your Password" Font-Bold="False" Font-Names="Yu Gothic UI Light" Font-Size="35pt" ForeColor="White"></asp:Label>
           </div>

            <div id="MasterLogin" class="jumbotron" runat="server">
                <div id="divLogin" class="text-center" runat="server">

                    <div class="lblWelcome text-center">
                        <asp:Label ID="lblChangePass" runat="server" Font-Names="Yu Gothic UI Light" Font-Size="X-Large"></asp:Label>
                    </div>
                    
                    <asp:Label ID="lblNewPass" runat="server" Text="New Password: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px" style="margin-left: 0px"></asp:Label>
                    <asp:TextBox ID="txtNewPassword" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="255" placeholder="Enter a new password..." required="true" type="password"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblPassword" runat="server" Text="Re-enter New Password: " Font-Names="Yu Gothic UI Light" Font-Size="Large" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtNewPassword2" runat="server" Height="60px" Width="302px" CssClass="textBoxes" MaxLength="50" placeholder="Re-enter new password..." type="password" required="true"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Label ID="lblMsg" runat="server" Visible="False" Font-Names="Yu Gothic UI Light" Font-Size="Medium" ForeColor="Red"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnLogin" class="loginButtons" runat="server" Text="Login" ForeColor="White" Width="170px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" Visible="false" OnClick="btnLogin_Click"/>
                    <asp:Button ID="btnChangePassword" class="btn-danger" runat="server" Text="Change Password" Width="199px" Font-Names="Yu Gothic UI Light" Font-Size="Medium" Height="60px" OnClick="btnChangePassword_Click"/>
                </div>
            </div>
        <%--</div>--%>

        

        
    </form>

</body>
</html>

