using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SystemDataApp.ModelStore;

namespace SystemDataApp
{
    public partial class FrmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            new FrmLogin().ShowDialog();
        }

        void setTabPage(UserControl formObject, string formText, Image image)
        {
            foreach (var item in xtraTabControl1.TabPages.ToList())
            {
                if (item.Text == formText)
                {
                    xtraTabControl1.SelectedTabPage = item;
                    return;
                }
            }
            xtraTabControl1.TabPages.Add(formText);
            formObject.Dock = DockStyle.Fill;
            var tc = xtraTabControl1.TabPages.Last();
            tc.Controls.Add(formObject);
            xtraTabControl1.SelectedTabPage = tc;
            xtraTabControl1.SelectedTabPage.ImageOptions.Image = image;

        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage != xtraTabControl1.TabPages[0])
            {
                xtraTabControl1.TabPages.Remove(xtraTabControl1.SelectedTabPage);
                xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages.Last();
            }
            else
            {
                // msg

            }
        }

        private void btnBranch_Click(object sender, EventArgs e)
        {
            FrmBranch frm = new FrmBranch();
            setTabPage(frm, btnBranch.Text, btnBranch.Image);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            FrmStore frm = new FrmStore();
            setTabPage(frm, btnStore.Text, btnStore.Image);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new FrmLogin().ShowDialog();
        }

    }
}
