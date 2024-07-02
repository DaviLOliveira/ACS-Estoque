using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ACS_Estoque
{
    public partial class TelaPrincipal : Form
    {
       

        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

        //Verificação de ADMIN para liberar e ocultar ferramentas de acordo com a permissão
        private void VerificacaoAdmin()
        {
            string select = "SELECT admin from login where usuario = '" + label4.Text + "'";
            string valorRecuperado = string.Empty;
            MySqlConnection Conexao;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(data_source))
                {
                    // Abrindo a conexão
                    connection.Open();

                    // Criando um comando com a consulta SQL e a conexão
                    using (MySqlCommand command = new MySqlCommand(select, connection))
                    {
                        // Executando a consulta e obtendo o resultado
                        object resultado = command.ExecuteScalar();

                        // Verificando se o resultado é nulo
                        if (resultado != null)
                        {
                            // Convertendo o resultado para o tipo correto (neste caso, string)
                            valorRecuperado = resultado.ToString();
                        }
                        connection.Close();
                    }
                }
                if (valorRecuperado == "1")
                {
                    button7.Enabled = true;

                }
                else
                {
                    button7.Enabled = false;
                    button7.Text = "";
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        private Form activeForm;


        public TelaPrincipal()
        {
            InitializeComponent();
            
            this.WindowState = FormWindowState.Maximized;
        }
        public TelaPrincipal(string valor)
        {

            InitializeComponent();
            label2.Text = valor;

            //Salvando o valor do usuario para fazer a verificação de administrador
            label4.Text = valor;


            string connectionString = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
            string query = "SELECT * FROM login WHERE usuario = '"+valor+"' ";
            bool valorEncontrado = false;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Recuperando o valor da coluna desejada (MeuCampo) da consulta
                            string valorRecuperado = reader["NomePrograma"].ToString();

                            label2.Text = valorRecuperado;  
                        }
                    }
                }
            }
            
        }

       

        private void timerRelogio_Tick(object sender, EventArgs e)
        {
            // Atualizando o valor do Label com a hora atual.
            label3.Text = DateTime.Now.ToString("MMM dd, yyyy HH:mm:ss");
        }

        //Função para abrir as telas de acordo com o botão clicado
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(childForm);
            this.panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormEstoque(), sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormCadastrarUsario(), sender);
        }

        private void TelaPrincipal_Load_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer timerRelogio = new System.Windows.Forms.Timer();
            timerRelogio.Interval = 1000; // 1 segundo
            timerRelogio.Tick += new EventHandler(timerRelogio_Tick);
            timerRelogio.Start();
            this.VerificacaoAdmin();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
