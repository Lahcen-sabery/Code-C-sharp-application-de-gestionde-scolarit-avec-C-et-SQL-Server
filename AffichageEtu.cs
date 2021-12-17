using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace gestiondescolarité
{
    public partial class AffichageEtu : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string choi = "";
        public AffichageEtu()
        {
            con = new SqlConnection("Data Source=SABERY\\SQLEXPRESS;Initial Catalog=gestiondescolarité;Integrated Security=True");
            cmd = new SqlCommand("", con);
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select Note,Date_exam,DureeExam from Examen where Nommodule='"+textBox2.Text+"'and CNE='"+textBox1.Text+"'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                textBox3.Text = dr[0].ToString();
                textBox4.Text = dr[1].ToString();
                textBox5.Text = dr[2].ToString();
            }
            con.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_Compte formge = new Form2_Compte();
            formge.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select AVG(Note) from Examen where CNE='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                textBox6.Text = dr[0].ToString();

            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select Date_exam from Examen where Nommodule='" + textBox2.Text + "'and CNE='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                
                textBox4.Text = dr[0].ToString();
                
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select DureeExam from Examen where Nommodule='" + textBox2.Text + "'and CNE='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                
                textBox5.Text = dr[0].ToString();
            }
            con.Close();
        }
    }
}
