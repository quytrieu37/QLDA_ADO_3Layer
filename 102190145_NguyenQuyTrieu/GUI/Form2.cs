using _102190145_NguyenQuyTrieu.BLL;
using _102190145_NguyenQuyTrieu.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102190145_NguyenQuyTrieu.GUI
{
    public partial class Form2 : Form
    {
        public delegate void Mydel(string mssv);
        public Mydel d;
        public delegate void MydelLoad();
        public MydelLoad d1;
        public Form2()
        {
            InitializeComponent();
            SetCBB();
            d = new Mydel(SetGUI);
        }
        private void SetCBB()
        {
            foreach (LSH lsh in BLL_QLSV.Instance.GetAllLSH_BLL())
            {
                CBB.Items.Add(new LSH()
                {
                    ID_Lop = lsh.ID_Lop,
                    NameLop = lsh.NameLop
                });
            }
        }
        public void SetGUI(string MSSV)
        {
            SV s =BLL_QLSV.Instance.GetSVByMSSV(MSSV);
            txtMSSV.Text = s.MSSV;
            txtMSSV.Enabled = false;
            txtName.Text = s.NameSV;
            rbMale.Checked = s.Gender;
            rbFemale.Checked = !rbMale.Checked;
            dateTimePicker1.Value = s.NS;
            foreach(LSH lsh in CBB.Items)
            {
                if(lsh.ID_Lop == s.ID_Lop)
                {
                    CBB.SelectedItem = lsh;
                }    
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtMSSV.Text == "")
            {
                MessageBox.Show("nhập mssv");
                return;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("nhập Tên SV");
                return;
            }
            if (CBB.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn LSH");
                return;
            }
            if (rbMale.Checked == false && rbFemale.Checked == false)
            {
                MessageBox.Show("Chọn giới tính");
                return;
            }
            SV s = new SV()
            {
                MSSV = txtMSSV.Text,
                NameSV = txtName.Text,
                Gender = rbMale.Checked,
                NS = dateTimePicker1.Value,
                ID_Lop = ((LSH)CBB.SelectedItem).ID_Lop
            };
            BLL_QLSV.Instance.AddOrEditSV(s);
            d1();
            this.Dispose();
        }
    }
}
