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
    public class DBManager
    {
        DBConnect objDB = new DBConnect();

        public DataSet AuthenticateUser(string email, string password)
        {
            SqlParameter userPassParam;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckUserPass";

            userPassParam = new SqlParameter("@email", email);
            userPassParam.Direction = ParameterDirection.Input;
            userPassParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(userPassParam);

            userPassParam = new SqlParameter("@password", password);
            userPassParam.Direction = ParameterDirection.Input;
            userPassParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(userPassParam);

            DataSet dbUserPass = objDB.GetDataSetUsingCmdObj(cmd);

            return dbUserPass;
        }

        public void CreateAccount(string email, string password)
        {
            SqlParameter CreateAccountParam;

            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.CommandText = "CreateAccount";

            CreateAccountParam = new SqlParameter("@email", email);
            CreateAccountParam.Direction = ParameterDirection.Input;
            CreateAccountParam.SqlDbType = SqlDbType.VarChar;
            cmd2.Parameters.Add(CreateAccountParam);

            CreateAccountParam = new SqlParameter("@password", password);
            CreateAccountParam.Direction = ParameterDirection.Input;
            CreateAccountParam.SqlDbType = SqlDbType.VarChar;
            cmd2.Parameters.Add(CreateAccountParam);

            objDB.DoUpdateUsingCmdObj(cmd2);
        }
        
        public DataSet GetAllUsers(string email)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllUsernames";

            SqlParameter AccountParam;
            AccountParam = new SqlParameter("@email", email);
            AccountParam.Direction = ParameterDirection.Input;
            AccountParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(AccountParam);

            //Dataset possibly containing matching username that already exists in database
            DataSet dbAllUsers = objDB.GetDataSetUsingCmdObj(cmd);

            return dbAllUsers;
        }

        public int GetActivationCode(string email)
        {
            int code;

            SqlParameter UserParam;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetActivationCode";

            UserParam = new SqlParameter("@email", email);
            UserParam.Direction = ParameterDirection.Input;
            UserParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(UserParam);

            DataSet dbActivationCodeSet = objDB.GetDataSetUsingCmdObj(cmd);

            code = (int)(dbActivationCodeSet.Tables[0].Rows[0]["ActivationCode"]);

            return code;
        }

        public void ActivateAccount(string activatedFlag, string email)
        {
            SqlParameter ActivationParam;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateActivationFlag";

            ActivationParam = new SqlParameter("@activatedFlag", activatedFlag);
            ActivationParam.Direction = ParameterDirection.Input;
            ActivationParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(ActivationParam);

            ActivationParam = new SqlParameter("@email", email);
            ActivationParam.Direction = ParameterDirection.Input;
            ActivationParam.SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.Add(ActivationParam);

            objDB.DoUpdateUsingCmdObj(cmd);
        }
    }
}