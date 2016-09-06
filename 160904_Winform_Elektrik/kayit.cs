using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _160904_Winform_Elektrik
{
   public class kayit
    {
       private string strName;
       private float flStart;
       private float flEnd;
       private float flUnit;
       private DateTime zaman;
       private System.Windows.Forms.ListViewItem lstItem;

        public string STRNAME { get { return strName; } set { this.strName = value; } }
        public DateTime ZAMAN { get { return zaman; } set { this.zaman = value; } }
        public float FLSTART { get { return flStart; } set { this.flStart = value; } }
        public float FLEND { get { return flEnd; } set { this.flEnd = value; } }
        public float FLCONSUME { get{ return FLEND-FLSTART;  } }
        public float FLUNIT { get { return flUnit; } set { this.flUnit = value; } }
        public float FLTOTAL { get{return flUnit*FLCONSUME; } }
        public kayit(string _name,DateTime _zaman,float _start,float _end,float _flunit)
        {
            STRNAME = _name;
            ZAMAN = _zaman;
            FLSTART = _start;
            FLEND = _end;
            FLUNIT = _flunit;
            lstItem = new System.Windows.Forms.ListViewItem();
            lstItem.Text = STRNAME;
            lstItem.SubItems.Add(zaman.ToString());
            lstItem.SubItems.Add(flStart.ToString());
            lstItem.SubItems.Add(flEnd.ToString());
            lstItem.SubItems.Add(FLCONSUME.ToString());
            lstItem.SubItems.Add(flUnit.ToString());
            lstItem.SubItems.Add(FLTOTAL.ToString());
        }

       
        public System.Windows.Forms.ListViewItem LSTITEM 
        {
            get 
            {
             
                return lstItem; 
               
            }  
        }
    }
}
