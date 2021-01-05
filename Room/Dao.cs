using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    class Dao
    {
        SqlConnection sc;
        //数据库的连接
        public SqlConnection connect()
        {
            //数据库连接字符串 
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\19472\Desktop\Room\roomdb.mdf;Integrated Security=True";
            //创建数据库连接对象
            sc = new SqlConnection(str);
            //打开数据库
            sc.Open();
            //返回数据库连接对象
            return sc;
        }
        public SqlCommand command(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }
        //更新
        public int Execute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }
        //读取
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
        //关闭数据库
        public void Daoclose()
        {
            //关闭数据库连接
            sc.Close();
        }
    }
}
