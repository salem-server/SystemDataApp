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
    public partial class FrmBranch : FrmMaster
    {
        SystemDataDBContext db = new SystemDataDBContext();
        int code;
        public FrmBranch()
        {
            InitializeComponent();

        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {
            GetData();
            btnNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnReload.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        int maxCode()
        {
            int code = 0;
            try
            {
                code = db.Branch.Max(x => x.Code);
            }
            catch (Exception)
            {
                return code;
            }
            return code;

        }
        public override void New()
        {
            txtCode.EditValue = maxCode() + 1;
            txtNameAr.ResetText();
            txtNameEn.ResetText();
            txtNameAr.Focus();
            ADD = true;
            base.New();
        }
        public override void GetData()
        {
            dgv.DataSource = db.Branch
                .Select(x => new { x.Code, x.NameAr, x.NameEn })
                .ToList();
            base.GetData();
        }
        public override void Save()
        {
            if (txtNameAr.Text == string.Empty.Trim())
            {
                txtNameAr.ErrorText = "ادخل الاسم بالعربية";
                txtNameAr.Focus();
                return;
            }
            if (txtNameEn.Text == string.Empty.Trim())
            {
                txtNameEn.ErrorText = "ادخل الاسم بالانجليزية";
                txtNameEn.Focus();
                return;
            }
            if (ADD)
            {
                // insert data
                Branch branch = new Branch();
                branch.Code = ToInt32(txtCode.Text);
                branch.NameAr = txtNameAr.Text;
                branch.NameEn = txtNameEn.Text;
                db.Add(branch);
                db.SaveChanges();
            }
            else
            {
                // update data
                Branch branch = db.Branch.Where(x => x.Code == code).FirstOrDefault();
                branch.NameAr = txtNameAr.Text;
                branch.NameEn = txtNameEn.Text;
                db.SaveChanges();
            }
            New();
            base.Save();
        }
        public override void Delete()
        {
            if (XtraMessageBox.Show("هل متأكد من الحذف", "الحذف",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                code = ToInt32(dgvList.GetFocusedRowCellValue(colCode));
                Branch branch = db.Branch.Where(x => x.Code == code).FirstOrDefault();
                db.Branch.Remove(branch);
                db.SaveChanges();

                base.Delete();
            }


        }

        private void repoEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            code = ToInt32(dgvList.GetFocusedRowCellValue(colCode));
            txtCode.EditValue = code;
            txtNameAr.Text = dgvList.GetFocusedRowCellValue(colNameAr).ToString();
            txtNameEn.Text = dgvList.GetFocusedRowCellValue(colNameEn).ToString();
            txtNameAr.Focus();
            txtNameAr.SelectAll();
            ADD = false;
        }

        private void txtNameAr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNameEn.Focus();
                txtNameEn.SelectAll();
            }
        }

        private void txtNameEn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }
    }
}
