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

namespace KobaSite
{
    public partial class Welcome : System.Web.UI.Page
    {
        DBManager objDBM = new DBManager();

        bool accountExistsFlag = false;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text;

            string password = txtPassword.Text;

            //Gets password hash from entered password
            byte[] encryptedPassword = System.Text.Encoding.ASCII.GetBytes(password);
            encryptedPassword = new System.Security.Cryptography.SHA256Managed().ComputeHash(encryptedPassword);
            String enteredPassHash = System.Text.Encoding.ASCII.GetString(encryptedPassword);

            DataSet dbUserPass = objDBM.AuthenticateUser(email, encryptedPassword);

            foreach (DataTable table in dbUserPass.Tables)
            {
                foreach(DataRow dr in table.Rows)
                {
                    string dbEmail = dbUserPass.Tables[0].Rows[0]["Email Address"].ToString();

                    //Gets stored password hash from database
                    byte[] dbPass = (byte[])(dbUserPass.Tables[0].Rows[0]["Password"]);
                    String storedPassHash = System.Text.Encoding.ASCII.GetString(dbPass);
                    //Converts hash to string
                    //String passHash = System.Text.Encoding.ASCII.GetString(dbPass);

                    string dbActivationFlag = (dbUserPass.Tables[0].Rows[0]["IsActivated"]).ToString();
                    string dbFakePasswordActiveFlag = (dbUserPass.Tables[0].Rows[0]["FakePasswordActiveFlag"]).ToString();

                    if (email != dbEmail)
                    {
                        CheckFlag();
                    }
                    else
                    {
                        accountExistsFlag = true;
                        CheckFlag();

                        //compares stored password hash with entered password hash
                        if (enteredPassHash == storedPassHash)
                        {
                            if (dbActivationFlag == "False")
                            {
                                Session["CurrentUser"] = dbEmail;
                                Response.Redirect("AccountActivation.aspx");
                            }
                            else if (dbActivationFlag == "True")
                            {
                                if(dbFakePasswordActiveFlag == "False")
                                {
                                    Session["UserOnline"] = dbEmail;
                                    Response.Redirect("Home.aspx");
                                }
                                else if(dbFakePasswordActiveFlag == "True")
                                {
                                    Session["CurrentUser"] = dbEmail;
                                    Response.Redirect("ChangePassword.aspx");
                                }
                                
                            }
                        }
                        else
                        {
                            //error - incorrect password
                            lblMsg.Text = "Sorry, we couldn't log you in. Your email address or password may be invalid!";
                            lblMsg.Visible = true;
                        }

                    }
                }
            }
            CheckFlag();
        }

        private void CheckFlag()
        {
            if(accountExistsFlag == false)
            {
                //error - username not found
                lblMsg.Text = "Sorry, looks like that account doesn't exist. Click Create Account to join our community!";
                lblMsg.Visible = true;
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAccount.aspx");
        }

        protected void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}