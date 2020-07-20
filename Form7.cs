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
    public partial class Form7 : Form
    {
        
        //判断号码输入正误
        public bool yz(String a)
        {
            try
            {
                int b = int.Parse(a);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button2.Text;
            }
            else
            {
                comboBox2.Text = button2.Text;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button3.Text;
            }
            else
            {
                comboBox2.Text = button3.Text;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button4.Text;
            }
            else
            {
                comboBox2.Text = button4.Text;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button5.Text;
            }
            else
            {
                comboBox2.Text = button5.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button6.Text;
            }
            else
            {
                comboBox2.Text = button6.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button7.Text;
            }
            else
            {
                comboBox2.Text = button7.Text;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button8.Text;
            }
            else
            {
                comboBox2.Text = button8.Text;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button9.Text;
            }
            else
            {
                comboBox2.Text = button9.Text;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = button11.Text;
            }
            else
            {
                comboBox2.Text = button11.Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string a;
        private void button10_Click(object sender, EventArgs e)
        {
            a=textBox1.Text;
            if (a=="")
	{
		 MessageBox.Show("请先输入卡号");
	}
            else if (yz(a))
	{
	        	 string conn = "server=.;database=yikatong;Integrated Security=true";
                SqlConnection link = new SqlConnection(conn);
                link.Open();
                string fz = "select  name,sex ,age  from xinxibiao where kahao='" + a + "'";
             SqlCommand wc=new SqlCommand(fz,link);
                SqlDataReader read=wc.ExecuteReader();
                        while (read.Read())
                   {
                      name.Text = read["name"].ToString();
                     sex.Text = read["sex"].ToString();
                       age.Text = read["age"].ToString();
                    }
              link.Close();

        }
          
         

       

               
                   
            
            else{
                MessageBox.Show("请输入正确卡号");
                 }
                      
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!=""&&comboBox2.Text!="")
            {
                int i = comboBox1.SelectedIndex;
                int j = comboBox2.SelectedIndex;
                if (comboBox1.Text!=comboBox2.Text)
                {
                    if (j != 8)
                    {
                        int sum = (j + 1 - i) * 2;
                        sum = Math.Abs(sum);
                        textBox7.Text = sum.ToString();
                    }
                    if (j == 8)
                    {
                        j = 0;
                        int sum = (j - i) * 2;
                        sum = Math.Abs(sum);
                        textBox7.Text = sum.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("选择无效");
                    textBox7.Text = "";
                }
               

            }
            else
            {
                MessageBox.Show("请选择站点");
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (name.Text == "")
            {
                MessageBox.Show("请先查询卡号");
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("请选择站点");
            }
           
            else
            {
                string kahao = textBox1.Text;
                //string jine = text_zhifjine.Text;
                string jinzhan = comboBox1.Text;
                string chuzhan = comboBox2.Text;
                int caozuojine = int.Parse(textBox7.Text);
                string guanliyuan = Form2.guanliyuan;
                DateTime dt = System.DateTime.Now;
                //查询可用余额
                string sqlstrs = "select money from xinxibiao where kahao="+kahao+" ";
                SqlDataReader read = lianjie.getSql(sqlstrs);
                int mom=0;
                while (read.Read())
                {
                     mom= (int)read["money"];

                }
                lianjie.link.Close();

                if (mom>=caozuojine)
                {
                         string sqlstr = string.Format("update  xinxibiao set money=money-{0}", caozuojine);

                string xx = "用户" + name.Text + "卡号" + kahao + "在" + jinzhan + "上车," + chuzhan + "下车,消费" + caozuojine + "元";
                string sqls = string.Format("insert into jilu values({0},'{1}','{2}','{3}',-{4})", kahao, xx, dt, guanliyuan, caozuojine);
                lianjie.setSql(sqls);

                if (lianjie.setSql(sqlstr))
                {
                    MessageBox.Show("支付成功！");

                }
                }
                else
                {
                    MessageBox.Show("余额不足，请充值 ");
                }

           
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.name.Clear();
            this.sex.Text="";
            this.age.Clear();
            this.comboBox1.Text = "";
            this.comboBox2.Text = "";
            this.textBox7.Clear();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Parent = dataGridView1;
           
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void age_TextChanged(object sender, EventArgs e)
        {

        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
