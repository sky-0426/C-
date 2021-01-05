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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "")
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id='{textBox1.Text}' and psw='{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登陆成功");
                    dao.Daoclose();
                    admin ad = new admin();
                    this.Hide();
                    ad.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("登录失败");
                    dao.Daoclose();

                }
            }
            else
            {
                MessageBox.Show("输入项有空，请重新输入");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
