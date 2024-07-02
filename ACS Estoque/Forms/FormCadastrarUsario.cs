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
    public partial class FormCadastrarUsario : Form
    {
        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
        public FormCadastrarUsario()
        {
            InitializeComponent();
        }

        private void AdicionarUsuario()
        {

            //Condição para criar usuário padrão
            if (comboBox2.Text != "Usuário Padrão")
            {
                try
                {
                    MySqlConnection Conexao;
                    Conexao = new MySqlConnection(data_source);
                    string sql = "INSERT INTO login (usuario, senha, admin, NomePrograma)VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', 1, '" + textBox10.Text + "')";
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);
                    Conexao.Open();
                    comando.ExecuteReader();
                    Conexao.Close();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }

            //Condição para criar usuário admin
            else
            {
                try
                {
                    MySqlConnection Conexao;
                    Conexao = new MySqlConnection(data_source);
                    string sql = "INSERT INTO login (usuario, senha, admin, NomePrograma)VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', 0, '" + textBox10.Text + "')";
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);
                    Conexao.Open();
                    comando.ExecuteReader();
                    Conexao.Close();
                    MessageBox.Show("Cadastro realizado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }

        }

        //Função para pesquisar pelos usuários no banco
        private void Pesquisar()
        {
            try
            {
                MySqlConnection Cn;
                Cn = new MySqlConnection(data_source);
                Cn.Open();
                var exibirVagas = "SELECT * FROM login WHERE usuario = '" + textBox3.Text + "' ";
                using (MySqlDataAdapter da = new MySqlDataAdapter(exibirVagas, Cn))
                {
                    using (DataTable dt = new DataTable())
                    {
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                Cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Função para alterar nome de usuário
        private void AlterarUsuario()
        {
            if (textBox3.Text != "")
            {
                try
                {
                    MySqlConnection conexao = new MySqlConnection(data_source);
                    string sql = "UPDATE login SET usuario = '" + textBox5.Text + "' WHERE usuario = '" + textBox3.Text + "'";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    conexao.Open();
                    comando.ExecuteReader();
                    conexao.Close();
                    MessageBox.Show("Nome de usuário atualizado!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Digite o nome do usuário na barra de pesquisa que deseja alterar!");
            }

        }

        //Função para alterar senha de usuário
        private void AlterarSenha()
        {
            if (textBox3.Text != "")
            {
                try
                {
                    MySqlConnection conexao = new MySqlConnection(data_source);
                    string sql = "UPDATE login SET senha = '" + textBox4.Text + "' WHERE usuario = '" + textBox3.Text + "'";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    conexao.Open();
                    comando.ExecuteReader();
                    conexao.Close();
                    MessageBox.Show("Senha atualizada!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Digite o nome do usuário na barra de pesquisa que deseja alterar!");
            }
        }

        //Função para alterar Tipo de usuário(padrão ou admin)
        private void AlterarTipo()
        {
            if (comboBox1.Text != "Usuário Padrão")
            {
                if (textBox3.Text != "")
                {
                    try
                    {
                        MySqlConnection conexao = new MySqlConnection(data_source);
                        string sql = "UPDATE login SET admin = 1 WHERE usuario = '" + textBox3.Text + "'";
                        MySqlCommand comando = new MySqlCommand(sql, conexao);
                        conexao.Open();
                        comando.ExecuteReader();
                        conexao.Close();
                        MessageBox.Show("Tipo de usuário atualizado!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Digite o nome do usuário na barra de pesquisa que deseja alterar!");
                }
            }
            else
            {
                if (textBox3.Text != "")
                {
                    try
                    {
                        MySqlConnection conexao = new MySqlConnection(data_source);
                        string sql = "UPDATE login SET admin = 0 WHERE usuario = '" + textBox3.Text + "'";
                        MySqlCommand comando = new MySqlCommand(sql, conexao);
                        conexao.Open();
                        comando.ExecuteReader();
                        conexao.Close();
                        MessageBox.Show("Tipo de usuário atualizado!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        throw;
                    }
                }
                else
                {
                    MessageBox.Show("Digite o nome do usuário na barra de pesquisa que deseja alterar!");
                }
            }
        }

        //Função para excluir o usuário
        private void ExcluirUsuario()
        {
            if (textBox3.Text != "")
            {
                try
                {
                    MySqlConnection conexao = new MySqlConnection(data_source);
                    string sql = "DELETE FROM login WHERE usuario = '" + textBox3.Text + "'";
                    MySqlCommand comando = new MySqlCommand(sql, conexao);
                    conexao.Open();
                    comando.ExecuteReader();
                    conexao.Close();
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Digite o nome do usuário na barra de pesquisa que deseja alterar!");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                this.Pesquisar();
            }
            else
            {
                MessageBox.Show("Digite o nome do usuário!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && textBox10.Text !="" )
            {
                this.AdicionarUsuario();
            }
            else
            {
                MessageBox.Show("Complete todos os campos!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                this.AlterarUsuario();
            }
            else
            {
                MessageBox.Show("Digite o novo Nome do usuário!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                this.AlterarSenha();
            }
            else
            {
                MessageBox.Show("Digite a nova senha do usuário!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                this.AlterarTipo();
            }
            else
            {
                MessageBox.Show("Selecione o novo tipo de usuário!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.ExcluirUsuario();
        }
    }
}
