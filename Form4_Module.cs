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
    public partial class Form4_Module : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public Form4_Module()
        {
            con = new SqlConnection("Data Source=SABERY\\SQLEXPRESS;Initial Catalog=gestiondescolarité;Integrated Security=True");
            cmd = new SqlCommand("", con);
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd.CommandText = ("insert into Examen values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Information Effectuée", "Ajouter Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
       
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "update Examen set Date_exam='" + textBox3.Text + "',Note='" + textBox4.Text + "',ProfesseurEns='"+ textBox5.Text + "',DureeExam='" + textBox6.Text + "'where Nommodule='" + textBox1.Text+"' AND CNE='"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Resultat bien Modifier", "Modifier info Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("voulez_vous vraiment supprrimer le info de module"+textBox1.Text+" pour L'étudiant qui a le CNE: " + textBox2.Text + "?", "supprimer Resultat Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                cmd.CommandText = "delete from Examen where Nommodule='" + textBox1.Text + "'and CNE='"+textBox2.Text+"'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Resultat bien Supprimer", "Supprimer Resultat d'un etudiant pour un module donner", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
