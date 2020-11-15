using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicFunction;
using System.Collections;
using System.Data.SqlClient;
using System.CodeDom;
using System.Collections;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Net.PeerToPeer.Collaboration;

namespace StudentManagementSystemDesktop
{
    public partial class Form1 : Form
    {
        ArrayList list;
        private int quotecount;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "Xu9UnkZZhf77zM38wNcI8JiQO1Fq9TTQGcXXvhhe",
            BasePath = "https://bright-student-portal.firebaseio.com/"
        };
        IFirebaseClient client;

        

        Function f;
        ArrayList listquote;

        SqlConnection con;
        String query;
        SqlCommand cmd;
        ArrayList listAdminNamePass;
        Boolean connect = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void quoteadd()
        {
            listquote = new ArrayList();
            listquote.Clear();
            listquote.Add("Believe you can and you’re halfway there.");
            listquote.Add("It always seems impossible until it’s done.");
            listquote.Add(" Start where you are. Use what you have. Do what you can. ");
            listquote.Add("The secret of success is to do the common things uncommonly well.");
            listquote.Add("Strive for progress, not perfection.");
            listquote.Add(" The secret to getting ahead is getting started.");
            listquote.Add("You don’t have to be great to start, but you have to start to be great.");
            listquote.Add("The expert in everything was once a beginner.");
            listquote.Add("There are no shortcuts to any place worth going.");
            listquote.Add("Push yourself, because no one else is going to do it for you.");
            listquote.Add("You don’t always get what you wish for; you get what you work for.");
            listquote.Add("The only place where success comes before work is in the dictionary.");
            listquote.Add("If it’s important to you, you’ll find a way. If not, you’ll find an excuse.");
            listquote.Add(" Life has two rules: 1) Never quit. 2) Always remember Rule #1.");
            listquote.Add(" If you’re going through hell, keep going.");
            listquote.Add("Failure is the opportunity to begin again more intelligently.");
            listquote.Add("Don't wish for it.Work for it.");
        }
        private void fetchclassbatch()
        {
            try
            {
                query = "select namee from class";
                cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        this.stlistclass.Items.Add(reader.GetValue(0));
                    }
                }
                con.Close();

                query = "select namee from batch";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            this.stlistbatch.Items.Add(reader.GetValue(0));
                        }
                    }
                }
                catch
                {
                    con.Close();
                }
                con.Close();
            }
            catch
            {
                
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            
            this.quoteadd();
            try
            {
                client = new FireSharp.FirebaseClient(config);
                connect = true;
            }
            catch
            {
                MessageBox.Show("Internet Error");
                connect = false;
            }
            String conString = "Data Source=SOHAIL-AMJAD-LA;Initial Catalog=studentManagementSystemDesktop;Integrated Security=True";
            con = new SqlConnection(conString);
            listAdminNamePass = new ArrayList();
            query = "select username,pasword from adminSystem";
            cmd = new SqlCommand(query, con);
            con.Open();
            using(SqlDataReader reader=cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    listAdminNamePass.Add(reader.GetValue(0));
                    listAdminNamePass.Add(reader.GetValue(1));
                }
            }
            con.Close();
            this.fetchclassbatch();
            this.timer1.Enabled = true;
        }

        private void usernameadminTXT_Enter(object sender, EventArgs e)
        {
            if (this.usernameadminTXT.Text.Equals("User Name"))
            {
                this.usernameadminTXT.Text = "";
                this.usernameadminTXT.ForeColor = Color.Black;
            }
        }

        private void usernameadminTXT_Leave(object sender, EventArgs e)
        {
            if (this.usernameadminTXT.Text == String.Empty || this.usernameadminTXT.Text.Equals("User Name"))
            {
                this.usernameadminTXT.Text = "User Name";
                this.usernameadminTXT.ForeColor = Color.DarkGray;
            }
        }

        private void userpassadminTXT_Enter(object sender, EventArgs e)
        {
            if (this.userpassadminTXT.Text.Equals("Password"))
            {
                this.userpassadminTXT.Text = "";
                this.userpassadminTXT.ForeColor = Color.Black;
            }
        }

        private void userpassadminTXT_Leave(object sender, EventArgs e)
        {
            if (this.userpassadminTXT.Text == String.Empty || this.userpassadminTXT.Text.Equals("Password"))
            {
                this.userpassadminTXT.Text = "Password";
                this.userpassadminTXT.ForeColor = Color.DarkGray;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            f = new Function();
            String username = this.usernameadminTXT.Text;
            String password = this.userpassadminTXT.Text;
            if(f.login(listAdminNamePass,username,password))
            {
                admin fm = new admin(this);
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
        private int i = 0;
        private bool j = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i=i+1;
            //if(tim)
            //{
            //    this.label2.ForeColor = Color.Aqua;
            //    this.label2.BackColor = Color.Blue;

            //    tim = false;
            //}
            //else
            //{
            //    this.label2.ForeColor = Color.Blue;
            //    this.label2.BackColor = Color.Aqua;
            //    tim = true;
            //}

            this.movelogin();
        }
        //380, 230
        //380, 170
        private void movelogin()
        {
            i++;
            if(j)
            {
                this.parrot2.Location = new Point(380, 80 + i * 2);
                this.balladmin.Location = new Point(20, 200-i*2);
                this.label2.ForeColor = Color.Aqua;
                this.label2.BackColor = Color.Blue;
                this.label2.Location = new Point(i * 2 + 130, 25);
                this.stlgnnum.Location = new Point(95+i,63-i);
                this.stlognlst.Location = new Point(101+i*2, 3+i);
                this.labelteacher.Location = new Point(45+i*3, 20);
                if (i>60)
                {
                    j = false; i = 0;
                    this.openclosebook();
                }
                
            }
            else
            {
                this.parrot2.Location = new Point(380, 200 - i * 2);
                this.balladmin.Location = new Point(20, 80+i*2);
                this.label2.ForeColor = Color.Blue;
                this.label2.BackColor = Color.Aqua;
                this.label2.Location = new Point(270- i*2, 25);
                this.stlgnnum.Location = new Point(186-i,i);
                this.stlognlst.Location = new Point(234-i*2, 62-i);
                this.labelteacher.Location = new Point(245-i*3, 30);
                if (i>60)
                {
                    j = true; i = 0;
                }
                
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void firebaselogin_Click(object sender, EventArgs e)
        {
            String username = this.usernameadminTXT.Text;
            String Password = this.userpassadminTXT.Text;
            String city = "";
            String type = "";
            String name = "";
            int k = 0;
            for(int i=0;i<username.Length;i++)
            {
                if(username[i].Equals('/'))
                {
                    k++;
                }
                else if(k==0)
                {
                    city = city + username[i];
                }
                else if(k==1)
                {
                    type = type + username[i];
                }
                else if(k==2)
                {
                    name = name + username[i];
                }
            }
            if(name.Equals("")||city.Equals("")||type.Equals("")||Password.Equals("Password"))
            {
                MessageBox.Show("Please Enter Correct Data");
            }
            else
            {

            }
            help gett = new help()
            {
                name = "a",
                password="azazazazazazazazazaz"
                
            };
            try
            {
                var get = client.Get(@"portal/" + city + "/" + type);
                gett = get.ResultAs<help>();
                String newname = Convert.ToString(gett.name);
                String newpass = Convert.ToString(gett.password);
                if (name.Equals(newname))
                {
                    if (Password.Equals(newpass))
                    {
                        MessageBox.Show("Login SuccessFully");
                        admin fm = new admin(this);
                        fm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password");
                    }
                }
                else
                {
                    MessageBox.Show("User Not Exist");
                }
            }
            catch
            {
                MessageBox.Show("Please Enter Correct Data");
            }
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private int p = 0;
        private bool q = true;
        private void timer2_Tick(object sender, EventArgs e)
        {
            p = p + 1;
            this.move2();
        }
        private int quote = -1;
        private void move2()
        {
            p++;
            if (q)
            {
                this.teacherlogo.Location = new Point(310+p, 158);
                if (p > 50)
                {
                    q = false; p = 0;
                    this.setquote();
                }

            }
            else
            {
                this.teacherlogo.Location = new Point(360-p, 158);
                if (p > 50)
                {
                    q = true; p = 0;
                    this.setquote();
                }

            }
            
        }
        private Boolean openbookk=true;
        private void openclosebook()
        {
            if(openbookk)
            {
                closebook.Hide();
                openbook.Show();
                openbookk = false;
            }
            else
            {
                openbook.Hide();
                closebook.Show();
                openbookk = true;
            }
        }
        private void setquote()
        {
            quote++;
            if (quote == listquote.Count)
            {
                quote = 0;
            }
            this.stlistquote.Text = listquote[quote].ToString();
            this.strollquote.Text = listquote[quote].ToString();
        }

        private void stlistroll_Enter(object sender, EventArgs e)
        {
            if(this.stlistroll.Text.Equals("000"))
            {
                this.stlistroll.Text = "";
                this.stlistroll.ForeColor = Color.Black;
            }
        }

        private void stlistroll_Leave(object sender, EventArgs e)
        {
            if(this.stlistroll.Text==String.Empty||this.stlistroll.Text.Equals("000"))
            {
                this.stlistroll.Text = "000";
                this.stlistroll.ForeColor = Color.DarkGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (this.stlistpass.Text.Equals("Password"))
            {
                this.stlistpass.Text = "";
                this.stlistpass.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.stlistpass.Text == String.Empty || this.stlistpass.Text.Equals("Password"))
            {
                this.stlistpass.Text = "Password";
                this.stlistpass.ForeColor = Color.DarkGray;
            }
        }

        private void stusername_Enter(object sender, EventArgs e)
        {
            if (this.stusername.Text.Equals("User Name"))
            {
                this.stusername.Text = "";
                this.stusername.ForeColor = Color.Black;
            }
        }

        private void stusername_Leave(object sender, EventArgs e)
        {
            if (this.stusername.Text == String.Empty || this.stusername.Text.Equals("User Name"))
            {
                this.stusername.Text = "User Name";
                this.stusername.ForeColor = Color.DarkGray;
            }
        }

        private void stpassword_Enter(object sender, EventArgs e)
        {
            if (this.stpassword.Text.Equals("Password"))
            {
                this.stpassword.Text = "";
                this.stpassword.ForeColor = Color.Black;
            }
        }

        private void stpassword_Leave(object sender, EventArgs e)
        {
            if (this.stpassword.Text == String.Empty || this.stpassword.Text.Equals("Password"))
            {
                this.stpassword.Text = "Password";
                this.stpassword.ForeColor = Color.DarkGray;
            }
        }

        private void tsusername_Enter(object sender, EventArgs e)
        {
            if (this.tsusername.Text.Equals("User Name"))
            {
                this.tsusername.Text = "";
                this.tsusername.ForeColor = Color.Black;
            }
        }

        private void tsusername_Leave(object sender, EventArgs e)
        {
            if (this.tsusername.Text == String.Empty || this.tsusername.Text.Equals("User Name"))
            {
                this.tsusername.Text = "User Name";
                this.tsusername.ForeColor = Color.DarkGray;
            }
        }

        private void tspassword_Enter(object sender, EventArgs e)
        {
            if (this.tspassword.Text.Equals("Password"))
            {
                this.tspassword.Text = "";
                this.tspassword.ForeColor = Color.Black;
            }
        }

        private void tspassword_Leave(object sender, EventArgs e)
        {
            if (this.tspassword.Text == String.Empty || this.tspassword.Text.Equals("Password"))
            {
                this.tspassword.Text = "Password";
                this.tspassword.ForeColor = Color.DarkGray;
            }
        }
        private Boolean rollcheck(String st)
        {
            if(st.Length<3)
            {
                return false;  
            }
            else
            {
                for (int i = 0; i < st.Length; i++)
                {
                    if (st[i] >= '0' && st[i] <= '9')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(this.stlistclass.Text==String.Empty||this.stlistbatch.Text==String.Empty)
            {
                MessageBox.Show("Please Select Claa/Batch");
            }
           else if(this.stlistroll.Text.Equals("000"))
            {
                MessageBox.Show("Please Enter roll Number");
            }
           else if(!this.rollcheck(stlistroll.Text))
            {
                MessageBox.Show("Please 3 digits roll number");
            }
           else if(this.stlistpass.Text.Equals("Password"))
            {
                MessageBox.Show("Please Enter Password");
            }
           else
            {
                String passs = "";
                /////
                String tablename = stlistclass.Text + "_" + stlistbatch.Text;
                query = "select pass from " + tablename+ " where id = '"+this.stlistroll.Text+"'";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    using(SqlDataReader reader=cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            passs = reader.GetValue(0).ToString();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("User not available");
                    con.Close();
                }
                con.Close();
                if(passs.Equals(stlistpass.Text))
                {
                    MessageBox.Show("Login Successfully");
                }
                else
                {
                    MessageBox.Show("Wrong roll number/Password");
                }
            }
        }
    }
}
