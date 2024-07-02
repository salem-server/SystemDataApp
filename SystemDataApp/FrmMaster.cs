using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemDataApp
{
    public partial class FrmMaster : DevExpress.XtraEditors.XtraUserControl
    {
       public bool ADD = true;
        public FrmMaster()
        {
            InitializeComponent();
        }

        public virtual void New()
        {

        }
        public virtual void GetData()
        {

        }
        public virtual void Save()
        {
            if (ADD)
            {
                // Insert Data
                Sett.MsgGreen("الاضافة", "تمت الاضافة بنجاح");
            }
            else
            {
                // Update Data
                Sett.MsgBlue("التحديث", "تم التحديث بنجاح");
            }
            GetData();
        }
        public virtual void Print()
        {

        }
        public virtual void Delete()
        {
            Sett.MsgRed("الحذف", "تم الحذف بنجاح");
            GetData();
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            New();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Print();
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetData();
        }
    }
}
