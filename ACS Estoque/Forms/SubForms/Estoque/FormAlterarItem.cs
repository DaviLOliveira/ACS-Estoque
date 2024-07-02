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
    public partial class FormAlterarItem : Form
    {
        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
        public FormAlterarItem()
        {
            InitializeComponent();
        }

        //Função para retornar quantidade de itens retornados das consultas
        private void AtualizarLabelQuantidadeItens()
        {
            // Obter a quantidade de itens encontrados no DataGridView
            int quantidadeItens = dataGridView1.RowCount - 1;

            // Atualizar a label com a quantidade de itens encontrados
            label8.Text = quantidadeItens.ToString();
        }

        //Alteração de item em grande escala
        private void AlterarGrandeEscala()
        {
            MySqlConnection Conexao;
            string item = Convert.ToString(comboBox2.Text);
            string sql = "";
            if (item == "Codigo")
            {
                sql = " SELECT * FROM Estoque WHERE CodigoItem = '" + textBox1.Text + "' ";
            }
            if (item == "Marca")
            {
                sql = "UPDATE Estoque SET Marca = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            if (item == "Descrição")
            {
                sql = "UPDATE Estoque SET Descricao = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            if (item == "Local")
            {
                sql = "UPDATE Estoque SET Localizacao = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            if (item == "Tipo")
            {
                sql = "UPDATE Estoque SET Tipo = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            if (item == "Item")
            {
                sql = "UPDATE Estoque SET Item = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            if (item == "Status")
            {
                sql = "UPDATE Estoque SET Stts = '" + textBox2.Text + "' where CodigoItem between '" + textBox4.Text + "' AND '" + textBox5.Text + "'";
            }
            try
            {

                Conexao = new MySqlConnection(data_source);
                MySqlCommand comando = new MySqlCommand(sql, Conexao);
                Conexao.Open();
                comando.ExecuteReader();
                MessageBox.Show("Atualização concluida");


                Conexao.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Certifique-se que todos os campos estão prenchidos!");

            }
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
        }

        //Alteração de Item de acordo com a seleção
        private void AlterarSelecionados()
        {
            string item = Convert.ToString(comboBox2.Text);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool Selecionado = Convert.ToBoolean(row.Cells["Seleção"].Value);
                if (Selecionado)
                {
                    string sql = "";
                    string codigoProduto = row.Cells["codigoItem"].Value.ToString();
                    string localAtual = row.Cells["Localizacao"].Value.ToString();
                    if (item == "Procedencia")
                    {
                        sql = "UPDATE Estoque SET Procedencia = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Marca")
                    {
                        sql = "UPDATE Estoque SET Marca = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Descrição")
                    {
                        sql = "UPDATE Estoque SET Descricao = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Local")
                    {
                        sql = "UPDATE Estoque SET Localizacao = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Tipo")
                    {
                        sql = "UPDATE Estoque SET Tipo = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Item")
                    {
                        sql = "UPDATE Estoque SET Item = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }
                    if (item == "Status")
                    {
                        sql = "UPDATE Estoque SET Stts = '" + textBox2.Text + "' WHERE codigoItem = '" + codigoProduto + "'";
                    }

                    MySqlConnection Conexao;
                    Conexao = new MySqlConnection(data_source);
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);
                    Conexao.Open();
                    comando.ExecuteReader();


                }
            }
            MessageBox.Show("Atualização concluida");
        }

        //Função para a pesquisa detalhada
        private void PesquisaDetalhada()
        {
            string item = Convert.ToString(comboBox1.Text);
            if (item != "")
            {
                try
                {
                    if (textBox1.Text != "")
                    {
                        var exibirVagas = "";
                        if (item == "Codigo")
                        {
                            exibirVagas = " SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE CodigoItem = '" + textBox1.Text + "' ";
                        }
                        if (item == "Marca")
                        {
                            exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE Marca = '" + textBox1.Text + "'";
                        }
                        if (item == "Descrição")
                        {
                            exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE Descricao = '" + textBox1.Text + "'";
                        }
                        if (item == "Local")
                        {
                            exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE Localizacao = '" + textBox1.Text + "'";
                        }
                        if (item == "Tipo")
                        {
                            exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE Tipo = '" + textBox1.Text + "'";
                        }
                        if (item == "Item")
                        {
                            exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque WHERE Item = '" + textBox1.Text + "'";
                        }
                        MySqlConnection Cn;

                        Cn = new MySqlConnection(data_source);
                        Cn.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(exibirVagas, Cn))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                dataGridView1.DataSource = dt;
                            }
                        }
                        Cn.Close();
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                    }
                    else MessageBox.Show("Preencha todos os campos para pesquisa detalhada!");
                }



                catch (Exception)
                {

                    throw;
                }
            }
            else MessageBox.Show("Preencha todos os campos para pesquisa detalhada!");


            this.AtualizarLabelQuantidadeItens();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox2.Text != "")
            {
                this.AlterarGrandeEscala();
            }
            else
            {
                MessageBox.Show("Certifique-se de que todos os campos estão prenchidos!");
            }
        }

        //Função para carregar datagridview com estoque completo
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection Cn;
                Cn = new MySqlConnection(data_source);
                Cn.Open();
                var exibirVagas = "SELECT codigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, datacadastro FROM Estoque";
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

            this.AtualizarLabelQuantidadeItens();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.Text != "")
            {
                this.AlterarSelecionados();
            }
            else
            {
                MessageBox.Show("Certifique-se de que todos os campos estão prenchidos!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PesquisaDetalhada();
        }
    }
}
