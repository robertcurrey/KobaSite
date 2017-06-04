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
                }

                //Attempt to create account
                CheckAccounts();
            }
            catch
            {
                //Attempt to create account
                CheckAccounts();
            }
        }

        private void CheckAccounts()
        {
            if (accountExistsFlag == false)
            {
                lblMsg.Text = "Sorry, this email doesn't have an account here!";
                lblMsg.Visible = true;
            }
            else
            {
                //Account exists!

                //UPDATE USER PASSWORD TO TEMPORARY PASSWORD, SET USER FAKEPASSWORDACTIVEFLAG = TRUE
                string newPassword1 = "x45vf";
                string fakePasswordActiveFlag = "True";
                objDBM.SetNewPassword(email, newPassword1, fakePasswordActiveFlag);

                //Send email with temporary fake password
                objEmail.SendTemporaryPasswordEmail(email, newPassword1);

                //Redirect to login
                Response.Redirect("Welcome.aspx");
            }
        }
    }
}