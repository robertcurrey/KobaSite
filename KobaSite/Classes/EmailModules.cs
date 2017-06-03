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
    public class EmailModules
    {
        int dbActivationCode;

        DBConnect objDB = new DBConnect();

        public void ResendConfirmationEmail(string email, int code)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("donotreply.koba@gmail.com", "Uchiha95");

            dbActivationCode = code;

            //Sends email containing stored activation code assigned at account creation
            MailMessage mm = new MailMessage("donotreply.koba@gmail.com", email, "Account Confirmation",
                "Thanks for signing up on my website! Enter the code below into our activation page to activate your account. " +
                "If you are receiving this email and you never signed up, feel free to disregard this " +
                "message and do not activate the account, as the account will be deleted after 24 hours of inactivation. " +
                "Thank you, and have a nice day!\n\nActivate your account by entering this code into the activation page:\n" + dbActivationCode);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }

        public void SendEmailConfirmation(string email, string activatedFlag)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("donotreply.koba@gmail.com", "Uchiha95");

            Random randCode = new Random();
            int activationCode = randCode.Next(10000, 99999);


            //insert activation code into UserTable
            SqlParameter ActivationParam;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AddActivationInfo";

            ActivationParam = new SqlParameter("@activationCode", activationCode);
            ActivationParam.Direction = ParameterDirection.Input;
            ActivationParam.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(ActivationParam);

            ActivationParam = new SqlParameter("@activatedFlag", activatedFlag);
            ActivationParam.Direction = ParameterDirection.Input;
            ActivationParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(ActivationParam);

            ActivationParam = new SqlParameter("@email", email);
            ActivationParam.Direction = ParameterDirection.Input;
            ActivationParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(ActivationParam);

            objDB.DoUpdateUsingCmdObj(cmd);
            ////////////////////////////////////////////////////////

            MailMessage mm = new MailMessage("donotreply.koba@gmail.com", email, "Account Confirmation",
                "Thanks for signing up on my website! Enter the code below into our activation page to activate your account. " +
                "If you are receiving this email and you never signed up, feel free to disregard this " +
                "message and do not activate the account, as the account will be deleted after 24 hours of inactivation. " +
                "Thank you, and have a nice day!\n\nActivate your account by entering this code into the activation page:\n" + activationCode);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}