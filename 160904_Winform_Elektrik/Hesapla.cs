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
    public partial class Hesapla : Form
    {
        
        string[] Unit = new string[4] { "0", "0", "0", "0"};
        public Hesapla()
        {
            InitializeComponent();
            lblState.Text = "Fatura Türü Seçerek Başlayınız.";
            string YOL = @"C:\Fatura\Deger.txt";
          
            if (!File.Exists(YOL))
            {
                dosyaya_yaz();
            }
           
            dosya();
        }

        private void dosyaya_yaz()
        {
               
            Directory.CreateDirectory("C:\\" + "Fatura");
            string dosyayolu = @"C:\Fatura\Deger.txt";

            FileStream fs = new FileStream(dosyayolu, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var item in Unit)
            {
                sw.WriteLine(item);
            }

            sw.Close();
            fs.Close();
        }

        private void dosya()
        {
            string YOL = @"C:\Fatura\Deger.txt";
            if (File.Exists(YOL))
            {
                FileStream fs = new FileStream(YOL, FileMode.Open, FileAccess.Read);
                StreamReader sw = new StreamReader(fs);
                string yazi;
                yazi = sw.ReadLine();
                int a = 0;
                while (yazi != null)
                {
                    Unit[a]=(yazi);
                    yazi = sw.ReadLine();
                    a++;
                }
                sw.Close();
                fs.Close();
            }
        }

        private void değiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nmrcUnit.ResetText();
            nmrcUnit.ReadOnly = false;
            nmrcUnit.Focus();
            lblState.Text = "Lütfen değeri değiştiriniz.";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboTur.SelectedIndex = -1;
            nmrcStart.ResetText();
            nmrcEnd.ResetText();
            btnSave.Enabled = true;
            lblState.Text = "Fatura Türü Seçerek Başlayınız.";
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            lblTotal.Text = decimal.Round((nmrcEnd.Value - nmrcStart.Value) * nmrcUnit.Value, 2).ToString();
            lblConsume.Text = decimal.Round(nmrcEnd.Value - nmrcStart.Value, 2).ToString();
            lblState.Text = "Değerler Hesaplandı.";
            Unit[comboTur.SelectedIndex] = nmrcUnit.Value.ToString();
            dosyaya_yaz();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\" + "Fatura");
            string dosyayolu = @"C:\Fatura\Liste.txt";
         
            FileStream fs = new FileStream(dosyayolu, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            _160904_Winform_Elektrik.kayit temp = new _160904_Winform_Elektrik.kayit(comboTur.Text, date.Value, (float)(nmrcStart.Value),
                (float)nmrcEnd.Value, (float)nmrcUnit.Value);
            sw.WriteLine(temp.LSTITEM.SubItems[0].Text +"_"+temp.LSTITEM.SubItems[1].Text+"_"+temp.LSTITEM.SubItems[2].Text+
                "_" + temp.LSTITEM.SubItems[3].Text + "_" + temp.LSTITEM.SubItems[4].Text + "_" + temp.LSTITEM.SubItems[5].Text + "_" + temp.LSTITEM.SubItems[6].Text);       
            sw.Flush();
            sw.Close();
            fs.Close();
            btnSave.Enabled = false;
            lblState.Text = "Başarılı Bir Şekilde Kaydedildi.";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            lblState.Text="";
        }

        private void comboTur_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboTur.SelectedIndex)
            {
                case 0://Doğalgaz
                    nmrcUnit.Value = Convert.ToDecimal(Unit[0]);//Buraya Değer girilecek
                    pictureBox1.Image = Properties.Resources.koffing;
                    break;
                case 1://Elektrik
                    nmrcUnit.Value =  Convert.ToDecimal(Unit[1]);//Buraya Değer girilecek
                    pictureBox1.Image = Properties.Resources.pikachu;
                    break;
                case 2://İnternet
                    nmrcUnit.Value =  Convert.ToDecimal(Unit[2]);//Buraya Değer girilecek
                    pictureBox1.Image = Properties.Resources.internet;
                    break;
                case 3://Su
                    nmrcUnit.Value =  Convert.ToDecimal(Unit[3]);//Buraya Değer girilecek
                    pictureBox1.Image = Properties.Resources.squirtle;
                    break;

                default:
                    break;
            }
            btnSave.Enabled = true;
            lblState.Text = "Değerleri Seçiniz.";
          
        }

        private void nmrcStart_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = decimal.Round((nmrcEnd.Value - nmrcStart.Value) * nmrcUnit.Value,2).ToString();
           lblConsume.Text= decimal.Round(nmrcEnd.Value - nmrcStart.Value,2).ToString();
           btnSave.Enabled = true;

        }

        private void nmrcUnit_ValueChanged(object sender, EventArgs e)
        {
            nmrcUnit.ReadOnly = true;
            nmrcStart.Focus();
            lblState.Text = "Birim Fiyat ile Değiştirildi.";
        }
        
    }
}
