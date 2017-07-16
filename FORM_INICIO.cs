using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
using System.Security.Cryptography;


namespace BitShare_Manager
{
    public partial class FORM_INICIO : Form
    {
        FORM_GESTAO_FILMES FormGestaoFilmes_Objects = (FORM_GESTAO_FILMES)Application.OpenForms["FORM_GESTAO_FILMES"];

        FORM_GESTAO_FILMES_GERIRCATEGORIAS FormGerirCategorias_Objects = (FORM_GESTAO_FILMES_GERIRCATEGORIAS)Application.OpenForms["FORM_GESTAO_FILMES_GERIRCATEGORIAS"];

        //int Endereco; 

        string HashKey = "";

        string Connection = "";
        string User = "";
        string Pass = "";

        public FORM_INICIO()
        {
            InitializeComponent();

            if (VerificarFirstLaunch() == true)
            {
                DialogResult DefinirDados = MessageBox.Show("Não existe configuração de ligação à base de dados. Deseja defini-la agora? \n Nota: Não poderá aceder à base de dados sem nenhuma configuração definida", "Configurar Ligação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DefinirDados == DialogResult.Yes)
                {
                    FORM_FirstLaunchConfig FirstLaunchConfig = new FORM_FirstLaunchConfig();
                    FirstLaunchConfig.ShowDialog();
                }
            }

            if (VerificarFirstLaunch() == false)
            {
                if (VerificarFicheiros() == false)
                {
                    Directory.CreateDirectory(@".\data");

                    using (StreamWriter HashConfig = new StreamWriter(@".\data\hash_config.bsm"))
                    {
                        HashConfig.WriteLine(Properties.Settings.Default.hash_key);
                    }

                    LerHash();
                    LerConnectionString();
                    LABEL_LIGACAOACTUAL.Text = "Ligado a: " + Properties.Settings.Default.connection_name + " como: " + Properties.Settings.Default.last_user;
                }

                if (VerificarFicheiros() == true)
                {
                    LerHash();
                    LerConnectionString();
                    LABEL_LIGACAOACTUAL.Text = "Ligado a: " + Properties.Settings.Default.connection_name + " como: " + Properties.Settings.Default.last_user;
                }
            }
        }

        private void MENUSTRIP_INICIO_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PICTUREBOX_FORMINICIO_FILMES_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_GESTAO_FILMES FormGestaoFilmes = new FORM_GESTAO_FILMES();
            FormGestaoFilmes.ShowDialog();
        }

        private void LABEL_FORMINICIO_FILMES_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_GESTAO_FILMES FormGestaoFilmes = new FORM_GESTAO_FILMES();
            FormGestaoFilmes.ShowDialog();
        }

        private void FORM_INICIO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BUTTON_FORMINICIO_DEFINICOES_Click(object sender, EventArgs e)
        {
            this.Hide();
            FORM_DEFINICOES FormDefinicoes = new FORM_DEFINICOES();
            FormDefinicoes.ShowDialog();
        }

        private void LISTBOX_FORMINICIO_ENDERECO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (LISTBOX_FORMINICIO_ENDERECO.SelectedIndex == 0)
            //{
            //    CLASS_GLOBAL_VARIABLES.Endereco = "datasource=192.168.1.88;port=3306;username=root;password=haze6n!root";
            //    //Endereco = 1;
            //}

            //if (LISTBOX_FORMINICIO_ENDERECO.SelectedIndex == 1)
            //{
            //    CLASS_GLOBAL_VARIABLES.Endereco = "datasource=bitcorp.servegame.com;port=3306;username=root;password=haze6n!root";
            //    //Endereco = 2;
            //}
        }

        private void FORM_INICIO_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        public bool VerificarFirstLaunch()
        {
            if (Properties.Settings.Default.first_launch == true)
                return true;
            else
                return false;
        }

        public bool VerificarFicheiros()
        {
            if (File.Exists(@".\data\hash_config.bsm") == true)
            {
                return true;                
            }

            else
            {
                return false;
            }                    
        }

        public void LerHash()
        {
            HashKey = Properties.Settings.Default.hash_key;

            using (StreamReader HashConfig = new StreamReader(@".\data\hash_config.bsm"))
            {
                if (HashKey != HashConfig.ReadLine())
                {
                    HashConfig.Close();

                    using (StreamWriter HashFixConfig = new StreamWriter(@".\data\hash_config.bsm"))
                    {
                        HashFixConfig.WriteLine(Properties.Settings.Default.hash_key);
                        MessageBox.Show("O chave de autenticação (hash) está corrupta ou foi alterada por terceiros. De modo a garantir a segurança da ligação, restauramos a ultima chave de autenticação guardada.", "Chave de Autenticação corrupta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }          
        }

        public void LerConnectionString()
        {
            CLASS_GLOBAL_VARIABLES.Servidor = Properties.Settings.Default.connectionString;
            CLASS_GLOBAL_VARIABLES.ServidorStoredProcedure = Properties.Settings.Default.connectionString_StoredProcedures;
            CLASS_GLOBAL_VARIABLES.BD = Properties.Settings.Default.bd;
            CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES = Properties.Settings.Default.bs_catalogo_filmes;
            CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES = Properties.Settings.Default.bs_filmes;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM = Properties.Settings.Default.bs_zoo_item;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY = Properties.Settings.Default.bs_zoo_category;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM = Properties.Settings.Default.bs_zoo_category_item;

            CLASS_GLOBAL_VARIABLES.HashKey = Properties.Settings.Default.hash_key;
        }

        private void SOBRE_Click(object sender, EventArgs e)
        {
            FORM_ABOUT SOBRE = new FORM_ABOUT();
            SOBRE.ShowDialog();
        }
    }
}
