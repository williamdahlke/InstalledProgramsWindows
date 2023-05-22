namespace WindowsFormsTeste
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Teste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Teste
            // 
            this.btn_Teste.Location = new System.Drawing.Point(345, 194);
            this.btn_Teste.Name = "btn_Teste";
            this.btn_Teste.Size = new System.Drawing.Size(83, 31);
            this.btn_Teste.TabIndex = 0;
            this.btn_Teste.Text = "Testar";
            this.btn_Teste.UseVisualStyleBackColor = true;
            this.btn_Teste.Click += new System.EventHandler(this.btn_Teste_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Teste);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Teste;
    }
}

