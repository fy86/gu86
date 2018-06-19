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
        public class mycFileSize
        {
            public string filename { get; set; }
            public long size { get; set; }
            public long days { get; set; }
        }
        public class mycHisA
        {
            public int date { get; set; }
            public float open { get; set; }
            public float high { get; set; }
            public float low { get; set; }
            public float close { get; set; }
            public float yc { get; set; }
            public float vol { get; set; }
            public float amount { get; set; }
            public float percent { get; set; }
        }

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

        private void load_configInfo()
        {
            if (!System.IO.File.Exists("configInfo.txt")) return;
            string[] lines = File.ReadAllLines("configinfo.txt");
            foreach(string line in lines)
            {
                string[] words = line.Split(new[] { ' ', '\t' },StringSplitOptions.None);
                if (words.Length > 1)
                {
                    if (words[0].Equals("tdx_root")) gstr_tdx_root = words[1];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //load_datagridview_test();
            load_configInfo();
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

        private void loadBinQLwgt()
        {
            // load bin 钱龙权息数据
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            byte[] buf = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            Buffer.BlockCopy(buf, 0, gnBuf, 0, (int)len);
            Buffer.BlockCopy(buf, 0, gfBuf, 0, (int)len);
            int n = (int)(len >> 2);
            richTextBox1.Text = "";
            for (int i = 0; i < n; i++)
            {
                // 钱龙权息
                string str = gnBuf[i].ToString()
                    + "  y: " + (gnBuf[i] >> 20).ToString()
                    + "  m: " + ((gnBuf[i] >> 16) & 0x0f).ToString()
                    + "  d: " + ((gnBuf[i] >> 11) & 0x01f).ToString()
                    + "  float: " + gfBuf[i].ToString("0.0000") + "\n";
                richTextBox1.AppendText(str);
            }

        }
        private void loadBinA()
        {
            // load bin 个股日线数据
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            byte[] buf = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            Buffer.BlockCopy(buf, 0, gnBuf, 0, (int)len);
            Buffer.BlockCopy(buf, 0, gfBuf, 0, (int)len);
            int n = (int)(len >> 2);
            richTextBox1.Text = "";
            for (int i = 0; i < n; i++)
            {
                string str = gnBuf[i].ToString() + " : " + gfBuf[i].ToString("0.0000") + "\n";
                richTextBox1.AppendText(str);
            }

        }
        private void loadBinAmin()
        {
            // load bin 个股分钟数据
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            byte[] buf = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            if (len > 4000) len = 4000;
            Buffer.BlockCopy(buf, 0, gnBuf, 0, (int)len);
            Buffer.BlockCopy(buf, 0, gfBuf, 0, (int)len);
            int n = (int)(len >> 2);
            richTextBox1.Text = "";
            for (int i = 0; i < n; i++)
            {
#if false
                string str = gnBuf[i].ToString()
                    + "  y: " + (gnBuf[i] >> 20).ToString()
                    + "  m: " + ((gnBuf[i] >> 16) & 0x0f).ToString()
                    + "  d: " + ((gnBuf[i] >> 11) & 0x01f).ToString()
                    + "  hh: " + ((gnBuf[i] >> 6) & 0x1f).ToString()
                    + "  mm: " + ((gnBuf[i]) & 0x3f).ToString()
                    + "  float: " + gfBuf[i].ToString("0.0000") + "\n";
#endif
                string str = gnBuf[i].ToString()
                    + " hex: " + gnBuf[i].ToString("X4")
                    + "  y: " + (gnBuf[i] >> 20).ToString()
                    + "  m: " + ((gnBuf[i] >> 16) & 0x0f).ToString()
                    + "  d: " + ((gnBuf[i] >> 11) & 0x01f).ToString()
                    + "  hh: " + (((gnBuf[i]>>16)&0x0ffff)/60).ToString()
                    + "  mm: " + (((gnBuf[i]>>16)&0x0ffff)%60).ToString()
                    + "  float: " + gfBuf[i].ToString("0.0000") + "\n";
                richTextBox1.AppendText(str);
            }

        }
        // 
        private void loadbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load 个股
            //loadBinA();
            loadBinAmin();
            // load qiaolong wgt
            //loadBinQLwgt();
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
        private void save_configinfo()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("configinfo.txt"))
            {
                if (gstr_tdx_root.Length > 0)
                {
                    file.WriteLine("tdx_root " + gstr_tdx_root);
                }
            }
        }
        // tdx_root ..
        // ths_root ..
        private string gstr_tdx_root = "";
        // save config.file
        private void saveconfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_configinfo();
        }

        private void get_tdx_root()
        {
            DialogResult r = folderBrowserDialog1.ShowDialog();
            if (r == DialogResult.OK || r == DialogResult.Yes)
            {
                gstr_tdx_root = folderBrowserDialog1.SelectedPath;
                int len = gstr_tdx_root.Length;
                if (!gstr_tdx_root.Substring(len - 1).Equals("\\")) gstr_tdx_root += "\\";
                save_configinfo();
            }

        }

        private void gettdxrootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("current tdx_root: " + gstr_tdx_root);
            get_tdx_root();
        }

        List<mycFileSize> listFileSize = new List<mycFileSize>();

        private void top100new()
        {
            int n = 0;
            if (gstr_tdx_root.Length < 1)
            {
                MessageBox.Show("tdx root dir blank!");
                return;
            }

            DirectoryInfo d = new DirectoryInfo(gstr_tdx_root + "vipdoc\\sh\\lday");
            FileInfo[] fs = d.GetFiles(@"sh60????*.day");
            foreach(FileInfo f in fs)
            {
                listFileSize.Add(new mycFileSize(){ filename = f.FullName, size = f.Length,days=f.Length>>5 });
            }
            DirectoryInfo ds = new DirectoryInfo(gstr_tdx_root + "vipdoc\\sz\\lday");
            FileInfo[] fs00 = ds.GetFiles(@"sz00????*.day");
            foreach (FileInfo f in fs00)
            {
                listFileSize.Add(new mycFileSize() { filename = f.FullName, size = f.Length ,days=f.Length>>5});
            }
            FileInfo[] fs30 = ds.GetFiles(@"sz30????*.day");
            foreach (FileInfo f in fs30)
            {
                listFileSize.Add(new mycFileSize() { filename = f.FullName, size = f.Length,days=f.Length>>5 });
            }
            n = fs.Length + fs00.Length + fs30.Length;
            richTextBox1.AppendText("total files : " + n.ToString() + " found\n");

            listFileSize.Sort(delegate (mycFileSize x, mycFileSize y)
            {
                return x.size.CompareTo(y.size);
            });

            int i = 0;
            foreach(mycFileSize cfs in listFileSize)
            {
                if (i++> 100) break;
                richTextBox1.AppendText(cfs.filename+"     size: " + cfs.size.ToString()+"     days: "+cfs.days.ToString()+"\n");
            }
        }

        private void new100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // new top 100
            top100new();
        }

        private void loadQLwgt()
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;

            return;
        }

        private void loadqlwqtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadQLwgt();
        }
    }
}
