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
    public partial class FormAdicionarItem : Form
    {

        string data_source = "server=localhost;database=acs;uid=root;pwd=escoteiro362;port=3306";
        public FormAdicionarItem()
        {
            InitializeComponent();
        }

        //Função para cadastra o Item
        private void Cadastrar()
        {
            DateTime dataCadastro = DateTime.Now; 
            string dataCadastroFormatada = dataCadastro.ToString("dd/MM/yyyy HH:mm:ss");

            int quant = Convert.ToInt32(textBox3.Text);
            for (int i = 0; i < quant; i++)
            {
                MySqlConnection Conexao;

                try
                {


                    Conexao = new MySqlConnection(data_source);
                    string sql = "INSERT INTO Estoque (CodigoItem, Item, Descricao, Marca, Tipo, Localizacao, Stts, Procedencia, Quantidade, dataCadastro) VALUES (null, '" + textBox1.Text + "' ,'" + textBox2.Text + "' ,'" + textBox4.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "', 1, '" + dataCadastroFormatada + "')";
                    MySqlCommand comando = new MySqlCommand(sql, Conexao);
                    Conexao.Open();
                    comando.ExecuteReader();

                    Conexao.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
            MessageBox.Show("Cadastrado Concluído !");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                this.Cadastrar();
            }
            else
            {
                MessageBox.Show("Preencha todas as informações");
            }
        }
    }
}
