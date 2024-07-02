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

namespace SystemDataApp
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        SystemDataDBContext db = new SystemDataDBContext();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = db.Users.Where(x=>x.UserName==txtUserName.Text 
                                        && x.Password==txtPassword.Text
                                        && x.BranchCode==ToInt32( cbBranch.EditValue))
                                .FirstOrDefault();
            if (user != null)
            {
                Sett.MsgGreen(user.FullName, "مرحباً بك");
                Close();
            }
            else
            {
                Sett.MsgRed("خطأ", "اسم المستخدم او كلمة المرور غير صحيحة");
                txtUserName.Focus();
                txtUserName.SelectAll();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            cbBranch.Properties.DataSource = db.Branch.ToList();
            cbBranch.EditValue = cbBranch.Properties.GetKeyValue(0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbBranch.Focus();
            }
        }

        private void cbBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
            }
        }
    }
}