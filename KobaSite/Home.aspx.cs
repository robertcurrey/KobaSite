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
using System.Timers;

namespace KobaSite
{
    public partial class Home : System.Web.UI.Page
    {
        DBManager objDBM = new DBManager();
        DataSet allYTURLS = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserOnline"] == null)
            {
                Response.Redirect("Welcome.aspx");
            }

            allYTURLS = objDBM.GetAllURLS();

        }

        public string getYouTubeThumbnail(string YoutubeUrl)
        {
            return "http://img.youtube.com/vi/" + YoutubeUrl + "/mqdefault.jpg";
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

            lblNowPlaying.Text = ("Now Playing: " + radioName + " Radio");
            nowPlayingField.Visible = true;
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

            foreach (DataTable table in allYTURLS.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                        //get the next radio/link combo
                        string dbRadio = (row["RadioName"]).ToString();
                        string dbLinkExt = (row["ThumbnailExt"]).ToString();

                        switch (dbRadio)
                        {
                            case "Pixl":
                                {
                                    Pixl.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                    break;
                                }
                            case "DJJeNy":
                                {
                                    DJJeNy.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                    break;
                                }
                            case "StaySee":
                                {
                                    StaySee.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                    break;
                                }
                        }
                }
            }
        }

        protected void btnLoFi_Click1(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;   
            edmRadioList.Visible = false;
            lofiRadioList.Visible = true;
            soundtrackRadioList.Visible = false;
            RadioListScrollToBottom();

            foreach (DataTable table in allYTURLS.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    //get the next radio/link combo
                    string dbRadio = (row["RadioName"]).ToString();
                    string dbLinkExt = (row["ThumbnailExt"]).ToString();

                    switch (dbRadio)
                    {
                        case "Nourish":
                            {
                                Nourish.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                break;
                            }
                        case "ChillhopCafe":
                            {
                                ChillhopCafe.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                break;
                            }
                    }
                }
            }
        }

        protected void btnSoundtrack_Click(object sender, ImageClickEventArgs e)
        {
            radioList.Visible = true;
            edmRadioList.Visible = false;
            lofiRadioList.Visible = false;
            soundtrackRadioList.Visible = true;
            RadioListScrollToBottom();

            foreach (DataTable table in allYTURLS.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    //get the next radio/link combo
                    string dbRadio = (row["RadioName"]).ToString();
                    string dbLinkExt = (row["ThumbnailExt"]).ToString();

                    switch (dbRadio)
                    {
                        case "SoulCandle":
                            {
                                SoulCandle.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                break;
                            }
                        case "EpicMusic":
                            {
                                EpicMusic.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                break;
                            }
                        case "Fallout":
                            {
                                Fallout.ImageUrl = getYouTubeThumbnail(dbLinkExt);
                                break;
                            }
                    }
                }
            }
        }
        //----------------------------------------------------------------------------

        //RADIO STATION BUTTONS/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Nourish Button Click
        protected void btnRadio1_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Nourish Radio");
            lblRadioDescription.Text = "Kick back and chill with the best lo-fi tunes out there in this great big world.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = Nourish.ID;
            DescriptionFieldScrollToBottom();
        }

        //DJJeNy Button Click
        protected void btnRadio2_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: DJ JeNy");
            lblRadioDescription.Text = "Get the party started with the hottest remixes of the best music of the year.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = DJJeNy.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnChillhopCafe_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Chillhop Cafe Radio");
            lblRadioDescription.Text = "Relax with some of the best jazzy instrumental hip hop on the scene.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = ChillhopCafe.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnStaySee_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Stay See");
            lblRadioDescription.Text = "Chill out, and have some good times with these groovy vibes.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = StaySee.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnPixl_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Pixl Radio");
            lblRadioDescription.Text = "Featuring the best of what the scene has to offer, relax, study, or party with Pixl Radio.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = Pixl.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnSoulCandle_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Soul Candle Radio");
            lblRadioDescription.Text = "Ignite your soul and relax with beautiful and elegant piano pieces that will sync your mind to the tranquility of the seas.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = SoulCandle.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnEpicMusic_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Epic Music Radio");
            lblRadioDescription.Text = "Some of the most powerful and epic soundtracks this side of the millennium.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = EpicMusic.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnFalloutRadio_Click(object sender, EventArgs e)
        {
            lblDescription.Text = ("Description: Fallout Radio");
            lblRadioDescription.Text = "Experience or relive the evolution of the Wastelands of the popular video game franchise, 'Fallout'.";
            descriptionField.Visible = true;
            Session["SelectedRadio"] = Fallout.ID;
            DescriptionFieldScrollToBottom();
        }

        protected void btnReportLink_Click(object sender, EventArgs e)
        {
            string currentRadio = Session["SelectedRadio"].ToString();

            EmailModules objEmail = new EmailModules();
            objEmail.BrokenLinkReport(currentRadio);

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ReportAlert", "alert('Thanks for telling us. We'll have that station back online soon!');", true);
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}