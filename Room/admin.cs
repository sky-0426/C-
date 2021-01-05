using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void 学生宿舍管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //页面跳转
            admin1 ad1 = new admin1();
            ad1.ShowDialog();
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }
    }
}
