namespace BitShare_Manager
{
    partial class FORM_GESTAO_FILMES_GERIRCATEGORIAS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_GESTAO_FILMES_GERIRCATEGORIAS));
            this.MENUSTRIP_GERIRCATEGORIASFILMES = new System.Windows.Forms.MenuStrip();
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR = new System.Windows.Forms.ToolStripMenuItem();
            this.LABEL_GERIRCATEGORIASFILMES_FILME = new System.Windows.Forms.Label();
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TITULOPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABEL_GERIRCATEGORIASFILMES_ID = new System.Windows.Forms.Label();
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID = new System.Windows.Forms.TextBox();
            this.LABEL_GERIRCATEGORIASFILMES_NOME = new System.Windows.Forms.Label();
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME = new System.Windows.Forms.TextBox();
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS = new System.Windows.Forms.Label();
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS = new System.Windows.Forms.ListBox();
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS = new System.Windows.Forms.Label();
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS = new System.Windows.Forms.ListBox();
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES = new System.Windows.Forms.Button();
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR = new System.Windows.Forms.TextBox();
            this.BUTTON_REFRESH = new System.Windows.Forms.Button();
            this.TEXTBOX_TITULOPT = new System.Windows.Forms.TextBox();
            this.MENUSTRIP_GERIRCATEGORIASFILMES.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME)).BeginInit();
            this.SuspendLayout();
            // 
            // MENUSTRIP_GERIRCATEGORIASFILMES
            // 
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR});
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Location = new System.Drawing.Point(0, 0);
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Name = "MENUSTRIP_GERIRCATEGORIASFILMES";
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Size = new System.Drawing.Size(777, 28);
            this.MENUSTRIP_GERIRCATEGORIASFILMES.TabIndex = 0;
            this.MENUSTRIP_GERIRCATEGORIASFILMES.Text = "menuStrip1";
            // 
            // MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR
            // 
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Image = global::BitShare_Manager.Properties.Resources.Fechar_2;
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Name = "MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR";
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Size = new System.Drawing.Size(75, 22);
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Text = "Fechar";
            this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR.Click += new System.EventHandler(this.MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR_Click);
            // 
            // LABEL_GERIRCATEGORIASFILMES_FILME
            // 
            this.LABEL_GERIRCATEGORIASFILMES_FILME.AutoSize = true;
            this.LABEL_GERIRCATEGORIASFILMES_FILME.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LABEL_GERIRCATEGORIASFILMES_FILME.Location = new System.Drawing.Point(2, 43);
            this.LABEL_GERIRCATEGORIASFILMES_FILME.Name = "LABEL_GERIRCATEGORIASFILMES_FILME";
            this.LABEL_GERIRCATEGORIASFILMES_FILME.Size = new System.Drawing.Size(40, 18);
            this.LABEL_GERIRCATEGORIASFILMES_FILME.TabIndex = 1;
            this.LABEL_GERIRCATEGORIASFILMES_FILME.Text = "Filme";
            // 
            // DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME
            // 
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.AllowUserToAddRows = false;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.AllowUserToDeleteRows = false;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.AllowUserToResizeRows = false;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Titulo,
            this.TITULOPT});
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.Location = new System.Drawing.Point(5, 73);
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.Name = "DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME";
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.ReadOnly = true;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.RowHeadersVisible = false;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.Size = new System.Drawing.Size(337, 473);
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.TabIndex = 2;
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.SelectionChanged += new System.EventHandler(this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME_SelectionChanged);
            this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Titulo
            // 
            this.Titulo.DataPropertyName = "Nome_Original";
            this.Titulo.HeaderText = "Titulo";
            this.Titulo.Name = "Titulo";
            this.Titulo.ReadOnly = true;
            this.Titulo.Width = 265;
            // 
            // TITULOPT
            // 
            this.TITULOPT.DataPropertyName = "Nome";
            this.TITULOPT.HeaderText = "Titulo PT";
            this.TITULOPT.Name = "TITULOPT";
            this.TITULOPT.ReadOnly = true;
            this.TITULOPT.Width = 265;
            // 
            // LABEL_GERIRCATEGORIASFILMES_ID
            // 
            this.LABEL_GERIRCATEGORIASFILMES_ID.AutoSize = true;
            this.LABEL_GERIRCATEGORIASFILMES_ID.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LABEL_GERIRCATEGORIASFILMES_ID.Location = new System.Drawing.Point(350, 73);
            this.LABEL_GERIRCATEGORIASFILMES_ID.Name = "LABEL_GERIRCATEGORIASFILMES_ID";
            this.LABEL_GERIRCATEGORIASFILMES_ID.Size = new System.Drawing.Size(20, 18);
            this.LABEL_GERIRCATEGORIASFILMES_ID.TabIndex = 3;
            this.LABEL_GERIRCATEGORIASFILMES_ID.Text = "ID";
            // 
            // TEXTBOX_GERIRCATEGORIASFILMES_ID
            // 
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.Location = new System.Drawing.Point(353, 96);
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.Name = "TEXTBOX_GERIRCATEGORIASFILMES_ID";
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.ReadOnly = true;
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.Size = new System.Drawing.Size(52, 23);
            this.TEXTBOX_GERIRCATEGORIASFILMES_ID.TabIndex = 4;
            // 
            // LABEL_GERIRCATEGORIASFILMES_NOME
            // 
            this.LABEL_GERIRCATEGORIASFILMES_NOME.AutoSize = true;
            this.LABEL_GERIRCATEGORIASFILMES_NOME.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LABEL_GERIRCATEGORIASFILMES_NOME.Location = new System.Drawing.Point(407, 73);
            this.LABEL_GERIRCATEGORIASFILMES_NOME.Name = "LABEL_GERIRCATEGORIASFILMES_NOME";
            this.LABEL_GERIRCATEGORIASFILMES_NOME.Size = new System.Drawing.Size(40, 18);
            this.LABEL_GERIRCATEGORIASFILMES_NOME.TabIndex = 5;
            this.LABEL_GERIRCATEGORIASFILMES_NOME.Text = "Filme";
            // 
            // TEXTBOX_GERIRCATEGORIASFILMES_NOME
            // 
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.Location = new System.Drawing.Point(410, 96);
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.Name = "TEXTBOX_GERIRCATEGORIASFILMES_NOME";
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.ReadOnly = true;
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.Size = new System.Drawing.Size(361, 23);
            this.TEXTBOX_GERIRCATEGORIASFILMES_NOME.TabIndex = 6;
            // 
            // LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS
            // 
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.AutoSize = true;
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.Location = new System.Drawing.Point(349, 164);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.Name = "LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS";
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.Size = new System.Drawing.Size(105, 18);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.TabIndex = 7;
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS.Text = "Atribuir Géneros";
            // 
            // LISTBOX_GERIRCATEGORIASFILMES_GENEROS
            // 
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.FormattingEnabled = true;
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.ItemHeight = 18;
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Location = new System.Drawing.Point(357, 190);
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Name = "LISTBOX_GERIRCATEGORIASFILMES_GENEROS";
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.Size = new System.Drawing.Size(234, 328);
            this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS.TabIndex = 8;
            // 
            // LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS
            // 
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.AutoSize = true;
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.Location = new System.Drawing.Point(590, 164);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.Name = "LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS";
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.Size = new System.Drawing.Size(90, 18);
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.TabIndex = 9;
            this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS.Text = "Atribuir Datas";
            // 
            // LISTBOX_GERIRCATEGORIASFILMES_DATAS
            // 
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.FormattingEnabled = true;
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.ItemHeight = 18;
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Location = new System.Drawing.Point(598, 190);
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Name = "LISTBOX_GERIRCATEGORIASFILMES_DATAS";
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Size = new System.Drawing.Size(172, 328);
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.Sorted = true;
            this.LISTBOX_GERIRCATEGORIASFILMES_DATAS.TabIndex = 10;
            // 
            // BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES
            // 
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Location = new System.Drawing.Point(357, 526);
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Name = "BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES";
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Size = new System.Drawing.Size(414, 67);
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.TabIndex = 11;
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Text = "Gravar Alterações";
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.UseVisualStyleBackColor = true;
            this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES.Click += new System.EventHandler(this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES_Click);
            // 
            // TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR
            // 
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Location = new System.Drawing.Point(45, 40);
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Name = "TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR";
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.Size = new System.Drawing.Size(297, 23);
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.TabIndex = 12;
            this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR.TextChanged += new System.EventHandler(this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR_TextChanged);
            // 
            // BUTTON_REFRESH
            // 
            this.BUTTON_REFRESH.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.BUTTON_REFRESH.Location = new System.Drawing.Point(5, 554);
            this.BUTTON_REFRESH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BUTTON_REFRESH.Name = "BUTTON_REFRESH";
            this.BUTTON_REFRESH.Size = new System.Drawing.Size(337, 39);
            this.BUTTON_REFRESH.TabIndex = 13;
            this.BUTTON_REFRESH.Text = "Actualizar";
            this.BUTTON_REFRESH.UseVisualStyleBackColor = true;
            this.BUTTON_REFRESH.Click += new System.EventHandler(this.BUTTON_REFRESH_Click);
            // 
            // TEXTBOX_TITULOPT
            // 
            this.TEXTBOX_TITULOPT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TEXTBOX_TITULOPT.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.TEXTBOX_TITULOPT.Location = new System.Drawing.Point(410, 121);
            this.TEXTBOX_TITULOPT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TEXTBOX_TITULOPT.Name = "TEXTBOX_TITULOPT";
            this.TEXTBOX_TITULOPT.ReadOnly = true;
            this.TEXTBOX_TITULOPT.Size = new System.Drawing.Size(361, 23);
            this.TEXTBOX_TITULOPT.TabIndex = 14;
            // 
            // FORM_GESTAO_FILMES_GERIRCATEGORIAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 598);
            this.Controls.Add(this.TEXTBOX_TITULOPT);
            this.Controls.Add(this.BUTTON_REFRESH);
            this.Controls.Add(this.TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR);
            this.Controls.Add(this.BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES);
            this.Controls.Add(this.LISTBOX_GERIRCATEGORIASFILMES_DATAS);
            this.Controls.Add(this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS);
            this.Controls.Add(this.LISTBOX_GERIRCATEGORIASFILMES_GENEROS);
            this.Controls.Add(this.LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS);
            this.Controls.Add(this.TEXTBOX_GERIRCATEGORIASFILMES_NOME);
            this.Controls.Add(this.LABEL_GERIRCATEGORIASFILMES_NOME);
            this.Controls.Add(this.TEXTBOX_GERIRCATEGORIASFILMES_ID);
            this.Controls.Add(this.LABEL_GERIRCATEGORIASFILMES_ID);
            this.Controls.Add(this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME);
            this.Controls.Add(this.LABEL_GERIRCATEGORIASFILMES_FILME);
            this.Controls.Add(this.MENUSTRIP_GERIRCATEGORIASFILMES);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MENUSTRIP_GERIRCATEGORIASFILMES;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FORM_GESTAO_FILMES_GERIRCATEGORIAS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BitShare Manager - Gerir Categorias dos Filmes";
            this.MENUSTRIP_GERIRCATEGORIASFILMES.ResumeLayout(false);
            this.MENUSTRIP_GERIRCATEGORIASFILMES.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MENUSTRIP_GERIRCATEGORIASFILMES;
        private System.Windows.Forms.ToolStripMenuItem MENUSTRIP_GERIRCATEGORIASFILMES_BUTTON_FECHAR;
        private System.Windows.Forms.Label LABEL_GERIRCATEGORIASFILMES_FILME;
        private System.Windows.Forms.DataGridView DATAGRIDVIEW_GERIRCATEGORIASFILMES_FILME;
        private System.Windows.Forms.Label LABEL_GERIRCATEGORIASFILMES_ID;
        private System.Windows.Forms.TextBox TEXTBOX_GERIRCATEGORIASFILMES_ID;
        private System.Windows.Forms.Label LABEL_GERIRCATEGORIASFILMES_NOME;
        private System.Windows.Forms.TextBox TEXTBOX_GERIRCATEGORIASFILMES_NOME;
        private System.Windows.Forms.Label LABEL_GERIRCATEGORIASFILMES_ATRIBUIRGENEROS;
        private System.Windows.Forms.ListBox LISTBOX_GERIRCATEGORIASFILMES_GENEROS;
        private System.Windows.Forms.Label LABEL_GERIRCATEGORIASFILMES_ATRIBUIRDATAS;
        private System.Windows.Forms.ListBox LISTBOX_GERIRCATEGORIASFILMES_DATAS;
        private System.Windows.Forms.Button BUTTON_GERIRCATEGORIASFILMES_GRAVARALTERACOES;
        private System.Windows.Forms.TextBox TEXTBOX_GERIRCATEGORIASFILMES_PROCURAR;
        private System.Windows.Forms.Button BUTTON_REFRESH;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TITULOPT;
        private System.Windows.Forms.TextBox TEXTBOX_TITULOPT;
    }
}