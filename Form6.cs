using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        //判断号码输入正误
        public bool yz(String d)
        {
            try
            {
                int b = int.Parse(d);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection link;
        string guanliyuan = Form2.guanliyuan; 
        private void Form6_Load(object sender, EventArgs e)
        {
            string conn = "server=.;database=yikatong;Integrated security=true";

            link = new SqlConnection(conn);

            link.Open();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || maskedTextBox3.Text == "" || maskedTextBox4.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("请完全信息");
            }
            else
            {

                string kahao = maskedTextBox1.Text;

                string name = maskedTextBox2.Text;

                string sex = comboBox1.Text;

                string age = maskedTextBox3.Text;

                int money = int.Parse(maskedTextBox4.Text);
                //系统时间
                DateTime dt = System.DateTime.Now;


                if (yz(kahao))
                {



                    //     添加数据到数据库                                               
                    string sql = string.Format("insert into xinxibiao values({0},'{1}','{2}',{3},{4},'{5}')", kahao, name, sex, age, money, dt);
                    SqlCommand cmd = new SqlCommand(sql, link);
                    string a = "用户" + name + " 卡号:" + kahao + "在开通账号时充值" + money + "元";
                    string sqa = string.Format("insert into jilu values({0},'{1}','{2}','{3}',{4})", kahao, a, dt, guanliyuan, money);
                    //判断是否存在用户
                    string sqlse = "select count(*) from xinxibiao where kahao='" + maskedTextBox1.Text + "'";
                    SqlCommand abcde = new SqlCommand(sqlse, link);
                    int abcd = (int)abcde.ExecuteScalar();
                    if (abcd > 0)
                    {
                        MessageBox.Show("用户已存在");
                    }
                    else if (money < 100)
                    {
                        MessageBox.Show("初始金额不能低于100");
                    }
                    else
                    {

                        SqlCommand abc = new SqlCommand(sqa, link);
                        //判断是否成功
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("添加成功");
                            maskedTextBox1.Text = "";
                            maskedTextBox2.Text = "";
                            maskedTextBox3.Text = "";
                            maskedTextBox4.Text = "";
                            comboBox1.Text = "";

                        }
                        if (abc.ExecuteNonQuery() > 0)
                        {

                        }






                        else
                        {
                            MessageBox.Show("请输入正确卡号");
                        }




                    }

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox5.Text=="")
            {
                MessageBox.Show("请输入查询数据");
            }
            else
            {
                DataSet ds = new DataSet();
                string conn = "server=.;database=yikatong;integrated security=true";
                string tiaojian = maskedTextBox5.Text;
                string sqa = string.Format("select * from xinxibiao stu where name like '%{0}%' ", tiaojian);

                SqlDataAdapter dap = new SqlDataAdapter(sqa, conn);
                dap.Fill(ds);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = ds.Tables[0];

            }
            
        }

        private void 浅色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.GreenYellow;
        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
                           
        }

        private void maskedTextBox4_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
