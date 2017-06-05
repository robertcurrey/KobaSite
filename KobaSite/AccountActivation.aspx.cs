using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections;
using System.Net.Mail;

namespace KobaSite
{
    public partial class AccountActivation : System.Web.UI.Page
    {
        DBManager objDBM = new DBManager();
       
        string email;
        int dbActivationCode;

        protected void Page_Load(object sender, EventArgs e)
        {
            bgVidLink.Src = "https://www.youtube.com/embed/FKu4v_boJ3o?controls=0&showinfo=0&rel=0&autoplay=1&loop=1&playlist=FKu4v_boJ3o";
            //Get current user
            email = GetEmail();
            //Get current user's stored activation code
            dbActivationCode = GetActivationCode();
        }

        private string GetEmail()
        {
            email = (string)(Session["CurrentUser"]);
            return email;
        }

        private int GetActivationCode()
        {
            int code = objDBM.GetActivationCode(email);

            return code;
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            int activationCode = Convert.ToInt32(txtActivationCode.Text);

            if(activationCode == dbActivationCode)
            {
                //Activate the account
                string activatedFlag = "True";
                objDBM.ActivateAccount(activatedFlag, email);

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Congratulations! Your account is now activated. You may now log in.";
                lblMsg.Visible = true;

                btnActivate.Visible = false;
                btnResendEmail.Visible = false;
                btnLogin.Visible = true;
            }
            else if(activationCode != dbActivationCode)
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Sorry, looks like that's the wrong code. Click Resend Activation Email to get the correct one sent to you!";
                lblMsg.Visible = true;
            }
        }

        protected void btnResendEmail_Click(object sender, EventArgs e)
        {
            EmailModules objEmail = new EmailModules();
            objEmail.ResendConfirmationEmail(email, dbActivationCode);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}