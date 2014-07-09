using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;
using System.Collections;
using System.Web;
using TweetSharp;

namespace Service
{
    public partial class Testform : Form
    {
        /// <summary>
        /// Filter class.
        /// </summary>
        readonly Filter _filter = new Filter();

        /// <summary>
        /// Twitter service (sdk).
        /// </summary>
        private TwitterService _service;

        /// <summary>
        /// Authentication keys.
        /// </summary>
        private string ConsumerKey = "8nZZDzlBOF7OnGFEJKd9AQYIZ";
        private string ConsumerSecret = "lFzTnuyiP5ZA8dyV7DhIp3GULhz1n3QprnzISAwzoAW2S7mK1K";
        private string AccessToken = "2427720560-TeWqCJAfRdhRFeDlT0PW619mtzkle4oAK7dKuWY";
        private string AccessTokenSecret = "5sL8svkD4PkVciRlCRDKgprnqh5CoJZrokSBptOhZbeg3";

        /// <summary>
        /// Filtered tweets in the HTML.
        /// </summary>
        public string Tweethtml;

        public Testform()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Test button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_go_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
            // HTML reset.
            Tweethtml = "";

            // Tweets lately.
            var tweets = _service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());

                if (tweets != null)
                {
                    foreach (var tweet in tweets)
                    {
                        // Сheck the appropriate filter.
                        if ((_filter.Hashcheck(tweet.Text)) | (_filter.Usercheck(tweet.User.ScreenName)))
                        {
                            // Add tweet HTML.
                            Tweethtml += tweet.User.ScreenName + @":<br>" + tweet.TextAsHtml + @"<br>";

                            // If tweet contains image.
                            if (tweet.TextAsHtml.Contains("pic.twitter.com"))
                            {
                                Tweethtml = Tweethtml.Remove(Tweethtml.IndexOf("pic.twitter.com"), 26);
                                // Parse tweet img.
                                string pic = Pict("http://twitter.com/" + tweet.User.ScreenName+
                                    tweet.TextAsHtml.Substring(
                                        tweet.TextAsHtml.IndexOf("/status/"), 34));
                                // Add tweet img tag.
                                Tweethtml += "<img src=\"" + pic + "\">";
                            }
                            Tweethtml += "<br>";
                            tb2.Text += tweet.Id + @"; ";  
                        }
                        tb1.Text = (Tweethtml);
                        tb1.Text += Environment.NewLine;
                    }
                }
           
            // Open tweet HTML in browser.
            wb1.DocumentText = @"
                <html>
                    <head>
                    </head>
                    <body id=body>" + Tweethtml +
                    @"</body>
               </html>";
        }

        /// <summary>
        /// Obtain a reference image of the code page.
        /// </summary>
        /// <param name="html">Page link.</param>
        /// <returns>Image link.</returns>
        private string Pict(string html)
        {
            WebBrowser wbimg = new WebBrowser();
            // Open img page.
            wbimg.Navigate(html);
            {
                // Waiting for full load.
                while (wbimg.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }
            // Extract link.
            string value = wbimg.DocumentText.Substring(wbimg.DocumentText.IndexOf("https://pbs.twimg.com/media/"),47);
            return value;
        }

        /// <summary>
        /// Authentication service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestForm_Load(object sender, EventArgs e)
        {
            _service = new TwitterService(ConsumerKey, ConsumerSecret);
            _service.AuthenticateWith(AccessToken, AccessTokenSecret);
        }

    }
}
