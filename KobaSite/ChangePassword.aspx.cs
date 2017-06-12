using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KobaSite
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        string email;
        string newPassword1;
        string newPassword2;

        DBManager objDBM = new DBManager();
        EmailModules objEmail = new EmailModules();

        protected void Page_Load(object sender, EventArgs e)
        {
            bgVidLink.Src = "https://www.youtube.com/embed/43ngkc2Ejgw?controls=0&showinfo=0&rel=0&autoplay=1&loop=1&modestbranding=0&playlist=43ngkc2Ejgw";
            email = GetEmail();
            lblChangePass.Text = ("Hi " + email + ", let's change your password.");
        }

        private string GetEmail()
        {
            email = (string)(Session["CurrentUser"]);
            return email;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            newPassword1 = txtNewPassword.Text;
            newPassword2 = txtNewPassword2.Text;

            if (newPassword1 == newPassword2)
            {
                string fakePasswordActiveFlag = "False";

                //Encrypt password
                byte[] encryptedPassword = System.Text.Encoding.ASCII.GetBytes(newPassword1);
                encryptedPassword = new System.Security.Cryptography.SHA256Managed().ComputeHash(encryptedPassword);

                //UPDATE PASSWORD FOR USER, UPDATE FAKEPASSWORDACTIVEFLAG = FALSE
                objDBM.SetNewPassword(email, encryptedPassword, fakePasswordActiveFlag);

                //Send Password Change Confirmation Email
                objEmail.SendPasswordChangeConfirmation(email);

                lblMsg.Text = "Success! You've changed your password. You may now log in.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Visible = true;
                btnChangePassword.Visible = false;
                btnLogin.Visible = true;

            }
            else if (newPassword1 != newPassword2)
            {
                lblMsg.Text = "The new passwords you entered aren't the same!";
                lblMsg.Visible = true;
            }
        }
    }
}