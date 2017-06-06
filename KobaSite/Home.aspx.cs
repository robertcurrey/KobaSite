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
    public partial class Home : System.Web.UI.Page
    {
        DBManager objDBM = new DBManager();
        string currentGenre;

        protected void Page_Load(object sender, EventArgs e)
        {

            if(Session["UserOnline"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
        }

        protected void btnRadio1_Click(object sender, EventArgs e)
        {
            
            lblRadioDescription.Text = "Kick back and chill with the best lo-fi tunes out there in this great big world.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio1.Text;
        }

        protected void btnPlay_Click(object sender, EventArgs e)
        {
            string radioName = Session["SelectedRadio"].ToString();
            bgVidLink.Src = objDBM.LinkPicker(radioName);
            videoBG.Visible = true;
        }

        protected void btnRadio2_Click(object sender, EventArgs e)
        {
            lblRadioDescription.Text = "Get the party started with the hottest remixes of the best music of the year.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio2.Text;
        }

        protected void btnEDM_Click(object sender, EventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = true;
            lofiRadioList.Visible = false;
        }

        protected void btnLoFi_Click(object sender, EventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = false;
            lofiRadioList.Visible = true;
        }
    }
}