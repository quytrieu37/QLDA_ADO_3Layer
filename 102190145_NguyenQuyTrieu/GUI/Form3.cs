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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(lgt1.User + ", " + lgt1.Passwork);
            lgt1.User = "hi";
            lgt1.Passwork = "áhi";
        }
    }
}
