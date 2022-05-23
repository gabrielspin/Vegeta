namespace Meus_testes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonAbrirArquivo = new System.Windows.Forms.Button();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.NumericUpDown();
            this.labelTime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonOrderByDate = new System.Windows.Forms.RadioButton();
            this.radioButtonOrderByTimeTaken = new System.Windows.Forms.RadioButton();
            this.buttonGo = new System.Windows.Forms.Button();
            this.labelOrderBy = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 77);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(404, 308);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "@C:\\";
            this.openFileDialog1.Title = "Abrir arquivo";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // buttonAbrirArquivo
            // 
            this.buttonAbrirArquivo.Location = new System.Drawing.Point(12, 14);
            this.buttonAbrirArquivo.Name = "buttonAbrirArquivo";
            this.buttonAbrirArquivo.Size = new System.Drawing.Size(63, 22);
            this.buttonAbrirArquivo.TabIndex = 5;
            this.buttonAbrirArquivo.Text = "Open log";
            this.buttonAbrirArquivo.UseVisualStyleBackColor = true;
            this.buttonAbrirArquivo.Click += new System.EventHandler(this.buttonAbrirArquivo_Click);
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(78, 19);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(67, 13);
            this.labelFilePath.TabIndex = 7;
            this.labelFilePath.Text = "labelFilePath";
            this.labelFilePath.Visible = false;
            this.labelFilePath.Click += new System.EventHandler(this.labelTitleDoc_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 402);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(57, 13);
            this.labelCount.TabIndex = 9;
            this.labelCount.Text = "labelCount";
            this.labelCount.Visible = false;
            this.labelCount.Click += new System.EventHandler(this.labelCount_Click);
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(94, 42);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(43, 20);
            this.timeBox.TabIndex = 0;
            this.timeBox.ValueChanged += new System.EventHandler(this.timeBox_ValueChanged);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(12, 45);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(82, 13);
            this.labelTime.TabIndex = 10;
            this.labelTime.Text = "Min. time taken:";
            this.labelTime.Click += new System.EventHandler(this.labelTime_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(286, 393);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 31);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonOrderByDate
            // 
            this.radioButtonOrderByDate.AutoSize = true;
            this.radioButtonOrderByDate.Checked = true;
            this.radioButtonOrderByDate.Location = new System.Drawing.Point(207, 45);
            this.radioButtonOrderByDate.Name = "radioButtonOrderByDate";
            this.radioButtonOrderByDate.Size = new System.Drawing.Size(48, 17);
            this.radioButtonOrderByDate.TabIndex = 12;
            this.radioButtonOrderByDate.TabStop = true;
            this.radioButtonOrderByDate.Text = "Date";
            this.radioButtonOrderByDate.UseVisualStyleBackColor = true;
            this.radioButtonOrderByDate.CheckedChanged += new System.EventHandler(this.radioButtonOrderByDate_CheckedChanged);
            // 
            // radioButtonOrderByTimeTaken
            // 
            this.radioButtonOrderByTimeTaken.AutoSize = true;
            this.radioButtonOrderByTimeTaken.Location = new System.Drawing.Point(253, 45);
            this.radioButtonOrderByTimeTaken.Name = "radioButtonOrderByTimeTaken";
            this.radioButtonOrderByTimeTaken.Size = new System.Drawing.Size(78, 17);
            this.radioButtonOrderByTimeTaken.TabIndex = 13;
            this.radioButtonOrderByTimeTaken.TabStop = true;
            this.radioButtonOrderByTimeTaken.Text = "Time taken";
            this.radioButtonOrderByTimeTaken.UseVisualStyleBackColor = true;
            // 
            // buttonGo
            // 
            this.buttonGo.Enabled = false;
            this.buttonGo.Location = new System.Drawing.Point(353, 42);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(63, 23);
            this.buttonGo.TabIndex = 14;
            this.buttonGo.Text = "Go";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // labelOrderBy
            // 
            this.labelOrderBy.AutoSize = true;
            this.labelOrderBy.Location = new System.Drawing.Point(156, 47);
            this.labelOrderBy.Name = "labelOrderBy";
            this.labelOrderBy.Size = new System.Drawing.Size(50, 13);
            this.labelOrderBy.TabIndex = 15;
            this.labelOrderBy.Text = "Order by:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(427, 434);
            this.Controls.Add(this.labelOrderBy);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.radioButtonOrderByTimeTaken);
            this.Controls.Add(this.radioButtonOrderByDate);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.buttonAbrirArquivo);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vegeta";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonAbrirArquivo;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.NumericUpDown timeBox;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RadioButton radioButtonOrderByDate;
        private System.Windows.Forms.RadioButton radioButtonOrderByTimeTaken;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.Label labelOrderBy;
    }
}

