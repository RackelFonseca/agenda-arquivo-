using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace aula_arquivo
{
    public partial class AGENDA : Form
    {
        string nomearquivo = "aluno.txt";
        string caminhoorigem= "C:/rackel/";
        string caminhodestino = " D:/Rackel/caminhodestino";
        public AGENDA()


        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtnomearquivo.Text = nomearquivo;
            txtcaminhoorigem.Text =caminhoorigem;
            txtcaminhodestino.Text = caminhodestino;
        }

        private void bntadicionar_Click(object sender, EventArgs e)
        {
            lblista.Items.Add(txtnome.Text.Trim());//adicionando o nome a lista
            lblista.Items.Add(txtelefone.Text.Trim());
            lblista.Items.Add(txtendereco.Text.Trim());
            lblista.Items.Add("===========================");

            txtnome.Text = "";
            txtendereco.Text = "";
            txtelefone.Text = "";

            txtnome.Focus();
        }
        //botam executar
        private void bntexecutar_Click(object sender, EventArgs e)
        {
            //salva
            if (rbsalva.Checked == true)
            {
                StreamWriter texto = new StreamWriter(caminhoorigem + nomearquivo);

                for (int i = 0; i < lblista.Items.Count; i++)
                {

                    texto.WriteLine(lblista.Items[i].ToString());

                }
                texto.Close();
                MessageBox.Show("arquivo gerado com sucesso!!!");


            }
            //copia
            else if (rbcopia.Checked == true)
            {
                if (Directory.Exists(caminhodestino))
                {
                    if (File.Exists(caminhodestino + nomearquivo) == true)
                    {
                        File.Delete(caminhodestino + nomearquivo);
                    }
                    File.Copy(caminhoorigem + nomearquivo, caminhodestino + nomearquivo);
                }
                else
                {
                    Directory.CreateDirectory(caminhodestino);
                    File.Copy(caminhoorigem + nomearquivo, caminhodestino + nomearquivo);
                }
                MessageBox.Show("Arquivo copiado com sucesso");
            }
            //apaga
            else if (rbapaga.Checked == true)
            {
                if(File.Exists(caminhoorigem+nomearquivo) == true)
                {
                    File.Delete(caminhoorigem+nomearquivo);
                    MessageBox.Show("Arquivo excluido!!!");

                }
                else
                {
                    MessageBox.Show("Arquivo não encontrado!!!");
                }
            }
        }

        private void btnlimpa_Click(object sender, EventArgs e)
        {
            lblista.Items.Clear();//limpar o texto
        }

        private void rbmove_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
