using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersOne.Epub;
using Windows.Storage.Pickers;
using FfmpegMaster;
using Google.Apis.YouTube.v3.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using CefSharp.WinForms;
using CefSharp;

namespace BookReader
{
    public partial class Form1 : Form
    {

        public string bookPath;
        public string savePath;
        public string imgPath;
        public CookieContainer cookies = new CookieContainer();
        public Form1()
        {
            //Create a new instance in code or add via the designer
            //Set the ChromiumWebBrowser.Address property to your Url if you use the designer.
            //var browser = new ChromiumWebBrowser("www.google.com");
            //parent.Controls.Add(browser);

         

            //for (var j = 0; j < 60; j++)
            //{
            //    if (browser.IsBrowserInitialized) { break; }
            //    Thread.Sleep(1000);
            //}


           
            //browser.ExecuteScriptAsync("document.getElementById('email').value=" + email);
            //browser.ExecuteScriptAsync("alert('test');");
             
            InitializeComponent();
          
        }


        // GO button click event handler.  

        private void GoButton_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();


            //if (String.IsNullOrEmpty(Url.Text) || Url.Text.Equals("about:blank"))
            //{
            //    MessageBox.Show("Enter a valid URL.");
            //    Url.Focus();
            //    return;
            //}
            //OpenURLInBrowser(Url.Text);
        }

        private void OpenURLInBrowser(string url)
        {

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }

            try
            {
    

                //webBrowser1.Navigate(new Uri(url));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //UploadVideo TEST = new UploadVideo();
            //TEST.authtori1(cookies);

            //string path = @"o:\Test\out.mp4";
            //using (FileStream fs = File.OpenRead(path))
            //{ };


            //Video video = new Video();
            //video.Snippet = new VideoSnippet();

            //video.Snippet.Title = BookName.Text;
            //video.Snippet.Description = Describe.Text;
            //video.Snippet.Tags = new string[] { "tag1", "tag2" };
            //video.Snippet.CategoryId = "22"; // See https://developers.google.com/youtube/v3/docs/videoCategories/list
            //video.Status = new VideoStatus();
            //video.Status.PrivacyStatus = "unlisted"; // or "private" or "public"
            //string filePath = @"o:\Test\out.mp4"; // Replace with path to actual movie file.

            //UploadVideo TEST = new UploadVideo();
            //TEST.Run(video, filePath);
            //if (cont.Text == "")
            //{
            //    cont.Text = "0";
            //}


            //SsadTest d = new SsadTest();
            //d.SetUp(@"o:\Test\out.mp4");
           
            //Reader book = new Reader(bookPath, savePath, imgPath, Describe.Text, BookName.Text, MainTags.Text, SecondTegs.Text, int.Parse(cont.Text));

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
  

        private  void  button2_ClickAsync(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "epub",
                Filter = "epub files (*.epub)|*.epub",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                bookPath = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                savePath = openFileDialog1.SelectedPath;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "png",
                Filter = "png files (*.png)|*.png",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                imgPath = openFileDialog1.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create(address);
         
            //cookies.SetCookies(webBrowser1.Document.Url,
            //                          webBrowser1.Document.Cookie.Replace(';', ','));
            ////req.CookieContainer = cookies;
            //cookies.GetCookieHeader(webBrowser1.Document.Url);
        }
    }
}
