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
using SystemDataApp.DAL;
using static System.Convert;

namespace SystemDataApp.ModelStore
{
    public partial class FrmStore : FrmMaster
    {
        SystemDataDBContext db = new SystemDataDBContext();
        int code;
        public FrmStore()
        {
            InitializeComponent();
        }

        private void FrmStore_Load(object sender, EventArgs e)
        {
            GetData();
            btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnReload.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            cbBranch.Properties.DataSource = db.Branch.Select(x => new { x.Code, Name = x.NameAr }).ToList();
            cbBranch.EditValue = cbBranch.Properties.GetKeyValue(0);
            New();
        }
        public override void GetData()
        {
            dgv.DataSource =
                db.Store.Join(
                    db.Branch,
                    sto => sto.BranchCode,
                    br => br.Code,
                    (sto, br) => new
                    {
                        sto.Code,
                        sto.Name,
                        sto.BranchCode,
                        BranchName = br.NameAr,
                    }
                    ).ToList();


            base.GetData();
        }
        int maxCode()
        {
            int code = 0;
            try
            {
                code = db.Store.Max(x => x.Code);
            }
            catch (Exception)
            {
                return code;
            }
            return code;
        }
        public override void Save()
        {
            if (ADD)
            {
                // insert data
                Store store = new Store();
                store.Code = maxCode() + 1;
                store.Name = txtName.Text;
                store.BranchCode = ToInt32(cbBranch.EditValue);
                db.Add(store);
                db.SaveChanges();
            }
            else
            {
                // update data
                Store store = db.Store.Where(x => x.Code == code).FirstOrDefault();
                store.Name = txtName.Text;
                store.BranchCode = ToInt32(cbBranch.EditValue);
                db.SaveChanges();
            }
            New();
            base.Save();
        }
        public override void New()
        {
            txtCode.EditValue = maxCode() + 1;
            txtName.ResetText();
            txtName.Focus();
            base.New();
        }
        public override void Delete()
        {
            if (XtraMessageBox.Show("هل متأكد من الحذف", "الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                code = ToInt32(dgvList.GetFocusedRowCellValue(colCode));
                Store store = db.Store.Where(x => x.Code == code).FirstOrDefault();
                db.Store.Remove(store);
                db.SaveChanges();

                base.Delete();
            }


        }

        private void repoEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ADD = false;
            code = ToInt32(dgvList.GetFocusedRowCellValue(colCode));
            txtCode.EditValue = code;
            txtName.Text = dgvList.GetFocusedRowCellValue(colName).ToString();
            cbBranch.EditValue = ToInt32(dgvList.GetFocusedRowCellValue(colBranchCode));
        }
    }
}
