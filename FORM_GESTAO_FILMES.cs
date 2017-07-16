using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Timers;
using System.Data.OleDb;

namespace BitShare_Manager
{
    public partial class FORM_GESTAO_FILMES : Form
    {
        //FORM_INFORMACOES_DETALHADAS FormDetailInfo_Objects = (FORM_INFORMACOES_DETALHADAS)Application.OpenForms["FORM_INFORMACOES_DETALHADAS"];

        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlConnection LigacaoDB_StoredProcedures = new MySqlConnection(CLASS_GLOBAL_VARIABLES.ServidorStoredProcedure);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;

        DataTable TabelaDados = new DataTable();

        

      /*---------------------------------------*/
        string GeneroAliasAUX = "";
        string GeneroAUX;
        public int CheckFilmeID;
        public int Loop = 1;
      /*---------------------------------------*/

      /*---------------------------------------*/
        public string Preview_TituloOriginal;
        public string Preview_TituloPT;
        public string Preview_Realizador;
        public string Preview_Actores;
        public string Preview_Sinopse;
        public string Preview_Genero;
        public string Preview_Ano;
        public string Preview_IMDB;
        public string Preview_Capa;
      /*---------------------------------------*/

      /*---------------------------------------*/
        public string String_AlterarFilme_FilmeID;
        public int Int_AlterarFilme_FilmeID;
        public int Int_AlterarFilme_FilmeID_Principal_Tabela_BsZooItem;
      /*---------------------------------------*/

      /*---------------------------------------*/
        public string DetailInfo_FilmeSelecionado;
        public string DetailInfo_ID;
        public string DetailInfo_IdPrincipal;
        public string DetailInfo_TituloOriginal;
        public string DetailInfo_TituloPT;
        public string DetailInfo_IMDB;
        public string DetailInfo_GeneroPrincipal;
        public string DetailInfo_AnoProducao;
        public string DetailInfo_Realizador;
        public string DetailInfo_ActoresPrincipais;
        public string DetailInfo_Sinopse;
        public string DetailInfo_AliasFilme;
        public string DetailInfo_LinkVerFilme;
        public string DetailInfo_LinkDownloadFilme;
        public string DetailInfo_AliasGenero;
        public string DetailInfo_LinkGenero;
        public string DetailInfo_LinkAno;
        public string DetailInfo_AliasAno;
        public string DetailInfo_LinkCapaBlog;
        public string DetailInfo_LinkCapaZoom;
        public string DetailInfo_FicheiroFilme;
        public string DetailInfo_FicheiroCapa;
      /*---------------------------------------*/

      /*---------------------------------------*/
        public int ID_Filme_Catalogo;

        public string CopyInfo_Titulo;
        public string CopyInfo_TituloPT;
        public string CopyInfo_Genero;
        public string CopyInfo_Data;
        public string CopyInfo_Realizador;
        public string CopyInfo_Actores;
        public string CopyInfo_Sinopse;
        public string CopyInfo_IMDB;
        public string CopyInfo_Capa;
        public int CopyInfo_Enviado;
      /*---------------------------------------*/

        public int IdAlterar_SelectListBox;

        public FORM_GESTAO_FILMES()
        {
            InitializeComponent();

            CLOCK.Start();

            DATAGRIDVIEW_LISTAFILMES.AutoGenerateColumns = false;
            DATAGRIDVIEW_REMOVERFILME.AutoGenerateColumns = false;
            DATAGRIDVIEW_ALTERARFILME.AutoGenerateColumns = false;

            DATAGRIDVIEW_LISTAFILMES.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DATAGRIDVIEW_REMOVERFILME.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DATAGRIDVIEW_ALTERARFILME.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //DATAGRIDVIEW_LISTAFILMES.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEORIGINAL.Select();
            RADIOBUTTON_REMOVERFILME_FILTRAR_NOME.Select();
            RADIOBUTTON_ALTERARFILME_FILTRAR_NOME.Select();

            PreencherDataGridView();

            LABEL_CALC_TOTALFILMES.Text = DATAGRIDVIEW_LISTAFILMES.RowCount.ToString();
        }

        private void CLOCK_Tick(object sender, EventArgs e)
        {
            DateTime Data = DateTime.Now;
            string FormatoData = "yyyy-MM-dd HH:mm:ss";
            LABEL_DATA.Text = Data.ToString(FormatoData);
        }

        private void FORM_GESTAO_FILMES_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            FORM_INICIO FormInicio = new FORM_INICIO();
            FormInicio.Visible = true;
        }

        private void MENUSTRIP_GESTAOFILMES_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEORIGINAL_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEORIGINAL.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEPT_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEPT.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_GENERO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_GENERO.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_ANO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_ANO.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_REALIZADOR_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_REALIZADOR.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_LISTAFILMES_FILTRARFILME_ACTORES_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_ACTORES.Checked == false)
            {
                TEXTBOX_LISTAFILMES_PROCURARFILME.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_TITULO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_FILTRAR_NOME.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_TITULOPT_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_TITULOPT.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_GENERO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_GENERO.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_ANO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_ANO.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_REALIZADOR_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_REALIZADOR.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_ACTORES_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_ACTORES.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_REMOVERFILME_CLASSIFICACAO_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_REMOVERFILME_CLASSIFICACAO.Checked == false)
            {
                TEXTBOX_REMOVERFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_ALTERARFILME_FILTRAR_NOME_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_ALTERARFILME_FILTRAR_NOME.Checked == false)
            {
                TEXTBOX_ALTERARFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void RADIOBUTTON_ALTERARFILME_FILTRAR_NOMEPT_CheckedChanged(object sender, EventArgs e)
        {
            if (RADIOBUTTON_ALTERARFILME_FILTRAR_NOMEPT.Checked == false)
            {
                TEXTBOX_ALTERARFILME_PROCURAR.Text = "";

                TabelaDados.Clear();

                PreencherDataGridView();
            }
        }

        private void TEXTBOX_LISTAFILMES_PROCURARFILME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_LISTAFILMES_PROCURARFILME.Text = TEXTBOX_LISTAFILMES_PROCURARFILME.Text.Replace("\"", string.Empty);

            ProcurarFilme();
        }

        private void COMBOBOX_ADICIONARFILME_GENERO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string ItemGenero = COMBOBOX_ADICIONARFILME_GENERO.SelectedItem.ToString();
                GeneroAUX = ItemGenero;
            }

            catch(Exception EX)
            { }
        }

        private void BUTTON_ADICIONARFILME_PROCURARMP4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Cover = new OpenFileDialog();

            Cover.InitialDirectory = Properties.Settings.Default.movie_connection_type.ToString();

            string Path;
            string Ficheiro;

            if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = Cover.FileName;
                Ficheiro = Cover.SafeFileName;

                TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text = Ficheiro;
                TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text = Ficheiro;
            }
        }

        private void BUTTON_ADICIONARFILME_PROCURARSCRIPTIMDB_Click(object sender, EventArgs e)
        {
            Stream Ler;

            OpenFileDialog Cover = new OpenFileDialog();

            Cover.InitialDirectory = @"C:\WebServer\www\bitshare\stuff\scripts";

            string Ficheiro;

            if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((Ler = Cover.OpenFile()) != null)
                {
                    Ficheiro = Cover.FileName;
                    TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text = File.ReadAllText(Ficheiro);
                }
            }
        }

        private void MENUSTRIP_GESTAOFILMES_GERIRCATEGORIAS_Click(object sender, EventArgs e)
        {
            FORM_GESTAO_FILMES_GERIRCATEGORIAS FormGerirCategoriasFilmes = new FORM_GESTAO_FILMES_GERIRCATEGORIAS();
            FormGerirCategoriasFilmes.Show();
        }

        private void BUTTON_ADICIONARFILME_ESCOLHERFICHEIRO_Click(object sender, EventArgs e)
        {
            OpenFileDialog Cover = new OpenFileDialog();

            Cover.InitialDirectory = Properties.Settings.Default.cover_connection_type.ToString();

            string Path;
            string Ficheiro;

            if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = Cover.FileName;
                Ficheiro = Cover.SafeFileName;

                PICTUREBOX_ADICIONARFILME_COVER.Image = Image.FromFile(Path);
                TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text = Ficheiro;
            }
        }

        private void BUTTON_ADICIONARFILME_INSERIRFILME_Click(object sender, EventArgs e)
        {
            InserirFilmeNaTabela_bsZooItem();

            InserirFilmeNaTabela_bsfilmes();

            InserirFilmeEmFilmes();

            LimparTextBoxs_InserirFilme();

            TabelaDados.Clear();

            PreencherDataGridView();

            //TIMER_ADICIONARFILME_PROGRESSBAR.Start();


            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            LABEL_CALC_TOTALFILMES.Text = DATAGRIDVIEW_LISTAFILMES.RowCount.ToString();
        }

        private void BackWork_CheckFilme_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void WEBROWSER_CheckFilme_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection Elementos = WEBROWSER_CheckFilme.Document.GetElementsByTagName("a");

            //Elementos.GetElementById("toolbar-apply").InvokeMember("Click");

            for (int i = 0; i < Elementos.Count; i++)
            {
                if (Elementos[i].GetAttribute("class") == "toolbar")
                {
                    if (Elementos[i].InnerHtml == "\n<a href=\"#\" class=\"toolbar\">\n<span class=\"icon-32-apply\">\n</span>\nSave\n</a>\n")
                    {
                        Elementos[i].Focus();
                        WEBROWSER_CheckFilme.Document.ActiveElement.InvokeMember("Click");

                    }
                }
            }

            foreach (HtmlElement Item in WEBROWSER_CheckFilme.Document.GetElementsByTagName("li"))
            {
                if (Item.OuterHtml.Contains("toolbar-apply"))
                {
                    foreach (HtmlElement ChildItem in Item.Children)
                    {
                        if (ChildItem.TagName == "A")
                        {
                            ChildItem.InvokeMember("Click");
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void TIMER_ADICIONARFILME_PROGRESSBAR_Tick(object sender, EventArgs e)
        {
            PROGRESSBAR_INSERIRFILME.Visible = true;

            PROGRESSBAR_INSERIRFILME.Increment(50);

            if (PROGRESSBAR_INSERIRFILME.Value == 100)
            {
                this.TIMER_ADICIONARFILME_PROGRESSBAR.Stop();
                PROGRESSBAR_INSERIRFILME.Value = 0;
                PROGRESSBAR_INSERIRFILME.Visible = false;
            }
        }

        private void DATAGRIDVIEW_ALTERARFILME_MouseClick(object sender, MouseEventArgs e)
        {
            //Int_AlterarFilme_FilmeID = Convert.ToInt32(DATAGRIDVIEW_ALTERARFILME.SelectedCells[0].Value);

            //AlterarFilme_PreencherInformacoesBasicas();
            //AlterarFilme_PreencherInformacoesDetalhadas();
        }

        private void TEXTBOX_ADICIONARFILME_TITULORIGINAL_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text = TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text.Replace("\"", string.Empty);

            try
            {
                if (TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text == "")
                    TEXTBOX_ADICIONARFILME_ALIAS.Text = "";
                if (TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text != "")
                    TEXTBOX_ADICIONARFILME_ALIAS.Text = Regex.Replace(TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text, @"\s+", "-").ToLower();
            }

            catch (Exception EX)
            {
            }
        }

        private void TEXTBOX_ADICIONARFILME_TITULORIGINAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    TEXTBOX_ADICIONARFILME_ALIAS.Text += e.KeyChar.ToString().ToLower();
                }
            }

            catch (Exception EX)
            {
            }

            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_TITULORIGINAL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    TEXTBOX_ADICIONARFILME_ALIAS.Text += "-";
                }

                if (e.KeyCode == Keys.Back)
                {
                    if (TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text != "")
                        TEXTBOX_ADICIONARFILME_ALIAS.Text = TEXTBOX_ADICIONARFILME_ALIAS.Text.Substring(0, (TEXTBOX_ADICIONARFILME_ALIAS.TextLength - 1));
                }
            }

            catch (Exception EX)
            {
            }
        }

        private void BUTTON_ADICIONARFILME_PREVISUALIZAR_Click(object sender, EventArgs e)
        {
            CopiarDataParaStringsPreview();

            FORM_PREVIEW_FILME FormPreviewFilme = new FORM_PREVIEW_FILME();
            FormPreviewFilme.ShowDialog();
        }

        private void TEXTBOX_REMOVERFILME_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_REMOVERFILME_PROCURAR.Text = TEXTBOX_REMOVERFILME_PROCURAR.Text.Replace("\"", string.Empty);

            ProcurarFilmeRemoverFilme();
        }

        private void DATAGRIDVIEW_REMOVERFILME_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    TEXTBOX_REMOVERFILME_ID.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[0].Value.ToString();
            //    TEXTBOX_REMOVERFILME_TITULORIGINAL.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[1].Value.ToString();
            //    TEXTBOX_REMOVERFILME_TITULOPT.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[2].Value.ToString();
            //    TEXTBOX_REMOVERFILME_GENERO.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[3].Value.ToString();
            //    TEXTBOX_REMOVERFILME_ANO.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[4].Value.ToString();
            //    TEXTBOX_REMOVERFILME_IMDB.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[7].Value.ToString();
            //}

            //catch (Exception EX)
            //{
            //}
        }

        private void DATAGRIDVIEW_REMOVERFILME_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TEXTBOX_REMOVERFILME_ID.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[0].Value.ToString();
                TEXTBOX_REMOVERFILME_TITULORIGINAL.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[1].Value.ToString();
                TEXTBOX_REMOVERFILME_TITULOPT.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[2].Value.ToString();
                TEXTBOX_REMOVERFILME_GENERO.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[3].Value.ToString();
                TEXTBOX_REMOVERFILME_ANO.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[4].Value.ToString();
                TEXTBOX_REMOVERFILME_IMDB.Text = DATAGRIDVIEW_REMOVERFILME.SelectedCells[7].Value.ToString();
            }

            catch (Exception EX)
            {
            }
        }

        private void BUTTON_REMOVERFILME_REMOVERFILME_Click(object sender, EventArgs e)
        {
            RemoverFilme();
            TabelaDados.Clear();
            PreencherDataGridView();

            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();

            MessageBox.Show("Filme removido com sucesso!", "Filme Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LABEL_CALC_TOTALFILMES.Text = DATAGRIDVIEW_LISTAFILMES.RowCount.ToString();
        }

        private void TEXTBOX_ALTERARFILME_PROCURAR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_PROCURAR.Text = TEXTBOX_ALTERARFILME_PROCURAR.Text.Replace("\"", string.Empty);

            ProcurarFilmeAlterarFilme();
        }

        private void DATAGRIDVIEW_ALTERARFILME_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Int_AlterarFilme_FilmeID = Convert.ToInt32(DATAGRIDVIEW_ALTERARFILME.SelectedCells[0].Value);

                AlterarFilme_PreencherInformacoesBasicas();
                AlterarFilme_PreencherInformacoesDetalhadas();                
                AlterarFilme_PreencherLinks();
                AlterarFilme_DefinirCapa();
            }

            catch (Exception EX)
            {
                
            }
        }

        private void TEXTBOX_ADICIONARFILME_FICHEIROMP4_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text = TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text;
            TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text = TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text.Replace("\"", string.Empty);
        }

        private void COMBOBOX_ALTERARFILME_GENERO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ItemGenero = COMBOBOX_ALTERARFILME_GENERO.SelectedItem.ToString();
            GeneroAUX = ItemGenero;
        }

        private void BUTTON_ALTERARFILME_GRAVARALTERACOES_Click(object sender, EventArgs e)
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                IdAlterar_SelectListBox = DATAGRIDVIEW_ALTERARFILME.SelectedRows[0].Index;
            }

            catch (Exception)
            { }

            AlterarFilme();
            TabelaDados.Clear();
            PreencherDataGridView();

            DATAGRIDVIEW_ALTERARFILME.CurrentRow.Selected = false;
            DATAGRIDVIEW_ALTERARFILME.CurrentCell = this.DATAGRIDVIEW_ALTERARFILME[0, IdAlterar_SelectListBox];
        }

        private void BUTTON_ALTERARFILME_ALTERARCAPA_Click(object sender, EventArgs e)
        {
            OpenFileDialog Cover = new OpenFileDialog();

            Cover.InitialDirectory = Properties.Settings.Default.cover_connection_type.ToString();

            string Path;
            string Ficheiro;

            string CapaBlog = "" + CLASS_GLOBAL_VARIABLES.BD + "/images/imagens/covers/filmes/capa-blog/";
            string CapaZoom = "" + CLASS_GLOBAL_VARIABLES.BD + "/images/imagens/covers/filmes/capa-zoom/";

            if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = Cover.FileName;
                Ficheiro = Cover.SafeFileName;

                PICTUREBOX_ALTERARFILME_CAPA.Image = Image.FromFile(Path);
                TEXTBOX_ALTERARFILME_ALTERARCAPA.Text = Ficheiro;

                TEXTBOX_ALTERARFILME_LINK_CapaBlog.Text = CapaBlog + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text;
                TEXTBOX_ALTERARFILME_LINK_CapaZoom.Text = CapaZoom + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text;
            }
        }

        private void TEXTBOX_ALTERARFILME_LINK_FicheiroMP4_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text = TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text.Replace("\"", string.Empty);

            TEXTBOX_ALTERARFILME_LINK_DOWNLOAD.Text = "" + CLASS_GLOBAL_VARIABLES.BD + "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
            TEXTBOX_ALTERARFILME_LINK_VERFILME.Text = "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
            TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text = TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
        }

        private void TEXTBOX_ALTERARFILME_LINK_DOWNLOAD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_LINK_DOWNLOAD.Text = "" + CLASS_GLOBAL_VARIABLES.BD + "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
        }

        private void TEXTBOX_ALTERARFILME_LINK_VERFILME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_LINK_VERFILME.Text = "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
        }

        private void TEXTBOX_ALTERARFILME_LINK_FILME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_LINK_FILME.Text = "" + CLASS_GLOBAL_VARIABLES.BD + "/index.php/filmes/item/" + TEXTBOX_ALTERARFILME_ALIASFILME.Text;
        }

        private void BUTTON_ALTERARFILME_PROCURARMP4_Click(object sender, EventArgs e)
        {
            OpenFileDialog Cover = new OpenFileDialog();

            Cover.InitialDirectory = Properties.Settings.Default.movie_connection_type.ToString();

            string Path;
            string Ficheiro;

            if (Cover.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Path = Cover.FileName;
                Ficheiro = Cover.SafeFileName;

                TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text = Ficheiro;
            }
        }

        private void TEXTBOX_ALTERARFILME_TITULORIGINAL_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_TITULORIGINAL.Text = TEXTBOX_ALTERARFILME_TITULORIGINAL.Text.Replace("\"", string.Empty);

            try
            {
                if (TEXTBOX_ALTERARFILME_TITULORIGINAL.Text == "")
                    TEXTBOX_ALTERARFILME_ALIASFILME.Text = "";
                if (TEXTBOX_ALTERARFILME_TITULORIGINAL.Text != "")
                    TEXTBOX_ALTERARFILME_ALIASFILME.Text = Regex.Replace(TEXTBOX_ALTERARFILME_TITULORIGINAL.Text, @"\s+", "-").ToLower();
            }

            catch (Exception EX)
            {
            }
        }

        private void TEXTBOX_ALTERARFILME_TITULORIGINAL_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetterOrDigit(e.KeyChar))
                {
                    TEXTBOX_ALTERARFILME_ALIASFILME.Text += e.KeyChar.ToString().ToLower();
                }
            }

            catch (Exception EX)
            {
            }

            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_TITULORIGINAL_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    TEXTBOX_ALTERARFILME_ALIASFILME.Text += "-";
                }

                if (e.KeyCode == Keys.Back)
                {
                    if (TEXTBOX_ALTERARFILME_TITULORIGINAL.Text != "")
                        TEXTBOX_ALTERARFILME_ALIASFILME.Text = TEXTBOX_ALTERARFILME_ALIASFILME.Text.Substring(0, (TEXTBOX_ALTERARFILME_ALIASFILME.TextLength - 1));
                }
            }

            catch (Exception EX)
            {
            }
        }

        private void TEXTBOX_ADICIONARFILME_ALIAS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
        }

        private void TEXTBOX_ADICIONARFILME_ALIAS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                e.Handled = true;

            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_ALIASFILME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
                e.Handled = true;

            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_ALIASFILME_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                e.Handled = true;
        }

        private void BUTTON_LISTAFILMES_INFORMACOES_Click(object sender, EventArgs e)
        {
            FORM_INFORMACOES_DETALHADAS FormInfo = new FORM_INFORMACOES_DETALHADAS();
            FormInfo.ShowDialog();
        }

        /*
                ╒╬═════════════════╬╕
                 ║ FUNÇÕES DA FORM ║  -> FUNÇÕES DO PRÓPRIO FORM
                ╘╬═════════════════╬╛
        */

        //      ╔═════════════════════════════════════╗
        //      ║..:                               :..║

        public void PreencherDataGridView()
        {
            //if (LigacaoDB.State == ConnectionState.Open)
            //    LigacaoDB.Close();

            try
            {
                LigacaoDB.Open();

                string Query = "SELECT * FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE application_id = 4";

                MySqlCommand ComandoFill = new MySqlCommand(Query, LigacaoDB);

                Adapter.SelectCommand = ComandoFill;

                Adapter.Fill(TabelaDados);

                BindingSource ColecaoDados = new BindingSource();

                ColecaoDados.DataSource = TabelaDados;

                DATAGRIDVIEW_LISTAFILMES.DataSource = ColecaoDados;
                DATAGRIDVIEW_REMOVERFILME.DataSource = ColecaoDados;
                DATAGRIDVIEW_ALTERARFILME.DataSource = ColecaoDados;

                Adapter.Update(TabelaDados);

                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        public void ProcurarFilme()
        {
            DataView DV = new DataView(TabelaDados);

            try
            {
                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEORIGINAL.Checked == true)
                {
                    DV.RowFilter = string.Format("Nome_Original LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }

                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_NOMEPT.Checked == true)
                {
                    DV.RowFilter = string.Format("Nome LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }

                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_GENERO.Checked == true)
                {
                    DV.RowFilter = string.Format("Categoria LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }

                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_ANO.Checked == true)
                {
                    DV.RowFilter = string.Format("Ano LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }

                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_REALIZADOR.Checked == true)
                {
                    DV.RowFilter = string.Format("Realizador LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }

                if (RADIOBUTTON_LISTAFILMES_FILTRARFILME_ACTORES.Checked == true)
                {
                    DV.RowFilter = string.Format("Actores_Principais LIKE '%{0}%'", TEXTBOX_LISTAFILMES_PROCURARFILME.Text);

                    DATAGRIDVIEW_LISTAFILMES.DataSource = DV;
                }
            }

            catch (Exception)
            {

            }
        }

        public void ProcurarFilmeRemoverFilme()
        {
            try
            {
                DataView DV2 = new DataView(TabelaDados);

                if (RADIOBUTTON_REMOVERFILME_FILTRAR_NOME.Checked == true)
                {
                    DV2.RowFilter = string.Format("Nome_Original LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_TITULOPT.Checked == true)
                {
                    DV2.RowFilter = string.Format("Nome LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_GENERO.Checked == true)
                {
                    DV2.RowFilter = string.Format("Categoria LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_ANO.Checked == true)
                {
                    DV2.RowFilter = string.Format("Ano LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_REALIZADOR.Checked == true)
                {
                    DV2.RowFilter = string.Format("Realizador LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_ACTORES.Checked == true)
                {
                    DV2.RowFilter = string.Format("Actores_Principais LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }

                if (RADIOBUTTON_REMOVERFILME_CLASSIFICACAO.Checked == true)
                {
                    DV2.RowFilter = string.Format("IMDB LIKE '%{0}%'", TEXTBOX_REMOVERFILME_PROCURAR.Text);

                    DATAGRIDVIEW_REMOVERFILME.DataSource = DV2;
                }
            }

            catch (Exception EX)
            {
            }
        }

        public void ProcurarFilmeAlterarFilme()
        {
            try
            {
                DataView DV3 = new DataView(TabelaDados);

                if (RADIOBUTTON_ALTERARFILME_FILTRAR_NOME.Checked == true)
                {
                    DV3.RowFilter = string.Format("Nome_Original LIKE '%{0}%'", TEXTBOX_ALTERARFILME_PROCURAR.Text);

                    DATAGRIDVIEW_ALTERARFILME.DataSource = DV3;
                }

                if (RADIOBUTTON_ALTERARFILME_FILTRAR_NOMEPT.Checked == true)
                {
                    DV3.RowFilter = string.Format("Nome LIKE '%{0}%'", TEXTBOX_ALTERARFILME_PROCURAR.Text);

                    DATAGRIDVIEW_ALTERARFILME.DataSource = DV3;
                }
            }

            catch (Exception EX)
            {
            }
        }

        public string AliasGenero()
        {
            string AliasCategoria = "";

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Acção")
            {
                AliasCategoria = "accao";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Animação")
            {
                AliasCategoria = "animacao";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Aventura")
            {
                AliasCategoria = "aventura";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Biografia")
            {
                AliasCategoria = "biografia";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Clássicos")
            {
                AliasCategoria = "classicos";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Comédia")
            {
                AliasCategoria = "comedia";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Crime")
            {
                AliasCategoria = "crime";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Desporto")
            {
                AliasCategoria = "desporto";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Documentário")
            {
                AliasCategoria = "documentario";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Drama")
            {
                AliasCategoria = "drama";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Familiar")
            {
                AliasCategoria = "familiar";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Fantasia")
            {
                AliasCategoria = "fantasia";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Ficção Cientifica")
            {
                AliasCategoria = "ficcao-cientifica";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Guerra")
            {
                AliasCategoria = "guerra";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "História")
            {
                AliasCategoria = "historia";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Mistério")
            {
                AliasCategoria = "misterio";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Musical")
            {
                AliasCategoria = "musical";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Romance")
            {
                AliasCategoria = "romance";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Terror")
            {
                AliasCategoria = "terror";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Thriller")
            {
                AliasCategoria = "thriller";
            }

            if (COMBOBOX_ADICIONARFILME_GENERO.SelectedItem == "Western")
            {
                AliasCategoria = "western";
            }

            GeneroAliasAUX = AliasCategoria;


            return AliasCategoria.ToString();
        }

        public string Alterar_AliasGenero()
        {
            string AliasCategoria = "";

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Acção")
            {
                AliasCategoria = "accao";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Animação")
            {
                AliasCategoria = "animacao";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Aventura")
            {
                AliasCategoria = "aventura";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Biografia")
            {
                AliasCategoria = "biografia";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Clássicos")
            {
                AliasCategoria = "classicos";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Comédia")
            {
                AliasCategoria = "comedia";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Crime")
            {
                AliasCategoria = "crime";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Desporto")
            {
                AliasCategoria = "desporto";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Documentário")
            {
                AliasCategoria = "documentario";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Drama")
            {
                AliasCategoria = "drama";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Familiar")
            {
                AliasCategoria = "familiar";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Fantasia")
            {
                AliasCategoria = "fantasia";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Ficção Cientifica")
            {
                AliasCategoria = "ficcao-cientifica";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Guerra")
            {
                AliasCategoria = "guerra";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "História")
            {
                AliasCategoria = "historia";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Mistério")
            {
                AliasCategoria = "misterio";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Musical")
            {
                AliasCategoria = "musical";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Romance")
            {
                AliasCategoria = "romance";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Terror")
            {
                AliasCategoria = "terror";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Thriller")
            {
                AliasCategoria = "thriller";
            }

            if (COMBOBOX_ALTERARFILME_GENERO.SelectedItem == "Western")
            {
                AliasCategoria = "western";
            }

            GeneroAliasAUX = AliasCategoria;

            return AliasCategoria.ToString();
        }

        public void InserirFilmeNaTabela_bsfilmes()
        {
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();
            try
            {
                LigacaoDB_StoredProcedures.Open();

                AliasGenero();

                int App_ID = 4;
                string Type = "article";
                string Nome = TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text;
                string NomePT = TEXTBOX_ADICIONARFILME_TITULOPT.Text;
                string Ano = TEXTBOX_ADICIONARFILME_ANO.Text;
                string Categoria = COMBOBOX_ADICIONARFILME_GENERO.SelectedItem.ToString();
                string Realizador = TEXTBOX_ADICIONARFILME_REALIZADOR.Text;
                string Actores = TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text;
                string Sinopse = TEXTBOX_ADICIONARFILME_SINOPSE.Text;
                string IMDB = TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text;
                string AliasFilme = TEXTBOX_ADICIONARFILME_ALIAS.Text;
                string LinkVerFilme = "bitwow.tk/stuff/filmes/" + TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text;
                string LinkFilme = "/index.php/filmes/item/" + TEXTBOX_ADICIONARFILME_ALIAS.Text;
                string LinkDownloadFilme = CLASS_GLOBAL_VARIABLES.BD + "/stuff/filmes/" + TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text;
                string AliasCategoria = GeneroAliasAUX;
                string LinkCategoria = "index.php/filmes-" + GeneroAliasAUX;
                string AliasAno = TEXTBOX_ADICIONARFILME_ANO.Text;
                string LinkAno = "index.php/filmes-" + TEXTBOX_ADICIONARFILME_ANO.Text;
                string LinkCapaBlog = "/images/imagens/covers/filmes/capa-blog/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;
                string LinkCapaZoom = "/images/imagens/covers/filmes/capa-zoom/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;
                string FicheiroFilme = TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text;
                string FicheiroCapa = TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;


                //string Query = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + "(`application_id`, `type`, `Nome`, `Nome_Original`, `Ano`, `Categoria`, `Realizador`, `Actores_Principais`, `Sinopse`, `IMDB`, `Alias_Filme`, `Link_Ver_Filme`, `Link_Filme`, `Link_Download_Filme`, `Alias_Categoria`, `Link_Categoria`, `Alias_Ano`, `Link_Ano`, `Link_Capa_BLOG`, `Link_Capa_ZOOM`, `Ficheiro_Filme`, `Ficheiro_Capa`) VALUES(4, 'article', '" + TEXTBOX_ADICIONARFILME_TITULOPT.Text + "', '" + TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text + "', '" + TEXTBOX_ADICIONARFILME_ANO.Text + "', '" + COMBOBOX_ADICIONARFILME_GENERO.SelectedItem.ToString() + "', '" + TEXTBOX_ADICIONARFILME_REALIZADOR.Text + "', '" + TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text + "', '" + TEXTBOX_ADICIONARFILME_SINOPSE.Text + "', '" + TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text + "', '" + TEXTBOX_ADICIONARFILME_ALIAS.Text + "', 'bitwow.tk/stuff/filmes/" + TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text + "', '/index.php/filmes/item/" + TEXTBOX_ADICIONARFILME_ALIAS.Text + "', '" + CLASS_GLOBAL_VARIABLES.BD + "/stuff/filmes/" + TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text + "', '" + GeneroAliasAUX + "', 'index.php/filmes-" + GeneroAliasAUX + "', '" + TEXTBOX_ADICIONARFILME_ANO.Text + "', 'index.php/filmes-" + TEXTBOX_ADICIONARFILME_ANO.Text + "', '/images/imagens/covers/filmes/capa-blog/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + "', '/images/imagens/covers/filmes/capa-zoom/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + "', '" + TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text + "', '" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + "')";

                MySqlCommand Comando = new MySqlCommand("SP_FILMES_BSFILMES_INSERIR", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.AddWithValue("_appid", App_ID);
                Comando.Parameters.AddWithValue("_type", Type);
                Comando.Parameters.AddWithValue("_nome", NomePT);
                Comando.Parameters.AddWithValue("_nomeoriginal", Nome);
                Comando.Parameters.AddWithValue("_ano", Ano);
                Comando.Parameters.AddWithValue("_categoria", Categoria);
                Comando.Parameters.AddWithValue("_realizador", Realizador);
                Comando.Parameters.AddWithValue("_actores", Actores);
                Comando.Parameters.AddWithValue("_sinopse", Sinopse);
                Comando.Parameters.AddWithValue("_imdb", IMDB);
                Comando.Parameters.AddWithValue("_aliasfilme", AliasFilme);
                Comando.Parameters.AddWithValue("_linkverfilme", LinkVerFilme);
                Comando.Parameters.AddWithValue("_linkfilme", LinkFilme);
                Comando.Parameters.AddWithValue("_linkdownloadfilme", LinkDownloadFilme);
                Comando.Parameters.AddWithValue("_aliascategoria", AliasCategoria);
                Comando.Parameters.AddWithValue("_linkcategoria", LinkCategoria);
                Comando.Parameters.AddWithValue("_aliasano", AliasAno);
                Comando.Parameters.AddWithValue("_linkano", LinkAno);
                Comando.Parameters.AddWithValue("_linkcapablog", LinkCapaBlog);
                Comando.Parameters.AddWithValue("_linkcapazoom", LinkCapaZoom);
                Comando.Parameters.AddWithValue("_ficheirofilme", FicheiroFilme);
                Comando.Parameters.AddWithValue("_ficheirocapa", FicheiroCapa);

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB_StoredProcedures.Close();
            }
                
            catch (Exception EX)
            {
            }
        }

        public void InserirFilmeNaTabela_bsZooItem()
        {
            try
            {
                LigacaoDB_StoredProcedures.Open();

                string QueryElement;
                string QueryParams;
                string Query;

                AliasGenero();

                QueryElement = @"{""2616ded9-e88b-4b77-a92c-2c4c18bb995f"":  {
		""0"":  {
			""value"": """"
		}
	},
	""fc5a6788-ffae-41d9-a812-3530331fef64"":  {
		""item"":  {

		}
	},
	""08795744-c2dc-4a68-8252-4e21c4c4c774"":  {
		""0"":  {
			""value"": """"
		}
	},
	
	""2e3c9e69-1f9e-4647-8d13-4e88094d2790"":  {
		""0"":  {
			""value"": ""<p><table border=\""0\"" width=\""100%\""><tbody><tr><td style=\""width: 150px;\""><a data-lightbox=\""on;transitionIn:elastic;transitionOut:elastic;\"" data-spotlight=\""on\"" href=\""images\/imagens\/covers\/filmes\/capa-zoom\/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + @"\""><img src=\""images\/imagens\/covers\/filmes\/capa-blog\/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + @"\""width=\""150\"" height=\""184\"" alt=\""" + TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text + @"\""\/><\/a><\/td><td><p style=\""text-align: center;\""><strong><span style=\""font-family: ''courier new'', courier; font-size: 12pt; color: #000080;\""><a href=\""index.php\/filmes\/item\/" + TEXTBOX_ADICIONARFILME_ALIAS.Text + @"\""><span style=\""color: #000080;\"">\""" + TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text + @"\""<\/span><\/a> | <a href=\""index.php\/filmes-" + GeneroAliasAUX + @"\""><span style=\""color: #000080;\"">" + GeneroAUX + @"<\/span><\/a> | <\/span><span style=\""color: #000080;\""><span style=\""font-family: ''courier new'', courier; font-size: 12pt;\""><a href=\""index.php\/filmes-" + TEXTBOX_ADICIONARFILME_ANO.Text + @"\""><span style=\""color: #000080;\"">" + TEXTBOX_ADICIONARFILME_ANO.Text + @"<\/span><\/a><\/span><\/span><\/strong><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">Realizador: " + TEXTBOX_ADICIONARFILME_REALIZADOR.Text + @"<\/span><\/span><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">Actores Principais: " + TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text + @"<\/span><\/span><\/p><p style=\""margin-left: 30px;\""><img src=\""images\/imagens\/blog\/imdb.png\"" width=\""46\"" height=\""22\"" alt=\""rating\"" style=\""vertical-align: top;\""\/><strong><span style=\""font-size: 16pt; color: #f88c00;\""> " + TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text + @"<\/span><\/strong><span style=\""font-size: 10pt; color: #000000;\"">\/10<\/span><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">" + TEXTBOX_ADICIONARFILME_SINOPSE.Text + @"<\/span><\/span><\/p><p style=\""text-align: center;\""><table border=\""0\"" style=\""width: 100%;\""><tbody><tr><td align=\""center\"" style=\""width: 50%;\""><a href=\""http:\/\/www.bitwow.tk\/stuff\/filmes\/" + TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text + @"\"" data-spotlight=\""effect:bottom\"" data-lightbox=\""on;transitionIn:fade;transitionOut:fade;\""><img width=\""100\"" height=\""21\"" alt=\""\"" src=\""images\/imagens\/blog\/play.png\"" \/><\/td><td align=\""left\"" style=\""width: 50%;\""><a href=\""http:\/\/www.bitwow.tk\/stuff\/filmes\/" + TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text + @"\"" title=\""\"" download=\""" + TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text + @"\""><img src=\""images\/imagens\/blog\/download2.png\"" width=\""100\"" height=\""21\"" alt=\""download\"" style=\""vertical-align: middle;\""\/><\/a><\/td><\/tr><\/tbody><\/table><\/p><\/td><\/tr><\/tbody><\/table><\/p>""
		}
	},
	""cdce6654-4e01-4a7f-9ed6-0407709d904c"":  {
		""file"": """",
		""title"": """",
		""link"": """",
		""target"": ""0"",
		""rel"": """",
		""lightbox_image"": """",
		""spotlight_effect"": """",
		""caption"": """"
	},
	""c26feca6-b2d4-47eb-a74d-b067aaae5b90"":  {
		""file"": ""images\/imagens\/covers\/filmes\/capa-modulos\/" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text + @""",
		""title"": """",
		""link"": """",
		""target"": ""0"",
		""rel"": """",
		""lightbox_image"": """",
		""spotlight_effect"": """",
		""caption"": """"
	},
	""0bee21e2-8f88-4f5b-83af-686cd1c7ef4b"":  {
		""url"": """",
		""width"": """",
		""height"": """",
		""autoplay"": ""0""
	},
	""65b7851d-199f-4ac6-95a7-409ad1bca488"":  {
		""item"":  {

		}
	},
	""fdcbebaa-e61a-462d-963e-aff74ff95499"":  {
		""0"":  {
			""value"": """",
			""text"": """",
			""target"": ""0"",
			""custom_title"": """",
			""rel"": """"
		}
	},
	""d857d939-47e9-4303-8f37-93b0cecace54"":  {
		""value"": ""1""
	}
}";
                QueryParams = @" {
	""metadata.title"": """",
	""metadata.description"": """",
	""metadata.keywords"": """",
	""metadata.robots"": """",
	""metadata.author"": """",
	""config.enable_comments"": ""1"",
	""config.primary_category"": 2
}";

                //Query = @"INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + "(`application_id`, `type`, `name`, `alias`, `created`, `modified`, `modified_by`, `publish_up`, `publish_down`, `priority`, `hits`, `state`, `access`, `created_by`, `searchable`, `elements`, `params`) VALUES(4,'article', '" + TEXTBOX_ADICIONARFILME_TITULOPT.Text + "', '" + TEXTBOX_ADICIONARFILME_ALIAS.Text + "', '" + LABEL_DATA.Text + "', '" + LABEL_DATA.Text + "', '928', '" + LABEL_DATA.Text + "', '0000-00-00 00:00:00', '0', '0', '1', '2', '928', '1', '" + QueryElement + "', '" + QueryParams + "')";

                MySqlCommand Comando = new MySqlCommand("SP_FILMES_BSZOOITEM_INSERIR", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;

                int App_ID = 4;
                string Type = "article";
                string Name = TEXTBOX_ADICIONARFILME_TITULOPT.Text;
                string Alias = TEXTBOX_ADICIONARFILME_ALIAS.Text;
                string Created = LABEL_DATA.Text;
                string Modified = LABEL_DATA.Text;
                int ModifiedBy = 928;
                string PublishUp = LABEL_DATA.Text;
                string PublishDown = "0000-00-00 00:00:00";
                int Priority = 0;
                int Hits = 0;
                int State = 1;
                int Access = 2;
                int CreatedBy = 928;
                int Searchable = 1;
                string Elements = QueryElement;
                string Params = QueryParams;

                Comando.Parameters.AddWithValue("_appid", App_ID);
                Comando.Parameters.AddWithValue("_type", Type);
                Comando.Parameters.AddWithValue("_name", Name);
                Comando.Parameters.AddWithValue("_alias", Alias);
                Comando.Parameters.AddWithValue("_created", Created);
                Comando.Parameters.AddWithValue("_modified", Modified);
                Comando.Parameters.AddWithValue("_modifiedby", ModifiedBy);
                Comando.Parameters.AddWithValue("_publishup", PublishUp);
                Comando.Parameters.AddWithValue("_publishdown", PublishDown);
                Comando.Parameters.AddWithValue("_priority", Priority);
                Comando.Parameters.AddWithValue("_hits", Hits);
                Comando.Parameters.AddWithValue("_state", State);
                Comando.Parameters.AddWithValue("_access", Access);
                Comando.Parameters.AddWithValue("_createdby", CreatedBy);
                Comando.Parameters.AddWithValue("_searchable", Searchable);
                Comando.Parameters.AddWithValue("_elements", Elements);
                Comando.Parameters.AddWithValue("_params", Params);

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB_StoredProcedures.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show("Ocorreu um erro ao inserir o filme na tabela BS_ZOO_ITEM \nErro: \n\n" + EX.Message, "Ocorreu um erro ao Inserir (BS_ZOO_ITEM)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void InserirFilmeEmFilmes()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB_StoredProcedures.Open();

                //string QueryFilmeID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name = '" + TEXTBOX_ADICIONARFILME_TITULOPT.Text + "'";

                MySqlCommand Comando = new MySqlCommand("SP_FILMES_BSZOOITEM_SELECT_ID_FOR_INSERT", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.AddWithValue("_name", TEXTBOX_ADICIONARFILME_TITULOPT.Text);
                int FilmeID = Convert.ToInt32(Comando.ExecuteScalar());

                //string QueryInserirFilme = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM + "(`category_id`, `item_id`) VALUES(2, " + FilmeID + ")";
                MySqlCommand Comando_INSERT = new MySqlCommand("SP_FILMES_BSZOOCATEGORYITEM_INSERT", LigacaoDB_StoredProcedures);
                Comando_INSERT.CommandType = CommandType.StoredProcedure;
                Comando_INSERT.Parameters.AddWithValue("_id", 2);
                Comando_INSERT.Parameters.AddWithValue("_itemid", FilmeID);
                Reader = Comando_INSERT.ExecuteReader();
                Reader.Close();

                LigacaoDB_StoredProcedures.Close();

                LimparStringsPreview();

                //PreencherDataGridView();

                AplicarEnviado();

                if (LigacaoDB_StoredProcedures.State == ConnectionState.Closed)
                    MessageBox.Show("Filme inserido com sucesso!", "Filme Inserido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        public void AplicarEnviado()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                string Query = "UPDATE " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " SET Enviado=1 WHERE ID = " + ID_Filme_Catalogo + "";

                MySqlCommand Comando = new MySqlCommand(Query, LigacaoDB);

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        public void DesaplicarEnviado()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                string NomePT = TEXTBOX_REMOVERFILME_TITULOPT.Text;
                int IdFilmeCatalogo;

                string QueryIdFilmeCatalogo = "SELECT ID FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " WHERE TituloPT = '" + NomePT + "'";
                MySqlCommand Comando_IdFilmeCatalogo = new MySqlCommand(QueryIdFilmeCatalogo, LigacaoDB);
                IdFilmeCatalogo = Convert.ToInt32(Comando_IdFilmeCatalogo.ExecuteScalar());

                string QueryDesaplicarEnviado = "UPDATE " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + " SET Enviado=0 WHERE ID = " + IdFilmeCatalogo + "";
                MySqlCommand Comando_DesaplicarEnviado = new MySqlCommand(QueryDesaplicarEnviado, LigacaoDB);
                Reader = Comando_DesaplicarEnviado.ExecuteReader();
                Reader.Close();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                //MessageBox.Show(EX.Message);
            }
        }

        public void Inserir_AccessBD()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB_StoredProcedures.Open();

                string Titulo = TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text;
                string TituloPT = TEXTBOX_ADICIONARFILME_TITULOPT.Text;
                string Genero = COMBOBOX_ADICIONARFILME_GENERO.Text;
                string Ano = TEXTBOX_ADICIONARFILME_ANO.Text;
                string IMDB = TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text;
                string Realizador = TEXTBOX_ADICIONARFILME_REALIZADOR.Text;
                string Actores = TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text;
                string Sinopse = TEXTBOX_ADICIONARFILME_SINOPSE.Text;
                string Capa = TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;

                //string Query = "INSERT INTO " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSCATALOGOFILMES + "(Titulo_Original, TituloPT, Genero, Data, Realizador, Actores_Principais, Sinopse, IMDB, Endereco_Capa) VALUES ('" + Titulo + "', '" + TituloPT + "', '" + Genero + "', '" + Ano + "', '" + Realizador + "', '" + Actores + "', '" + Sinopse + "', '" + IMDB + "', '" + Capa + "');";

                MySqlCommand Comando = new MySqlCommand("SP_CATALOGOFILMES_INSERIR", LigacaoDB_StoredProcedures);
                Comando.CommandType = CommandType.StoredProcedure;

                Comando.Parameters.AddWithValue("titulo", Titulo);
                Comando.Parameters.AddWithValue("titulopt", TituloPT);
                Comando.Parameters.AddWithValue("genero", Genero);
                Comando.Parameters.AddWithValue("ano", Ano);
                Comando.Parameters.AddWithValue("realizador", IMDB);
                Comando.Parameters.AddWithValue("actores", Realizador);
                Comando.Parameters.AddWithValue("sinopse", Actores);
                Comando.Parameters.AddWithValue("imdb", Sinopse);
                Comando.Parameters.AddWithValue("enderecocapa", Capa);

                Reader = Comando.ExecuteReader();

                Reader.Close();

                LigacaoDB_StoredProcedures.Close();
            }

            catch(Exception EX)
            { }
        }

        public void AlterarFilme()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB_StoredProcedures.Open();

                AlterarFilme_Obter_FilmeID_TabelaPrincipal();

                Alterar_AliasGenero();

                if (LigacaoDB.State == ConnectionState.Open)
                    LigacaoDB.Close();
                if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                    LigacaoDB_StoredProcedures.Close();

                LigacaoDB_StoredProcedures.Open();

                int TabelaBSFilmes_FilmeID = Convert.ToInt32(DATAGRIDVIEW_ALTERARFILME.SelectedCells[0].Value);

                LigacaoDB.Open();

                string Created;
                string QueryCreated = "SELECT created FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE id=" + Int_AlterarFilme_FilmeID_Principal_Tabela_BsZooItem + "";
                MySqlCommand Comando_Created = new MySqlCommand(QueryCreated, LigacaoDB);
                Created = Comando_Created.ExecuteScalar().ToString();

                //DateTime Data = DateTime.Now;
                //string FormatoData = "yyyy-MM-dd HH:mm:ss";
                //LABEL_DATA.Text = Data.ToString(FormatoData);

                //DateTime dt = Convert.ToDateTime(Created);

                LigacaoDB.Close();


                #region STORED PROCEDURE [ALTERAR] PARA A TABELA BS_FILMES

                #region QUERY ANTIGA
                //string Query_UPDATE_BSFILMES = "UPDATE " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " SET application_id=4, type='article', Nome='" + TEXTBOX_ALTERARFILME_TITULOPT.Text + "', Nome_Original='" + TEXTBOX_ALTERARFILME_TITULORIGINAL.Text + "', Ano='" + TEXTBOX_ALTERARFILME_ANO.Text + "', Categoria='" + COMBOBOX_ALTERARFILME_GENERO.Text + "', Realizador='" + TEXTBOX_ALTERARFILME_REALIZADOR.Text + "', Actores_Principais='" + TEXTBOX_ALTERARFILME_ACTORES.Text + "', Sinopse='" + TEXTBOX_ALTERARFILME_SINOPSE.Text + "', IMDB='" + TEXTBOX_ALTERARFILME_IMDB.Text + "', Alias_Filme='" + TEXTBOX_ALTERARFILME_ALIASFILME.Text + "', Link_Ver_Filme='/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_VERFILME.Text + "', Link_Filme='/index.php/filmes/item/" + TEXTBOX_ALTERARFILME_LINK_FILME.Text + "', Link_Download_Filme='/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_DOWNLOAD.Text + "', Alias_Categoria='" + GeneroAliasAUX + "', Link_Categoria='index.php/filmes-" + GeneroAliasAUX + "', Alias_Ano='" + TEXTBOX_ALTERARFILME_ANO.Text + "', Link_Ano='index.php/filmes-" + TEXTBOX_ALTERARFILME_ANO.Text + "', Link_Capa_BLOG='/images/imagens/covers/filmes/capa-blog/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + "', Link_Capa_ZOOM='" + CLASS_GLOBAL_VARIABLES.BD + "/images/imagens/covers/filmes/capa-zoom/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + "', Ficheiro_Filme='" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text + "', Ficheiro_Capa='" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + "' WHERE id=" + TabelaBSFilmes_FilmeID + "";
                #endregion

                int A_id = TabelaBSFilmes_FilmeID;
                int A_App_ID = 4;
                string A_Type = "article";
                string A_Nome = TEXTBOX_ALTERARFILME_TITULORIGINAL.Text;
                string A_NomePT = TEXTBOX_ALTERARFILME_TITULOPT.Text;
                string A_Ano = TEXTBOX_ALTERARFILME_ANO.Text;
                string A_Categoria = COMBOBOX_ALTERARFILME_GENERO.Text;
                string A_Realizador = TEXTBOX_ALTERARFILME_REALIZADOR.Text;
                string A_Actores = TEXTBOX_ALTERARFILME_ACTORES.Text;
                string A_Sinopse = TEXTBOX_ALTERARFILME_SINOPSE.Text;
                string A_IMDB = TEXTBOX_ALTERARFILME_IMDB.Text;
                string A_AliasFilme = TEXTBOX_ALTERARFILME_ALIASFILME.Text;
                string A_LinkVerFilme = "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_VERFILME.Text;
                string A_LinkFilme = "/index.php/filmes/item/" + TEXTBOX_ALTERARFILME_LINK_FILME.Text;
                string A_LinkDownloadFilme = CLASS_GLOBAL_VARIABLES.BD + "/stuff/filmes/" + TEXTBOX_ALTERARFILME_LINK_DOWNLOAD.Text;
                string A_AliasCategoria = GeneroAliasAUX;
                string A_LinkCategoria = "index.php/filmes-" + GeneroAliasAUX;
                string A_AliasAno = TEXTBOX_ALTERARFILME_ANO.Text;
                string A_LinkAno = "index.php/filmes-" + TEXTBOX_ALTERARFILME_ANO.Text;
                string A_LinkCapaBlog = "/images/imagens/covers/filmes/capa-blog/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text;
                string A_LinkCapaZoom = "/images/imagens/covers/filmes/capa-zoom/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text;
                string A_FicheiroFilme = TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text;
                string A_FicheiroCapa = TEXTBOX_ALTERARFILME_ALTERARCAPA.Text;

                MySqlCommand Comando_UPDATE_BSFILMES = new MySqlCommand("SP_FILMES_BSFILMES_ALTERAR", LigacaoDB_StoredProcedures);
                Comando_UPDATE_BSFILMES.CommandType = CommandType.StoredProcedure;

                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_id", A_id);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_appid", A_App_ID);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_type", A_Type);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_nome", A_NomePT);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_nomeoriginal", A_Nome);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_ano", A_Ano);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_categoria", A_Categoria);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_realizador", A_Realizador);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_actores", A_Actores);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_sinopse", A_Sinopse);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_imdb", A_IMDB);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_aliasfilme", A_AliasFilme);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkverfilme", A_LinkVerFilme);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkfilme", A_LinkFilme);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkdownloadfilme", A_LinkDownloadFilme);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_aliascategoria", A_AliasCategoria);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkcategoria", A_LinkCategoria);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_aliasano", A_AliasAno);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkano", A_LinkAno);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkcapablog", A_LinkCapaBlog);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_linkcapazoom", A_LinkCapaZoom);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_ficheirofilme", A_FicheiroFilme);
                Comando_UPDATE_BSFILMES.Parameters.AddWithValue("_ficheirocapa", A_FicheiroCapa);

                Comando_UPDATE_BSFILMES.ExecuteNonQuery();

                #endregion

                #region STORED PROCEDURE [ALTERAR] PARA A TABELA BS_ZOO_ITEM

                string QueryElement;
                string QueryParams;
                string Query_UPDATE_BSZOOITEM;

                QueryElement = @"{""2616ded9-e88b-4b77-a92c-2c4c18bb995f"":  {
		""0"":  {
			""value"": """"
		}
	},
	""fc5a6788-ffae-41d9-a812-3530331fef64"":  {
		""item"":  {

		}
	},
	""08795744-c2dc-4a68-8252-4e21c4c4c774"":  {
		""0"":  {
			""value"": """"
		}
	},
	
	""2e3c9e69-1f9e-4647-8d13-4e88094d2790"":  {
		""0"":  {
			""value"": ""<p><table border=\""0\"" width=\""100%\""><tbody><tr><td style=\""width: 150px;\""><a data-lightbox=\""on;transitionIn:elastic;transitionOut:elastic;\"" data-spotlight=\""on\"" href=\""images\/imagens\/covers\/filmes\/capa-zoom\/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + @"\""><img src=\""images\/imagens\/covers\/filmes\/capa-blog\/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + @"\""width=\""150\"" height=\""184\"" alt=\""" + TEXTBOX_ALTERARFILME_TITULORIGINAL.Text + @"\""\/><\/a><\/td><td><p style=\""text-align: center;\""><strong><span style=\""font-family: ''courier new'', courier; font-size: 12pt; color: #000080;\""><a href=\""index.php\/filmes\/item\/" + TEXTBOX_ALTERARFILME_ALIASFILME.Text + @"\""><span style=\""color: #000080;\"">\""" + TEXTBOX_ALTERARFILME_TITULORIGINAL.Text + @"\""<\/span><\/a> | <a href=\""index.php\/filmes-" + GeneroAliasAUX + @"\""><span style=\""color: #000080;\"">" + GeneroAUX + @"<\/span><\/a> | <\/span><span style=\""color: #000080;\""><span style=\""font-family: ''courier new'', courier; font-size: 12pt;\""><a href=\""index.php\/filmes-" + TEXTBOX_ALTERARFILME_ANO.Text + @"\""><span style=\""color: #000080;\"">" + TEXTBOX_ALTERARFILME_ANO.Text + @"<\/span><\/a><\/span><\/span><\/strong><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">Realizador: " + TEXTBOX_ALTERARFILME_REALIZADOR.Text + @"<\/span><\/span><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">Actores Principais: " + TEXTBOX_ALTERARFILME_ACTORES.Text + @"<\/span><\/span><\/p><p style=\""margin-left: 30px;\""><img src=\""images\/imagens\/blog\/imdb.png\"" width=\""46\"" height=\""22\"" alt=\""rating\"" style=\""vertical-align: top;\""\/><strong><span style=\""font-size: 16pt; color: #f88c00;\""> " + TEXTBOX_ALTERARFILME_IMDB.Text + @"<\/span><\/strong><span style=\""font-size: 10pt; color: #000000;\"">\/10<\/span><\/p><p style=\""margin-left: 30px;\""><span style=\""color: #808080;\""><span style=\""font-family: ''book antiqua'', palatino; font-size: 10pt;\"">" + TEXTBOX_ALTERARFILME_SINOPSE.Text + @"<\/span><\/span><\/p><p style=\""text-align: center;\""><table border=\""0\"" style=\""width: 100%;\""><tbody><tr><td align=\""center\"" style=\""width: 50%;\""><a href=\""http:\/\/www.bitwow.tk\/stuff\/filmes\/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text + @"\"" data-spotlight=\""effect:bottom\"" data-lightbox=\""on;transitionIn:fade;transitionOut:fade;\""><img width=\""100\"" height=\""21\"" alt=\""\"" src=\""images\/imagens\/blog\/play.png\"" \/><\/td><td align=\""left\"" style=\""width: 50%;\""><a href=\""http:\/\/www.bitwow.tk\/stuff\/filmes\/" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text + @"\"" title=\""\"" download=\""" + TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text + @"\""><img src=\""images\/imagens\/blog\/download2.png\"" width=\""100\"" height=\""21\"" alt=\""download\"" style=\""vertical-align: middle;\""\/><\/a><\/td><\/tr><\/tbody><\/table><\/p><\/td><\/tr><\/tbody><\/table><\/p>""
		}
	},
	""cdce6654-4e01-4a7f-9ed6-0407709d904c"":  {
		""file"": """",
		""title"": """",
		""link"": """",
		""target"": ""0"",
		""rel"": """",
		""lightbox_image"": """",
		""spotlight_effect"": """",
		""caption"": """"
	},
	""c26feca6-b2d4-47eb-a74d-b067aaae5b90"":  {
		""file"": ""images\/imagens\/covers\/filmes\/capa-modulos\/" + TEXTBOX_ALTERARFILME_ALTERARCAPA.Text + @""",
		""title"": """",
		""link"": """",
		""target"": ""0"",
		""rel"": """",
		""lightbox_image"": """",
		""spotlight_effect"": """",
		""caption"": """"
	},
	""0bee21e2-8f88-4f5b-83af-686cd1c7ef4b"":  {
		""url"": """",
		""width"": """",
		""height"": """",
		""autoplay"": ""0""
	},
	""65b7851d-199f-4ac6-95a7-409ad1bca488"":  {
		""item"":  {

		}
	},
	""fdcbebaa-e61a-462d-963e-aff74ff95499"":  {
		""0"":  {
			""value"": """",
			""text"": """",
			""target"": ""0"",
			""custom_title"": """",
			""rel"": """"
		}
	},
	""d857d939-47e9-4303-8f37-93b0cecace54"":  {
		""value"": ""1""
	}
}";

                QueryParams = @" {
	""metadata.title"": """",
	""metadata.description"": """",
	""metadata.keywords"": """",
	""metadata.robots"": """",
	""metadata.author"": """",
	""config.enable_comments"": ""1"",
	""config.primary_category"": 2
}";

                #region QUERY ANTIGA
                //Query_UPDATE_BSZOOITEM = @"UPDATE " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " SET application_id=4, type='article', name='" + TEXTBOX_ALTERARFILME_TITULOPT.Text + "', alias='" + TEXTBOX_ALTERARFILME_ALIASFILME.Text + "', created='" + LABEL_DATA.Text + "', modified='" + LABEL_DATA.Text + "', modified_by='928', publish_up='" + LABEL_DATA.Text + "', publish_down='0000-00-00 00:00:00', priority='0', hits='0', state='1', access='2', created_by='928', searchable='1', elements='" + QueryElement + "',  params='" + QueryParams + "' WHERE id=" + Int_AlterarFilme_FilmeID_Principal_Tabela_BsZooItem + "";
                #endregion

                MySqlCommand Comando_UPDATE_BSZOOITEM = new MySqlCommand("SP_FILMES_BSZOOITEM_ALTERAR", LigacaoDB_StoredProcedures);
                Comando_UPDATE_BSZOOITEM.CommandType = CommandType.StoredProcedure;

                int B_id = Int_AlterarFilme_FilmeID_Principal_Tabela_BsZooItem;
                int B_App_ID = 4;
                string B_Type = "article";
                string B_Name = TEXTBOX_ALTERARFILME_TITULOPT.Text;
                string B_Alias = TEXTBOX_ALTERARFILME_ALIASFILME.Text;
                string B_Created = LABEL_DATA.Text;
                string B_Modified = LABEL_DATA.Text;
                int B_ModifiedBy = 928;
                string B_PublishUp = LABEL_DATA.Text;
                string B_PublishDown = "0000-00-00 00:00:00";
                int B_Priority = 0;
                int B_Hits = 0;
                int B_State = 1;
                int B_Access = 2;
                int B_CreatedBy = 928;
                int B_Searchable = 1;
                string B_Elements = QueryElement;
                string B_Params = QueryParams;

                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_id", B_id);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_appid", B_App_ID);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_type", B_Type);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_name", B_Name);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_alias", B_Alias);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_created", B_Created);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_modified", B_Modified);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_modifiedby", B_ModifiedBy);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_publishup", B_PublishUp);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_publishdown", B_PublishDown);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_priority", B_Priority);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_hits", B_Hits);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_state", B_State);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_access", B_Access);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_createdby", B_CreatedBy);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_searchable", B_Searchable);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_elements", B_Elements);
                Comando_UPDATE_BSZOOITEM.Parameters.AddWithValue("_params", B_Params);               

                Comando_UPDATE_BSZOOITEM.ExecuteNonQuery();

                #endregion

                LigacaoDB_StoredProcedures.Close();

                if (LigacaoDB_StoredProcedures.State == ConnectionState.Closed)
                    MessageBox.Show("Filme alterado com sucesso!", "Filme Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
                MessageBox.Show("Ocorreu um erro em Alterar Filme: \n\n " + EX.Message + "", "Erro em Alterar Filme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimparTextBoxs_InserirFilme()
        {
            TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text = "";
            TEXTBOX_ADICIONARFILME_TITULOPT.Text = "";
            TEXTBOX_ADICIONARFILME_ALIAS.Text = "";
            TEXTBOX_ADICIONARFILME_ANO.Text = "";
            TEXTBOX_ADICIONARFILME_REALIZADOR.Text = "";
            TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text = "";
            TEXTBOX_ADICIONARFILME_SINOPSE.Text = "";
            TEXTBOX_ADICIONARFILME_FICHEIROMP4.Text = "";
            TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text = "";
            TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text = "";
            TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text = "";
            PICTUREBOX_ADICIONARFILME_COVER.Image = null;
            COMBOBOX_ADICIONARFILME_GENERO.SelectedItem = null;
        }

        public void LimparStringsPreview()
        {
            Preview_TituloOriginal = "";
            Preview_TituloPT = "";
            Preview_Realizador = "";
            Preview_Actores = "";
            Preview_Sinopse = "";
            Preview_Genero = "";
            Preview_Ano = "";
            Preview_IMDB = "";
            Preview_Capa = "";
        }

        public void CopiarDataParaStringsPreview()
        {
            try
            {
                Preview_TituloOriginal = TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text;
                Preview_TituloPT = TEXTBOX_ADICIONARFILME_TITULOPT.Text;
                Preview_Realizador = TEXTBOX_ADICIONARFILME_REALIZADOR.Text;
                Preview_Actores = TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text;
                Preview_Sinopse = TEXTBOX_ADICIONARFILME_SINOPSE.Text;
                Preview_Genero = COMBOBOX_ADICIONARFILME_GENERO.SelectedItem.ToString();
                Preview_Ano = TEXTBOX_ADICIONARFILME_ANO.Text;
                Preview_IMDB = TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text;
                Preview_Capa = PICTUREBOX_ADICIONARFILME_COVER.ImageLocation.ToString() + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;
            }

            catch (Exception EX)
            {
            }
        }

        public void RemoverFilme()
        {
            try
            {
                LigacaoDB_StoredProcedures.Open();

                //--------------------------------------------------------------------------------------------

                //string Query_bsFilmes_SelectID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome = '" + TEXTBOX_REMOVERFILME_TITULOPT.Text + "'";
                //string Query_bsFilmes_Delete = "DELETE FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome = '" + TEXTBOX_REMOVERFILME_TITULOPT.Text + "'";

                MySqlCommand Comando_bsFilmes_Delete = new MySqlCommand("SP_FILMES_BSFILMES_DELETE", LigacaoDB_StoredProcedures);
                Comando_bsFilmes_Delete.CommandType = CommandType.StoredProcedure;
                string BSFILMES_NOME = TEXTBOX_REMOVERFILME_TITULOPT.Text;
                Comando_bsFilmes_Delete.Parameters.AddWithValue("_nome", BSFILMES_NOME);
                Reader = Comando_bsFilmes_Delete.ExecuteReader();
                Reader.Close();

                //--------------------------------------------------------------------------------------------

                //string Query_bsZooItem_Delete = "DELETE FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE id = '" + FilmeID + "'";

                MySqlCommand Comando_bsZooItem_Delete = new MySqlCommand("SP_FILMES_BSZOOITEM_DELETE", LigacaoDB_StoredProcedures);
                Comando_bsZooItem_Delete.CommandType = CommandType.StoredProcedure;
                string Name = TEXTBOX_REMOVERFILME_TITULOPT.Text;
                Comando_bsZooItem_Delete.Parameters.AddWithValue("_name", Name);
                Reader = Comando_bsZooItem_Delete.ExecuteReader();
                Reader.Close();                

                //--------------------------------------------------------------------------------------------

                //string QuerybsZooItemSelectID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name = '" + TEXTBOX_REMOVERFILME_TITULOPT.Text + "'";
                //string StringFilmeID = ComandobsZooItemSelectID.ExecuteScalar().ToString();
                //int FilmeID = Convert.ToInt32(StringFilmeID); 

                MySqlCommand Comando_bsZooItem_SelectForDelete = new MySqlCommand("SP_FILMES_BSZOOITEM_SELECT_ID_FOR_DELETE", LigacaoDB_StoredProcedures);
                Comando_bsZooItem_SelectForDelete.CommandType = CommandType.StoredProcedure;
                Comando_bsZooItem_SelectForDelete.Parameters.AddWithValue("_name", Name);
                int FilmeID = Convert.ToInt32(Comando_bsZooItem_SelectForDelete.ExecuteScalar());

                //string Query_bsZooCategoryItem_Delete = "DELETE FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM + " WHERE item_id = '" + FilmeID + "'";
                MySqlCommand Comando_bsZooCategoryItem_Delete = new MySqlCommand("SP_FILMES_BSZOOCATEGORYITEM_DELETE", LigacaoDB_StoredProcedures);
                Comando_bsZooCategoryItem_Delete.CommandType = CommandType.StoredProcedure;
                Comando_bsZooCategoryItem_Delete.Parameters.AddWithValue("_id", FilmeID);
                Reader = Comando_bsZooCategoryItem_Delete.ExecuteReader();
                Reader.Close();

                //--------------------------------------------------------------------------------------------
                
                LigacaoDB_StoredProcedures.Close();

                DesaplicarEnviado();

                MessageBox.Show("Filme Removido com Sucesso", "Filme Removido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception EX)
            {
            }
        }

        public void AlterarFilme_PreencherInformacoesBasicas()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                AliasGenero();

                string TituloOriginal = "";
                string TituloPT = "";
                string Alias = "";
                string Genero = "";
                string Ano = "";
                string IMDB = "";

                string Query_TituloOriginal = "SELECT Nome_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_TituloPT = "SELECT Nome FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_Alias = "SELECT Alias_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_Genero = "SELECT Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_Ano = "SELECT Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_IMDB = "SELECT IMDB FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";

                MySqlCommand Comando_TituloOriginal = new MySqlCommand(Query_TituloOriginal, LigacaoDB);
                TituloOriginal = Comando_TituloOriginal.ExecuteScalar().ToString();

                MySqlCommand Comando_TituloPT = new MySqlCommand(Query_TituloPT, LigacaoDB);
                TituloPT = Comando_TituloPT.ExecuteScalar().ToString();

                MySqlCommand Comando_Alias = new MySqlCommand(Query_Alias, LigacaoDB);
                Alias = Comando_Alias.ExecuteScalar().ToString();

                MySqlCommand Comando_Genero = new MySqlCommand(Query_Genero, LigacaoDB);
                Genero = Comando_Genero.ExecuteScalar().ToString();

                MySqlCommand Comando_Ano = new MySqlCommand(Query_Ano, LigacaoDB);
                Ano = Comando_Ano.ExecuteScalar().ToString();

                MySqlCommand Comando_IMDB = new MySqlCommand(Query_IMDB, LigacaoDB);
                IMDB = Comando_IMDB.ExecuteScalar().ToString();

                TEXTBOX_ALTERARFILME_TITULORIGINAL.Text = TituloOriginal;
                TEXTBOX_ALTERARFILME_TITULOPT.Text = TituloPT;
                TEXTBOX_ALTERARFILME_ALIASFILME.Text = Alias;

                #region COMBOBOX GENERO
                if (Genero == "Acção")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 0;
                if (Genero == "Animação")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 1;
                if (Genero == "Aventura")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 2;
                if (Genero == "Biografia")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 3;
                if (Genero == "Clássicos")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 4;
                if (Genero == "Comédia")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 5;
                if (Genero == "Crime")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 6;
                if (Genero == "Desporto")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 7;
                if (Genero == "Documentário")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 8;
                if (Genero == "Drama")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 9;
                if (Genero == "Familiar")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 10;
                if (Genero == "Fantasia")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 11;
                if (Genero == "Ficção Cientifica")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 12;
                if (Genero == "Guerra")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 13;
                if (Genero == "História")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 14;
                if (Genero == "Mistério")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 15;
                if (Genero == "Musical")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 16;
                if (Genero == "Romance")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 17;
                if (Genero == "Terror")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 18;
                if (Genero == "Thriller")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 19;
                if (Genero == "Western")
                    COMBOBOX_ALTERARFILME_GENERO.SelectedIndex = 20;
                #endregion

                TEXTBOX_ALTERARFILME_ANO.Text = Ano;
                TEXTBOX_ALTERARFILME_IMDB.Text = IMDB;

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        public void AlterarFilme_PreencherInformacoesDetalhadas()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                string Realizador = "";
                string Actores = "";
                string Sinopse = "";

                string Query_Realizador = "SELECT Realizador FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_Actores = "SELECT Actores_Principais FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_Sinopse = "SELECT Sinopse FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";

                MySqlCommand Comando_Realizador = new MySqlCommand(Query_Realizador, LigacaoDB);
                Realizador = Comando_Realizador.ExecuteScalar().ToString();
                

                MySqlCommand Comando_Actores = new MySqlCommand(Query_Actores, LigacaoDB);
                Actores = Comando_Actores.ExecuteScalar().ToString();

                MySqlCommand Comando_Sinopse = new MySqlCommand(Query_Sinopse, LigacaoDB);
                Sinopse = Comando_Sinopse.ExecuteScalar().ToString();

                TEXTBOX_ALTERARFILME_REALIZADOR.Text = Realizador;
                TEXTBOX_ALTERARFILME_ACTORES.Text = Actores;
                TEXTBOX_ALTERARFILME_SINOPSE.Text = Sinopse;

                LigacaoDB.Close();
            }

            catch (Exception EX)
            { }
        }

        public void AlterarFilme_PreencherLinks()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                string Link_VerFilme = "";
                string Link_Download = "";
                string Link_Filme = "";
                string Link_AliasAno = "";
                string Link_Ano = "";
                string Link_CapaBlog = "";
                string Link_CapaZoom = "";
                string Link_FicheiroMP4 = "";
                string Link_AliasCategoria = "";
                string Link_Categoria = "";

                string Query_LinkVerFilme = "SELECT Link_Ver_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_LinkDownload = "SELECT Link_Download_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_LinkFilme = "SELECT Link_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_AliasAno = "SELECT Alias_Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_LinkAno = "SELECT Link_Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_CapaLinkBlog = "SELECT Link_Capa_BLOG FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_LinkCapaZoom = "SELECT Link_Capa_ZOOM FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_FicheiroMP4 = "SELECT Ficheiro_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_AliasCategoria = "SELECT Alias_Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";
                string Query_LinkCategoria = "SELECT Link_Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";

                MySqlCommand Comando_VerFilme = new MySqlCommand(Query_LinkVerFilme, LigacaoDB);
                Link_VerFilme = Comando_VerFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkDownload = new MySqlCommand(Query_LinkDownload, LigacaoDB);
                Link_Download = Comando_LinkDownload.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkFilme = new MySqlCommand(Query_LinkFilme, LigacaoDB);
                Link_Filme = Comando_LinkFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_AliasAno = new MySqlCommand(Query_AliasAno, LigacaoDB);
                Link_AliasAno = Comando_AliasAno.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkAno = new MySqlCommand(Query_LinkAno, LigacaoDB);
                Link_Ano = Comando_LinkAno.ExecuteScalar().ToString();

                MySqlCommand Comando_CapaLinkBlog = new MySqlCommand(Query_CapaLinkBlog, LigacaoDB);
                Link_CapaBlog = Comando_CapaLinkBlog.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkCapaZoom = new MySqlCommand(Query_LinkCapaZoom, LigacaoDB);
                Link_CapaZoom = Comando_LinkCapaZoom.ExecuteScalar().ToString();

                MySqlCommand Comando_FicheiroMP4 = new MySqlCommand(Query_FicheiroMP4, LigacaoDB);
                Link_FicheiroMP4 = Comando_FicheiroMP4.ExecuteScalar().ToString();

                MySqlCommand Comando_AliasCategoria = new MySqlCommand(Query_AliasCategoria, LigacaoDB);
                Link_AliasCategoria = Comando_AliasCategoria.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkCategoria = new MySqlCommand(Query_LinkCategoria, LigacaoDB);
                Link_Categoria = Comando_LinkCategoria.ExecuteScalar().ToString();

                TEXTBOX_ALTERARFILME_LINK_VERFILME.Text = Link_VerFilme;
                TEXTBOX_ALTERARFILME_LINK_DOWNLOAD.Text = Link_Download;
                TEXTBOX_ALTERARFILME_LINK_FILME.Text = Link_Filme;
                TEXTBOX_ALTERARFILME_ALIAS_ANO.Text = Link_AliasAno;
                TEXTBOX_ALTERARFILME_LINK_ANO.Text = Link_Ano;
                TEXTBOX_ALTERARFILME_LINK_CapaBlog.Text = Link_CapaBlog;
                TEXTBOX_ALTERARFILME_LINK_CapaZoom.Text = Link_CapaZoom;
                TEXTBOX_ALTERARFILME_LINK_FicheiroMP4.Text = Link_FicheiroMP4;
                TEXTBOX_ALTERARFILME_ALIAS_CATEGORIA.Text = Link_AliasCategoria;
                TEXTBOX_ALTERARFILME_LINK_CATEGORIA.Text = Link_Categoria;

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
            }
        }

        public void AlterarFilme_DefinirCapa()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                string Capa = "";

                string Query_Capa = "SELECT Ficheiro_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE id = " + Int_AlterarFilme_FilmeID + "";

                MySqlCommand Comando_Capa = new MySqlCommand(Query_Capa, LigacaoDB);
                Capa = Comando_Capa.ExecuteScalar().ToString();

                TEXTBOX_ALTERARFILME_ALTERARCAPA.Text = Capa;

                if (Capa != "")
                    PICTUREBOX_ALTERARFILME_CAPA.Image = Image.FromFile(Properties.Settings.Default.cover_connection_type.ToString() + @"\" + Capa);
                if (Capa == "")
                    PICTUREBOX_ALTERARFILME_CAPA.Image = null;

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
                
            }
        }

        public void AlterarFilme_Obter_FilmeID_TabelaPrincipal()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                LigacaoDB.Open();

                int FilmeID;

                string Query_ObterFilmeID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name = '" + DATAGRIDVIEW_ALTERARFILME.SelectedCells[2].Value.ToString() + "'";

                MySqlCommand Comando = new MySqlCommand(Query_ObterFilmeID, LigacaoDB);

                FilmeID = Convert.ToInt32(Comando.ExecuteScalar());
                Int_AlterarFilme_FilmeID_Principal_Tabela_BsZooItem = FilmeID;

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
            }
        }        

        public void TransferirInformacao_FormInformacoesDetalhadas()
        {
            if (LigacaoDB.State == ConnectionState.Open)
                LigacaoDB.Close();
            if (LigacaoDB_StoredProcedures.State == ConnectionState.Open)
                LigacaoDB_StoredProcedures.Close();

            try
            {
                string DATAGRIDVIEW_FilmeSelecionado = DATAGRIDVIEW_LISTAFILMES.SelectedCells[2].Value.ToString();

                string Query_ID = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_IdPrincipal = "SELECT id FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + " WHERE name='" + DATAGRIDVIEW_FilmeSelecionado + "'";

                string Query_TituloOriginal = "SELECT Nome_Original FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_TituloPT = "SELECT Nome FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_IMDB = "SELECT IMDB FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_GeneroPrincipal = "SELECT Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_AnoProducao = "SELECT Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_Realizador = "SELECT Realizador FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_ActoresPrincipais = "SELECT Actores_Principais FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_Sinopse = "SELECT Sinopse FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_AliasFilme = "SELECT Alias_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkVerFilme = "SELECT Link_Ver_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkDownloadFilme = "SELECT Link_Download_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_AliasGenero = "SELECT Alias_Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkGenero = "SELECT Link_Categoria FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkAno = "SELECT Link_Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_AliasAno = "SELECT Alias_Ano FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkCapaBlog = "SELECT Link_Capa_BLOG FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_LinkCapaZoom = "SELECT Link_Capa_ZOOM FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_FicheiroFilme = "SELECT Ficheiro_Filme FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";
                string Query_FicheiroCapa = "SELECT Ficheiro_Capa FROM " + CLASS_GLOBAL_VARIABLES.BD + "." + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + " WHERE Nome='" + DATAGRIDVIEW_FilmeSelecionado + "'";

                LigacaoDB.Open();

                DetailInfo_FilmeSelecionado = DATAGRIDVIEW_LISTAFILMES.SelectedCells[2].Value.ToString();

                MySqlCommand Comando_ID = new MySqlCommand(Query_ID, LigacaoDB);
                DetailInfo_ID = Comando_ID.ExecuteScalar().ToString();

                MySqlCommand Comando_IdPrincipal = new MySqlCommand(Query_IdPrincipal, LigacaoDB);
                DetailInfo_IdPrincipal = Comando_IdPrincipal.ExecuteScalar().ToString();

                MySqlCommand Comando_TituloOriginal = new MySqlCommand(Query_TituloOriginal, LigacaoDB);
                DetailInfo_TituloOriginal = Comando_TituloOriginal.ExecuteScalar().ToString();

                MySqlCommand Comando_TituloPT = new MySqlCommand(Query_TituloPT, LigacaoDB);
                DetailInfo_TituloPT = Comando_TituloPT.ExecuteScalar().ToString();

                MySqlCommand Comando_IMDB = new MySqlCommand(Query_IMDB, LigacaoDB);
                DetailInfo_IMDB = Comando_IMDB.ExecuteScalar().ToString();

                MySqlCommand Comando_GeneroPrincipal = new MySqlCommand(Query_GeneroPrincipal, LigacaoDB);
                DetailInfo_GeneroPrincipal = Comando_GeneroPrincipal.ExecuteScalar().ToString();

                MySqlCommand Comando_AnoProducao = new MySqlCommand(Query_AnoProducao, LigacaoDB);
                DetailInfo_AnoProducao = Comando_AnoProducao.ExecuteScalar().ToString();

                MySqlCommand Comando_Realizador = new MySqlCommand(Query_Realizador, LigacaoDB);
                DetailInfo_Realizador = Comando_Realizador.ExecuteScalar().ToString();

                MySqlCommand Comando_ActoresPrincipais = new MySqlCommand(Query_ActoresPrincipais, LigacaoDB);
                DetailInfo_ActoresPrincipais = Comando_ActoresPrincipais.ExecuteScalar().ToString();

                MySqlCommand Comando_Sinopse = new MySqlCommand(Query_Sinopse, LigacaoDB);
                DetailInfo_Sinopse = Comando_Sinopse.ExecuteScalar().ToString();

                MySqlCommand Comando_AliasFilme = new MySqlCommand(Query_AliasFilme, LigacaoDB);
                DetailInfo_AliasFilme = Comando_AliasFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkVerFilme = new MySqlCommand(Query_LinkVerFilme, LigacaoDB);
                DetailInfo_LinkVerFilme = Comando_LinkVerFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkDownloadFilme = new MySqlCommand(Query_LinkDownloadFilme, LigacaoDB);
                DetailInfo_LinkDownloadFilme = Comando_LinkDownloadFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_AliasGenero = new MySqlCommand(Query_AliasGenero, LigacaoDB);
                DetailInfo_AliasGenero = Comando_AliasGenero.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkGenero = new MySqlCommand(Query_LinkGenero, LigacaoDB);
                DetailInfo_LinkGenero = Comando_LinkGenero.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkAno = new MySqlCommand(Query_LinkAno, LigacaoDB);
                DetailInfo_LinkAno = Comando_LinkAno.ExecuteScalar().ToString();

                MySqlCommand Comando_AliasAno = new MySqlCommand(Query_AliasAno, LigacaoDB);
                DetailInfo_AliasAno = Comando_AliasAno.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkCapaBlog = new MySqlCommand(Query_LinkCapaBlog, LigacaoDB);
                DetailInfo_LinkCapaBlog = Comando_LinkCapaBlog.ExecuteScalar().ToString();

                MySqlCommand Comando_LinkCapaZoom = new MySqlCommand(Query_LinkCapaZoom, LigacaoDB);
                DetailInfo_LinkCapaZoom = Comando_LinkCapaZoom.ExecuteScalar().ToString();

                MySqlCommand Comando_FicheiroFilme = new MySqlCommand(Query_FicheiroFilme, LigacaoDB);
                DetailInfo_FicheiroFilme = Comando_FicheiroFilme.ExecuteScalar().ToString();

                MySqlCommand Comando_FicheiroCapa = new MySqlCommand(Query_FicheiroCapa, LigacaoDB);
                DetailInfo_FicheiroCapa = Comando_FicheiroCapa.ExecuteScalar().ToString();

                LigacaoDB.Close();
            }

            catch (Exception EX)
            {
            }

            //FormDetailInfo_Objects.FilmeSelecionado = DetailInfo_FilmeSelecionado;
            //FormDetailInfo_Objects.ID = DetailInfo_ID;
            //FormDetailInfo_Objects.IdPrincipal = DetailInfo_IdPrincipal;
            //FormDetailInfo_Objects.TituloOriginal = DetailInfo_TituloOriginal;
            //FormDetailInfo_Objects.TituloPT = DetailInfo_TituloPT;
            //FormDetailInfo_Objects.IMDB = DetailInfo_IMDB;
            //FormDetailInfo_Objects.GeneroPrincipal = DetailInfo_GeneroPrincipal;
            //FormDetailInfo_Objects.AnoProducao = DetailInfo_AnoProducao;
            //FormDetailInfo_Objects.Realizador = DetailInfo_Realizador;
            //FormDetailInfo_Objects.ActoresPrincipais = DetailInfo_ActoresPrincipais;
            //FormDetailInfo_Objects.Sinopse = DetailInfo_Sinopse;
            //FormDetailInfo_Objects.AliasFilme = DetailInfo_AliasFilme;
            //FormDetailInfo_Objects.LinkVerFilme = DetailInfo_LinkVerFilme;
            //FormDetailInfo_Objects.LinkDownloadFilme = DetailInfo_LinkDownloadFilme;
            //FormDetailInfo_Objects.AliasGenero = DetailInfo_AliasGenero;
            //FormDetailInfo_Objects.LinkGenero = DetailInfo_LinkGenero;
            //FormDetailInfo_Objects.LinkAno = DetailInfo_LinkAno;
            //FormDetailInfo_Objects.AliasAno = DetailInfo_AliasAno;
            //FormDetailInfo_Objects.LinkCapaBlog = DetailInfo_LinkCapaBlog;
            //FormDetailInfo_Objects.LinkCapaZoom = DetailInfo_LinkCapaZoom;
            //FormDetailInfo_Objects.FicheiroFilme = DetailInfo_FicheiroFilme;
            //FormDetailInfo_Objects.FicheiroCapa = DetailInfo_FicheiroCapa;
        }

        private void DATAGRIDVIEW_LISTAFILMES_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                TransferirInformacao_FormInformacoesDetalhadas();
            }

            catch (Exception EX)
            {
            }
        }

        private void catálogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FORM_CATALOGO_FILMES Catalogo = new FORM_CATALOGO_FILMES();
            Catalogo.StartPosition = FormStartPosition.CenterScreen;
            Catalogo.Show();
        }

        public void CopyInfo()
        {
            try
            {

                TEXTBOX_ADICIONARFILME_TITULORIGINAL.Text = CopyInfo_Titulo;
                TEXTBOX_ADICIONARFILME_TITULOPT.Text = CopyInfo_TituloPT;
                COMBOBOX_ADICIONARFILME_GENERO.SelectedItem = CopyInfo_Genero;
                TEXTBOX_ADICIONARFILME_ANO.Text = CopyInfo_Data;
                TEXTBOX_ADICIONARFILME_REALIZADOR.Text = CopyInfo_Realizador;
                TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text = CopyInfo_Actores;
                TEXTBOX_ADICIONARFILME_SINOPSE.Text = CopyInfo_Sinopse;
                TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text = CopyInfo_IMDB;
                TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text = CopyInfo_Capa;

                string CoverPath = Properties.Settings.Default.cover_connection_type.ToString() + @"\" + TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text;

                if(CopyInfo_Capa != "")
                    PICTUREBOX_ADICIONARFILME_COVER.Image = Image.FromFile(CoverPath);
                if (CopyInfo_Capa == "")
                    PICTUREBOX_ADICIONARFILME_COVER.Image = null;
            }

            catch(Exception EX)
            { }
        }

        private void TEXTBOX_LISTAFILMES_PROCURARFILME_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_TITULOPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_ANO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_REALIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_SINOPSE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_FICHEIROMP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_LINKDOWNLOAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_REMOVERFILME_PROCURAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_PROCURAR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_TITULOPT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_ANO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_IMDB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_REALIZADOR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_ACTORES_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_SINOPSE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_LINK_FicheiroMP4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ALTERARFILME_ALTERARCAPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)34 || e.KeyChar == (char)37 || e.KeyChar == (char)39 || e.KeyChar == (char)44 || e.KeyChar == (char)60 || e.KeyChar == (char)61 || e.KeyChar == (char)62 || e.KeyChar == (char)92)
            {
                e.Handled = true;
            }
        }

        private void TEXTBOX_ADICIONARFILME_TITULOPT_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_TITULOPT.Text = TEXTBOX_ADICIONARFILME_TITULOPT.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_ALIAS_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_ALIAS.Text = TEXTBOX_ADICIONARFILME_ALIAS.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_ANO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_ANO.Text = TEXTBOX_ADICIONARFILME_ANO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_REALIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_REALIZADOR.Text = TEXTBOX_ADICIONARFILME_REALIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text = TEXTBOX_ADICIONARFILME_ACTORESPRINCIPAIS.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_SINOPSE_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_SINOPSE.Text = TEXTBOX_ADICIONARFILME_SINOPSE.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_LINKDOWNLOAD_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text = TEXTBOX_ADICIONARFILME_LINKDOWNLOAD.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_SCRIPTIMDB_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text = TEXTBOX_ADICIONARFILME_SCRIPTIMDB.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text = TEXTBOX_ADICIONARFILME_ESCOLHERFICHEIRO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_TITULOPT_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_TITULOPT.Text = TEXTBOX_ALTERARFILME_TITULOPT.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_ALIASFILME_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_ALIASFILME.Text = TEXTBOX_ALTERARFILME_ALIASFILME.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_REALIZADOR_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_REALIZADOR.Text = TEXTBOX_ALTERARFILME_REALIZADOR.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_ACTORES_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_ACTORES.Text = TEXTBOX_ALTERARFILME_ACTORES.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_SINOPSE_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_SINOPSE.Text = TEXTBOX_ALTERARFILME_SINOPSE.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_ANO_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_ANO.Text = TEXTBOX_ALTERARFILME_ANO.Text.Replace("\"", string.Empty);
        }

        private void TEXTBOX_ALTERARFILME_IMDB_TextChanged(object sender, EventArgs e)
        {
            TEXTBOX_ALTERARFILME_IMDB.Text = TEXTBOX_ALTERARFILME_IMDB.Text.Replace("\"", string.Empty);
        }



        
    }
}
