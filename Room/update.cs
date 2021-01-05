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
    public partial class update : Form
    {
        string ID = "";
        public update()
        {
            InitializeComponent();
        }
        //构造方法
        public update(string id,string name,string sex,string collage,string classname,string room)
        {
            InitializeComponent();
            ID=textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = sex;
            textBox4.Text = collage;
            textBox5.Text = classname;
            textBox6.Text = room;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_student set id='{textBox1.Text}',name='{textBox2.Text}',sex='{textBox3.Text}',collage='{textBox4.Text}'," +
                $"classname='{textBox5.Text}',room='{textBox6.Text}' where id='{textBox1.Text}'";
            Dao dao = new Dao();
            if(dao.Execute(sql)>0)
            {   
                dao.Daoclose();
                MessageBox.Show("修改成功");
                this.Close();
            }

        }

        private void update_Load(object sender, EventArgs e)
        {

        }
    }
}
