using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestiondescolarité
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2_Compte formConnexion = new Form2_Compte();
            formConnexion.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Compte formConnexion = new Form2_Compte();
            formConnexion.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2_Compte formConnexion = new Form2_Compte();
            formConnexion.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
