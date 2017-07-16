namespace BitShare_Manager
{
    partial class FORM_DEFINICOES_GESTAO_LIGACOES
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_DEFINICOES_GESTAO_LIGACOES));
            this.MENUSTRIP_GESTAOLIGACOES = new System.Windows.Forms.MenuStrip();
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR = new System.Windows.Forms.ToolStripMenuItem();
            this.TABCONTROL_GESTAOLIGACOES = new System.Windows.Forms.TabControl();
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO = new System.Windows.Forms.TabPage();
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO = new System.Windows.Forms.GroupBox();
            this.RADIOBUTTON_GESTAOLIGACOES_WEB = new System.Windows.Forms.RadioButton();
            this.RADIOBUTTON_GESTAOLIGACOES_LAN = new System.Windows.Forms.RadioButton();
            this.LABEL_GESTAOLIGACOES_TIPO = new System.Windows.Forms.Label();
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL = new System.Windows.Forms.RadioButton();
            this.TEXTBOX_GESTAOLIGACOES_BD = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_BD = new System.Windows.Forms.Label();
            this.TEXTBOX_GESTAOLIGACOES_NOME = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_NOME = new System.Windows.Forms.Label();
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_PASSWORD = new System.Windows.Forms.Label();
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_UTILIZADOR = new System.Windows.Forms.Label();
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO = new System.Windows.Forms.Button();
            this.TEXTBOX_GESTAOLIGACOES_PORTA = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_PORTA = new System.Windows.Forms.Label();
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO = new System.Windows.Forms.TextBox();
            this.LABEL_GESTAOLIGACOES_ENDERECO = new System.Windows.Forms.Label();
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO = new System.Windows.Forms.ListView();
            this.LIGACAO_NOME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LIGACAO_ENDERECO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LIGACAO_PORTA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO = new System.Windows.Forms.Label();
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO = new System.Windows.Forms.TabPage();
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO = new System.Windows.Forms.Button();
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO = new System.Windows.Forms.ListView();
            this.LIGACAO__REMOVER_NOME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LIGACAO__REMOVER_ENDERECO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LIGACAO__REMOVER_PORTA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LABEL_GESTAOLIGACOES_LIGACAO = new System.Windows.Forms.Label();
            this.MENUSTRIP_GESTAOLIGACOES.SuspendLayout();
            this.TABCONTROL_GESTAOLIGACOES.SuspendLayout();
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.SuspendLayout();
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.SuspendLayout();
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // MENUSTRIP_GESTAOLIGACOES
            // 
            this.MENUSTRIP_GESTAOLIGACOES.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR});
            this.MENUSTRIP_GESTAOLIGACOES.Location = new System.Drawing.Point(0, 0);
            this.MENUSTRIP_GESTAOLIGACOES.Name = "MENUSTRIP_GESTAOLIGACOES";
            this.MENUSTRIP_GESTAOLIGACOES.Size = new System.Drawing.Size(630, 24);
            this.MENUSTRIP_GESTAOLIGACOES.TabIndex = 0;
            this.MENUSTRIP_GESTAOLIGACOES.Text = "menuStrip1";
            // 
            // MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR
            // 
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR.Image = global::BitShare_Manager.Properties.Resources.Fechar_2;
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR.Name = "MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR";
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR.Size = new System.Drawing.Size(70, 20);
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR.Text = "Fechar";
            this.MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // TABCONTROL_GESTAOLIGACOES
            // 
            this.TABCONTROL_GESTAOLIGACOES.Controls.Add(this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO);
            this.TABCONTROL_GESTAOLIGACOES.Controls.Add(this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO);
            this.TABCONTROL_GESTAOLIGACOES.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TABCONTROL_GESTAOLIGACOES.Location = new System.Drawing.Point(0, 24);
            this.TABCONTROL_GESTAOLIGACOES.Name = "TABCONTROL_GESTAOLIGACOES";
            this.TABCONTROL_GESTAOLIGACOES.SelectedIndex = 0;
            this.TABCONTROL_GESTAOLIGACOES.Size = new System.Drawing.Size(630, 315);
            this.TABCONTROL_GESTAOLIGACOES.TabIndex = 1;
            // 
            // TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO
            // 
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Name = "TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO";
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Size = new System.Drawing.Size(622, 289);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.TabIndex = 0;
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.Text = "Adicionar Ligação";
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.UseVisualStyleBackColor = true;
            // 
            // GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO
            // 
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.RADIOBUTTON_GESTAOLIGACOES_WEB);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.RADIOBUTTON_GESTAOLIGACOES_LAN);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_TIPO);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.RADIOBUTTON_GESTAOLIGACOES_LOCAL);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_BD);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_BD);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_NOME);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_NOME);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_PASSWORD);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_PASSWORD);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_UTILIZADOR);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_PORTA);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_PORTA);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.TEXTBOX_GESTAOLIGACOES_ENDERECO);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_ENDERECO);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Location = new System.Drawing.Point(309, 28);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Name = "GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO";
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Size = new System.Drawing.Size(305, 257);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.TabIndex = 13;
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.TabStop = false;
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.Text = "Adicionar Ligação";
            // 
            // RADIOBUTTON_GESTAOLIGACOES_WEB
            // 
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.AutoSize = true;
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.Location = new System.Drawing.Point(234, 187);
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.Name = "RADIOBUTTON_GESTAOLIGACOES_WEB";
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.Size = new System.Drawing.Size(50, 17);
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.TabIndex = 21;
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.TabStop = true;
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.Text = "WEB";
            this.RADIOBUTTON_GESTAOLIGACOES_WEB.UseVisualStyleBackColor = true;
            // 
            // RADIOBUTTON_GESTAOLIGACOES_LAN
            // 
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.AutoSize = true;
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.Location = new System.Drawing.Point(234, 160);
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.Name = "RADIOBUTTON_GESTAOLIGACOES_LAN";
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.Size = new System.Drawing.Size(46, 17);
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.TabIndex = 20;
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.TabStop = true;
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.Text = "LAN";
            this.RADIOBUTTON_GESTAOLIGACOES_LAN.UseVisualStyleBackColor = true;
            // 
            // LABEL_GESTAOLIGACOES_TIPO
            // 
            this.LABEL_GESTAOLIGACOES_TIPO.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_TIPO.Location = new System.Drawing.Point(220, 119);
            this.LABEL_GESTAOLIGACOES_TIPO.Name = "LABEL_GESTAOLIGACOES_TIPO";
            this.LABEL_GESTAOLIGACOES_TIPO.Size = new System.Drawing.Size(28, 13);
            this.LABEL_GESTAOLIGACOES_TIPO.TabIndex = 19;
            this.LABEL_GESTAOLIGACOES_TIPO.Text = "Tipo";
            // 
            // RADIOBUTTON_GESTAOLIGACOES_LOCAL
            // 
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.AutoSize = true;
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.Location = new System.Drawing.Point(234, 135);
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.Name = "RADIOBUTTON_GESTAOLIGACOES_LOCAL";
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.Size = new System.Drawing.Size(51, 17);
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.TabIndex = 18;
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.TabStop = true;
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.Text = "Local";
            this.RADIOBUTTON_GESTAOLIGACOES_LOCAL.UseVisualStyleBackColor = true;
            // 
            // TEXTBOX_GESTAOLIGACOES_BD
            // 
            this.TEXTBOX_GESTAOLIGACOES_BD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_BD.Location = new System.Drawing.Point(9, 184);
            this.TEXTBOX_GESTAOLIGACOES_BD.Name = "TEXTBOX_GESTAOLIGACOES_BD";
            this.TEXTBOX_GESTAOLIGACOES_BD.Size = new System.Drawing.Size(189, 20);
            this.TEXTBOX_GESTAOLIGACOES_BD.TabIndex = 17;
            this.TEXTBOX_GESTAOLIGACOES_BD.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_BD_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_BD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_BD_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_BD
            // 
            this.LABEL_GESTAOLIGACOES_BD.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_BD.Location = new System.Drawing.Point(6, 168);
            this.LABEL_GESTAOLIGACOES_BD.Name = "LABEL_GESTAOLIGACOES_BD";
            this.LABEL_GESTAOLIGACOES_BD.Size = new System.Drawing.Size(80, 13);
            this.LABEL_GESTAOLIGACOES_BD.TabIndex = 16;
            this.LABEL_GESTAOLIGACOES_BD.Text = "Base de Dados";
            // 
            // TEXTBOX_GESTAOLIGACOES_NOME
            // 
            this.TEXTBOX_GESTAOLIGACOES_NOME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_NOME.Location = new System.Drawing.Point(9, 38);
            this.TEXTBOX_GESTAOLIGACOES_NOME.Name = "TEXTBOX_GESTAOLIGACOES_NOME";
            this.TEXTBOX_GESTAOLIGACOES_NOME.Size = new System.Drawing.Size(290, 20);
            this.TEXTBOX_GESTAOLIGACOES_NOME.TabIndex = 15;
            this.TEXTBOX_GESTAOLIGACOES_NOME.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_NOME_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_NOME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_NOME_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_NOME
            // 
            this.LABEL_GESTAOLIGACOES_NOME.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_NOME.Location = new System.Drawing.Point(6, 22);
            this.LABEL_GESTAOLIGACOES_NOME.Name = "LABEL_GESTAOLIGACOES_NOME";
            this.LABEL_GESTAOLIGACOES_NOME.Size = new System.Drawing.Size(91, 13);
            this.LABEL_GESTAOLIGACOES_NOME.TabIndex = 14;
            this.LABEL_GESTAOLIGACOES_NOME.Text = "Nome da Ligação";
            // 
            // TEXTBOX_GESTAOLIGACOES_PASSWORD
            // 
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.Location = new System.Drawing.Point(115, 135);
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.Name = "TEXTBOX_GESTAOLIGACOES_PASSWORD";
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.PasswordChar = '●';
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.Size = new System.Drawing.Size(83, 20);
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.TabIndex = 13;
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_PASSWORD_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_PASSWORD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_PASSWORD_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_PASSWORD
            // 
            this.LABEL_GESTAOLIGACOES_PASSWORD.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_PASSWORD.Location = new System.Drawing.Point(112, 119);
            this.LABEL_GESTAOLIGACOES_PASSWORD.Name = "LABEL_GESTAOLIGACOES_PASSWORD";
            this.LABEL_GESTAOLIGACOES_PASSWORD.Size = new System.Drawing.Size(53, 13);
            this.LABEL_GESTAOLIGACOES_PASSWORD.TabIndex = 12;
            this.LABEL_GESTAOLIGACOES_PASSWORD.Text = "Password";
            // 
            // TEXTBOX_GESTAOLIGACOES_UTILIZADOR
            // 
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Location = new System.Drawing.Point(9, 135);
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Name = "TEXTBOX_GESTAOLIGACOES_UTILIZADOR";
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.Size = new System.Drawing.Size(93, 20);
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.TabIndex = 11;
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_UTILIZADOR_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_UTILIZADOR
            // 
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.Location = new System.Drawing.Point(6, 119);
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.Name = "LABEL_GESTAOLIGACOES_UTILIZADOR";
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.Size = new System.Drawing.Size(50, 13);
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.TabIndex = 10;
            this.LABEL_GESTAOLIGACOES_UTILIZADOR.Text = "Utilizador";
            // 
            // BUTTON_GESTAOLIGACOES_GUARDARLIGACAO
            // 
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.Location = new System.Drawing.Point(9, 228);
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.Name = "BUTTON_GESTAOLIGACOES_GUARDARLIGACAO";
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.Size = new System.Drawing.Size(290, 23);
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.TabIndex = 9;
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.Text = "Guardar Ligação";
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.UseVisualStyleBackColor = true;
            this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO.Click += new System.EventHandler(this.BUTTON_GESTAOLIGACOES_GUARDARLIGACAO_Click);
            // 
            // TEXTBOX_GESTAOLIGACOES_PORTA
            // 
            this.TEXTBOX_GESTAOLIGACOES_PORTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_PORTA.Location = new System.Drawing.Point(223, 85);
            this.TEXTBOX_GESTAOLIGACOES_PORTA.Name = "TEXTBOX_GESTAOLIGACOES_PORTA";
            this.TEXTBOX_GESTAOLIGACOES_PORTA.Size = new System.Drawing.Size(76, 20);
            this.TEXTBOX_GESTAOLIGACOES_PORTA.TabIndex = 8;
            this.TEXTBOX_GESTAOLIGACOES_PORTA.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_PORTA_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_PORTA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_PORTA_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_PORTA
            // 
            this.LABEL_GESTAOLIGACOES_PORTA.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_PORTA.Location = new System.Drawing.Point(220, 69);
            this.LABEL_GESTAOLIGACOES_PORTA.Name = "LABEL_GESTAOLIGACOES_PORTA";
            this.LABEL_GESTAOLIGACOES_PORTA.Size = new System.Drawing.Size(32, 13);
            this.LABEL_GESTAOLIGACOES_PORTA.TabIndex = 7;
            this.LABEL_GESTAOLIGACOES_PORTA.Text = "Porta";
            // 
            // TEXTBOX_GESTAOLIGACOES_ENDERECO
            // 
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.Location = new System.Drawing.Point(9, 85);
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.Name = "TEXTBOX_GESTAOLIGACOES_ENDERECO";
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.Size = new System.Drawing.Size(189, 20);
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.TabIndex = 6;
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.TextChanged += new System.EventHandler(this.TEXTBOX_GESTAOLIGACOES_ENDERECO_TextChanged);
            this.TEXTBOX_GESTAOLIGACOES_ENDERECO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_GESTAOLIGACOES_ENDERECO_KeyPress);
            // 
            // LABEL_GESTAOLIGACOES_ENDERECO
            // 
            this.LABEL_GESTAOLIGACOES_ENDERECO.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_ENDERECO.Location = new System.Drawing.Point(6, 69);
            this.LABEL_GESTAOLIGACOES_ENDERECO.Name = "LABEL_GESTAOLIGACOES_ENDERECO";
            this.LABEL_GESTAOLIGACOES_ENDERECO.Size = new System.Drawing.Size(53, 13);
            this.LABEL_GESTAOLIGACOES_ENDERECO.TabIndex = 0;
            this.LABEL_GESTAOLIGACOES_ENDERECO.Text = "Endereço";
            // 
            // LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO
            // 
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LIGACAO_NOME,
            this.LIGACAO_ENDERECO,
            this.LIGACAO_PORTA});
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Location = new System.Drawing.Point(23, 28);
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Name = "LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO";
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.Size = new System.Drawing.Size(280, 257);
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.TabIndex = 12;
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.UseCompatibleStateImageBehavior = false;
            this.LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO.View = System.Windows.Forms.View.Details;
            // 
            // LIGACAO_NOME
            // 
            this.LIGACAO_NOME.Text = "Nome";
            this.LIGACAO_NOME.Width = 108;
            // 
            // LIGACAO_ENDERECO
            // 
            this.LIGACAO_ENDERECO.Text = "Endereço";
            this.LIGACAO_ENDERECO.Width = 110;
            // 
            // LIGACAO_PORTA
            // 
            this.LIGACAO_PORTA.Text = "Porta";
            this.LIGACAO_PORTA.Width = 58;
            // 
            // LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO
            // 
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.Location = new System.Drawing.Point(20, 9);
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.Name = "LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO";
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.Size = new System.Drawing.Size(45, 13);
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.TabIndex = 11;
            this.LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO.Text = "Ligacao";
            // 
            // TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO
            // 
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Controls.Add(this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Controls.Add(this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Controls.Add(this.LABEL_GESTAOLIGACOES_LIGACAO);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Location = new System.Drawing.Point(4, 22);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Name = "TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO";
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Padding = new System.Windows.Forms.Padding(3);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Size = new System.Drawing.Size(622, 289);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.TabIndex = 1;
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.Text = "Remover Ligação";
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.UseVisualStyleBackColor = true;
            // 
            // BUTTON_GESTAOLIGACOES_REMOVERLIGACAO
            // 
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.Location = new System.Drawing.Point(378, 28);
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.Name = "BUTTON_GESTAOLIGACOES_REMOVERLIGACAO";
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.Size = new System.Drawing.Size(121, 23);
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.TabIndex = 15;
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.Text = "Remover Ligação";
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.UseVisualStyleBackColor = true;
            this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO.Click += new System.EventHandler(this.BUTTON_GESTAOLIGACOES_REMOVERLIGACAO_Click);
            // 
            // LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO
            // 
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LIGACAO__REMOVER_NOME,
            this.LIGACAO__REMOVER_ENDERECO,
            this.LIGACAO__REMOVER_PORTA});
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Location = new System.Drawing.Point(23, 28);
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Name = "LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO";
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.Size = new System.Drawing.Size(328, 259);
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.TabIndex = 14;
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.UseCompatibleStateImageBehavior = false;
            this.LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO.View = System.Windows.Forms.View.Details;
            // 
            // LIGACAO__REMOVER_NOME
            // 
            this.LIGACAO__REMOVER_NOME.Text = "Nome";
            this.LIGACAO__REMOVER_NOME.Width = 120;
            // 
            // LIGACAO__REMOVER_ENDERECO
            // 
            this.LIGACAO__REMOVER_ENDERECO.Text = "Endereço";
            this.LIGACAO__REMOVER_ENDERECO.Width = 120;
            // 
            // LIGACAO__REMOVER_PORTA
            // 
            this.LIGACAO__REMOVER_PORTA.Text = "Porta";
            this.LIGACAO__REMOVER_PORTA.Width = 84;
            // 
            // LABEL_GESTAOLIGACOES_LIGACAO
            // 
            this.LABEL_GESTAOLIGACOES_LIGACAO.AutoSize = true;
            this.LABEL_GESTAOLIGACOES_LIGACAO.Location = new System.Drawing.Point(20, 9);
            this.LABEL_GESTAOLIGACOES_LIGACAO.Name = "LABEL_GESTAOLIGACOES_LIGACAO";
            this.LABEL_GESTAOLIGACOES_LIGACAO.Size = new System.Drawing.Size(45, 13);
            this.LABEL_GESTAOLIGACOES_LIGACAO.TabIndex = 13;
            this.LABEL_GESTAOLIGACOES_LIGACAO.Text = "Ligacao";
            // 
            // FORM_DEFINICOES_GESTAO_LIGACOES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 339);
            this.Controls.Add(this.TABCONTROL_GESTAOLIGACOES);
            this.Controls.Add(this.MENUSTRIP_GESTAOLIGACOES);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENUSTRIP_GESTAOLIGACOES;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_DEFINICOES_GESTAO_LIGACOES";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BitShare Manager: Gestão de Ligações";
            this.TopMost = true;
            this.MENUSTRIP_GESTAOLIGACOES.ResumeLayout(false);
            this.MENUSTRIP_GESTAOLIGACOES.PerformLayout();
            this.TABCONTROL_GESTAOLIGACOES.ResumeLayout(false);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.ResumeLayout(false);
            this.TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO.PerformLayout();
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.ResumeLayout(false);
            this.GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO.PerformLayout();
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.ResumeLayout(false);
            this.TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MENUSTRIP_GESTAOLIGACOES;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_GESTAOLIGACOES_BUTTON_FECHAR;
        private System.Windows.Forms.TabControl TABCONTROL_GESTAOLIGACOES;
        private System.Windows.Forms.TabPage TABPAGE_GESTAOLIGACOES_ADICIONARLIGACAO;
        private System.Windows.Forms.GroupBox GROUPBOX_GESTAOLIGACOES_ADICIONARLIGACAO;
        private System.Windows.Forms.Button BUTTON_GESTAOLIGACOES_GUARDARLIGACAO;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_PORTA;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_PORTA;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_ENDERECO;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_ENDERECO;
        private System.Windows.Forms.ListView LISTVIEW_GESTAOLIGACOES_ADICIONARLIGACAO_LIGACAO;
        private System.Windows.Forms.ColumnHeader LIGACAO_ENDERECO;
        private System.Windows.Forms.ColumnHeader LIGACAO_PORTA;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_REMOVERLIGACAO_ADICIONARLIGACAO_LIGACAO;
        private System.Windows.Forms.TabPage TABPAGE_GESTAOLIGACOES_REMOVERLIGACAO;
        private System.Windows.Forms.Button BUTTON_GESTAOLIGACOES_REMOVERLIGACAO;
        private System.Windows.Forms.ListView LISTVIEW_GESTAOLIGACOES_REMOVERLIGACAO_LIGACAO;
        private System.Windows.Forms.ColumnHeader LIGACAO__REMOVER_ENDERECO;
        private System.Windows.Forms.ColumnHeader LIGACAO__REMOVER_PORTA;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_LIGACAO;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_PASSWORD;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_PASSWORD;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_UTILIZADOR;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_UTILIZADOR;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_NOME;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_NOME;
        private System.Windows.Forms.ColumnHeader LIGACAO_NOME;
        private System.Windows.Forms.ColumnHeader LIGACAO__REMOVER_NOME;
        private System.Windows.Forms.TextBox TEXTBOX_GESTAOLIGACOES_BD;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_BD;
        private System.Windows.Forms.Label LABEL_GESTAOLIGACOES_TIPO;
        private System.Windows.Forms.RadioButton RADIOBUTTON_GESTAOLIGACOES_LOCAL;
        private System.Windows.Forms.RadioButton RADIOBUTTON_GESTAOLIGACOES_WEB;
        private System.Windows.Forms.RadioButton RADIOBUTTON_GESTAOLIGACOES_LAN;
    }
}