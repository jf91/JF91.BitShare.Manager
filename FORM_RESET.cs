using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace BitShare_Manager
{
    public partial class FORM_RESET : Form
    {
        public FORM_RESET()
        {
            InitializeComponent();
            FunctionRESET();
            TIMER_RESET.Start();
        }

        private void TIMER_RESET_Tick(object sender, EventArgs e)
        {
            PROGRESSBAR_RESET.Increment(100 / 4 + 10 - (50 / 15 - 90 / 30));
            if (PROGRESSBAR_RESET.Value == 100)
            {
                TIMER_RESET.Stop();
                DialogResult DR = MessageBox.Show("As definições foram restauradas com sucesso. Para que possa voltar a ligar-se à base de dados o BitShare Manager irá reiniciar para que possa configurar as definições de acesso à base de dados","Definições restauradas com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (DR == DialogResult.OK)
                {
                    Application.Restart();
                }
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

            Properties.Settings.Default.connectionString = "";
            Properties.Settings.Default.bd = "";
            Properties.Settings.Default.bs_filmes = "";
            Properties.Settings.Default.bs_zoo_item = "";
            Properties.Settings.Default.bs_zoo_category = "";
            Properties.Settings.Default.bs_zoo_category_item = "";
            Properties.Settings.Default.hash_key = "";
            Properties.Settings.Default.last_user = "";
            Properties.Settings.Default.first_launch = true;
            Properties.Settings.Default.bs_connections = "";
            Properties.Settings.Default.bs_users = "";

            Properties.Settings.Default.Save();
        }

    }
}
