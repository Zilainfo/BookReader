using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookReader
{
    public partial class Form2 : Form
    {


        public string email = "zilainfo@gmail.com";
        public string password = "5091996KstasNew";
        public ChromiumWebBrowser chromeBrowser;

        public Form2()
        {
            InitializeComponent();
            // Start the browser after initialize global component
            InitializeChromium();

            chromeBrowser.LoadingStateChanged += (sender, args) =>
            {
                //chromeBrowser.RequestHandler
                if (args.IsLoading == false)
                {
                    //Set Login
                    //var j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"data-initial-value\", \"" + email + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //var task = chromeBrowser.EvaluateScriptAsync(j);
               
                    //j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"value\", \"" + email + "\" );";
                    //chromeBrowser.ExecuteScriptAsync();

                    //j = "document.getElementById(\"identifierId\").click();";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var c = document.querySelector('div[role=\"button\"]'); c.click();";
                    //chromeBrowser.EvaluateScriptAsync(j);

                    //for (var c = 0; c < 60; c++)
                    //{
                    //    if (!chromeBrowser.IsLoading) { break; }
                    //    Thread.Sleep(1000);
                    //}


                    //chromeBrowser.ExecuteScriptAsync(j);
                    //chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);

                    //Set Password
                    //j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"data-initial-value\", \"" + password + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"value\", \"" + password + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var v = document.querySelector('div[role=\"button\"]'); v.click();";
                    //chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);

















                      var task =  Auth1();

                    ////Set Login
                    //var j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"data-initial-value\", \"" + email + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"value\", \"" + email + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);
               
                    //j = "document.getElementById(\"identifierId\").click();";
                    //chromeBrowser.ExecuteScriptAsync(j);
                    
                    //j = "var c = document.querySelector('div[role=\"button\"]'); c.click();";
                    //chromeBrowser.EvaluateScriptAsync(j);

                    //for (var c = 0; c < 60; c++)
                    //{
                    //    if (!chromeBrowser.IsLoading) { break; }
                    //    Thread.Sleep(1000);
                    //}


                    ////chromeBrowser.ExecuteScriptAsync(j);
                    ////chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);

                    ////Set Password
                    //j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"data-initial-value\", \"" + password + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"value\", \"" + password + "\" );";
                    //chromeBrowser.ExecuteScriptAsync(j);

                    //j = "var v = document.querySelector('div[role=\"button\"]'); v.click();";
                    //chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);

                }
            };
            

            // Register an object in javascript named "cefCustomObject" with function of the CefCustomObject class :3
            //chromeBrowser.RegisterJsObject("cefCustomObject", new CefCustomObject(chromeBrowser, this));
        }
       
        private async Task Auth2()

        {  //Set Login


            var j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"data-initial-value\", \"" + email + "\" );";
            await chromeBrowser.EvaluateScriptAsync(j);
            //AsyncHelpers.RunSync(chromeBrowser.EvaluateScriptAsync(j));

            //AsyncHelpers.RunSync<Task ( () => chromeBrowser.EvaluateScriptAsync(j));

            j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"value\", \"" + email + "\" );";
            await chromeBrowser.EvaluateScriptAsync(j);

            j = "document.getElementById(\"identifierId\").click();";
            await chromeBrowser.EvaluateScriptAsync(j);

            j = "var c = document.querySelector('div[role=\"button\"]'); c.click();";
            await chromeBrowser.EvaluateScriptAsync(j);


            for (var c = 0; c < 60; c++)
            {
                if (!chromeBrowser.IsLoading) { break; }
                Thread.Sleep(1000);
            }


            j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"data-initial-value\", \"" + password + "\" );";
            await chromeBrowser.EvaluateScriptAsync(j);

            j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"value\", \"" + password + "\" );";
            await chromeBrowser.EvaluateScriptAsync(j);

            j = "var v = document.querySelector('div[role=\"button\"]'); v.click();";
            await chromeBrowser.EvaluateScriptAsync(j);
        }



        private async Task AsyncToSync()
        {
           
        }

            private async Task Auth1()
        {

            var j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"data-initial-value\", \"" + email + "\" ); return 1;";
            

            object result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();


            j = "var b = document.getElementById(\"identifierId\"); b.setAttribute(\"value\", \"" + email + "\" );";
             result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
            j = "document.getElementById(\"identifierId\").click();";
             result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();

            j = "var c = document.querySelector('div[role=\"button\"]'); c.click();";
            result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();

            for (var c = 0; c < 60; c++)
            {
                if (!chromeBrowser.IsLoading) { break;  }
                Thread.Sleep(100000);
            }


            j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"data-initial-value\", \"" + password + "\" );";
            result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
            j = "var c = document.querySelector('input[type=\"password\"]'); c.setAttribute(\"value\", \"" + password + "\" );";
            result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();

            j = "var v = document.querySelector('div[id=\"passwordNext\"]'); v.click();";
            result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
            for (var c = 0; c < 60; c++)
            {
                if (!chromeBrowser.IsLoading) { break; }
                Thread.Sleep(100000);
            }
            Thread.Sleep(50000);
            // await chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);

            j = " var r = document.querySelector('img[alt=\"Ranobe Hub\"]'); r.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.click();";
            result = EvaluateScript(j, 0, TimeSpan.FromSeconds(1)).GetAwaiter().GetResult();
            Form2 fd = new Form2();
            fd.Show();
        }

        public async Task<object> EvaluateScript(string script, object defaultValue, TimeSpan timeout)
        {
            object result = defaultValue;
            if (chromeBrowser.IsBrowserInitialized && !chromeBrowser.IsDisposed && !chromeBrowser.Disposing)
            {
                try
                {
                    var task = chromeBrowser.EvaluateScriptAsync(script, timeout);
                    await task.ContinueWith(res => {
                        if (!res.IsFaulted)
                        {
                            var response = res.Result;
                            result = response.Success ? (response.Result ?? "null") : response.Message;
                        }
                    }).ConfigureAwait(false); // <-- This makes the task to synchronize on a different context
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
            return result;
        }
        private async Task Auth(string j)
        {
            await chromeBrowser.EvaluateScriptAsync(j).ConfigureAwait(false);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            chromeBrowser.ShowDevTools();
        }

        public void InitializeChromium()

        {
            CefSettings settings = new CefSettings();

            chromeBrowser = new ChromiumWebBrowser("https://accounts.google.com/signin/v2/identifier?service=youtube&uilel=3&passive=true&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26app%3Ddesktop%26hl%3Dru%26next%3Dhttps%253A%252F%252Fwww.youtube.com%252F&hl=ru&ec=65620&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

            chromeBrowser.Width = 100;
            chromeBrowser.Height = 100;

            

            // Add it to the form and fill it to the form window.
            this.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;

            // Allow the use of local resources in the browser
            BrowserSettings browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrls = CefState.Enabled;
            browserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            chromeBrowser.BrowserSettings = browserSettings;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

    }
}
