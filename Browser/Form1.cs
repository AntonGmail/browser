using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Browser.Models;

namespace Browser
{
    public partial class Form1 : Form
    {
        private DbContext db;

        public Form1()
        {
            InitializeComponent();
            db = new DbContext();
            comboBox1.DataSource = db.Categories;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void gotoPage()
        {
            string addstr = textBox1.Text;
            if (addstr == "")
            {
                MessageBox.Show("input adress corectly", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                webBrowser1.Navigate(addstr);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gotoPage();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                gotoPage();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.Categories;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object id = (int)comboBox1.SelectedValue;

            var res = db.Sites.Where(s => s.categoryid == (int)id).ToList();

            listBox1.DataSource = res;
            listBox1.DisplayMember = "name";
            listBox1.ValueMember = "id";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("u dont use", " attantion ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

            }object id = listBox1.SelectedValue;
            MessageBox.Show(id.ToString());
        }
    }
}
