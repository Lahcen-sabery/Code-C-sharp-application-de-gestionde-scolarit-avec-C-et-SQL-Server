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
namespace gestiondescolarité
{
    public partial class Form2_Compte : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form2_Compte()
        {
            con = new SqlConnection("Data Source=SABERY\\SQLEXPRESS;Initial Catalog=gestiondescolarité;Integrated Security=True");
            cmd = new SqlCommand("", con);

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            
            cmd.CommandText = "select logine, modpasse,Profil from Compte where logine='" + textBox1.Text + "'and modpasse='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                if (dr[2].ToString() == "Etudiant") {
                    
                    AffichageEtu formEtudiant = new AffichageEtu();
                    formEtudiant.Show();
                    this.Hide();
                }
                else 
                if (dr[2].ToString() == "Surveillance")
                {
                   
                    Form2 formsurveillance = new Form2();
                    formsurveillance.Show();
                    this.Hide();
                }
                else
                if (dr[2].ToString() == "Professeur")
                {
                   
                    Form4_Module formmodule = new Form4_Module();
                    formmodule.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Logine ou mod passe et incorrect", "Erreue Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            } 
         

            con.Close();
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void textBox1_Enter(object sender, EventArgs e)
        {
if (textBox1.Text== "Utulisateur ")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.WhiteSmoke;
            }
        }

        

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Mot de passe ")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.WhiteSmoke;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Utulisateur ";
                textBox1.ForeColor = Color.Silver;
            }
        }
  
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Mot de passe ";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void Form2_Compte_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
