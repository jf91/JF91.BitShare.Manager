using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace BitShare_Manager
{
    public partial class FORM_CATALOGO_FILMES : Form
    {
        FORM_GESTAO_FILMES FormGestaoFilmes = (FORM_GESTAO_FILMES)Application.OpenForms["FORM_GESTAO_FILMES"];

        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);
        MySqlConnection LigacaoDB_StoredProcedures = new MySqlConnection(CLASS_GLOBAL_VARIABLES.ServidorStoredProcedure);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;

        public DataTable TabelaDados = new DataTable();

        // STRINGS PARA PASSAR PARA O FORM DE INSERCAO
        public string Titulo;
        public string TituloPT;
        public string Genero;
        public string Data;
        public string Realizador;
        public string Actores;
        public string Sinopse;
        public string IMDB;
        public string Capa;
        public int Copy_Enviado;
        //////////////////////////////////////////////

        public int IdAlterar_SelectListBox;

        public FORM_CATALOGO_FILMES()
        {
            InitializeComponent();

            DATAGRIDVIEW_FILMES.AutoGenerateColumns = false;
            DATAGRIDVIEW_FILMES.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DATAGRIDVIEW_REMOVER.AutoGenerateColumns = false;
            DATAGRIDVIEW_REMOVER.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DATAGRIDVIEW_ALTERAR.AutoGenerateColumns = false;
            DATAGRIDVIEW_ALTERAR.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            PreencherDataGridView();
        }        

        private void MENUSTRIP_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DATAGRIDVIEW_FILMES_SelectionChanged(object sender, EventArgs e)
        {
            PreencherTextBoxs();
        }

        private void DATAGRIDVIEW_REMOVER_SelectionChanged(object sender, EventArgs e)
        {
            PreencherTextBoxs_Remover();
        }

        private void DATAGRIDVIEW_ALTERAR_SelectionChanged(object sender, EventArgs e)
        {
            PreencherTextBoxs_Alterar();
        }

        private void TEXTBOX_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_PROCURAR.Text = TEXTBOX_PROCURAR.Text.Replace("\"", string.Empty);
            Procurar_Catalogo();
        }

        private void TEXTBOX_REMOVER_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_REMOVER_PROCURAR.Text = TEXTBOX_REMOVER_PROCURAR.Text.Replace("\"", string.Empty);
            Procurar_Remover();
        }

        private void TEXTBOX_ALTERAR_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_PROCURAR.Text = TEXTBOX_ALTERAR_PROCURAR.Text.Replace("\"", string.Empty);
            Procurar_Alterar();
        }
        
        private void BUTTON_COPY_Click(object sender, EventArgs e)
        {
            PassarParaFormInsercao();
        }

        private void BUTTON_ALTERAR_CAPA_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Cover2 = new OpenFileDialog();
                Cover2.AutoUpgradeEnabled = false;

                Cover2.InitialDirectory = Properties.Settings.Default.cover_connection_type.ToString();

                string Path;
                string Ficheiro;

                if (Cover2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Path = Cover2.FileName;
                    Ficheiro = Cover2.SafeFileName;

                    PICTUREBOX_ALTERAR_CAPA.Image = Image.FromFile(Path);
                    TEXTBOX_ALTERAR_CAPA.Text = Ficheiro;
                }
            }

            catch(Exception EX)
            { }
        }

        private void BUTTON_ALTERAR_Click(object sender, EventArgs e)
        {
            try
            {
                IdAlterar_SelectListBox = DATAGRIDVIEW_ALTERAR.SelectedRows[0].Index;
            }

            catch(Exception)
            { }
            Alterar();
            ClearDataGridView();
            PreencherDataGridView();
            DATAGRIDVIEW_ALTERAR.CurrentRow.Selected = false;
            DATAGRIDVIEW_ALTERAR.CurrentCell = this.DATAGRIDVIEW_ALTERAR[0, IdAlterar_SelectListBox];
        }

        private void BUTTON_REMOVER_Click(object sender, EventArgs e)
        {
            Remover();
            ClearDataGridView();
            PreencherDataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inserir();
            ClearDataGridView();
            PreencherDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog Cover = new OpenFileDialog();
                Cover.AutoUpgradeEnabled = false;

                Cover.InitialDirectory = Properties.Settings.Default.cover_connection_type.ToString();

                string Path;
                string Ficheiro;

                if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Path = Cover.FileName;
                    Ficheiro = Cover.SafeFileName;

                    PICTUREBOX_ADICIONAR_CAPA.Image = Image.FromFile(Path);
                    TEXTBOX_ADICIONAR_CAPA.Text = Ficheiro;
                }
            }

            catch(Exception EX)
            { }
        }

        private void TEXTBOX_ALTERAR_TITULO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_TITULOPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_ANO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_IMDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_REALIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_ACTORES_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_SINOPSE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_CAPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_PROCURAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_REMOVER_PROCURAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERAR_PROCURAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_TITULO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_TITULOPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_ANO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_IMDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_REALIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_ACTORES_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_SINOPSE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_CAPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONAR_TITULO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_TITULO.Text = TEXTBOX_ADICIONAR_TITULO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_TITULOPT_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_TITULOPT.Text = TEXTBOX_ADICIONAR_TITULOPT.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_ANO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_ANO.Text = TEXTBOX_ADICIONAR_ANO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_IMDB_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_IMDB.Text = TEXTBOX_ADICIONAR_IMDB.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_REALIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_REALIZADOR.Text = TEXTBOX_ADICIONAR_REALIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_ACTORES_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_ACTORES.Text = TEXTBOX_ADICIONAR_ACTORES.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_SINOPSE_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_SINOPSE.Text = TEXTBOX_ADICIONAR_SINOPSE.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONAR_CAPA_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONAR_CAPA.Text = TEXTBOX_ADICIONAR_CAPA.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_TITULO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_TITULO.Text = TEXTBOX_ALTERAR_TITULO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_TITULOPT_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_TITULOPT.Text = TEXTBOX_ALTERAR_TITULOPT.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_ANO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_ANO.Text = TEXTBOX_ALTERAR_ANO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_IMDB_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_IMDB.Text = TEXTBOX_ALTERAR_IMDB.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_REALIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_REALIZADOR.Text = TEXTBOX_ALTERAR_REALIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_ACTORES_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_ACTORES.Text = TEXTBOX_ALTERAR_ACTORES.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_SINOPSE_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_SINOPSE.Text = TEXTBOX_ALTERAR_SINOPSE.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERAR_CAPA_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERAR_CAPA.Text = TEXTBOX_ALTERAR_CAPA.Text.Replace("\"", string.Empty);
        }


        public void PreencherDataGridView()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            try
            {
                LigacaoDB.Open();

                string Query = "SELECT ID,Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " ORDER BY ID ASC";

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Adapter.SelectCommand = Comando;

                Adapter.Fill(TabelaDados);

                BindingSource ColecaoDados = new BindingSource();

                DATAGRIDVIEW_FILMES.DataSource = TabelaDados;
                DATAGRIDVIEW_REMOVER.DataSource = TabelaDados;
                DATAGRIDVIEW_ALTERAR.DataSource = TabelaDados;

                Adapter.Update(TabelaDados);

                LigacaoDB.Close();
            }

            catch(Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        #region FUNÇÕES DESNECESSÁRIAS

        //public void PreencherDataGridViewMain()
        //{
        //    if (LigacaoDB.State == ConnectionState.Open)
        //        LigacaoDB.Close();

        //    try
        //    {
        //        LigacaoDB.Open();

        //        string Query = "SELECT ID,Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " ORDER BY ID ASC";

        //        MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

        //        Adapter.SelectCommand = Comando;

        //        Adapter.Fill(TabelaDados);

        //        BindingSource ColecaoDados = new BindingSource();

        //        DATAGRIDVIEW_FILMES.DataSource = TabelaDados;

        //        Adapter.Update(TabelaDados);

        //        LigacaoDB.Close();
        //    }

        //    catch (Exception EX)
        //    {
        //        MessageBox.Show(EX.Message);
        //    }
        //}

        //public void PreencherDataGridViewRemover()
        //{
        //    if (LigacaoDB.State == ConnectionState.Open)
        //        LigacaoDB.Close();

        //    try
        //    {
        //        LigacaoDB.Open();

        //        string Query = "SELECT ID,Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " ORDER BY ID ASC";

        //        MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

        //        Adapter.SelectCommand = Comando;

        //        Adapter.Fill(TabelaDados);

        //        BindingSource ColecaoDados = new BindingSource();

        //        DATAGRIDVIEW_REMOVER.DataSource = TabelaDados;

        //        Adapter.Update(TabelaDados);

        //        LigacaoDB.Close();
        //    }

        //    catch (Exception EX)
        //    {
        //        MessageBox.Show(EX.Message);
        //    }
        //}

        //public void PreencherDataGridViewAlterar()
        //{
        //    if (LigacaoDB.State == ConnectionState.Open)
        //        LigacaoDB.Close();

        //    try
        //    {
        //        LigacaoDB.Open();

        //        string Query = "SELECT ID,Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " ORDER BY ID ASC";

        //        MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

        //        Adapter.SelectCommand = Comando;

        //        Adapter.Fill(TabelaDados);

        //        BindingSource ColecaoDados = new BindingSource();

        //        DATAGRIDVIEW_ALTERAR.DataSource = TabelaDados;

        //        Adapter.Update(TabelaDados);

        //        LigacaoDB.Close();
        //    }

        //    catch (Exception EX)
        //    {
        //        MessageBox.Show(EX.Message);
        //    }
        //}

        #endregion

        public void ClearDataGridView()
        {
            TabelaDados.Clear();
        }                        

        public void Inserir()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            try
            {
                LigacaoDB_StoredProcedures.Open();


                string Titulo = TEXTBOX_ADICIONAR_TITULO.Text;
                string TituloPT = TEXTBOX_ADICIONAR_TITULOPT.Text;
                string Genero = COMBOBOX_ADICIONAR_GENERO.Text;
                string Ano = TEXTBOX_ADICIONAR_ANO.Text;
                string IMDB = TEXTBOX_ADICIONAR_IMDB.Text;
                string Realizador = TEXTBOX_ADICIONAR_REALIZADOR.Text;
                string Actores = TEXTBOX_ADICIONAR_ACTORES.Text;
                string Sinopse = TEXTBOX_ADICIONAR_SINOPSE.Text;
                string Capa = TEXTBOX_ADICIONAR_CAPA.Text;
                int Enviado = 0;

                //string Query = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + "(Titulo_Original, TituloPT, Genero, Data, Realizador, Actores_Principais, Sinopse, IMDB, Endereco_Capa) VALUES ('" + Titulo + "', '" + TituloPT + "', '" + Genero + "', '" + Ano + "', '" + Realizador + "', '" + Actores + "', '" + Sinopse + "', '" + IMDB + "', '" + Capa + "');";                

                MySqlCommand Comando = new MySqlCommand("SP_CATALOGOFILMES_INSERIR", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.AddWithValue("titulo", Titulo);
                Comando.Parameters.AddWithValue("titulopt", TituloPT);
                Comando.Parameters.AddWithValue("genero", Genero);
                Comando.Parameters.AddWithValue("ano", Ano);
                Comando.Parameters.AddWithValue("realizador", Realizador);
                Comando.Parameters.AddWithValue("actores", Actores);
                Comando.Parameters.AddWithValue("sinopse", Sinopse);
                Comando.Parameters.AddWithValue("imdb", IMDB);
                Comando.Parameters.AddWithValue("enderecocapa", Capa);
                Comando.Parameters.AddWithValue("_enviado", Enviado);

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB_StoredProcedures.Close();

                LimparAdicionar();

                MessageBox.Show("Filme Inserido com Sucesso", "Filme Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void Remover()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            try
            {
                LigacaoDB_StoredProcedures.Open();

                int ID = Convert.ToInt32(DATAGRIDVIEW_REMOVER.SelectedCells[0].Value);

                //string Query = "DELETE FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";

                MySqlCommand Command = new MySqlCommand("SP_CATALOGOFILMES_DELETE", LigacaoDB_StoredProcedures);
                Command.CommandType = CommandType.StoredProcedure;

                Command.Parameters.AddWithValue("_id", ID);

                Reader = Command.ExecuteReader();

                Reader.Close();

                LigacaoDB_StoredProcedures.Close();

                MessageBox.Show("Filme Removido com Sucesso", "Filme Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            { }
        }

        public void Alterar()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            try
            {
                LigacaoDB_StoredProcedures.Open();

                int ID = Convert.ToInt32(DATAGRIDVIEW_REMOVER.SelectedCells[0].Value);

                string Titulo = TEXTBOX_ALTERAR_TITULO.Text;
                string TituloPT = TEXTBOX_ALTERAR_TITULOPT.Text;
                string Genero = COMBOBOX_ALTERAR_GENERO.Text;
                string Data = TEXTBOX_ALTERAR_ANO.Text;
                string Realizador = TEXTBOX_ALTERAR_REALIZADOR.Text;
                string Actores = TEXTBOX_ALTERAR_ACTORES.Text;
                string Sinopse = TEXTBOX_ALTERAR_SINOPSE.Text;
                string IMDB = TEXTBOX_ALTERAR_IMDB.Text;
                string Capa = TEXTBOX_ALTERAR_CAPA.Text;

                //string Query = "UPDATE " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " SET Titulo_Original='" + Titulo + "', TituloPT='" + TituloPT + "', Genero='" + Genero + "', Data='" + Data + "', Realizador='" + Realizador + "', Actores_Principais='" + Actores + "', Sinopse='" + Sinopse + "', IMDB='" + IMDB + "', Endereco_Capa='" + Capa + "' WHERE ID = " + ID + "";

                MySqlCommand Comando = new MySqlCommand("SP_CATALOGOFILMES_ALTERAR", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.AddWithValue("_id", ID);
                Comando.Parameters.AddWithValue("titulo", Titulo);
                Comando.Parameters.AddWithValue("titulopt", TituloPT);
                Comando.Parameters.AddWithValue("genero", Genero);
                Comando.Parameters.AddWithValue("ano", Data);
                Comando.Parameters.AddWithValue("realizador", Realizador);
                Comando.Parameters.AddWithValue("actores", Actores);
                Comando.Parameters.AddWithValue("sinopse", Sinopse);
                Comando.Parameters.AddWithValue("imdb", IMDB);
                Comando.Parameters.AddWithValue("enderecocapa", Capa);

                Comando.ExecuteNonQuery();

                LigacaoDB_StoredProcedures.Close();

                MessageBox.Show("Filme Alterado com Sucesso", "Filme Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void PreencherTextBoxs()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            LigacaoDB.Open();

            try
            {

                int ID = Convert.ToInt32(DATAGRIDVIEW_FILMES.SelectedCells[0].Value);
                int Enviado = 0;
                FormGestaoFilmes.ID_Filme_Catalogo = ID;

                string QueryID = "SELECT ID FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTitulo = "SELECT Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTituloPT = "SELECT TituloPT FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryGenero = "SELECT Genero FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryData = "SELECT Data FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryRealizador = "SELECT Realizador FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryActores = "SELECT Actores_Principais FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QuerySinopse = "SELECT Sinopse FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryIMDB = "SELECT IMDB FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryCapa = "SELECT Endereco_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string Capa = "";
                string QueryEnviado = "SELECT Enviado FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";

                MySqlCommand ComandoTitulo = new MySqlCommand(QueryTitulo, LigacaoDB);
                MySqlCommand ComandoTituloPT = new MySqlCommand(QueryTituloPT, LigacaoDB);
                MySqlCommand ComandoGenero = new MySqlCommand(QueryGenero, LigacaoDB);
                MySqlCommand ComandoData = new MySqlCommand(QueryData, LigacaoDB);
                MySqlCommand ComandoRealizador = new MySqlCommand(QueryRealizador, LigacaoDB);
                MySqlCommand ComandoActores = new MySqlCommand(QueryActores, LigacaoDB);
                MySqlCommand ComandoSinopse = new MySqlCommand(QuerySinopse, LigacaoDB);
                MySqlCommand ComandoIMDB = new MySqlCommand(QueryIMDB, LigacaoDB);
                MySqlCommand ComandoCapa = new MySqlCommand(QueryCapa, LigacaoDB);
                MySqlCommand ComandoEnviado = new MySqlCommand(QueryEnviado, LigacaoDB);

                TEXTBOX_TITULO.Text = ComandoTitulo.ExecuteScalar().ToString();
                TEXTBOX_TITULO.Text = TEXTBOX_TITULO.Text.Replace("\"", string.Empty);
                TEXTBOX_TITULOPT.Text = ComandoTituloPT.ExecuteScalar().ToString();
                TEXTBOX_TITULOPT.Text = TEXTBOX_TITULOPT.Text.Replace("\"", string.Empty);
                TEXTBOX_GENERO.Text = ComandoGenero.ExecuteScalar().ToString();
                TEXTBOX_GENERO.Text = TEXTBOX_GENERO.Text.Replace("\"", string.Empty);
                TEXTBOX_ANO.Text = ComandoData.ExecuteScalar().ToString();
                TEXTBOX_ANO.Text = TEXTBOX_ANO.Text.Replace("\"", string.Empty);
                TEXTBOX_IMDB.Text = ComandoIMDB.ExecuteScalar().ToString();
                TEXTBOX_IMDB.Text = TEXTBOX_IMDB.Text.Replace("\"", string.Empty);
                TEXTBOX_REALIZADOR.Text = ComandoRealizador.ExecuteScalar().ToString();
                TEXTBOX_REALIZADOR.Text = TEXTBOX_REALIZADOR.Text.Replace("\"", string.Empty);
                TEXTBOX_ACTORES.Text = ComandoActores.ExecuteScalar().ToString();
                TEXTBOX_ACTORES.Text = TEXTBOX_ACTORES.Text.Replace("\"", string.Empty);
                TEXTBOX_SINOPSE.Text = ComandoSinopse.ExecuteScalar().ToString();
                TEXTBOX_SINOPSE.Text = TEXTBOX_SINOPSE.Text.Replace("\"", string.Empty);
                Capa = ComandoCapa.ExecuteScalar().ToString();
                Enviado = Convert.ToInt32(ComandoEnviado.ExecuteScalar());
                Copy_Enviado = Enviado;

                if (Capa != "")
                    PICTUREBOX_CAPA.Image = Image.FromFile(Properties.Settings.Default.cover_connection_type.ToString() + @"\" + Capa);
                if (Capa == "")
                    PICTUREBOX_CAPA.Image = null;

                if (Enviado == 1)
                    CHECKBOX_ENVIADO.Checked = true;
                if (Enviado == 0)
                    CHECKBOX_ENVIADO.Checked = false;
            }

            catch (Exception EX)
            { }

            LigacaoDB.Close();
        }

        public void PreencherTextBoxs_Remover()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            LigacaoDB.Open();

            try
            {

                int ID = Convert.ToInt32(DATAGRIDVIEW_REMOVER.SelectedCells[0].Value);

                string QueryID = "SELECT ID FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTitulo = "SELECT Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTituloPT = "SELECT TituloPT FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryGenero = "SELECT Genero FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryData = "SELECT Data FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryRealizador = "SELECT Realizador FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryActores = "SELECT Actores_Principais FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QuerySinopse = "SELECT Sinopse FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryIMDB = "SELECT IMDB FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryCapa = "SELECT Endereco_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string Capa = "";

                MySqlCommand ComandoTitulo = new MySqlCommand(QueryTitulo, LigacaoDB);
                MySqlCommand ComandoTituloPT = new MySqlCommand(QueryTituloPT, LigacaoDB);
                MySqlCommand ComandoGenero = new MySqlCommand(QueryGenero, LigacaoDB);
                MySqlCommand ComandoData = new MySqlCommand(QueryData, LigacaoDB);
                MySqlCommand ComandoRealizador = new MySqlCommand(QueryRealizador, LigacaoDB);
                MySqlCommand ComandoActores = new MySqlCommand(QueryActores, LigacaoDB);
                MySqlCommand ComandoSinopse = new MySqlCommand(QuerySinopse, LigacaoDB);
                MySqlCommand ComandoIMDB = new MySqlCommand(QueryIMDB, LigacaoDB);
                MySqlCommand ComandoCapa = new MySqlCommand(QueryCapa, LigacaoDB);

                TEXTBOX_REMOVER_TITULO.Text = ComandoTitulo.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_TITULO.Text = TEXTBOX_REMOVER_TITULO.Text.Replace("\"", string.Empty);
                TEXTBOX_REMOVER_TITULOPT.Text = ComandoTituloPT.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_TITULOPT.Text = TEXTBOX_REMOVER_TITULOPT.Text.Replace("\"", string.Empty);
                COMBOBOX_REMOVER_GENERO.SelectedItem = ComandoGenero.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_ANO.Text = ComandoData.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_ANO.Text = TEXTBOX_REMOVER_ANO.Text.Replace("\"", string.Empty);
                TEXTBOX_REMOVER_IMDB.Text = ComandoIMDB.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_IMDB.Text = TEXTBOX_REMOVER_IMDB.Text.Replace("\"", string.Empty);
                TEXTBOX_REMOVER_REALIZADOR.Text = ComandoRealizador.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_REALIZADOR.Text = TEXTBOX_REMOVER_REALIZADOR.Text.Replace("\"", string.Empty);
                TEXTBOX_REMOVER_ACTORES.Text = ComandoActores.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_ACTORES.Text = TEXTBOX_REMOVER_ACTORES.Text.Replace("\"", string.Empty);
                TEXTBOX_REMOVER_SINOPSE.Text = ComandoSinopse.ExecuteScalar().ToString();
                TEXTBOX_REMOVER_SINOPSE.Text = TEXTBOX_REMOVER_SINOPSE.Text.Replace("\"", string.Empty);
                Capa = ComandoCapa.ExecuteScalar().ToString();

                if (Capa != "")
                    PICTUREBOX_REMOVER_CAPA.Image = Image.FromFile(Properties.Settings.Default.cover_connection_type.ToString() + @"\" + Capa);
                if (Capa == "")
                    PICTUREBOX_REMOVER_CAPA.Image = null;
            }

            catch (Exception EX)
            { }

            LigacaoDB.Close();
        }

        public void PreencherTextBoxs_Alterar()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            LigacaoDB.Open();

            try
            {

                int ID = Convert.ToInt32(DATAGRIDVIEW_ALTERAR.SelectedCells[0].Value);


                string QueryID = "SELECT ID FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTitulo = "SELECT Titulo_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryTituloPT = "SELECT TituloPT FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryGenero = "SELECT Genero FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryData = "SELECT Data FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryRealizador = "SELECT Realizador FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryActores = "SELECT Actores_Principais FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QuerySinopse = "SELECT Sinopse FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryIMDB = "SELECT IMDB FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string QueryCapa = "SELECT Endereco_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                string Capa = "";

                MySqlCommand ComandoTitulo = new MySqlCommand(QueryTitulo, LigacaoDB);
                MySqlCommand ComandoTituloPT = new MySqlCommand(QueryTituloPT, LigacaoDB);
                MySqlCommand ComandoGenero = new MySqlCommand(QueryGenero, LigacaoDB);
                MySqlCommand ComandoData = new MySqlCommand(QueryData, LigacaoDB);
                MySqlCommand ComandoRealizador = new MySqlCommand(QueryRealizador, LigacaoDB);
                MySqlCommand ComandoActores = new MySqlCommand(QueryActores, LigacaoDB);
                MySqlCommand ComandoSinopse = new MySqlCommand(QuerySinopse, LigacaoDB);
                MySqlCommand ComandoIMDB = new MySqlCommand(QueryIMDB, LigacaoDB);
                MySqlCommand ComandoCapa = new MySqlCommand(QueryCapa, LigacaoDB);

                TEXTBOX_ALTERAR_TITULO.Text = ComandoTitulo.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_TITULO.Text = TEXTBOX_ALTERAR_TITULO.Text.Replace("\"", string.Empty);
                TEXTBOX_ALTERAR_TITULOPT.Text = ComandoTituloPT.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_TITULOPT.Text = TEXTBOX_ALTERAR_TITULOPT.Text.Replace("\"", string.Empty);
                COMBOBOX_ALTERAR_GENERO.SelectedItem = ComandoGenero.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_ANO.Text = ComandoData.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_ANO.Text = TEXTBOX_ALTERAR_ANO.Text.Replace("\"", string.Empty);
                TEXTBOX_ALTERAR_IMDB.Text = ComandoIMDB.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_IMDB.Text = TEXTBOX_ALTERAR_IMDB.Text.Replace("\"", string.Empty);
                TEXTBOX_ALTERAR_REALIZADOR.Text = ComandoRealizador.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_REALIZADOR.Text = TEXTBOX_ALTERAR_REALIZADOR.Text.Replace("\"", string.Empty);
                TEXTBOX_ALTERAR_ACTORES.Text = ComandoActores.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_ACTORES.Text = TEXTBOX_ALTERAR_ACTORES.Text.Replace("\"", string.Empty);
                TEXTBOX_ALTERAR_SINOPSE.Text = ComandoSinopse.ExecuteScalar().ToString();
                TEXTBOX_ALTERAR_SINOPSE.Text = TEXTBOX_ALTERAR_SINOPSE.Text.Replace("\"", string.Empty);
                Capa = ComandoCapa.ExecuteScalar().ToString();

                if (Capa != "")
                {
                    PICTUREBOX_ALTERAR_CAPA.Image = Image.FromFile(Properties.Settings.Default.cover_connection_type.ToString() + @"\" + Capa);
                    TEXTBOX_ALTERAR_CAPA.Text = Capa;
                }
                if (Capa == "")
                {
                    PICTUREBOX_ALTERAR_CAPA.Image = null;
                    TEXTBOX_ALTERAR_CAPA.Text = "";
                }
            }

            catch (Exception EX)
            { }

            LigacaoDB.Close();
        }                       

        public void Procurar_Catalogo()
        {
            DataView DV = new DataView(TabelaDados);

            DV.RowFilter = string.Format("Titulo_Original LIKE '%{0}%'", TEXTBOX_PROCURAR.Text);

            DATAGRIDVIEW_FILMES.DataSource = DV;
        }

        public void Procurar_Remover()
        {
            DataView DV = new DataView(TabelaDados);

            DV.RowFilter = string.Format("Titulo_Original LIKE '%{0}%'", TEXTBOX_REMOVER_PROCURAR.Text);

            DATAGRIDVIEW_REMOVER.DataSource = DV;
        }

        public void Procurar_Alterar()
        {
            DataView DV = new DataView(TabelaDados);

            DV.RowFilter = string.Format("Titulo_Original LIKE '%{0}%'", TEXTBOX_ALTERAR_PROCURAR.Text);

            DATAGRIDVIEW_ALTERAR.DataSource = DV;
        }

        public void PassarParaFormInsercao()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            try
            {
                LigacaoDB.Open();

                int ID = Convert.ToInt32(DATAGRIDVIEW_FILMES.SelectedCells[0].Value);
                FormGestaoFilmes.ID_Filme_Catalogo = ID;

                string QueryCapa = "SELECT Endereco_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE ID = " + ID + "";
                MySqlCommand ComandoCapa = new MySqlCommand(QueryCapa, LigacaoDB);
                Capa = ComandoCapa.ExecuteScalar().ToString();

                Titulo = TEXTBOX_TITULO.Text;
                TituloPT = TEXTBOX_TITULOPT.Text;
                Genero = TEXTBOX_GENERO.Text;
                Data = TEXTBOX_ANO.Text;
                Realizador = TEXTBOX_REALIZADOR.Text;
                Actores = TEXTBOX_ACTORES.Text;
                Sinopse = TEXTBOX_SINOPSE.Text;
                IMDB = TEXTBOX_IMDB.Text;

                FormGestaoFilmes.CopyInfo_Titulo = Titulo;
                FormGestaoFilmes.CopyInfo_TituloPT = TituloPT;
                FormGestaoFilmes.CopyInfo_Genero = Genero;
                FormGestaoFilmes.CopyInfo_Data = Data;
                FormGestaoFilmes.CopyInfo_Realizador = Realizador;
                FormGestaoFilmes.CopyInfo_Actores = Actores;
                FormGestaoFilmes.CopyInfo_Sinopse = Sinopse;
                FormGestaoFilmes.CopyInfo_IMDB = IMDB;
                FormGestaoFilmes.CopyInfo_Capa = Capa;
                //FormGestaoFilmes.CopyInfo_Enviado = Copy_Enviado;

                LigacaoDB.Close();

                FormGestaoFilmes.CopyInfo();

                //this.Close();

                FORM_GESTAO_FILMES Form_Gestao_Filmes = new FORM_GESTAO_FILMES();
                Form_Gestao_Filmes.Focus();
            }

            catch (Exception EX)
            { }
        } 

        public void LimparAdicionar()
        {
            TEXTBOX_ADICIONAR_TITULO.Text = "";
            TEXTBOX_ADICIONAR_TITULOPT.Text = "";
            TEXTBOX_ADICIONAR_ANO.Text = "";
            TEXTBOX_ADICIONAR_IMDB.Text = "";
            TEXTBOX_ADICIONAR_REALIZADOR.Text = "";
            TEXTBOX_ADICIONAR_ACTORES.Text = "";
            TEXTBOX_ADICIONAR_SINOPSE.Text = "";
            TEXTBOX_ADICIONAR_CAPA.Text = "";
            COMBOBOX_ADICIONAR_GENERO.SelectedItem = null;
            PICTUREBOX_ADICIONAR_CAPA.Image = null;
        }

        private void BUTTON_REFRESH_MAIN_Click(object sender, EventArgs e)
        {
            PreencherDataGridView();
        }

        private void BUTTON_REFRESH_REMOVER_Click(object sender, EventArgs e)
        {
            PreencherDataGridView();
        }

        private void BUTTON_REFRESH_ALTERAR_Click(object sender, EventArgs e)
        {
            PreencherDataGridView();
        }

        
    }
}
