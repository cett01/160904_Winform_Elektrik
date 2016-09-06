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
    public partial class Kayitlar : Form
    {
        public Kayitlar()
        {

            InitializeComponent();
            dosyadanoku();

        }
          public  void dosyadanoku(){
              string YOL = @"C:\Fatura\Liste.txt";
             if(File.Exists(YOL)){
                FileStream fs = new FileStream(YOL, FileMode.Open, FileAccess.Read);
                 StreamReader sw = new StreamReader(fs);
                 string yazi;
                  yazi=sw.ReadLine();
                  while (yazi != null)
                  {
                   string []line= yazi.Split('_');// _name _zaman_start _end consume _flunit total
                    ListViewItem temp=new ListViewItem();
                      temp.Text=line[0];//name
                      temp.SubItems.Add(line[1]);//zaman
                      temp.SubItems.Add(line[2]);//start
                      temp.SubItems.Add(line[3]);//end
                      temp.SubItems.Add(line[4]);//consume
                      temp.SubItems.Add(line[5]);//Unit
                      temp.SubItems.Add(line[6]);//total
                      listView1.Items.Add(temp);

                      yazi = sw.ReadLine();
                  }
                  
               sw.Close();
               fs.Close();
             }
            
       }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if ( listView1.SelectedItems[0]!=null)
            {
                listView1.SelectedItems[0].Remove();
            }
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btnSil.Enabled = false;
        }
       
    }
}
