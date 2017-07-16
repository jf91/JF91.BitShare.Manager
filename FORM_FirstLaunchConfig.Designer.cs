namespace BitShare_Manager
{
    partial class FORM_FirstLaunchConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_FirstLaunchConfig));
            this.LABEL_FIRSTLAUNCH_ENDERECO = new System.Windows.Forms.Label();
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO = new System.Windows.Forms.TextBox();
            this.TEXTBOX_FIRSTLAUNCH_PORTA = new System.Windows.Forms.TextBox();
            this.LABEL_FIRSTLAUNCH_PORTA = new System.Windows.Forms.Label();
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR = new System.Windows.Forms.TextBox();
            this.LABEL_FIRSTLAUNCH_UTILIZADOR = new System.Windows.Forms.Label();
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD = new System.Windows.Forms.TextBox();
            this.LABEL_FIRSTLAUNCH_PASSWORD = new System.Windows.Forms.Label();
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO = new System.Windows.Forms.GroupBox();
            this.LABEL_FIRSTLAUNCH_NOME = new System.Windows.Forms.Label();
            this.TEXTBOX_FIRSTLAUNCH_NOME = new System.Windows.Forms.TextBox();
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO = new System.Windows.Forms.Button();
            this.BGWORKER = new System.ComponentModel.BackgroundWorker();
            this.LABEL_FIRSTLAUNCH_BD = new System.Windows.Forms.Label();
            this.TEXTBOX_FIRSTLAUNCH_BD = new System.Windows.Forms.TextBox();
            this.LABEL_FIRSTLAUNCH_TIPO = new System.Windows.Forms.Label();
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL = new System.Windows.Forms.RadioButton();
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN = new System.Windows.Forms.RadioButton();
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB = new System.Windows.Forms.RadioButton();
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // LABEL_FIRSTLAUNCH_ENDERECO
            // 
            this.LABEL_FIRSTLAUNCH_ENDERECO.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_ENDERECO.Location = new System.Drawing.Point(11, 48);
            this.LABEL_FIRSTLAUNCH_ENDERECO.Name = "LABEL_FIRSTLAUNCH_ENDERECO";
            this.LABEL_FIRSTLAUNCH_ENDERECO.Size = new System.Drawing.Size(53, 13);
            this.LABEL_FIRSTLAUNCH_ENDERECO.TabIndex = 1;
            this.LABEL_FIRSTLAUNCH_ENDERECO.Text = "Endereco";
            // 
            // TEXTBOX_FIRSTLAUNCH_ENDERECO
            // 
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.Location = new System.Drawing.Point(14, 64);
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.Name = "TEXTBOX_FIRSTLAUNCH_ENDERECO";
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.Size = new System.Drawing.Size(160, 20);
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.TabIndex = 2;
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_ENDERECO_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_ENDERECO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_ENDERECO_KeyPress);
            // 
            // TEXTBOX_FIRSTLAUNCH_PORTA
            // 
            this.TEXTBOX_FIRSTLAUNCH_PORTA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_PORTA.Location = new System.Drawing.Point(180, 64);
            this.TEXTBOX_FIRSTLAUNCH_PORTA.Name = "TEXTBOX_FIRSTLAUNCH_PORTA";
            this.TEXTBOX_FIRSTLAUNCH_PORTA.Size = new System.Drawing.Size(110, 20);
            this.TEXTBOX_FIRSTLAUNCH_PORTA.TabIndex = 4;
            this.TEXTBOX_FIRSTLAUNCH_PORTA.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_PORTA_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_PORTA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_PORTA_KeyPress);
            // 
            // LABEL_FIRSTLAUNCH_PORTA
            // 
            this.LABEL_FIRSTLAUNCH_PORTA.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_PORTA.Location = new System.Drawing.Point(179, 48);
            this.LABEL_FIRSTLAUNCH_PORTA.Name = "LABEL_FIRSTLAUNCH_PORTA";
            this.LABEL_FIRSTLAUNCH_PORTA.Size = new System.Drawing.Size(32, 13);
            this.LABEL_FIRSTLAUNCH_PORTA.TabIndex = 3;
            this.LABEL_FIRSTLAUNCH_PORTA.Text = "Porta";
            // 
            // TEXTBOX_FIRSTLAUNCH_UTILIZADOR
            // 
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Location = new System.Drawing.Point(14, 103);
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Name = "TEXTBOX_FIRSTLAUNCH_UTILIZADOR";
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.Size = new System.Drawing.Size(160, 20);
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.TabIndex = 6;
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR_KeyPress);
            // 
            // LABEL_FIRSTLAUNCH_UTILIZADOR
            // 
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.Location = new System.Drawing.Point(11, 87);
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.Name = "LABEL_FIRSTLAUNCH_UTILIZADOR";
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.Size = new System.Drawing.Size(50, 13);
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.TabIndex = 5;
            this.LABEL_FIRSTLAUNCH_UTILIZADOR.Text = "Utilizador";
            // 
            // TEXTBOX_FIRSTLAUNCH_PASSWORD
            // 
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.Location = new System.Drawing.Point(179, 103);
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.Name = "TEXTBOX_FIRSTLAUNCH_PASSWORD";
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.PasswordChar = '●';
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.Size = new System.Drawing.Size(111, 20);
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.TabIndex = 8;
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_PASSWORD_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_PASSWORD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_PASSWORD_KeyPress);
            // 
            // LABEL_FIRSTLAUNCH_PASSWORD
            // 
            this.LABEL_FIRSTLAUNCH_PASSWORD.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_PASSWORD.Location = new System.Drawing.Point(177, 87);
            this.LABEL_FIRSTLAUNCH_PASSWORD.Name = "LABEL_FIRSTLAUNCH_PASSWORD";
            this.LABEL_FIRSTLAUNCH_PASSWORD.Size = new System.Drawing.Size(53, 13);
            this.LABEL_FIRSTLAUNCH_PASSWORD.TabIndex = 7;
            this.LABEL_FIRSTLAUNCH_PASSWORD.Text = "Password";
            // 
            // GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO
            // 
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.LABEL_FIRSTLAUNCH_NOME);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_NOME);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.LABEL_FIRSTLAUNCH_ENDERECO);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_PASSWORD);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.LABEL_FIRSTLAUNCH_PASSWORD);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_ENDERECO);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.LABEL_FIRSTLAUNCH_PORTA);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_UTILIZADOR);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_PORTA);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Controls.Add(this.LABEL_FIRSTLAUNCH_UTILIZADOR);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Location = new System.Drawing.Point(12, 12);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Name = "GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO";
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Size = new System.Drawing.Size(303, 134);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.TabIndex = 9;
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.TabStop = false;
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.Text = "Dados da Ligação";
            // 
            // LABEL_FIRSTLAUNCH_NOME
            // 
            this.LABEL_FIRSTLAUNCH_NOME.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_NOME.Location = new System.Drawing.Point(11, 22);
            this.LABEL_FIRSTLAUNCH_NOME.Name = "LABEL_FIRSTLAUNCH_NOME";
            this.LABEL_FIRSTLAUNCH_NOME.Size = new System.Drawing.Size(35, 13);
            this.LABEL_FIRSTLAUNCH_NOME.TabIndex = 9;
            this.LABEL_FIRSTLAUNCH_NOME.Text = "Nome";
            // 
            // TEXTBOX_FIRSTLAUNCH_NOME
            // 
            this.TEXTBOX_FIRSTLAUNCH_NOME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_NOME.Location = new System.Drawing.Point(52, 18);
            this.TEXTBOX_FIRSTLAUNCH_NOME.Name = "TEXTBOX_FIRSTLAUNCH_NOME";
            this.TEXTBOX_FIRSTLAUNCH_NOME.Size = new System.Drawing.Size(238, 20);
            this.TEXTBOX_FIRSTLAUNCH_NOME.TabIndex = 10;
            this.TEXTBOX_FIRSTLAUNCH_NOME.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_NOME_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_NOME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_NOME_KeyPress);
            // 
            // BUTTON_FIRSTLAUNCH_GUARDARLIGACAO
            // 
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Enabled = false;
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Location = new System.Drawing.Point(28, 208);
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Name = "BUTTON_FIRSTLAUNCH_GUARDARLIGACAO";
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Size = new System.Drawing.Size(158, 23);
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.TabIndex = 11;
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Text = "Guardar Ligacao";
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.UseVisualStyleBackColor = true;
            this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO.Click += new System.EventHandler(this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO_Click);
            // 
            // BGWORKER
            // 
            this.BGWORKER.WorkerReportsProgress = true;
            // 
            // LABEL_FIRSTLAUNCH_BD
            // 
            this.LABEL_FIRSTLAUNCH_BD.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_BD.Location = new System.Drawing.Point(25, 149);
            this.LABEL_FIRSTLAUNCH_BD.Name = "LABEL_FIRSTLAUNCH_BD";
            this.LABEL_FIRSTLAUNCH_BD.Size = new System.Drawing.Size(80, 13);
            this.LABEL_FIRSTLAUNCH_BD.TabIndex = 12;
            this.LABEL_FIRSTLAUNCH_BD.Text = "Base de Dados";
            // 
            // TEXTBOX_FIRSTLAUNCH_BD
            // 
            this.TEXTBOX_FIRSTLAUNCH_BD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_FIRSTLAUNCH_BD.Location = new System.Drawing.Point(28, 165);
            this.TEXTBOX_FIRSTLAUNCH_BD.Name = "TEXTBOX_FIRSTLAUNCH_BD";
            this.TEXTBOX_FIRSTLAUNCH_BD.Size = new System.Drawing.Size(158, 20);
            this.TEXTBOX_FIRSTLAUNCH_BD.TabIndex = 13;
            this.TEXTBOX_FIRSTLAUNCH_BD.Text = "bitshare";
            this.TEXTBOX_FIRSTLAUNCH_BD.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TEXTBOX_FIRSTLAUNCH_BD_MouseClick);
            this.TEXTBOX_FIRSTLAUNCH_BD.TextChanged += new System.EventHandler(this.TEXTBOX_FIRSTLAUNCH_BD_TextChanged);
            this.TEXTBOX_FIRSTLAUNCH_BD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TEXTBOX_FIRSTLAUNCH_BD_KeyPress);
            // 
            // LABEL_FIRSTLAUNCH_TIPO
            // 
            this.LABEL_FIRSTLAUNCH_TIPO.AutoSize = true;
            this.LABEL_FIRSTLAUNCH_TIPO.Location = new System.Drawing.Point(192, 149);
            this.LABEL_FIRSTLAUNCH_TIPO.Name = "LABEL_FIRSTLAUNCH_TIPO";
            this.LABEL_FIRSTLAUNCH_TIPO.Size = new System.Drawing.Size(84, 13);
            this.LABEL_FIRSTLAUNCH_TIPO.TabIndex = 14;
            this.LABEL_FIRSTLAUNCH_TIPO.Text = "Tipo de Ligação";
            // 
            // RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL
            // 
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.AutoSize = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Location = new System.Drawing.Point(217, 168);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Name = "RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Size = new System.Drawing.Size(51, 17);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.TabIndex = 15;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.TabStop = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.Text = "Local";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.UseVisualStyleBackColor = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL.CheckedChanged += new System.EventHandler(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL_CheckedChanged);
            // 
            // RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN
            // 
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.AutoSize = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Location = new System.Drawing.Point(217, 191);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Name = "RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Size = new System.Drawing.Size(46, 17);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.TabIndex = 16;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.TabStop = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.Text = "LAN";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.UseVisualStyleBackColor = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN.CheckedChanged += new System.EventHandler(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN_CheckedChanged);
            // 
            // RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB
            // 
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.AutoSize = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Location = new System.Drawing.Point(217, 214);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Name = "RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Size = new System.Drawing.Size(61, 17);
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.TabIndex = 17;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.TabStop = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.Text = "Internet";
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.UseVisualStyleBackColor = true;
            this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB.CheckedChanged += new System.EventHandler(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB_CheckedChanged);
            // 
            // FORM_FirstLaunchConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 246);
            this.Controls.Add(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB);
            this.Controls.Add(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN);
            this.Controls.Add(this.RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL);
            this.Controls.Add(this.LABEL_FIRSTLAUNCH_TIPO);
            this.Controls.Add(this.LABEL_FIRSTLAUNCH_BD);
            this.Controls.Add(this.TEXTBOX_FIRSTLAUNCH_BD);
            this.Controls.Add(this.BUTTON_FIRSTLAUNCH_GUARDARLIGACAO);
            this.Controls.Add(this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FORM_FirstLaunchConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BitShare Manager: Primeira Configuração";
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.ResumeLayout(false);
            this.GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_ENDERECO;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_ENDERECO;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_PORTA;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_PORTA;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_UTILIZADOR;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_UTILIZADOR;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_PASSWORD;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_PASSWORD;
        private System.Windows.Forms.GroupBox GROUPBOX_FIRSTLAUNCH_DADOSLIGACAO;
        private System.Windows.Forms.Button BUTTON_FIRSTLAUNCH_GUARDARLIGACAO;
        private System.ComponentModel.BackgroundWorker BGWORKER;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_BD;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_BD;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_NOME;
        private System.Windows.Forms.TextBox TEXTBOX_FIRSTLAUNCH_NOME;
        private System.Windows.Forms.Label LABEL_FIRSTLAUNCH_TIPO;
        private System.Windows.Forms.RadioButton RADIOBUTTON_FIRSTLAUNCH_TIPO_LOCAL;
        private System.Windows.Forms.RadioButton RADIOBUTTON_FIRSTLAUNCH_TIPO_LAN;
        private System.Windows.Forms.RadioButton RADIOBUTTON_FIRSTLAUNCH_TIPO_WEB;
    }
}