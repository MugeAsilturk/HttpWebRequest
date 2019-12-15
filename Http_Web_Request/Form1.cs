using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;
using System.Net;

namespace Http_Web_Request
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the web request  
            try
            {
                
                HttpWebRequest request = WebRequest.Create("https://onedio.com/") as HttpWebRequest;
                request.Method = "GET";

                //request.Credentials = new NetworkCredential("Username", "Password");
                
                // the next line generates exception [System.Net.WebException] = {"The remote server returned an error: (401) Unauthorized."}
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    // Get the response stream  
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    ///////////////////////////////////////
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(reader.ReadToEnd());

                    richTextBox1.Text = doc.DocumentNode.SelectSingleNode("//*[@id='articles']/article[1]/header/a/h3").InnerText;

                }


            }
            catch (Exception ex)
            {
                richTextBox1.Text = "There is an error !!";

            }
        }
    }
}
