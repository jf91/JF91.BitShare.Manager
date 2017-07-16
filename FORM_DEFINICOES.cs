using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace BitShare_Manager
{
    public partial class FORM_DEFINICOES : Form
    {
        FORM_INICIO FormInicio_Objects = (FORM_INICIO)Application.OpenForms["FORM_INICIO"];

        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();        

        MySqlDataReader Reader;
        MySqlDataReader Reader2;

        DataTable TabelaDados = new DataTable();
        DataSet DS = new DataSet();

        string TestarConexao;
        string IdConnection;

        public FORM_DEFINICOES()
        {
            InitializeComponent();
            
            PreencherListviewLigacoes();

            Preencher_TEXTBOXs_InfoTabelas();
        }

        private void MENUSTRIP_FORMDEFINICOES_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            //CLASS_GLOBAL_VARIABLES.EnderecoDB = "datasource=" + TEXTBOX_FORMDEFINICOES_ENDERECO.Text + ";port=" + TEXTBOX_FORMDEFINICOES_PORTA.Text + ";username=" + TEXTBOX_FORMDEFINICOES_USERNAME.Text + ";password=" + TEXTBOX_FORMDEFINICOES_PASSWORD.Text;
            this.Close();
        }

        private void RADIOBUTTON_FORMDEFINICOES_DARK_CheckedChanged(object sender, EventArgs e)
        {
            //Assembly Skin = Assembly.GetExecutingAssembly();
            //Stream Skin2;
            //Skin2 = Skin.GetManifestResourceStream("Office2007 (Black).vssf");

            //STYLER.LoadVisualStyle(Skin2);
        }

        public void PreencherListviewLigacoes()
        {
            try
            {
                LigacaoDB.Open();

                string Query = "SELECT nome,endereco,porta FROM " + CLASS_GLOBAL_VARIABLES.BD + ".bs_bitsharemanager_connections";
                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    var ROW = new ListViewItem();
                    ROW.Text = Reader["nome"].ToString();
                    ROW.SubItems.Add(Reader["endereco"].ToString());
                    ROW.SubItems.Add(Reader["porta"].ToString());
                    LISTVIEW_DEFINICOES_LIGACAO.Items.Add(ROW);
                }

                LigacaoDB.Close();
            }

            catch(Exception EX)
            { }
        }

        private void MENUSTRIP_FORMDEFINICOES_BUTTON_GESTAOLIGACOES_Click(object sender, EventArgs e)
        {
            FORM_DEFINICOES_GESTAO_LIGACOES FormGestaoLigacoes = new FORM_DEFINICOES_GESTAO_LIGACOES();
            FormGestaoLigacoes.ShowDialog();
        }

        private void BUTTON_DEFINICOES_LIGACAO_GUARDAR_Click(object sender, EventArgs e)
        {
            if (VerificarLigacao() == true)
            {
                Properties.Settings.Default.connectionString = CLASS_GLOBAL_VARIABLES.Servidor;
                Properties.Settings.Default.last_user = TEXTBOX_DEFINICOES_UTILIZADOR.Text;
                Properties.Settings.Default.connection_name = LISTVIEW_DEFINICOES_LIGACAO.SelectedItems[0].SubItems[0].Text;

                Properties.Settings.Default.Save();

                LigacaoDB.Close();

                MessageBox.Show("Definições alteradas com sucesso!", "Definições Alteradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (VerificarLigacao() == false)
            {
                MessageBox.Show("A ligação falhou, Verifique as credenciais", "Ligação Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool VerificarLigacao()
        {
            try
            {
                string Endereco = LISTVIEW_DEFINICOES_LIGACAO.SelectedItems[0].SubItems[1].Text;
                string Porta = LISTVIEW_DEFINICOES_LIGACAO.SelectedItems[0].SubItems[2].Text;
                string User = TEXTBOX_DEFINICOES_UTILIZADOR.Text;
                string Pass = TEXTBOX_DEFINICOES_PASSWORD.Text;

                string Testar = "datasource=" + Endereco + ";port=" + Porta + ";username=" + User + " ;password=" + Pass + "";

                LigacaoDB.ConnectionString = Testar;
                CLASS_GLOBAL_VARIABLES.Servidor = Testar;

                LigacaoDB.Open();

                return true;
            }

            catch (Exception EX)
            {                
                LigacaoDB.ConnectionString = Properties.Settings.Default.connectionString;
                return false;
            }
        }

        public void ClearListView()
        {
            LISTVIEW_DEFINICOES_LIGACAO.Items.Clear();
        }

        private void BUTTON_DEFINICOES_DB_GUARDAR_Click(object sender, EventArgs e)
        {
            GuardarInfoTabelas();
        }

        public void GuardarInfoTabelas()
        {
            CLASS_GLOBAL_VARIABLES.BD = TEXTBOX_DEFINICOES_DB.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES = TEXTBOX_DEFINICOES_CATALOGO.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES = TEXTBOX_DEFINICOES_BSFILMES.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM = TEXTBOX_DEFINICOES_BSZOOITEM.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY = TEXTBOX_DEFINICOES_BSZOOCATEGORY.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM = TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSCONNECTIONS = TEXTBOX_DEFINICOES_CONNECTIONS.Text;
            CLASS_GLOBAL_VARIABLES.Tabela_BSUSERS = TEXTBOX_DEFINICOES_USERS.Text;

            Properties.Settings.Default.bd = TEXTBOX_DEFINICOES_DB.Text;
            Properties.Settings.Default.bs_catalogo_filmes = TEXTBOX_DEFINICOES_CATALOGO.Text;
            Properties.Settings.Default.bs_filmes = TEXTBOX_DEFINICOES_BSFILMES.Text;
            Properties.Settings.Default.bs_zoo_item = TEXTBOX_DEFINICOES_BSZOOITEM.Text;
            Properties.Settings.Default.bs_zoo_category = TEXTBOX_DEFINICOES_BSZOOCATEGORY.Text;
            Properties.Settings.Default.bs_zoo_category_item = TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM.Text;
            Properties.Settings.Default.bs_connections = TEXTBOX_DEFINICOES_CONNECTIONS.Text;
            Properties.Settings.Default.bs_users = TEXTBOX_DEFINICOES_USERS.Text;

            Properties.Settings.Default.Save();

            MessageBox.Show("Definições alteradas com sucesso!", "Definições Alteradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Preencher_TEXTBOXs_InfoTabelas()
        {
            TEXTBOX_DEFINICOES_DB.Text = Properties.Settings.Default.bd;
            TEXTBOX_DEFINICOES_CATALOGO.Text = Properties.Settings.Default.bs_catalogo_filmes;
            TEXTBOX_DEFINICOES_BSFILMES.Text = Properties.Settings.Default.bs_filmes;
            TEXTBOX_DEFINICOES_BSZOOITEM.Text = Properties.Settings.Default.bs_zoo_item;
            TEXTBOX_DEFINICOES_BSZOOCATEGORY.Text = Properties.Settings.Default.bs_zoo_category;
            TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM.Text = Properties.Settings.Default.bs_zoo_category_item;
            TEXTBOX_DEFINICOES_CONNECTIONS.Text = Properties.Settings.Default.bs_connections;
            TEXTBOX_DEFINICOES_USERS.Text = Properties.Settings.Default.bs_users;
        }

        private void BUTTON_RESET_Click(object sender, EventArgs e)
        {
            //FunctionRESET();

            DialogResult DR = MessageBox.Show("Tem a certeza que deseja restaurar as definições de origem? Todos os dados de ligação e utilizadores da aplicação ficarão anulados. Terá de re-configurar as definições de acesso à base de dados e às tabelas", "Tem a certeza?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                FORM_RESET RESET = new FORM_RESET();
                RESET.ShowDialog();
            }
        }

        public void FunctionRESET()
        {
            CLASS_GLOBAL_VARIABLES.BD = "";
            CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES = "bs_filmes";
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM = "bs_zoo_item";
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY = "bs_zoo_category";
            CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM = "bs_zoo_category_item";
            CLASS_GLOBAL_VARIABLES.Tabela_BSCONNECTIONS = "bs_bitsharemanager_connections";
            CLASS_GLOBAL_VARIABLES.Tabela_BSUSERS = "bs_bitsharemanager_users";

            Properties.Settings.Default.connectionString = null;
            Properties.Settings.Default.bd = null;
            Properties.Settings.Default.bs_filmes = null;
            Properties.Settings.Default.bs_zoo_item = null;
            Properties.Settings.Default.bs_zoo_category = null;
            Properties.Settings.Default.bs_zoo_category_item = null;
            Properties.Settings.Default.hash_key = null;
            Properties.Settings.Default.last_user = null;
            Properties.Settings.Default.first_launch = true;
            Properties.Settings.Default.bs_connections = null;
            Properties.Settings.Default.bs_users = null;

            Properties.Settings.Default.Save();
        }

        private void FORM_DEFINICOES_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            FORM_INICIO FormInicio = new FORM_INICIO();
            FormInicio.Visible = true;
        }

        private void TEXTBOX_DEFINICOES_UTILIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_PASSWORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_DB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_BSFILMES_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_BSZOOITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_BSZOOCATEGORY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_CATALOGO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_CONNECTIONS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_USERS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_DEFINICOES_UTILIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_UTILIZADOR.Text = TEXTBOX_DEFINICOES_UTILIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_PASSWORD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_PASSWORD.Text = TEXTBOX_DEFINICOES_PASSWORD.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_DB_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_DB.Text = TEXTBOX_DEFINICOES_DB.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_BSFILMES_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_BSFILMES.Text = TEXTBOX_DEFINICOES_BSFILMES.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_BSZOOITEM_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_BSZOOITEM.Text = TEXTBOX_DEFINICOES_BSZOOITEM.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_BSZOOCATEGORY_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_BSZOOCATEGORY.Text = TEXTBOX_DEFINICOES_BSZOOCATEGORY.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM.Text = TEXTBOX_DEFINICOES_BSZOOCATEGORYITEM.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_CATALOGO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_CATALOGO.Text = TEXTBOX_DEFINICOES_CATALOGO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_CONNECTIONS_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_CONNECTIONS.Text = TEXTBOX_DEFINICOES_CONNECTIONS.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_DEFINICOES_USERS_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_DEFINICOES_USERS.Text = TEXTBOX_DEFINICOES_USERS.Text.Replace("\"", string.Empty);
        }
    }
}
