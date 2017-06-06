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
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string email;
        bool accountExistsFlag = false;
        DBManager objDBM = new DBManager();
        EmailModules objEmail = new EmailModules();

        protected void Page_Load(object sender, EventArgs e)
        {
            bgVidLink.Src = "https://www.youtube.com/embed/43ngkc2Ejgw?controls=0&showinfo=0&rel=0&autoplay=1&loop=1&modestbranding=0&playlist=43ngkc2Ejgw";
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //Check that the account exists
            email = txtUsername.Text;

            DataSet dbAllUsers = objDBM.GetAllUsers(email);

            try
            {
                //Get whatever email address the dataset may or may not have returned
                string dbEmail = dbAllUsers.Tables[0].Rows[0]["Email Address"].ToString();

                //Test if entered email already exists on system
                if (email == dbEmail)
                {
                    accountExistsFlag = true;
                    CheckAccounts();
                }
            }
            catch
            {
                lblMsg.Text = "Sorry, this email doesn't have an account here!";
                lblMsg.Visible = true;
            }
        }

        private void CheckAccounts()
        {
            if(accountExistsFlag == true)
            {
                //Account exists!

                //UPDATE USER PASSWORD TO TEMPORARY PASSWORD, SET USER FAKEPASSWORDACTIVEFLAG = TRUE
                string newPassword1 = "x45vf";
                string fakePasswordActiveFlag = "True";

                //Send email with temporary fake password
                objEmail.SendTemporaryPasswordEmail(email, newPassword1);

                objDBM.SetNewPassword(email, newPassword1, fakePasswordActiveFlag);

                //Redirect to login
                Response.Redirect("Welcome.aspx");
            }
        }
    }
}