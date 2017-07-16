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
    public partial class FORM_INFORMACOES_DETALHADAS : Form
    {
        MySqlConnection LigacaoDB = new MySqlConnection(CLASS_GLOBAL_VARIABLES.Servidor);

        MySqlDataAdapter Adapter = new MySqlDataAdapter();

        MySqlDataReader Reader;
        MySqlDataReader Reader2;

        DataTable TabelaDados = new DataTable();

        public static FORM_GESTAO_FILMES FormGestaoFilmes_Objects = (FORM_GESTAO_FILMES)Application.OpenForms["FORM_GESTAO_FILMES"];

        public string FilmeSelecionado = FormGestaoFilmes_Objects.DetailInfo_FilmeSelecionado;

        public string ID = FormGestaoFilmes_Objects.DetailInfo_ID;
        public string IdPrincipal = FormGestaoFilmes_Objects.DetailInfo_IdPrincipal;
        public string TituloOriginal = FormGestaoFilmes_Objects.DetailInfo_TituloOriginal;
        public string TituloPT = FormGestaoFilmes_Objects.DetailInfo_TituloPT;
        public string IMDB = FormGestaoFilmes_Objects.DetailInfo_IMDB;
        public string GeneroPrincipal = FormGestaoFilmes_Objects.DetailInfo_GeneroPrincipal;
        public string AnoProducao = FormGestaoFilmes_Objects.DetailInfo_AnoProducao;
        public string Realizador = FormGestaoFilmes_Objects.DetailInfo_Realizador;
        public string ActoresPrincipais = FormGestaoFilmes_Objects.DetailInfo_ActoresPrincipais;
        public string Sinopse = FormGestaoFilmes_Objects.DetailInfo_Sinopse;
        public string AliasFilme = FormGestaoFilmes_Objects.DetailInfo_AliasFilme;
        public string LinkVerFilme = FormGestaoFilmes_Objects.DetailInfo_LinkVerFilme;
        public string LinkDownloadFilme = FormGestaoFilmes_Objects.DetailInfo_LinkDownloadFilme;
        public string AliasGenero = FormGestaoFilmes_Objects.DetailInfo_AliasGenero;
        public string LinkGenero = FormGestaoFilmes_Objects.DetailInfo_LinkGenero;
        public string LinkAno = FormGestaoFilmes_Objects.DetailInfo_LinkAno;
        public string AliasAno = FormGestaoFilmes_Objects.DetailInfo_AliasAno;
        public string LinkCapaBlog = FormGestaoFilmes_Objects.DetailInfo_LinkCapaBlog;
        public string LinkCapaZoom = FormGestaoFilmes_Objects.DetailInfo_LinkCapaZoom;
        public string FicheiroFilme = FormGestaoFilmes_Objects.DetailInfo_FicheiroFilme;
        public string FicheiroCapa = FormGestaoFilmes_Objects.DetailInfo_FicheiroCapa;

        public FORM_INFORMACOES_DETALHADAS()
        {
            InitializeComponent();

            PreenchimentoTextBoxs();
            DefinirCapa();
            //CarregarGeneros();
        }

        private void MENUSTRIP_INFORMACOESDETALHADAS_BUTTON_FECHAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void PreenchimentoTextBoxs()
        {
            TEXTBOX_INFORMACOESDETALHADAS_ID.Text = ID;
            TEXTBOX_INFORMACOESDETALHADAS_IdPrincipal.Text = IdPrincipal;
            TEXTBOX_INFORMACOESDETALHADAS_TituloOriginal.Text = TituloOriginal;
            TEXTBOX_INFORMACOESDETALHADAS_TituloPT.Text = TituloPT;
            TEXTBOX_INFORMACOESDETALHADAS_IMDB.Text = IMDB;
            TEXTBOX_INFORMACOESDETALHADAS_GeneroPrincipal.Text = GeneroPrincipal;
            TEXTBOX_INFORMACOESDETALHADAS_AnoProducao.Text = AnoProducao;
            TEXTBOX_INFORMACOESDETALHADAS_Realizador.Text = Realizador;
            TEXTBOX_INFORMACOESDETALHADAS_ActoresPrincipais.Text = ActoresPrincipais;
            TEXTBOX_INFORMACOESDETALHADAS_Sinopse.Text = Sinopse;
            TEXTBOX_INFORMACOESDETALHADAS_AliasFilme.Text = AliasFilme;
            TEXTBOX_INFORMACOESDETALHADAS_LinkVerFilme.Text = LinkVerFilme;
            TEXTBOX_INFORMACOESDETALHADAS_LinkDownloadFilme.Text = LinkDownloadFilme;
            TEXTBOX_INFORMACOESDETALHADAS_AliasGenero.Text = AliasGenero;
            TEXTBOX_INFORMACOESDETALHADAS_LinkGenero.Text = LinkGenero;
            TEXTBOX_INFORMACOESDETALHADAS_LinkAno.Text = LinkAno;
            TEXTBOX_INFORMACOESDETALHADAS_AliasAno.Text = AliasAno;
            TEXTBOX_INFORMACOESDETALHADAS_LinkCapaBlog.Text = LinkCapaBlog;
            TEXTBOX_INFORMACOESDETALHADAS_LinkCapaZoom.Text = LinkCapaZoom;
            TEXTBOX_INFORMACOESDETALHADAS_FicheiroFilme.Text = FicheiroFilme;
            TEXTBOX_INFORMACOESDETALHADAS_FicheiroCapa.Text = FicheiroCapa;
        }

        public void DefinirCapa()
        {
            try
            {
                PICTUREBOX_INFORMACOESDETALHADAS_Capa.Image = Image.FromFile(Properties.Settings.Default.cover_connection_type.ToString() + @"\" + FicheiroCapa);
            }

            catch (Exception EX)
            { }
        }

        public void CarregarGeneros()
        {
            //int FilmeID = Convert.ToInt32(IdPrincipal);
            //string Query_CatID = "SELECT category_id FROM bitshare_build.bs_zoo_category_item WHERE item_id=" + FilmeID + "";
            //string Cat;
            //string Category_IDs[];
            //string Query_Generos;
            //string Genero;

            //int CatID;

            //LigacaoDB.Open();

            //MySqlCommand Comando_CatID = new MySqlCommand(Query_CatID, LigacaoDB);
            //Reader = Comando_CatID.ExecuteReader();

            //while (Reader.Read())
            //{
            //    Category_IDs = Reader.GetString("category_id");
            //    Category_IDs += Environment.NewLine + Category_IDs;

            //    Query_Generos = "SELECT name FROM bitshare_build.bs_zoo_category WHERE id='" + Convert.ToInt32(Category_IDs) + "'";
            //    MySqlCommand Comando_Generos = new MySqlCommand(Query_Generos, LigacaoDB);

            //    //Reader.Close();
            //    Genero = Comando_Generos.ExecuteScalar().ToString();
            //    Genero += Environment.NewLine + Genero;

            //    LISTBOX_INFORMACOESDETALHADAS_Generos.Items.Add(Genero);
            //}

            //LigacaoDB.Close();
        }
    }
}
