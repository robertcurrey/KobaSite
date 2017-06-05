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
    public partial class CreateAccount : System.Web.UI.Page
    {
        DBManager objDBM = new DBManager();
        EmailModules objEmail = new EmailModules();

        bool accountExistsFlag = false;
        string email;
        string password;
        string password2;
        string activatedFlag = "False";

        protected void Page_Load(object sender, EventArgs e)
        {
            bgVidLink.Src = "https://www.youtube.com/embed/FKu4v_boJ3o?controls=0&showinfo=0&rel=0&autoplay=1&loop=1&playlist=FKu4v_boJ3o";
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            email = txtUsername.Text.ToLower();

            password = txtPassword.Text;
            password2 = txtPassword2.Text;

            //Get dataset of all users with matching email
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
                if (password == password2)
                {
                    //Create Account
                    objDBM.CreateAccount(email, password);

                    //Send Confirmation Email
                    objEmail.SendEmailConfirmation(email, activatedFlag);

                    //Save Current User's Email
                    Session["CurrentUser"] = email;

                    //Redirect to Activation
                    Response.Redirect("AccountActivation.aspx");
                }
                else
                {
                    //error - passwords do not match!
                    lblMsg.Text = "Your passwords don't match!";
                    lblMsg.Visible = true;
                }
            }
            else
            {
                //error - Account already exists!
                lblMsg.Text = "Sorry, this email already has an account here!";
                lblMsg.Visible = true;
            }
        }
    }
}