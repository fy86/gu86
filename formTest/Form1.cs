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
        public int date;
        public int o;
        public int h;
        public int l;
        public int c;
        public float a;
        public int v;
        public int dummy;
    }

    public partial class Form1 : Form
    {
        private string gStrCurrentDir = "";
        private string gStrTHSdir = "";
        private string gStrTDXdir = "";

        st_tdxa[] pst_tdxa=new st_tdxa[4000];
        st_tdxa[] pst_tdxI = new st_tdxa[4000];
        int nLen_tdxI = 0;
        int gnTdxa = 0;

        int[] gnBuf = new int[4000<<3];
        float[] gfBuf = new float[4000<<3];

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
            //load_datagridview_test();
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

        private void loadidxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gtableIdx.Columns.Add("sn", typeof(int));
            gtableIdx.Columns.Add("date", typeof(int));
            gtableIdx.Columns.Add("open", typeof(float));
            gtableIdx.Columns.Add("high", typeof(float));
            gtableIdx.Columns.Add("low", typeof(float));
            gtableIdx.Columns.Add("close", typeof(float));
            gtableIdx.Columns.Add("vol", typeof(float));
            gtableIdx.Columns.Add("amount", typeof(float));
            gtableIdx.Columns.Add("percent", typeof(float));

            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            byte[] buf = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            int n = (int)(len >> (2+3));
            if (n <= 4000)
            {
                Buffer.BlockCopy(buf, 0, gnBuf,0, n << 5);
                Buffer.BlockCopy(buf, 0, gfBuf, 0, n << 5);
                nLen_tdxI = n;
            }
            else
            {
                Buffer.BlockCopy(buf, (n - 4000) << 5, gnBuf, 0, 4000 << 5);
                Buffer.BlockCopy(buf, (n - 4000) << 5, gfBuf, 0, 4000 << 5);
                nLen_tdxI = 4000;
            }
            for(int i = 0; i < n; i++)
            {
                gtableIdx.Rows.Add(i + 1, gnBuf[i << 3],
                    gnBuf[(i << 3) + 1] * 0.01,
                    gnBuf[(i << 3) + 2] * 0.01,
                    gnBuf[(i << 3) + 3] * 0.01,
                    gnBuf[(i << 3) + 4] * 0.01,
                    gnBuf[(i << 3) + 6] * 0.00000001,
                    gfBuf[(i<<3)+5] * 0.00000001,
                    0.0f);
            }
            dataGridView1.DataSource = gtableIdx;
        }
    }
}
