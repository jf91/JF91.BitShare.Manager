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

namespace BitShare_Manager
{
    public partial class FORM_GESTAO_FILMES_GERIRCATEGORIAS : Form
    {
        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;
        MySqlDataReader Reader2;

        DataTable TabelaDados = new DataTable();
        
        public int Sucess = 0;
        public bool SuccesState = false;


        public string aux = "";
        public string aux2 = "";

        public int IdAlterar_SelectListBox;

        public FORM_GESTAO_FILMES_GERIRCATEGORIAS()
        {
            InitializeComponent();

            DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.AutoGenerateColumns = false;

            PreencherDataGridView();

            PreencherListBoxGeneros();

            PreencherListBoxAnosDecadas();

            PreencherListBoxAnos();
        }

        private void TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Text = TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Text.Replace("\"", string.Empty);

            ProcurarFilme();
        }

        private void DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME_MouseClick(object sender, MouseEventArgs e)
        {
            //TEXTBOX_GERIRCATEGORIASFILMES_ID.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[0].Value.ToString();
            //TEXTBOX_GERIRCATEGORIASFILMES_NOME.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[1].Value.ToString();
            //TEXTBOX_TITULOPT.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[2].Value.ToString();
        }

        private void DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TEXTBOX_GERIRCATEGORIASFILMES_ID.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[0].Value.ToString();
                TEXTBOX_GERIRCATEGORIASFILMES_NOME.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[1].Value.ToString();
                TEXTBOX_TITULOPT.Text = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedCells[2].Value.ToString();
            }

            catch(Exception EX)
            { }
        }

        private void BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES_Click(object sender, EventArgs e)
        {
            Query_AtribuirGeneros();

            Query_InserirGeneros();

            Query_AtribuirAnos();

            Query_InserirAnos();

            LigacaoDB.Close();

            LISTBOX_GERIRCATEGORIASFILMES_GENEROS.SelectedItem = null;
            LISTBOX_GERIRCATEGORIASFILMES_DATAS.SelectedItem = null;
            LISTBOX_GERIRCATEGORIASFILMES_GENEROS.SelectedItem = 0;
            LISTBOX_GERIRCATEGORIASFILMES_DATAS.SelectedItem = 0;

            try
            {
                IdAlterar_SelectListBox = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedRows[0].Index;

                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.CurrentRow.Selected = false;
                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.CurrentCell = this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME[0, IdAlterar_SelectListBox];
            }

            catch (Exception)
            { }            
        }

        private void MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*··•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••····•••··
                 ╒╬═════════════════╬╕
                  ║ FUNÇÕES DA FORM ║  -> FUNÇÕES DO PRÓPRIO FORM
                 ╘╬═════════════════╬╛
        */

        //     ╔═════════════════════════════════════╗
        //     ║..:                               :..║

        public void PreencherDataGridView()
        {
            try
            {
                LigacaoDB.Open();

                string Query = @"SELECT * FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE application_id = 4";

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Adapter.SelectCommand = Comando;

                Adapter.Fill(TabelaDados);

                BindingSource ColecaoDados = new BindingSource();

                ColecaoDados.DataSource = TabelaDados;

                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.DataSource = ColecaoDados;

                Adapter.Update(TabelaDados);

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void ProcurarFilme()
        {
            DataView DV = new DataView(TabelaDados);

            try
            {
                DV.RowFilter = string.Format("Nome LIKE '%{0}%'", TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Text);

                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.DataSource = DV;
            }
            catch (Exception)
            {

            }
        }

        public void PreencherListBoxGeneros()
        {
            try
            {
                LigacaoDB.Open();

                string Query = @"SELECT * FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + " WHERE description = '<p>filme-genero</p>'";

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    string Genero = Reader.GetString("name");
                    LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Items.Add(Genero);
                }

                LigacaoDB.Close();
            }

            catch (Exception)
            {

            }
        }

        public void PreencherListBoxAnos()
        {
            try
            {
                LigacaoDB.Open();

                string Query = @"SELECT * FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + " WHERE description ='<p>filme-ano</p>' ORDER BY 'ordem' DESC";

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Reader = Comando.ExecuteReader();

                while (Reader.Read())
                {
                    string Genero = Reader.GetString("name");
                    LISTBOX_GERIRCATEGORIASFILMES_DATAS.Items.Add(Genero);
                }

                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception)
            {

            }
        }

        public void PreencherListBoxAnosDecadas()
        {
            try
            {
                LigacaoDB.Open();

                string Query2 = @"SELECT * FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + " WHERE description ='filmeanorange' ORDER BY 'ordem' DESC";

                MySqlCommand Comando2 = new MySqlCommand(Query2, LigacaoDB);

                Reader2 = Comando2.ExecuteReader();

                while (Reader2.Read())
                {
                    string Genero2 = Reader2.GetString("name");
                    LISTBOX_GERIRCATEGORIASFILMES_DATAS.Items.Add(Genero2);
                }

                Reader2.Close();

                LigacaoDB.Close();
            }

            catch (Exception)
            {

            }
        }

        public void Query_AtribuirGeneros()
        {
            try
            {
                LigacaoDB.Open();

                foreach (string Item in LISTBOX_GERIRCATEGORIASFILMES_GENEROS.SelectedItems)
                {
                    string FilmeSelecionado = TEXTBOX_TITULOPT.Text;  // NOME FILME
                    string Query_FilmeID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name = '" + FilmeSelecionado + "';";
                    MySqlCommand Comando_Filme = new MySqlCommand(Query_FilmeID, LigacaoDB);
                    int IDFilme = Convert.ToInt32(Comando_Filme.ExecuteScalar());

                    string GeneroSelecionado = LISTBOX_GERIRCATEGORIASFILMES_GENEROS.SelectedItem.ToString();
                    string Query_GeneroID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + " WHERE name = '" + Item.ToString() + "';";
                    MySqlCommand Comando = new MySqlCommand(Query_GeneroID, LigacaoDB);

                    Reader = Comando.ExecuteReader();

                    while (Reader.Read())
                    {
                        string Genero = Reader.GetString("id");

                        string QueryInserirGenero = "REPLACE INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM + " (`category_id`, `item_id`) VALUES ('" + Genero + "', '" + IDFilme + "');";

                        string aux1 = QueryInserirGenero;

                        aux += Environment.NewLine + aux1;
                    }

                    Reader.Close();
                }

                LigacaoDB.Close();

                Sucess = 1;
            }

            catch (Exception EX)
            {
            }
        }

        public void Query_InserirGeneros()
        {
            try
            {
                string Query = aux;

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                LigacaoDB.Open();

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB.Close();

                if (Sucess == 1)
                    Sucess = 2;
            }

            catch (Exception EX)
            {
            }
        }

        public void Query_AtribuirAnos()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            try
            {
                LigacaoDB.Open();

                foreach (string Item in LISTBOX_GERIRCATEGORIASFILMES_DATAS.SelectedItems)
                {
                    string FilmeSelecionado = TEXTBOX_TITULOPT.Text;  // NOME FILME
                    string Query_FilmeID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name = '" + FilmeSelecionado + "';";
                    MySqlCommand Comando_Filme = new MySqlCommand(Query_FilmeID, LigacaoDB);
                    int IDFilme = Convert.ToInt32(Comando_Filme.ExecuteScalar());

                    string GeneroSelecionado = Item.ToString();
                    string Query_GeneroID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + " WHERE name = '" + Item + "';";
                    MySqlCommand Comando = new MySqlCommand(Query_GeneroID, LigacaoDB);

                    Reader = Comando.ExecuteReader();

                    while (Reader.Read())
                    {
                        string Genero = Reader.GetString("id");

                        string QueryInserirGenero = "REPLACE INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM + " (`category_id`, `item_id`) VALUES ('" + Genero + "', '" + IDFilme + "');";

                        string aux1 = QueryInserirGenero;

                        aux2 += Environment.NewLine + aux1;
                    }

                    Reader.Close();
                }

                LigacaoDB.Close();

                if (Sucess == 2)
                    Sucess = 3;
            }

            catch (Exception EX)
            {
            }
        }

        public void Query_InserirAnos()
        {
            try
            {
                string Query = aux2;

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                LigacaoDB.Open();

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB.Close();

                if (Sucess == 3)
                    Sucess = 4;

                if (Sucess == 4)
                    SuccesState = true;

                if (SuccesState == true)
                    MessageBox.Show("Alterações Gravadas com Sucesso", "Alterações Gravadas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
            }
        }

        private void BUTTON_REFRESH_Click(object sender, EventArgs e)
        {
            try
            {
                IdAlterar_SelectListBox = DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectedRows[0].Index;
            }

            catch (Exception)
            { }


            TabelaDados.Clear();
            PreencherDataGridView();

            try
            {
                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.CurrentRow.Selected = false;
                DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.CurrentCell = this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME[0, IdAlterar_SelectListBox];
            }

            catch (Exception)
            { }
        }        
    }
}
