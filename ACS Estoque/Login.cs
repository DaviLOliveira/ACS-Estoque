using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_Estoque
{
    public partial class Login : Form
    {
        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
        public Login()
        {
            InitializeComponent();
        }

        

        //Verificação de login 
        public void Verificação()
        {

            try
            {
                MySqlConnection Conexao;
                Conexao = new MySqlConnection(data_source);
                Conexao.Open();
                string user = textBox1.Text;
                string pass = textBox2.Text;
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Login WHERE usuario='" + textBox1.Text + "' AND senha ='" + textBox2.Text + "'", Conexao);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //Abrindo Form Geral caso os dados do Login estejam certos
                    this.Hide();
                    var form2 = new TelaPrincipal(textBox1.Text);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();

                }
                else
                {
                    label3.Visible = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Verificação();
        }
    }
}
