using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BitShare_Manager
{
    public partial class FORM_PREVIEW_FILME : Form
    {
        public static FORM_GESTAO_FILMES FormGestaoFilmes_Objects = (FORM_GESTAO_FILMES)Application.OpenForms["FORM_GESTAO_FILMES"];

        public FORM_PREVIEW_FILME()
        {
            InitializeComponent();
            PreencherTudo();
            PICTUREBOX_FORMPREVIEWFILME_CAPA.Image = FormGestaoFilmes_Objects.PICTUREBOX_ADICIONARFILME_COVER.Image;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public void ApagarTudo()
        {

        }

        public void PreencherTudo()
        {
            try
            {
                LABEL_FORMPREVIEWFILME_NOMEPT.Text = FormGestaoFilmes_Objects.Preview_TituloPT;
                LABEL_FORMPREVIEWFILME_CABECALHO.Text = @"""" + FormGestaoFilmes_Objects.Preview_TituloOriginal + @"""" + " | " + FormGestaoFilmes_Objects.Preview_Genero + " | " + FormGestaoFilmes_Objects.Preview_Ano;
                LABEL_FORMPREVIEWFILME_REALIZADOR.Text = "Realizador: " + FormGestaoFilmes_Objects.Preview_Realizador;
                LABEL_FORMPREVIEWFILME_ACTORES.Text = "Actores Principais: " + FormGestaoFilmes_Objects.Preview_Actores;
                LABEL_FORMPREVIEWFILME_IMDB.Text = "Classificação IMDB: " + FormGestaoFilmes_Objects.Preview_IMDB;
                TEXTBOX_FORMPREVIEWFILME_SINOPSE.Text = "Sinopse: " + FormGestaoFilmes_Objects.Preview_Sinopse;

                PICTUREBOX_FORMPREVIEWFILME_CAPA.ImageLocation = FormGestaoFilmes_Objects.Preview_Capa;
            }

            catch (Exception EX)
            {
            }
        }
    }
}
