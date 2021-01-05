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
    public partial class admin1 : Form
    {
        public admin1()
        {
            InitializeComponent();
        }

        private void admin1_Load(object sender, EventArgs e)
        {
            Table();
            //默认选中第一行
            label3.Text = $"{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}  {dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}";
        }

        //从数据库读取数据写到表格中
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空旧的数据
            Dao dao = new Dao();
            string sql = "select * from t_student";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());

            }
            dc.Close();
            dao.Daoclose();
        }

        //根据学号显示信息
        public void Table_id()
        {
            dataGridView1.Rows.Clear();//清空旧的数据
            Dao dao = new Dao();
            string sql = $"select * from t_student where id='{textBox2.Text}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());

            }
            dc.Close();
            dao.Daoclose();
        }
        //根据宿舍号显示信息
        public void Table_room()
        {
            dataGridView1.Rows.Clear();//清空旧的数据
            Dao dao = new Dao();
            string sql = $"select * from t_student where room like '%{textBox1.Text}%'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString(), dc[5].ToString());

            }
            dc.Close();
            dao.Daoclose();
        }

        //删除逻辑
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //获取学号
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                //label3显示
                label3.Text= id+dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                //提示框
                DialogResult dr = MessageBox.Show("是否确认删除", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(dr==DialogResult.OK)
                {
                    //sql语句
                    string sql = $"delete from t_student where id='{id}'";
                    Dao dao = new Dao();
                    if(dao.Execute(sql)>0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败" + sql);
                    }
                    dao.Daoclose();
                }

            }
            catch 
            {
                MessageBox.Show("在表格中选中要删除的信息", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //表格的单击事件
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //单击后显示选中的信息
            label3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }


        //添加stu
        private void button1_Click(object sender, EventArgs e)
        {
            add ad = new add();
            ad.ShowDialog();
        }

        //update
        private void button2_Click(object sender, EventArgs e)
        {

                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string sex = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string collage = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string classname = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string room = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                update up = new update(id, name, sex, collage, classname, room);
                up.ShowDialog();
                //刷新数据
                

        }

        //宿舍号查询
        private void button5_Click(object sender, EventArgs e)
        {
            Table_room();
        }

        //学号查询
        private void button6_Click(object sender, EventArgs e)
        {
            Table_id();
        }

        //刷新
        private void button4_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
