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
    public partial class FORM_FirstLaunchConfig : Form
    {
        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;
        MySqlDataReader Reader2;

        DataTable TabelaDados = new DataTable();

        public string String_ConnectionConfig;
        public string String_UserConfig;
        public string String_UserPassConfig;

        public FORM_FirstLaunchConfig()
        {
            InitializeComponent();
        }    

        private void BUTTON_FIRSTLAUNCH_GUARDARLIGACAO_Click(object sender, EventArgs e)
        {
            VariaveisGlobais();

            try
            {
                LigacaoDB.ConnectionString = CLASS_GLOBAL_VARIABLES.Servidor;
                LigacaoDB.Open();
            }

            catch (Exception EX)
            {
                MessageBox.Show("A ligação falhou, Verifique as credenciais", "Ligação Falhada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (LigacaoDB.State == ConnectionState.Open)
            {                
                EncriptarHashKey();
                CriarFicheirosConfig();
                GuardarLigacao();
            }
        }

        public void VariaveisGlobais()
        {
            CLASS_GLOBAL_VARIABLES.Endereco = TEXTBOX_FIRSTLAUNCH_ENDERECO.Text;            
            CLASS_GLOBAL_VARIABLES.Porta = TEXTBOX_FIRSTLAUNCH_PORTA.Text;
            CLASS_GLOBAL_VARIABLES.Utilizador = TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text;
            
            CLASS_GLOBAL_VARIABLES.Password = TEXTBOX_FIRSTLAUNCH_PASSWORD.Text;
            CLASS_GLOBAL_VARIABLES.Servidor = "datasource=" + TEXTBOX_FIRSTLAUNCH_ENDERECO.Text + ";port=" + TEXTBOX_FIRSTLAUNCH_PORTA.Text + ";username=" + TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text + ";password=" + TEXTBOX_FIRSTLAUNCH_PASSWORD.Text + "";

            CLASS_GLOBAL_VARIABLES.ServidorStoredProcedure = "Server=" + TEXTBOX_FIRSTLAUNCH_ENDERECO.Text + ";Database=" + TEXTBOX_FIRSTLAUNCH_BD.Text + ";Uid=" + TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text + ";Pwd=" + TEXTBOX_FIRSTLAUNCH_PASSWORD.Text + ";Use Procedure Bodies=false;";

            CLASS_GLOBAL_VARIABLES.HashKey = CLASS_GLOBAL_VARIABLES.Servidor;
            CLASS_GLOBAL_VARIABLES.BD = TEXTBOX_FIRSTLAUNCH_BD.Text;
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

        public void CriarFicheirosConfig()
        {
            string TipoLigacao;

            Directory.CreateDirectory(@".\data");

            using (StreamWriter HashConfig = new StreamWriter(@".\data\hash_config.bsm"))
            {
                HashConfig.WriteLine(CLASS_GLOBAL_VARIABLES.HashKey);
            }
            
            Properties.Settings.Default.connectionString = CLASS_GLOBAL_VARIABLES.Servidor;
            Properties.Settings.Default.connectionString_StoredProcedures = CLASS_GLOBAL_VARIABLES.ServidorStoredProcedure;
            Properties.Settings.Default.bd = CLASS_GLOBAL_VARIABLES.BD;
            Properties.Settings.Default.bs_catalogo_filmes = CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES;
            Properties.Settings.Default.bs_filmes = CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES;
            Properties.Settings.Default.bs_zoo_item = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM;
            Properties.Settings.Default.bs_zoo_category = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY;
            Properties.Settings.Default.bs_zoo_category_item = CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM;
            Properties.Settings.Default.bs_connections = CLASS_GLOBAL_VARIABLES.Tabela_BSCONNECTIONS;
            Properties.Settings.Default.bs_users = CLASS_GLOBAL_VARIABLES.Tabela_BSUSERS;
            Properties.Settings.Default.last_user = TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text;
            Properties.Settings.Default.connection_name = TEXTBOX_FIRSTLAUNCH_NOME.Text;

            if (RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_Localhost;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_Localhost;
            }

            if (RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_LAN;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_LAN;
            }

            if (RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Checked == true)
            {
                Properties.Settings.Default.movie_connection_type = CLASS_GLOBAL_VARIABLES.FILME_Tipo_Web;
                Properties.Settings.Default.cover_connection_type = CLASS_GLOBAL_VARIABLES.CAPA_Tipo_Web;
            }

        }

        public void GuardarLigacao()
        {
            try
            {
                string Query_InserirLigacao = "INSERT INTO " + TEXTBOX_FIRSTLAUNCH_BD.Text + ".bs_bitsharemanager_connections(`nome`,`endereco`,`porta`,`hash_key`) VALUES('" + TEXTBOX_FIRSTLAUNCH_NOME.Text + "','" + TEXTBOX_FIRSTLAUNCH_ENDERECO.Text + "','" + TEXTBOX_FIRSTLAUNCH_PORTA.Text + "','" + CLASS_GLOBAL_VARIABLES.HashKey + "')";
                MySqlCommand Comando_InserirLigacao = new MySqlCommand(Query_InserirLigacao, LigacaoDB);
                Reader = Comando_InserirLigacao.ExecuteReader();
                Reader.Close();


                string Query_InserirUtilizador = "INSERT INTO " + TEXTBOX_FIRSTLAUNCH_BD.Text + ".bs_bitsharemanager_users(`nome`,`pass`,`hash_key`,`last_login`) VALUES ('" + TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text + "','" + TEXTBOX_FIRSTLAUNCH_PASSWORD.Text + "','" + CLASS_GLOBAL_VARIABLES.HashKey + "',1)";
                MySqlCommand Comando_InserirUtilizador = new MySqlCommand(Query_InserirUtilizador, LigacaoDB);
                Reader = Comando_InserirUtilizador.ExecuteReader();

                LigacaoDB.Close();

                Properties.Settings.Default.last_user = TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text;
                Properties.Settings.Default.hash_key = CLASS_GLOBAL_VARIABLES.HashKey;
                Properties.Settings.Default.first_launch = false;

                Properties.Settings.Default.Save();

                this.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private static string MakeHashString(byte[] hashBytes)
        {
            StringBuilder hash = new StringBuilder(32);

            foreach (byte b in hashBytes)
                hash.Append(b.ToString("X2").ToLower());

            return hash.ToString();
        }

        private void TEXTBOX_FIRSTLAUNCH_BD_MouseClick(object sender, MouseEventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_BD.Text = "";
        }

        private void TEXTBOX_FIRSTLAUNCH_NOME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_NOME.Text = TEXTBOX_FIRSTLAUNCH_NOME.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        public bool ActivarBotaoGuardar()
        {
            if (TEXTBOX_FIRSTLAUNCH_NOME.Text != "" && TEXTBOX_FIRSTLAUNCH_ENDERECO.Text != "" && TEXTBOX_FIRSTLAUNCH_PORTA.Text != "" && TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text != "" && TEXTBOX_FIRSTLAUNCH_PASSWORD.Text != "" && TEXTBOX_FIRSTLAUNCH_BD.Text != "" && RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Checked == true || RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Checked == true || RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Checked == true)
            {
                return true;
            }

            else
            {
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = false;
                return false;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_ENDERECO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_ENDERECO.Text = TEXTBOX_FIRSTLAUNCH_ENDERECO.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void TEXTBOX_FIRSTLAUNCH_PORTA_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_PORTA.Text = TEXTBOX_FIRSTLAUNCH_PORTA.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void TEXTBOX_FIRSTLAUNCH_UTILIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text = TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void TEXTBOX_FIRSTLAUNCH_PASSWORD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_PASSWORD.Text = TEXTBOX_FIRSTLAUNCH_PASSWORD.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void TEXTBOX_FIRSTLAUNCH_BD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_FIRSTLAUNCH_BD.Text = TEXTBOX_FIRSTLAUNCH_BD.Text.Replace("\"", string.Empty);

            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB_CheckedChanged(object sender, EventArgs e)
        {
            if (ActivarBotaoGuardar() == true)
                BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = true;
        }

        private void TEXTBOX_FIRSTLAUNCH_NOME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_ENDERECO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_PORTA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_UTILIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_PASSWORD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_FIRSTLAUNCH_BD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }
    }
}
