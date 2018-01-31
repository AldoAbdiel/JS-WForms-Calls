using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace js_wforms {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();            
            webBrowser1.ObjectForScripting = new ScriptManager(this);
        }

        private void button1_Click(object sender, EventArgs e) {
            object[] o = new object[1];
            o[0] =  textBox1.Text;
            object result = this.webBrowser1.Document.InvokeScript("ShowMessage", o);
        }
        private void Form1_Load(object sender, EventArgs e) {
            string curDir = Directory.GetCurrentDirectory();
            webBrowser1.Url = new Uri(String.Format("file:///{0}/TestPage.html", curDir));
        }

        [ComVisible(true)]
        public class ScriptManager {
            Form1 _form;
            public ScriptManager(Form1 form) {
                _form = form;
            }
            public void ShowMessage(object obj) {
                MessageBox.Show(obj.ToString());
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {

        }
    }
}