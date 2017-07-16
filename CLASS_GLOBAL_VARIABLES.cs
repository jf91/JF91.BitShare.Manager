using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitShare_Manager
{
    class CLASS_GLOBAL_VARIABLES
    {
        public static string Servidor = "";
        public static string ServidorStoredProcedure = "";

        public static string Endereco = "";
        public static string Porta = "";
        public static string Utilizador = "";
        public static string Password = "";

        public static string BD = "";
        public static string Tabela_BSCATALOGOFILMES = "bs_catalogo_filmes";
        public static string Tabela_BSFILMES = "bs_filmes";
        public static string Tabela_BSZOOITEM = "bs_zoo_item";
        public static string Tabela_BSZOOCATEGORY = "bs_zoo_category";
        public static string Tabela_BSZOOCATEGORYITEM = "bs_zoo_category_item";

        public static string FILME_Tipo_Localhost = @"C:\BitCorp Local Servers\WWW\www\bitshare\stuff\filmes";
        public static string FILME_Tipo_LAN = @"\\192.168.1.88\BitWoW Server - Disco Local C\BitCorp Local Servers\WWW\www\bitshare\stuff\filmes";
        public static string FILME_Tipo_Web = @"\\25.131.233.194\BitWoW Server - Disco Local C\BitCorp Local Servers\WWW\www\bitshare\stuff\filmes";

        public static string CAPA_Tipo_Localhost = @"C:\BitCorp Local Servers\WWW\www\bitshare\images\imagens\covers\filmes\capa-zoom";
        public static string CAPA_Tipo_LAN = @"\\192.168.1.88\BitWoW Server - Disco Local C\BitCorp Local Servers\WWW\www\bitshare\images\imagens\covers\filmes\capa-zoom";
        public static string CAPA_Tipo_Web = @"\\25.131.233.194\BitWoW Server - Disco Local C\BitCorp Local Servers\WWW\www\bitshare\images\imagens\covers\filmes\capa-zoom";
        //public static string CAPA_Tipo_Web = @"http://bitcorp.servegame.com/bitshare/images/imagens/covers/filmes/";


        public static string Tabela_BSCONNECTIONS = "bs_bitsharemanager_connections";
        public static string Tabela_BSUSERS = "bs_bitsharemanager_users";

        public static string HashKey;

        //" + CLASS_GLOBAL_VARIABLES.BD + "
        //" + CLASS_GLOBAL_VARIABLES.Tabela_BSFILMES + "
        //" + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOITEM + "
        //" + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORY + "
        //" + CLASS_GLOBAL_VARIABLES.Tabela_BSZOOCATEGORYITEM + "
    }
}
