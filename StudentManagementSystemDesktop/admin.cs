using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using BasicFunction;

namespace StudentManagementSystemDesktop
{
    public partial class admin : Form
    {
        Boolean erroris;
        Boolean error2is;
        Boolean error3is;
        Form1 fm;
        Function f;
        ArrayList list;
        SqlConnection con;
        String query;
        SqlCommand cmd;
        ArrayList listclasscontain;
        ArrayList listbatchcontain;
        ArrayList listadminstudentdata;
        public admin(Form1 fm)
        {
            InitializeComponent();
            this.fm = fm;
        }

        private void admin_Load(object sender, EventArgs e)
        {
            String conString = "Data Source=SOHAIL-AMJAD-LA;Initial Catalog=studentManagementSystemDesktop;Integrated Security=True";
            con = new SqlConnection(conString);
            listclasscontain = new ArrayList();
            listbatchcontain = new ArrayList();
            listadminstudentdata = new ArrayList();
            this.fetchclassbatch();
            this.fetchstudentview();
            
        }
        private void fetchstudentview()
        {
            try
            {
                listadminstudentdata.Clear();
                if(this.clas.Text==String.Empty||this.batch.Text==String.Empty)
                {
                    return;
                }
                String tablenamee = this.clas.Text + "_" + this.batch.Text;
                query = "select id,namee,fname,cnic,mobile,email,addres,DOB,gender,pass from "+tablenamee;
                cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for(int i=0;i<reader.FieldCount;i++)
                        {
                            listadminstudentdata.Add(reader.GetValue(i));
                        }
                    }
                }
                con.Close();


                // Set Value Into Table'
                con.Open();
                query = "select * from " + tablenamee;
                SqlDataAdapter adp = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                adp.Fill(dataTable);
                dataGridViewAdminstudent.DataSource = dataTable;
                con.Close();

            }
            catch
            {

            }
        }
        private void fetchclassbatch()
        {
            try
            {
                listclasscontain.Clear();
                query = "select namee from class";
                cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listclasscontain.Add(reader.GetValue(0));
                    }
                }
                con.Close();

                listbatchcontain.Clear();
                query = "select namee from batch";
                cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listbatchcontain.Add(reader.GetValue(0));
                    }
                }
                con.Close();
                this.clas.Items.Clear();
                for (int i = 0; i < listclasscontain.Count; i++)
                {
                    this.clas.Items.Add(listclasscontain[i]);
                }
                this.batch.Items.Clear();
                for (int i = 0; i < listbatchcontain.Count; i++)
                {
                    this.batch.Items.Add(listbatchcontain[i]);
                }
            }
            catch
            {
                con.Close();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            fm.Show();
            base.OnClosing(e);
        }

        private void name_Enter(object sender, EventArgs e)
        {
            if (this.name.Text.Equals("Enter Your Name"))
            {
                this.name.Text = "";
                this.name.ForeColor = Color.Black;
            }
        }

        private void name_Leave(object sender, EventArgs e)
        {
            if (this.name.Text == String.Empty)
            {
                this.name.Text = "Enter Your Name";
                this.name.ForeColor = Color.DarkGray;
            }
        }

        private void Fname_FontChanged(object sender, EventArgs e)
        {

        }

        private void Fname_Enter(object sender, EventArgs e)
        {
            if (this.Fname.Text.Equals("Enter Your Father Name"))
            {
                this.Fname.Text = "";
                this.Fname.ForeColor = Color.Black;
            }
        }

        private void Fname_Leave(object sender, EventArgs e)
        {
            if (this.Fname.Text == String.Empty)
            {
                this.Fname.Text = "Enter Your Father Name";
                this.Fname.ForeColor = Color.Gray;
            }
        }

        private void CNIC_Enter(object sender, EventArgs e)
        {
            if (this.CNIC.Text.Equals("Enter Your CNIC No"))
            {
                this.CNIC.Text = "";
                this.CNIC.ForeColor = Color.Black;
            }
        }

        private void CNIC_Leave(object sender, EventArgs e)
        {
            if (this.CNIC.Text == String.Empty)
            {
                this.CNIC.Text = "Enter Your CNIC No";
                this.CNIC.ForeColor = Color.Gray;
            }
        }

        private void M_Enter(object sender, EventArgs e)
        {
            if (this.M.Text.Equals("Enter Your Mobile NO"))
            {
                this.M.Text = "";
                this.M.ForeColor = Color.Black;
            }
        }

        private void M_Leave(object sender, EventArgs e)
        {
            if (this.M.Text == String.Empty)
            {
                this.M.Text = "Enter Your Mobile NO";
                this.M.ForeColor = Color.Gray;
            }
        }

        private void E_Enter(object sender, EventArgs e)
        {
            if (this.E.Text.Equals("Enter E-Mail"))
            {
                this.E.Text = "";
                this.E.ForeColor = Color.Black;
            }
        }

        private void E_Leave(object sender, EventArgs e)
        {
            if (this.E.Text == String.Empty)
            {
                this.E.Text = "Enter E-Mail";
                this.E.ForeColor = Color.Gray;
            }
        }

        private void A_Enter(object sender, EventArgs e)
        {
            if (this.A.Text.Equals("Enter Your Address"))
            {
                this.A.Text = "";
                this.A.ForeColor = Color.Black;
            }
        }

        private void A_Leave(object sender, EventArgs e)
        {
            if (this.A.Text == String.Empty)
            {
                this.A.Text = "Enter Your Address";
                this.A.ForeColor = Color.Gray;
            }
        }

        private void D_Enter(object sender, EventArgs e)
        {
            if (this.D.Text.Equals("dd/mm/yyyy"))
            {
                this.D.Text = "";
                this.D.ForeColor = Color.Black;
            }
        }

        private void D_Leave(object sender, EventArgs e)
        {
            if (this.D.Text == String.Empty)
            {
                this.D.Text = "dd/mm/yyyy";
                this.D.ForeColor = Color.Gray;
            }
        }

        private void G_Enter(object sender, EventArgs e)
        {
            if ((!
                (this.G.Text.Equals("Male")
                ||
                this.G.Text.Equals("Female")
                ||
                this.G.Text.Equals("Other")
                ))
                ||
                this.G.Text == String.Empty
                )
            {
                this.G.Text = "";
                this.G.ForeColor = Color.Black;
            }
        }

        private void G_Leave(object sender, EventArgs e)
        {
            if (
                !
                (this.G.Text.Equals("Male")
                ||
                this.G.Text.Equals("Female")
                ||
                this.G.Text.Equals("Other")
                )
                )
            {
                this.G.Text = "Select";
                this.G.ForeColor = Color.Gray;
            }
        }

        private void name_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(name.Text == "Enter Your Name"))
            {
                if (this.checkAlphabet(name.Text))
                {

                }
                else
                {
                    errorProvider1.SetError(name, "Please Enter Correct Name");
                    erroris = true;
                }
            }
            else
            {
                errorProvider1.SetError(name, "Please Enter Your Name");
                erroris = true;
            }
        }
        private Boolean checkAlphabet(String st)
        {
            for (int i = 0; i < st.Length; i++)
            {
                if (
                    (st[i] >= 'a' && st[i] <= 'z')
                    ||
                    (st[i] >= 'A' && st[i] <= 'Z')
                    )
                {

                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void Fname_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(this.Fname.Text == "Enter Your Name"))
            {
                if (this.checkAlphabet(this.Fname.Text))
                {

                }
                else
                {
                    errorProvider1.SetError(Fname, "Please Enter Correct Father Name");
                    erroris = true;
                }
            }
            else
            {
                errorProvider1.SetError(Fname, "Please Enter Your Father Name");
                erroris = true;
            }
        }

        private void CNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void M_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(this.CNIC.Text == String.Empty))
            {
                if (!this.CNIC.Text.Equals("Enter Your CNIC No"))
                {
                    String st = "";
                    for (int i = 0; i < this.CNIC.Text.Length - 1; i++)
                    {
                        st = st + this.CNIC.Text[i];
                    }
                    this.CNIC.Text = st;
                }
            }
            if (this.CNIC.Text == String.Empty)
            {
                this.CNIC.Text = "Enter Your CNIC No";
                this.CNIC.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!(this.M.Text == String.Empty))
            {
                if (!this.M.Text.Equals("Enter Your Mobile NO"))
                {
                    String st = "";
                    for (int i = 0; i < this.M.Text.Length - 1; i++)
                    {
                        st = st + this.M.Text[i];
                    }
                    this.M.Text = st;
                }
            }
            if (this.M.Text == String.Empty)
            {
                this.M.Text = "Enter Your Mobile NO";
                this.M.ForeColor = Color.Gray;
            }
        }

        private void D_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(this.D.Text.Equals("dd/mm/yyyy")))
            {
                if ((this.D.Text.Length.Equals(10)))
                {

                    if (
                        (D.Text[0] >= '0' && D.Text[0] <= '9')
                        &&
                        (D.Text[1] >= '0' && D.Text[1] <= '9')
                        &&
                        (D.Text[2].Equals('/'))
                        &&
                        (D.Text[3] >= '0' && D.Text[3] <= '9')
                        &&
                        (D.Text[4] >= '0' && D.Text[4] <= '9')
                        &&
                        (D.Text[5].Equals('/'))
                        &&
                        (D.Text[6] >= '0' && D.Text[6] <= '9')
                        &&
                        (D.Text[7] >= '0' && D.Text[7] <= '9')
                        &&
                        (D.Text[8] >= '0' && D.Text[8] <= '9')
                        &&
                        (D.Text[9] >= '0' && D.Text[9] <= '9')
                        )
                    {
                        if (!(this.datecheck(D.Text)))
                        {
                            errorProvider1.SetError(D, "Please Enter Corrrect Date");
                            erroris = true;
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(D, "Please Enter Valid Date Of Birth");
                        erroris = true;
                    }
                }
                else
                {
                    errorProvider1.SetError(D, "Please Enter Valid Date Of Birth length");
                    erroris = true;
                }

            }

            else
            {
                errorProvider1.SetError(D, "Please Enter Date Of Birth");
                erroris = true;
            }

        }
        private Boolean datecheck(String date)
        {

            String month = "";
            String dat = "";
            String year = "";
            dat = date[0] + "" + date[1] + "";
            month = date[3] + "" + date[4] + "";
            year = date[6] + "" + date[7] + "" + date[8] + "" + date[9] + "";
            if (Convert.ToInt32(year) > 2020 || Convert.ToInt32(year) < 1947)
            {
                return false;
            }
            if (Convert.ToInt32(dat) <= 0)
            {
                return false;
            }
            if (month.Equals("01"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("02"))
            {
                if (Convert.ToInt32(dat) > 29)
                {
                    return false;
                }
            }
            else if (month.Equals("03"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("04"))
            {
                if (Convert.ToInt32(dat) > 30)
                {
                    return false;
                }
            }
            else if (month.Equals("05"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("06"))
            {
                if (Convert.ToInt32(dat) > 30)
                {
                    return false;
                }
            }
            else if (month.Equals("07"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("08"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("09"))
            {
                if (Convert.ToInt32(dat) > 30)
                {
                    return false;
                }
            }
            else if (month.Equals("10"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else if (month.Equals("11"))
            {
                if (Convert.ToInt32(dat) > 30)
                {
                    return false;
                }
            }
            else if (month.Equals("12"))
            {
                if (Convert.ToInt32(dat) > 31)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void CNIC_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(this.CNIC.Text.Equals("Enter Your CNIC No")))
            {
                if (this.CNIC.Text.Length < 13)
                {
                    errorProvider1.SetError(this.CNIC, "Please Enter Full CNIC");
                    erroris = true;
                }
            }
            else
            {
                errorProvider1.SetError(this.CNIC, "Please Enter Your CNIC");
                erroris = true;
            }
        }

        private void M_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(this.M.Text.Equals("Enter Your Mobile NO")))
            {
                if (this.M.Text.Length < 11)
                {
                    errorProvider1.SetError(this.M, "Please Enter Full Mobile No.");
                    erroris = true;
                }
            }
            else
            {
                errorProvider1.SetError(this.M, "Please Enter Your Mobile No.");
                erroris = true;
            }
        }

        private void E_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (!(this.E.Text.Equals("Enter E-Mail")))
            {
                if (!this.E.Text.Contains("@gmail.com"))
                {
                    errorProvider1.SetError(E, "Please Enter Valid E-Mail");
                    erroris = true;
                }
            }
            else
            {
                errorProvider1.SetError(E, "Please Enter Your E-Mail");
                erroris = true;
            }
        }

        private void A_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (this.A.Text.Equals("Enter Your Address"))
            {
                errorProvider1.SetError(A, "Please Enter Your Address");
                erroris = true;
            }
        }

        private void G_Validating(object sender, CancelEventArgs e)
        {
            errorProvider1.Clear();
            erroris = false;
            if (this.G.Text.Equals("Male"))
            { }
            else if (this.G.Text.Equals("Female"))
            { }
            else if (this.G.Text.Equals("Other"))
            { }
            else
            {
                errorProvider1.SetError(G, "Please Select The Correct Gender");
                erroris = true;
            }
        }

        private void stID_Enter(object sender, EventArgs e)
        {
            if (this.stID.Text.Equals("Enter ID"))
            {
                this.stID.Text = "";
                this.stID.ForeColor = Color.Black;
            }
        }

        private void stID_Leave(object sender, EventArgs e)
        {
            if (this.stID.Text == String.Empty)
            {
                this.stID.Text = "Enter ID";
                this.stID.ForeColor = Color.DarkGray;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.idcheck();
        }
        private void idcheck()
        {
            if (!(this.stID.Text == String.Empty))
            {
                if (!this.stID.Text.Equals("Enter ID"))
                {
                    String st = "";
                    for (int i = 0; i < this.stID.Text.Length - 1; i++)
                    {
                        st = st + this.stID.Text[i];
                    }
                    this.stID.Text = st;
                }
            }
            if (this.stID.Text == String.Empty)
            {
                this.stID.Text = "Enter ID";
                this.stID.ForeColor = Color.Gray;
            }
        }

        private void stID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {

            }
            else
            {
                e.Handled = true;
            }
        }
        private Boolean idch(String st)
        {
            if(st.Length<3)
            {
                return false;
            }
            return true;
        }
        private void st_add_bt_Click(object sender, EventArgs e)
        {
            String tablename = this.clas.Text + "_" + this.batch.Text;
            query = "create table "+tablename.ToString() +" (id varchar(3) primary key,namee varchar(50),fname varchar(50),cnic varchar(15),mobile varchar(15),email varchar(50),addres varchar(50),DOB varchar(11),gender varchar(7),pass varchar(10))";
            cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
            }
            con.Close();
            if(erroris==true||this.clas.Text==String.Empty||this.batch.Text==String.Empty)
            {
                MessageBox.Show("Please Enter Correct Data");
            }
            else if(!(idch(this.stID.Text)))
            {
                MessageBox.Show("Please Enter 3 digit ID");
            }
            else
            {
                query = "insert into "+tablename+" (id,namee,fname,cnic,mobile,email,addres,DOB,gender,pass)values('"+this.stID.Text+"','"+this.name.Text+"','"+this.Fname.Text+"','"+this.CNIC.Text+"','"+this.M.Text+"','"+this.E.Text+"','"+this.A.Text+"','"+this.D.Text+"','"+this.G.Text+"','123456')";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added SuccessFully");
                }
                catch
                {
                    MessageBox.Show("Data Error\nMaybe Already Exist ID");
                    con.Close();
                }
                con.Close();
            }
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.emojipannel.Location = new Point(0, 0);
            this.addclassbatchpannel.Location = new Point(0, 0);
            this.addclassbatchpannel.Visible = true;
            this.button7.Hide();
            this.label3.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.addclassbatchpannel.Visible = false;
            this.button7.Show();
            this.label3.Show();
        }
        private Boolean tim = true;
        private int i = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if(tim)
            {
                this.label2.Location = new Point(100, 9+i);
                if(i>60)
                {
                    tim = false;
                    i = 0;
                }
            }
            else
            {
                this.label2.Location = new Point(100, 65-i);
                if(i>60)
                {
                    tim = true;
                    i = 0;
                }
            }
        }

        private void newclassname_Enter(object sender, EventArgs e)
        {
            if(this.newclassname.Text.Equals("Enter New Class Name"))
            {
                this.newclassname.Text = "";
                this.newclassname.ForeColor = Color.Black;
            }
        }

        private void newclassname_Leave(object sender, EventArgs e)
        {
            if(this.newclassname.Text==String.Empty||this.newclassname.Text.Equals("Enter New Class Name"))
            {
                this.newclassname.Text = "Enter New Class Name";
                this.newclassname.ForeColor = Color.Gray;
            }
        }

        private void newbatchname_Enter(object sender, EventArgs e)
        {
            if(this.newbatchname.Text.Equals("Enter New Batch Name"))
            {
                this.newbatchname.Text = "";
                this.newbatchname.ForeColor = Color.Black;
            }
        }

        private void newbatchname_Leave(object sender, EventArgs e)
        {
            if(this.newbatchname.Text==String.Empty||this.newbatchname.Text.Equals("Enter New Batch Name"))
            {
                this.newbatchname.Text = "Enter New Batch Name";
                this.newbatchname.ForeColor = Color.Gray;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
                query = "create table class(namee varchar(20) primary key)";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    con.Close();
                }
                con.Close();
            
            if(this.newclassname.Text.Equals("Enter New Class Name"))
            {
                MessageBox.Show("Please Enter New Class Name");
            }
            else if(!this.validatee(this.newclassname))
            {
                MessageBox.Show("Please Enter Correcr Class Name\nOnly Alphabets And Digits Allowed");
            }
            else
            {
                query = "insert into class(namee)values('"+this.newclassname.Text+"')";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Class Added Successfully => " + this.newclassname.Text);
                    this.clas.Items.Add(this.newclassname.Text);
                }
                catch
                {
                    MessageBox.Show("Class Already Exist ");
                    con.Close();
                }
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            query = "create table batch (namee varchar(20) primary key)";
            cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                con.Close();
            }
            con.Close();
            if (this.newbatchname.Text.Equals("Enter New Batch Name"))
            {
                MessageBox.Show("Please Enter New Batch Name");
            }
            else if (!this.validatee(this.newbatchname))
            {
                MessageBox.Show("Please Enter Correct Name\nOnly Digits And Alphabets Allowed Allowed");
            }
            else
            { 
                query = "insert into batch(namee)values('" + this.newbatchname.Text + "')";
                cmd = new SqlCommand(query, con);
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Batch Added Successfully => " + this.newbatchname.Text);
                    this.batch.Items.Add(this.newbatchname.Text);
                }
                catch
                {
                    MessageBox.Show("Batch Already Exist ");
                    con.Close();
                }
                con.Close();
            }
        }
        private Boolean validatee(TextBox tx)
        {
            if(tx.Text.Contains(" "))
            {
                return false;
            }
            for (int i = 0; i < tx.Text.Length; i++)
            {
                if (tx.Text[i] >= 'A' && tx.Text[i] <= 'Z')
                {
                    return true;
                }
                else if (tx.Text[i] >= 'a' && tx.Text[i] <= 'z')
                {
                    return true;
                }
                else if (tx.Text[i] >= '0' && tx.Text[i] <= '9')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        private void newclassname_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void newbatchname_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void clas_TextChanged(object sender, EventArgs e)
        {
            this.fetchstudentview();
            MessageBox.Show("New");
        }
    }
}
// 100, 9
// 100, 65
