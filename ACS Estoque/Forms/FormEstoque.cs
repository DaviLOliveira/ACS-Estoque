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

namespace ACS_Estoque.Forms
{
    public partial class FormEstoque : Form
    {
        private Form activeForm;
        public FormEstoque()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panelEstoque_Paint(object sender, PaintEventArgs e)
        {
            this.TotalItem();
            this.ItemObra();
            this.ItemForaObra();
            this.Maquina();
            this.Ferramentas();
            this.Domesticos();
            this.Escritorio();
            this.Comprado();
            this.Alugado();
        }

        private void TotalItem()
        {
            //Carregar itens cadastrados
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label1.Text = soma.ToString();
            con.Close();
        }

        //Carregar itens em obra
        private void ItemObra()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Stts = 'dentro de obra' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label5.Text = soma.ToString();
            con.Close();
        }

        //Carregar itens fora de obra
        private void ItemForaObra()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Stts = 'fora de obra' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label6.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de máquinas cadastradas no estoque
        private void Maquina()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Tipo = 'Máquina' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label13.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de ferramentas cadastradas no estoque
        private void Ferramentas()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Tipo = 'Ferramentas' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label14.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de domesticos cadastradas no estoque
        private void Domesticos()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Tipo = 'Domésticos' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label15.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de itens de escritório cadastrados no estoque
        private void Escritorio()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Tipo = 'Escritório' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label16.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de itens comprados
        private void Comprado()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Procedencia = 'Comprado' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label17.Text = soma.ToString();
            con.Close();
        }

        //Carregar quantidade de itens alugados
        private void Alugado()
        {
            string strConexao = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";

            MySqlConnection con = new MySqlConnection(strConexao);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM estoque where Procedencia = 'Alugado' ", con);
            MySqlDataReader dados = cmd.ExecuteReader();

            var listaNumeros = new List<string>();
            while (dados.Read())
            {
                listaNumeros.Add(dados["Quantidade"].ToString());

            }

            decimal soma = 0;
            foreach (var valor in listaNumeros)
            {

                soma += Convert.ToDecimal(valor);


            }
            label18.Text = soma.ToString();
            con.Close();
        }

        //Função para abrir as telas 
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
            this.panelEstoque.Controls.Add(childForm);
            this.panelEstoque.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void cadastrarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SubForms.Estoque.FormAdicionarItem(), sender);
        }

        private void alterarItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SubForms.Estoque.FormAlterarItem(), sender);
        }

        private void visualizarEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SubForms.Estoque.FormVisualizar(), sender);
        }

        private void uniformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.SubForms.Estoque.FormCadastrarUniforme(), sender);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
