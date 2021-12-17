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
    public partial class Nouveaucompte : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string choi = "";
        public Nouveaucompte()
        {
            con = new SqlConnection("Data Source=SABERY\\SQLEXPRESS;Initial Catalog=gestiondescolarité;Integrated Security=True");
            cmd = new SqlCommand("", con);
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            con.Open();
            if (MessageBox.Show("voulez_vous vraiment supprrimer le compte de Logine: " + textBox1.Text + "?", "supprimer Etudiant", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                cmd.CommandText = "Delete From Compte where logine='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Compte bien Supprimer", "Supprimer un  Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            con.Close();
            
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Form2 formge = new Form2();
            formge.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            if (radioButton1.Checked)
            {
                choi = "Etudiant";
            }
            if (radioButton2.Checked)
            {
                choi = "Professeur";
            }
            if (radioButton2.Checked)
            {
                choi = "Surveillance";
            }
            cmd.CommandText = "update Compte set modpasse='" + textBox2.Text + "', Profil='"+ choi + "'where logine='"+textBox1.Text+"'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Compte  de logine "+textBox1.Text+" à éte modifier", "modifier Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (radioButton1.Checked)
            {
                choi = "Etudiant";
            }
            if (radioButton2.Checked)
            {
                choi = "Professeur";
            }
            if (radioButton2.Checked)
            {
                choi = "Surveillance";
            }
            cmd.CommandText = ("insert into Compte values('" + textBox1.Text + "','" + textBox2.Text + "','" + choi + "')");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Compte bien Enregestrer", "Ajouter Compte", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }
    }
}
