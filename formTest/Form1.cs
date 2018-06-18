using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace formTest
{
    struct st_tdxa
    {
        int dt;
        int o;
        int h;
        int l;
        float a;
        int v;
        int dummy;
    }

    public partial class Form1 : Form
    {
        private string gStrCurrentDir = "";
        private string gStrTHSdir = "";
        private string gStrTDXdir = "";

        st_tdxa[] pst_tdxa=new st_tdxa[5000];
        int gnTdxa = 0;

        int[] gnBuf = new int[100000];
        float[] gfBuf = new float[100000];

        public Form1()
        {
            InitializeComponent();
        }

        private void load_datagridview_test()
        {
            gtable1.Columns.Add("sn", typeof(int));
            gtable1.Columns.Add("code", typeof(string));
            gtable1.Columns.Add("name", typeof(string));
            gtable1.Rows.Add(4, "600000", "shenfazhan1");
            gtable1.Rows.Add(1, "600004", "shenfazhan2");
            gtable1.Rows.Add(2, "600003", "shenfazhan3");
            gtable1.Rows.Add(3, "600002", "shenfazhan4");

            dataGridView1.DataSource = gtable1;
            gtable1.DefaultView.Sort = "sn";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_datagridview_test();
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
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            byte[] buf=System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            Buffer.BlockCopy(buf, 0, gnBuf, 0,(int)len );
            Buffer.BlockCopy(buf, 0, gfBuf, 0, (int)len);
            int n = (int)(len >> 2);
            for(int i = n-30; i < n; i++)
            {
                string str = gnBuf[i].ToString() +" : " + gfBuf[i].ToString("0.0000")+"\n";
                richTextBox1.Text += str;
            }



        }

        DataTable gtable1 = new DataTable();
        DataTable gtableIdx = new DataTable();
        DataTable gtableA = new DataTable();

        private void datatableshowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
