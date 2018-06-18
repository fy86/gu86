using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formTest
{
    public partial class Form1 : Form
    {
        private string gStrCurrentDir = "";
        private string gStrTHSdir = "";
        private string gStrTDXdir = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadtxtgbToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                richTextBox1.Text +=openFileDialog1.FileName;
                richTextBox2.Text = System.IO.File.ReadAllText(openFileDialog1.FileName, Encoding.GetEncoding(936));// gb2312
            }

            gStrCurrentDir = System.IO.Directory.GetCurrentDirectory();
            richTextBox1.Text += "\ncurrent work dir: " + gStrCurrentDir;
        }

        private void loadbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load bin 个股日线数据

        }
    }
}
