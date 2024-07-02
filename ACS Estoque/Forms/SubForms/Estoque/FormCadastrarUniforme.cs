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

namespace ACS_Estoque.Forms.SubForms.Estoque
{
    public partial class FormCadastrarUniforme : Form
    {
        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
        public FormCadastrarUniforme()
        {
            InitializeComponent();
        }

        //Funçao para verificar TextBox vazias
        private bool textBoxVazias()
        {
            foreach (Control c in this.Controls)
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                        return true;
                }
            return false;


        }

       

        // Cadastrar Uniforme
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.textBoxVazias();
            if (textBoxVazias()) MessageBox.Show("Preencha todas as informações");
            else
            {
                if ((comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox7.Text != ""))
                {
                    //string para adicionar na tabela uniforme string sql = "INSERT INTO Uniformes (CodigoUniforme, Tipo, Tamanho, Stts, Quantidade, Material) Values (null, '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + comboBox3.Text + "', '" + textBox1.Text + "', '" + comboBox7.Text + "')";
                    MySqlConnection Conexao;
                    try
                    {

                        Conexao = new MySqlConnection(data_source);
                        string sql = "update Uniformes set quantidade = quantidade + '" + textBox1.Text + "' where Tipo = '" + comboBox1.Text + "' and Tamanho = '" + comboBox2.Text + "' and Stts = '" + comboBox3.Text + "' and Material = '" + comboBox7.Text + "'";
                        MySqlCommand comando = new MySqlCommand(sql, Conexao);
                        Conexao.Open();
                        comando.ExecuteReader();
                        Conexao.Close();
                        MessageBox.Show("Cadastro concluído!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Preencha todas as informações");
                }
            }
        }

        //Função para dar baixa em um uniforme
        private void button4_Click_1(object sender, EventArgs e)
        {
            if ((comboBox1.Text != "") && (comboBox2.Text != "") && (comboBox3.Text != "") && (comboBox7.Text != ""))
            {
                MySqlConnection Conexao;
                try
                {

                    Conexao = new MySqlConnection(data_source);
                    string sql = "update Uniformes set quantidade = quantidade - '" + textBox1.Text + "' where Tipo = '" + comboBox1.Text + "' and Tamanho = '" + comboBox2.Text + "' and Stts = '" + comboBox3.Text + "'";
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);
                    Conexao.Open();
                    comando.ExecuteReader();
                    Conexao.Close();
                    MessageBox.Show("Exclusão concluída!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            else
            {
                MessageBox.Show("Preencha todas as informações");
            }
        }

        //Carregar datagridview com todo banco
        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Cn;
                Cn = new MySqlConnection(data_source);
                Cn.Open();
                var exibirVagas = "SELECT ID_Uniforme, Tipo, Tamanho, Stts, Material, quantidade FROM uniformes ";
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

        //Carregar datagridview com pesquisa exata
        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Cn;
                Cn = new MySqlConnection(data_source);
                Cn.Open();
                var exibirVagas = "SELECT ID_Uniforme, Tipo, Tamanho, Stts, Material, quantidade FROM uniformes Where Tipo = '" + comboBox4.Text + "' AND Tamanho = '" + comboBox5.Text + "' AND STTS = '" + comboBox6.Text + "' AND Material = '" + comboBox8.Text + "' ";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
    }
}
