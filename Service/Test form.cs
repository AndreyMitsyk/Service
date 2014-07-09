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
using Service;

namespace Service
{
    public partial class Testform : Form
    {
        readonly Filter _filter = new Filter();

        private TwitterService _service;
        public string ConsumerKey = "8nZZDzlBOF7OnGFEJKd9AQYIZ";
        public string ConsumerSecret = "lFzTnuyiP5ZA8dyV7DhIp3GULhz1n3QprnzISAwzoAW2S7mK1K";
        public string AccessToken = "2427720560-TeWqCJAfRdhRFeDlT0PW619mtzkle4oAK7dKuWY";
        public string AccessTokenSecret = "5sL8svkD4PkVciRlCRDKgprnqh5CoJZrokSBptOhZbeg3";
        public string Tweethtml;

        public Testform()
        {
            InitializeComponent();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            tb1.Text = "";
            Tweethtml = "";
            int i = 0;

            
            while (i <= 20)
            {
            var tweets = _service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions());
                if (tweets != null)
                {
                    foreach (var tweet in tweets)
                    {
                        if ((_filter.Hashcheck(tweet.Text)) | (_filter.Usercheck(tweet.User.ScreenName)))
                        {
                            Tweethtml += tweet.User.ScreenName + @":<br>" + tweet.TextAsHtml + @"<br>";

                            if (tweet.TextAsHtml.Contains("pic.twitter.com"))
                            {
                                string pic = Pict("http://twitter.com/" + tweet.User.ScreenName+
                                    tweet.TextAsHtml.Substring(
                                        tweet.TextAsHtml.IndexOf("/status/"), 34));
                                Tweethtml += "<img src=\"" + pic + "\">";
                            }
                            Tweethtml += "<br>";
                            tb2.Text += tweet.Id + "; ";
                        }

                        tb1.Text += (tweet.User.ScreenName + " says: '" + tweet.TextAsHtml + "'");
                        tb1.Text += Environment.NewLine;
                    }
                    i = 25;
                }
                else i++;
            }

            if ((i>19)&(i!=25))
                MessageBox.Show(@"Unable to Load");
           
            wb1.DocumentText = @"
                <html>
                    <head>
                    </head>
                    <body id=body>" + Tweethtml +
                    @"</body>
               </html>";

        }

        private string Pict(string html)
        {
            WebBrowser wbimg = new WebBrowser();

            wbimg.Navigate(html);
            {
                while (wbimg.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }
            string value = wbimg.DocumentText.Substring(wbimg.DocumentText.IndexOf("https://pbs.twimg.com/media/"),47);

            return value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _service = new TwitterService(ConsumerKey, ConsumerSecret);
            _service.AuthenticateWith(AccessToken, AccessTokenSecret);
        }

    }
}
