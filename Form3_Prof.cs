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
    public partial class Form3_Prof : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string choi = "";
        
        public Form3_Prof()
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
            if (radioButton1.Checked)
            {
                choi = "M";
            }
            else { choi = "F"; }
            cmd.CommandText = ("insert into Professeur values('" + textBox1.Text + "','" + textBox2.Text + "','" + choi + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text +"')");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Professeur bien Enregestrer", "Ajouter Professeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (MessageBox.Show("voulez_vous vraiment supprrimer le professeur qui CIN+: " + textBox4.Text + "?", "supprimer Professeur", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                cmd.CommandText = "delete from Professeur where CIN='" + textBox4.Text + "'";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Professeur bien Supprimer", "Supprimer un  Professeur", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           
        
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 formge = new Form2();
            formge.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if (radioButton1.Checked)
            {
                choi = "M";
            }
            else { choi = "F"; }
            cmd.CommandText = "update Professeur set Nom='" + textBox1.Text + "',Prenom='" + textBox2.Text + "',Sexe='" + choi + "',Date_naiss='" + textBox3.Text + "',CIN='" + textBox4.Text + "',Email='" + textBox5.Text + "',Tel='" + textBox6.Text + "',Moduleens='" + textBox7.Text +"'where CIN='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Info Professeur bien Modifier", "Modifier info Professeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
