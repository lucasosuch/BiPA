namespace AlgorytmyDoTTP.Widoki
{
    partial class RezultatBadania
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.wykresMax = new System.Windows.Forms.PictureBox();
            this.wykresMin = new System.Windows.Forms.PictureBox();
            this.wykresSrednia = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wykresMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresSrednia)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.wykresSrednia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.wykresMin, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.wykresMax, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1107, 635);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // wykresMax
            // 
            this.wykresMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresMax.Location = new System.Drawing.Point(556, 3);
            this.wykresMax.Name = "wykresMax";
            this.wykresMax.Size = new System.Drawing.Size(548, 311);
            this.wykresMax.TabIndex = 1;
            this.wykresMax.TabStop = false;
            // 
            // wykresMin
            // 
            this.wykresMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresMin.Location = new System.Drawing.Point(3, 3);
            this.wykresMin.Name = "wykresMin";
            this.wykresMin.Size = new System.Drawing.Size(547, 311);
            this.wykresMin.TabIndex = 2;
            this.wykresMin.TabStop = false;
            // 
            // wykresSrednia
            // 
            this.wykresSrednia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wykresSrednia.Location = new System.Drawing.Point(3, 320);
            this.wykresSrednia.Name = "wykresSrednia";
            this.wykresSrednia.Size = new System.Drawing.Size(547, 312);
            this.wykresSrednia.TabIndex = 3;
            this.wykresSrednia.TabStop = false;
            // 
            // RezultatBadania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 635);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RezultatBadania";
            this.Text = "RezultatBadania";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wykresMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wykresSrednia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox wykresSrednia;
        private System.Windows.Forms.PictureBox wykresMin;
        private System.Windows.Forms.PictureBox wykresMax;
    }
}