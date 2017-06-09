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

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserOnline"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }
        }

        //SCRIPTS//////////////////////////////////////////////////////////////////
        private void RadioListScrollToBottom()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "RLScrollToBottom", "var element = document.getElementById('radioList'); element.scrollIntoView({block: 'end', behavior: 'smooth'});", true);
        }

        private void DescriptionFieldScrollToBottom()
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "RLScrollToBottom", "var element = document.getElementById('descriptionField'); element.scrollIntoView({block: 'end', behavior: 'smooth'});", true);
        }
        //--------------------------------------------------------------------------

        //PLAY BUTTON///////////////////////////////////////////////////////////////
        protected void btnPlay_Click1(object sender, ImageClickEventArgs e)
        {
            string radioName = Session["SelectedRadio"].ToString();
            bgVidLink.Src = objDBM.LinkPicker(radioName);
            videoBG.Visible = true;

        }
        //--------------------------------------------------------------------------

        //GENRE BUTTONS/////////////////////////////////////////////////////////////
        protected void btnEDM_Click(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = true;
            lofiRadioList.Visible = false;
            soundtrackRadioList.Visible = false;
            RadioListScrollToBottom();
        }

        protected void btnLoFi_Click1(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;   
            edmRadioList.Visible = false;
            lofiRadioList.Visible = true;
            soundtrackRadioList.Visible = false;
            RadioListScrollToBottom();
        }

        protected void btnSoundtrack_Click(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = false;
            lofiRadioList.Visible = false;
            soundtrackRadioList.Visible = true;
            RadioListScrollToBottom();
        }
        //----------------------------------------------------------------------------
        
        //RADIO STATION BUTTONS/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void btnRadio1_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnRadio1.Text);
            lblRadioDescription.Text = "Kick back and chill with the best lo-fi tunes out there in this great big world.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio1.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnRadio2_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnRadio2.Text);
            lblRadioDescription.Text = "Get the party started with the hottest remixes of the best music of the year.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnRadio2.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnChillhopCafe_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnChillhopCafe.Text);
            lblRadioDescription.Text = "Relax with some of the best jazzy instrumental hip hop on the scene.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnChillhopCafe.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnStaySee_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnStaySee.Text);
            lblRadioDescription.Text = "Chill out, and have some good times with these groovy vibes.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnStaySee.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnPixl_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnPixl.Text);
            lblRadioDescription.Text = "Featuring the best of what the scene has to offer, relax, study, or party with Pixl Radio.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnPixl.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnSoulCandle_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnSoulCandle.Text);
            lblRadioDescription.Text = "Ignite your soul and relax with beautiful and elegant piano pieces that will sync your mind to the tranquility of the seas.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnSoulCandle.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnEpicMusic_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnEpicMusic.Text);
            lblRadioDescription.Text = "Some of the most powerful and epic soundtracks this side of the millennium.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnEpicMusic.Text;
            DescriptionFieldScrollToBottom();
        }

        protected void btnFalloutRadio_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: " + btnFalloutRadio.Text);
            lblRadioDescription.Text = "Experience or relive the evolution of the Wastelands of the popular video game franchise, 'Fallout'.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = btnFalloutRadio.Text;
            DescriptionFieldScrollToBottom();
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
        
    }
}