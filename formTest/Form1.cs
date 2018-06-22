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
        List<mycHisA> hisA1 = new List<mycHisA>();

        public class mycQLwgt
        {
            public int date;
            public float song;
            public float zhuan;
            public float price;
            public float pei;
            public float hong;
            public float liutong;
            public float all;
            public float r;
        }
        List<mycQLwgt> gQLwgt = new List<mycQLwgt>();

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

        // load list gQLwgt
        private void loadListQLwgt()
        {
            // load bin QL.wgt
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            long len4 = len >> 2;
            long len9 = len4 / 9;

            using (BinaryReader reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
            {
                for (long il = 0; il < len9; il++)
                {
                    mycQLwgt qlwgt = new mycQLwgt();
                    int dt = reader.ReadInt32();
                    qlwgt.date = 10000 * (dt >> 20) + 100 * ((dt >> 16) & 0x0f) + ((dt >> 11) & 0x01f);
                    qlwgt.song = 0.0001f * reader.ReadInt32() ;// per 10
                    qlwgt.pei = 0.0001f * reader.ReadInt32();
                    qlwgt.price = 0.001f * reader.ReadInt32();
                    qlwgt.hong = 0.0001f * reader.ReadInt32();// mei.gu....yuan
                    qlwgt.zhuan = 0.0001f * reader.ReadInt32();
                    qlwgt.all = 1.0f * reader.ReadInt32();// wan.gu
                    qlwgt.liutong = 1.0f * reader.ReadInt32();// wan.gu
                    dt = reader.ReadInt32();
                    gQLwgt.Add(qlwgt);
                }
            }

            richTextBox1.Text = "";
            foreach(mycQLwgt wgt in gQLwgt)
            {
                string str = wgt.date.ToString();
                if (wgt.song > 0.001) str += " 10.song:" + wgt.song.ToString("f2");
                if (wgt.zhuan > 0.001) str += " 10.zhuan:" + wgt.zhuan.ToString("f2");
                if (wgt.pei > 0.001) str += " 10.pei:" + wgt.pei.ToString("f2")
                        + " jia:" + wgt.price.ToString("f2");
                if (wgt.hong > 0.0001) str += " 1.hong:" + wgt.hong.ToString("f4");
                str+="\n";
                richTextBox1.AppendText(str);
            }
        }

        private void loadBinQLwgt()
        {
            // load bin QL.wgt
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
                // QL.wgt
                string str = gnBuf[i].ToString()
                    + "  y: " + (gnBuf[i] >> 20).ToString()
                    + "  m: " + ((gnBuf[i] >> 16) & 0x0f).ToString()
                    + "  d: " + ((gnBuf[i] >> 11) & 0x01f).ToString()
                    + "  float: " + gfBuf[i].ToString("0.0000") + "\n";
                richTextBox1.AppendText(str);
            }

        }
        private void loadHisA()
        {
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;
            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            long len4 = len >> 2;
            long len8 = len4 >> 3;
            long il = 0;
            int ri;
            float rf;
            using (BinaryReader reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
            {
                for (il = 0; il < len8; il++)
                {
                    mycHisA cHisA = new mycHisA();
                    cHisA.date = reader.ReadInt32();
                    cHisA.open = .01f * reader.ReadInt32();
                    cHisA.high = .01f * reader.ReadInt32();
                    cHisA.low = .01f * reader.ReadInt32();
                    cHisA.close = .01f * reader.ReadInt32();
                    cHisA.amount = .01f * reader.ReadSingle();
                    cHisA.vol = .01f * reader.ReadInt32();
                    ri = reader.ReadInt32();
                    hisA1.Add(cHisA);
                }
            }
            hisA1.Sort(delegate (mycHisA x, mycHisA y)
            {
                return y.date.CompareTo(x.date);
            });
            hisA1.Sort(delegate (mycHisA x, mycHisA y)
            {
                return x.date.CompareTo(y.date);
            });

            richTextBox1.Text = "";
            foreach(mycHisA chisa in hisA1)
            {
                richTextBox1.AppendText(chisa.date.ToString()
                    + " " + chisa.open.ToString("f2")
                    + " " + chisa.high.ToString("f2")
                    + " " + chisa.low.ToString("f2")
                    + " " + chisa.close.ToString("f2")
                    + " " + chisa.vol.ToString("f0")
                    + " " + chisa.amount.ToString("f0")
                    +"\n");
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
        // tdx.min
        private void loadBinAmin()
        {
            // load bin min1 , min5
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
                string str = gnBuf[i].ToString()
                    + "  " + (((gnBuf[i]>>11)&0x1f)+2004 ).ToString()
                    + "-" + ((gnBuf[i] &0x3ff)/100).ToString()
                    + "-" + ((gnBuf[i] &0x3ff)%100).ToString()
                    + "  " + ((gnBuf[i]>>16)/60).ToString()
                    + ":" + ((gnBuf[i]>>16)%60).ToString()
                    + "  float: " + gfBuf[i].ToString("0.0000") + "\n";
                richTextBox1.AppendText(str);
            }

        }
        // tdx.1,5min lc1,lc5 format
        private void loadBinAmin2()
        {
            // load bin 个股分钟数据
            DialogResult r = openFileDialog1.ShowDialog();
            if (r != DialogResult.OK) return;

            FileInfo fi = new FileInfo(openFileDialog1.FileName);
            long len = fi.Length;
            long len4 = len >> 2;
            long len8 = len4 >> 3;
            long il = 0;
            short dt = 0,dt1 = 0;
            short hhmm = 0, hhmm1 = 0;
            int i=0;
            float f1, f2, f3, f4, f5;
            int v = 0;
            using (BinaryReader reader = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
            {
                for (il = 0; il < len8; il++)
                {
                    dt = reader.ReadInt16();
                    hhmm = reader.ReadInt16();
                    if (dt != dt1)
                    {
                        richTextBox1.AppendText("dt: " + dt1.ToString("X4") + " -> " + dt.ToString("X4") + " -- " + (dt-dt1).ToString()+ "\n");
                    }
                    dt1 = dt;
                    if (hhmm - hhmm1 != 1)
                    {
                        richTextBox1.AppendText("hhmm: " + hhmm1.ToString("X4") + " -> " + hhmm.ToString("X4") + "\n");
                    }
                    hhmm1 = hhmm;

                    f1 = reader.ReadSingle();
                    f2 = reader.ReadSingle();
                    f3 = reader.ReadSingle();
                    f4 = reader.ReadSingle();
                    f5 = reader.ReadSingle();
                    v = reader.ReadInt32();
                    i = reader.ReadInt32();

                    richTextBox1.AppendText((2004+(dt >> 11)).ToString()
                        + "-" + ((dt & 0x7ff) / 100).ToString() 
                        + "-" + ((dt & 0x7ff) % 100).ToString()
                        + " " + (hhmm/60).ToString()
                        + ":" + (hhmm%60).ToString()
                        + " " + f1.ToString("f3")
                        + " " + f2.ToString("f3")
                        + " " + f3.ToString("f3")
                        + " " + f4.ToString("f3")
                        + " " + v.ToString()
                        + " " + f5.ToString("f3")
                        + "\n");
                }
            }

        }
        // 
        private void loadbinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load 个股
            //loadBinA();
            //loadBinAmin2();

            //loadHisA();

            // load qiaolong wgt
            //loadBinQLwgt();
            loadListQLwgt();
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
