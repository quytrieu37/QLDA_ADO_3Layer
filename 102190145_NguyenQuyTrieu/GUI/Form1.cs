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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
            SetCBBSort();
        }
        private void SetCBB()
        {
            CBBLSH.Items.Add(new LSH()
            { 
                ID_Lop =0,
                NameLop = "All"
            });
            foreach(LSH lsh in BLL_QLSV.Instance.GetAllLSH_BLL())
            {
                CBBLSH.Items.Add(new LSH()
                {
                    ID_Lop = lsh.ID_Lop,
                    NameLop = lsh.NameLop
                });
            }
            CBBLSH.SelectedIndex = 0;
        }
        public void LoadData()
        {
            dataGridView1.DataSource = BLL_QLSV.Instance.GetListSV_BLL(((LSH)CBBLSH.SelectedItem).ID_Lop, txtSeach.Text);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtSeach_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.d1 = new Form2.MydelLoad(LoadData);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                Form2 f = new Form2();
                f.d1 = new Form2.MydelLoad(LoadData);
                f.d(dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString());
                f.Show();
            }
            else
            {
                MessageBox.Show("Chọn sinh viên cần Edit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BLL_QLSV.Instance.DeleteSV(dataGridView1.CurrentRow.Cells["MSSV"].Value.ToString());
            MessageBox.Show("Đã xóa sinh viên " + dataGridView1.CurrentRow.Cells["NameSV"].Value.ToString());
        }
        public void SetCBBSort()
        {
            CBBSortCBB.Items.AddRange(new string[]
                {
                "1 : Tuổi giảm",
                "2 : Tuổi Tăng",
                "3 : Tên SV A-Z",
                "4 : Tên SV Z-A"
                });
        }

        private void CBBSortCBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SV> list = BLL_QLSV.Instance.GetListSV_BLL(((LSH)CBBLSH.SelectedItem).ID_Lop, txtSeach.Text);
            switch (CBBSortCBB.SelectedIndex)
            {
                case 0:
                    BLL_QLSV.Instance.Sort(list, SV.ASCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 1:
                    BLL_QLSV.Instance.Sort(list, SV.DESCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 2:
                    BLL_QLSV.Instance.Sort(list, SV.ASCNameSV);
                    dataGridView1.DataSource = list;
                    break;
                case 3:
                    BLL_QLSV.Instance.Sort(list, SV.DESCTenSV);
                    dataGridView1.DataSource = list;
                    break;
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<SV> list = BLL_QLSV.Instance.GetListSV_BLL(((LSH)CBBLSH.SelectedItem).ID_Lop, txtSeach.Text);
            switch (CBBSortCBB.SelectedIndex)
            {
                case 0:
                    BLL_QLSV.Instance.Sort(list, SV.ASCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 1:
                    BLL_QLSV.Instance.Sort(list, SV.DESCNS);
                    dataGridView1.DataSource = list;
                    break;
                case 2:
                    BLL_QLSV.Instance.Sort(list, SV.ASCNameSV);
                    dataGridView1.DataSource = list;
                    break;
                case 3:
                    BLL_QLSV.Instance.Sort(list, SV.DESCTenSV);
                    dataGridView1.DataSource = list;
                    break;
            }
        }
    }
}
