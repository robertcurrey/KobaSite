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
            lblDescription.Text = ("Description: " + btnRadio1.Text);
            lblRadioDescription.Text = "Kick back and chill with the best lo-fi tunes out there in this great big world.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio1.Text;
        }

        protected void btnRadio2_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnRadio2.Text);
            lblRadioDescription.Text = "Get the party started with the hottest remixes of the best music of the year.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio2.Text;
        }

        protected void btnChillhopCafe_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnChillhopCafe.Text);
            lblRadioDescription.Text = "Relax with some of the best jazzy instrumental hip hop on the scene.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnChillhopCafe.Text;
            
        }

        protected void btnStaySee_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnStaySee.Text);
            lblRadioDescription.Text = "Chill out, and have some good times with these groovy vibes.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnStaySee.Text;
        }

        protected void btnPixl_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnPixl.Text);
            lblRadioDescription.Text = "Featuring the best of what the scene has to offer, relax, study, or party with Pixl Radio.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnPixl.Text;
        }

        protected void btnEDM_Click1(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = true;
            lofiRadioList.Visible = false;
        }

        protected void btnPlay_Click1(object sender, ImageClickEventArgs e)
        {
            string radioName = Session["SelectedRadio"].ToString();
            bgVidLink.Src = objDBM.LinkPicker(radioName);
            videoBG.Visible = true;

        }

        protected void btnLoFi_Click1(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = false;
            lofiRadioList.Visible = true;
        }
    }
}