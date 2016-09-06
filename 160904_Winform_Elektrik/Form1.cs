using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _160904_Winform_Elektrik
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program faturaları kabaca hesaplayabilmek için yapılmış bir programdır.", "Program Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

      

        private void hesaplaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hesapla hesapForm = new Hesapla();
            this.Hide();
            hesapForm.Show();
            hesapForm.FormClosed += hesapForm_FormClosed;
        }

        void hesapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void kayitlarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kayitlar kayitForm = new Kayitlar();
            this.Hide();
            kayitForm.Show();
            kayitForm.FormClosed+=kayitForm_FormClosed;
           
        }
        public void Dosyaya_yaz(ListView coming)
        {
            Directory.CreateDirectory("C:\\" + "Fatura");
            string dosyayolu = @"C:\Fatura\Liste.txt";

            FileStream fs = new FileStream(dosyayolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (ListViewItem temp in coming.Items)
            {
                sw.WriteLine(temp.SubItems[0].Text + "_" + temp.SubItems[1].Text + "_" + temp.SubItems[2].Text +
                "_" + temp.SubItems[3].Text + "_" + temp.SubItems[4].Text + "_" + temp.SubItems[5].Text + "_" + temp.SubItems[6].Text);
            }

            
            sw.Flush();
            sw.Close();
            fs.Close();
        }
        private void kayitForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Kayitlar a = (Kayitlar)sender;
            Dosyaya_yaz(a.listView1);
            this.Show();
        }

       
    }
}
