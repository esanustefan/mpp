﻿namespace baschet
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Echipa1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Echipa2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PretBilete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BileteDisponibile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.only_availableBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.id, this.Echipa1, this.Echipa2, this.PretBilete, this.BileteDisponibile, this.statusColumn });
            this.dataGridView1.Location = new System.Drawing.Point(80, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(805, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // Echipa1
            // 
            this.Echipa1.HeaderText = "Echipa1";
            this.Echipa1.MinimumWidth = 6;
            this.Echipa1.Name = "Echipa1";
            this.Echipa1.Width = 125;
            // 
            // Echipa2
            // 
            this.Echipa2.HeaderText = "Echipa2";
            this.Echipa2.MinimumWidth = 6;
            this.Echipa2.Name = "Echipa2";
            this.Echipa2.Width = 125;
            // 
            // PretBilete
            // 
            this.PretBilete.HeaderText = "Pret Bilete";
            this.PretBilete.MinimumWidth = 6;
            this.PretBilete.Name = "PretBilete";
            this.PretBilete.Width = 125;
            // 
            // BileteDisponibile
            // 
            this.BileteDisponibile.HeaderText = "Bilete Disponibile";
            this.BileteDisponibile.MinimumWidth = 6;
            this.BileteDisponibile.Name = "BileteDisponibile";
            this.BileteDisponibile.Width = 125;
            // 
            // statusColumn
            // 
            this.statusColumn.HeaderText = "";
            this.statusColumn.MinimumWidth = 6;
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.Width = 125;
            // 
            // only_availableBtn
            // 
            this.only_availableBtn.Location = new System.Drawing.Point(551, 12);
            this.only_availableBtn.Name = "only_availableBtn";
            this.only_availableBtn.Size = new System.Drawing.Size(113, 23);
            this.only_availableBtn.TabIndex = 1;
            this.only_availableBtn.Text = "Doar Diponibile";
            this.only_availableBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.only_availableBtn.UseVisualStyleBackColor = true;
            this.only_availableBtn.Click += new System.EventHandler(this.only_availableBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(810, 389);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 2;
            this.refreshBtn.Text = "Rerfresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtnClick);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(375, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Inapoi";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.Inapoi_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.Location = new System.Drawing.Point(80, 389);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(75, 23);
            this.LogOutBtn.TabIndex = 4;
            this.LogOutBtn.Text = "Log Out";
            this.LogOutBtn.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.only_availableBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Echipa1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Echipa2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PretBilete;
        private System.Windows.Forms.DataGridViewTextBoxColumn BileteDisponibile;
        private System.Windows.Forms.Button only_availableBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button LogOutBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
    }
}