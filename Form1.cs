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
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        string choi = "";
        string cne;
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=SABERY\\SQLEXPRESS;Initial Catalog=gestiondescolarité;Integrated Security=True");
            cmd = new SqlCommand("", con);
            con.Open();
            cmd.CommandText = "select CNE from Etudiant";
            dr = cmd.ExecuteReader();
            while (dr.Read())
                comboBox1.Items.Add(dr[0]);
            con.Close();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            con.Open();
            if (radioButton1.Checked)
            {
                choi = "M";
            }
            else { choi = "F"; } 
            cmd.CommandText=("insert into Etudiant values('" + textBox1.Text + "','" + textBox2.Text + "','" + choi + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox10.Text + "','" + textBox8.Text + "')");
            cmd.ExecuteNonQuery();
            MessageBox.Show("Etudiant bien Enregestrer","Ajouter etudiant",MessageBoxButtons.OK,MessageBoxIcon.Information);
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox4.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox10.Text == "" && textBox8.Text == "") { 
            comboBox1.Visible = true;
            }
            else { 
            con.Open();
            if (radioButton1.Checked)
            {
                choi = "M";
            }
            else { choi = "F"; }
            cmd.CommandText = "update Etudiant set Nom='" + textBox1.Text + "',Prenom='" + textBox2.Text + "',Sexe='" +choi+ "',Date_niss='" + textBox4.Text + "',CNE='" + textBox5.Text + "',CIN='" + textBox6.Text + "',Specialité='" + textBox7.Text + "',Email='" + textBox10.Text + "',Tel='" + textBox8.Text+ "'where CNE='" + cne +"'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Etudiant bien Modifier", "Modifier Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
                }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox4.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox10.Text == "" && textBox8.Text == "")
            {
                comboBox1.Visible = true;
            }
            else
            {
                con.Open();
                if (MessageBox.Show("voulez_vous vraiment supprrimer L'étudiant qui a le CNE: " + cne + "?", "supprimer Etudiant", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    cmd.CommandText = "delete from Etudiant where CNE='" +cne + "'";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Etudiant bien Supprimer", "Supprimer un  Etudiant", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                con.Close();
            }
        }
        

        private void button10_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            Application.Exit();
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             String r = comboBox1.SelectedItem.ToString();
            cne = r.Substring(comboBox1.Text.IndexOf(""));
            textBox5.Text = cne;
            con.Open();
            
            cmd.CommandText = "select Sexe,Nom,Prenom,Date_niss,CIN,Specialité,Email,Tel  from Etudiant";
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                if (dr[0].ToString() == "F") { 
                    
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox6.Text = dr[4].ToString();
                textBox7.Text = dr[5].ToString();
                textBox10.Text = dr[6].ToString();
                textBox8.Text = dr[7].ToString();
                
            }
               
            con.Close();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form2 formge = new Form2();
            formge.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
