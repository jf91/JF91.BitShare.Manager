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
using System.Configuration;

namespace BitShare_Manager
{
    public partial class FORM_DEFINICOES_GESTAO_LIGACOES : Form
    {
        FORM_DEFINICOES FormDefinicoes_Objects = (FORM_DEFINICOES)Application.OpenForms["FORM_DEFINICOES"];

        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;

        DataTable TabelaDados = new DataTable();

        public FORM_DEFINICOES_GESTAO_LIGACOES()
        {
            InitializeComponent();
            PreencherListviewLigacoes();
        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUTTON_GESTAOLIGACOES_GUARDARLIGACAO_Click(object sender, EventArgs e)
        {
            if (VerificarLigacao() == true)
            {
                LigacaoDB.Close();

                VariaveisGlobais();
                EncriptarHashKey();                
                InserirLigacao();
                CriarFicheirosConfig();
                ClearListView();
                PreencherListviewLigacoes();
                FormDefinicoes_Objects.ClearListView();
                FormDefinicoes_Objects.PreencherListviewLigacoes();
            }

            if (VerificarLigacao() == false)
            {
                MessageBox.Show("A ligação falhou, Verifique as credenciais", "Ligação Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PreencherListviewLigacoes()
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
                LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Items.Add(ROW);

                var ROW2 = new ListViewItem();
                ROW2.Text = Reader["nome"].ToString();
                ROW2.SubItems.Add(Reader["endereco"].ToString());
                ROW2.SubItems.Add(Reader["porta"].ToString());
                LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Items.Add(ROW2);
            }

            LigacaoDB.Close();
        }

        public void ClearListView()
        {
            LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Items.Clear();
            LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Items.Clear();
        }

        public bool VerificarLigacao()
        {
            try
            {
                string Endereco = TEXTBOX_GESTAOLIGACOES_ENDERECO.Text;
                string Porta = TEXTBOX_GESTAOLIGACOES_PORTA.Text;
                string User = TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text;
                string Pass = TEXTBOX_GESTAOLIGACOES_PASSWORD.Text;

                string Testar = "datasource=" + Endereco + ";port=" + Porta + ";username=" + User + " ;password=" + Pass + "";

                LigacaoDB.ConnectionString = Testar;

                LigacaoDB.Open();

                return true;
            }

            catch (Exception EX)
            {
                LigacaoDB.Close();
                LigacaoDB.ConnectionString = Properties.Settings.Default.connectionString;
                return false;
            }
        }

        public void VariaveisGlobais()
        {
            CLASS_GLOBAL_VARIABLES.Endereco = TEXTBOX_GESTAOLIGACOES_ENDERECO.Text;
            CLASS_GLOBAL_VARIABLES.Porta = TEXTBOX_GESTAOLIGACOES_PORTA.Text;
            CLASS_GLOBAL_VARIABLES.Utilizador = TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text;
            CLASS_GLOBAL_VARIABLES.Password = TEXTBOX_GESTAOLIGACOES_PASSWORD.Text;
            CLASS_GLOBAL_VARIABLES.Servidor = "datasource=" + TEXTBOX_GESTAOLIGACOES_ENDERECO.Text + ";port=" + TEXTBOX_GESTAOLIGACOES_PORTA.Text + ";username=" + TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text + ";password=" + TEXTBOX_GESTAOLIGACOES_PASSWORD.Text + "";
            CLASS_GLOBAL_VARIABLES.HashKey = CLASS_GLOBAL_VARIABLES.Servidor;
            CLASS_GLOBAL_VARIABLES.BD = TEXTBOX_GESTAOLIGACOES_BD.Text;
        }
        
        public void EncriptarHashKey()
        {
            string ENCRYPT_ConnectionConfig = CLASS_GLOBAL_VARIABLES.HashKey;
            byte[] ENCRYPT_ConnectionConfig_Buffer;

            int ENCRYPT_ConnectionConfig_BytesRead;
            long ENCRYPT_ConnectionConfig_Size;

            byte[] ENCRYPT_ConnectionConfig_ByteString = Encoding.UTF8.GetBytes(CLASS_GLOBAL_VARIABLES.HashKey);

            MemoryStream ENCRYPT_ConnectionConfig_ByteStringStream = new MemoryStream(ENCRYPT_ConnectionConfig_ByteString);

            ENCRYPT_ConnectionConfig_Size = ENCRYPT_ConnectionConfig_ByteStringStream.Length;

            using (HashAlgorithm ENCRYPT_ConnectionConfig_Hasher = MD5.Create())
            {
                do
                {
                    ENCRYPT_ConnectionConfig_Buffer = new byte[4096];

                    ENCRYPT_ConnectionConfig_BytesRead = ENCRYPT_ConnectionConfig_ByteStringStream.Read(ENCRYPT_ConnectionConfig_Buffer, 0, ENCRYPT_ConnectionConfig_Buffer.Length);

                    ENCRYPT_ConnectionConfig_Hasher.TransformBlock(ENCRYPT_ConnectionConfig_Buffer, 0, ENCRYPT_ConnectionConfig_BytesRead, null, 0);
                }
                while (ENCRYPT_ConnectionConfig_BytesRead != 0);

                ENCRYPT_ConnectionConfig_Hasher.TransformFinalBlock(ENCRYPT_ConnectionConfig_Buffer, 0, 0);

                CLASS_GLOBAL_VARIABLES.HashKey = MakeHashString(ENCRYPT_ConnectionConfig_Hasher.Hash);
            }
        }

        private static string MakeHashString(byte[] hashBytes)
        {
            StringBuilder hash = new StringBuilder(32);

            foreach (byte b in hashBytes)
                hash.Append(b.ToString("X2").ToLower());

            return hash.ToString();
        }        

        public void InserirLigacao()
        {
            try
            {
                LigacaoDB.Open();

                string Query_InserirLigacao = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + ".bs_bitsharemanager_connections(`nome`,`endereco`,`porta`,`hash_key`) VALUES('" + TEXTBOX_GESTAOLIGACOES_NOME.Text + "','" + TEXTBOX_GESTAOLIGACOES_ENDERECO.Text + "','" + TEXTBOX_GESTAOLIGACOES_PORTA.Text + "','" + CLASS_GLOBAL_VARIABLES.HashKey + "')";
                MySqlCommand Comando_InserirLigacao = new MySqlCommand(Query_InserirLigacao, LigacaoDB);
                Reader = Comando_InserirLigacao.ExecuteReader();
                Reader.Close();


                string Query_InserirUtilizador = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + ".bs_bitsharemanager_users(`nome`,`pass`,`hash_key`,`last_login`) VALUES ('" + TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text + "','" + TEXTBOX_GESTAOLIGACOES_PASSWORD.Text + "','" + CLASS_GLOBAL_VARIABLES.HashKey + "',1)";
                MySqlCommand Comando_InserirUtilizador = new MySqlCommand(Query_InserirUtilizador, LigacaoDB);
                Reader = Comando_InserirUtilizador.ExecuteReader();

                LigacaoDB.Close();                

                MessageBox.Show("Ligacao Guardada com Sucesso!", "Ligacao Guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show("A ligação à Base de Dados falhou, Verifique as credenciais", "Ligação Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CriarFicheirosConfig()
        {
            Directory.CreateDirectory(@".\data");

            using (StreamWriter HashConfig = new StreamWriter(@".\data\hash_config.bsm"))
            {
                HashConfig.WriteLine(CLASS_GLOBAL_VARIABLES.HashKey);
            }

            Properties.Settings.Default.connectionString = CLASS_GLOBAL_VARIABLES.Servidor;
            Properties.Settings.Default.bd = CLASS_GLOBAL_VARIABLES.BD;
            Properties.Settings.Default.bs_filmes = CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES;
            Properties.Settings.Default.bs_zoo_item = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM;
            Properties.Settings.Default.bs_zoo_category = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY;
            Properties.Settings.Default.bs_zoo_category_item = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM;
            Properties.Settings.Default.last_user = TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text;
            Properties.Settings.Default.connection_name = TEXTBOX_GESTAOLIGACOES_NOME.Text;
            Properties.Settings.Default.hash_key = CLASS_GLOBAL_VARIABLES.HashKey;

            if (RADIOBUTTON_GESTAOLIGACOES_LOCAL.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_Localhost;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_Localhost;
            }

            if (RADIOBUTTON_GESTAOLIGACOES_LAN.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_LAN;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_LAN;
            }

            if (RADIOBUTTON_GESTAOLIGACOES_WEB.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_Web;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_Web;
            }

            Properties.Settings.Default.Save();
        }

        private void BUTTON_GESTAOLIGACOES_REMOVERLIGACAO_Click(object sender, EventArgs e)
        {
            RemoverLigacao();
            ClearListView();
            PreencherListviewLigacoes();
            FormDefinicoes_Objects.ClearListView();
            FormDefinicoes_Objects.PreencherListviewLigacoes();
        }

        public void RemoverLigacao()
        {
            try
            {
                LigacaoDB.Open();

                int ID;

                string Nome = LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.SelectedItems[0].SubItems[0].Text;
                string Endereco = LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.SelectedItems[0].SubItems[1].Text;
                string Porta = LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.SelectedItems[0].SubItems[2].Text;

                string Query = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCONNECTIONS + " WHERE nome='" + Nome + "' AND endereco='" + Endereco + "' AND porta='" + Porta + "'";
                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);
                ID = Convert.ToInt32(Comando.ExecuteScalar());

                string QueryRemove = "DELETE FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCONNECTIONS + " WHERE id=" + ID + "";
                MySqlCommand ComandoRemove = new MySqlCommand(QueryRemove, LigacaoDB);
                ComandoRemove.ExecuteReader();

                LigacaoDB.Close();

                MessageBox.Show("Ligação removida com sucesso", "Ligação Removida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            { }
        }

        private void TEXTBOX_GESTAOLIGACOES_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_ENDERECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_PORTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_UTILIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_PASSWORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_GESTAOLIGACOES_NOME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_NOME.Text = TEXTBOX_GESTAOLIGACOES_NOME.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_GESTAOLIGACOES_ENDERECO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_ENDERECO.Text = TEXTBOX_GESTAOLIGACOES_ENDERECO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_GESTAOLIGACOES_PORTA_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_PORTA.Text = TEXTBOX_GESTAOLIGACOES_PORTA.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_GESTAOLIGACOES_UTILIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text = TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_GESTAOLIGACOES_PASSWORD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_PASSWORD.Text = TEXTBOX_GESTAOLIGACOES_PASSWORD.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_GESTAOLIGACOES_BD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GESTAOLIGACOES_BD.Text = TEXTBOX_GESTAOLIGACOES_BD.Text.Replace("\"", string.Empty);
        }
    }
}