namespace TubeAppWin
{
    partial class MainForm
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
            this.tbAppId = new System.Windows.Forms.TextBox();
            this.tbAppKey = new System.Windows.Forms.TextBox();
            this.lblAppId = new System.Windows.Forms.Label();
            this.lblAppKey = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvTubeLines = new System.Windows.Forms.DataGridView();
            this.lblXMLDataDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTubeLines)).BeginInit();
            this.SuspendLayout();
            // 
            // tbAppId
            // 
            this.tbAppId.Location = new System.Drawing.Point(67, 12);
            this.tbAppId.Name = "tbAppId";
            this.tbAppId.Size = new System.Drawing.Size(122, 20);
            this.tbAppId.TabIndex = 0;
            // 
            // tbAppKey
            // 
            this.tbAppKey.Location = new System.Drawing.Point(67, 38);
            this.tbAppKey.Name = "tbAppKey";
            this.tbAppKey.Size = new System.Drawing.Size(122, 20);
            this.tbAppKey.TabIndex = 1;
            // 
            // lblAppId
            // 
            this.lblAppId.AutoSize = true;
            this.lblAppId.Location = new System.Drawing.Point(12, 15);
            this.lblAppId.Name = "lblAppId";
            this.lblAppId.Size = new System.Drawing.Size(44, 13);
            this.lblAppId.TabIndex = 2;
            this.lblAppId.Text = "App Id: ";
            // 
            // lblAppKey
            // 
            this.lblAppKey.AutoSize = true;
            this.lblAppKey.Location = new System.Drawing.Point(12, 41);
            this.lblAppKey.Name = "lblAppKey";
            this.lblAppKey.Size = new System.Drawing.Size(50, 13);
            this.lblAppKey.TabIndex = 3;
            this.lblAppKey.Text = "App Key:";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(197, 37);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 22);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Pull";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(197, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 22);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dgvTubeLines
            // 
            this.dgvTubeLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTubeLines.Location = new System.Drawing.Point(12, 76);
            this.dgvTubeLines.Name = "dgvTubeLines";
            this.dgvTubeLines.Size = new System.Drawing.Size(554, 244);
            this.dgvTubeLines.TabIndex = 6;
            // 
            // lblXMLDataDate
            // 
            this.lblXMLDataDate.AutoSize = true;
            this.lblXMLDataDate.Location = new System.Drawing.Point(283, 13);
            this.lblXMLDataDate.Name = "lblXMLDataDate";
            this.lblXMLDataDate.Size = new System.Drawing.Size(115, 13);
            this.lblXMLDataDate.TabIndex = 7;
            this.lblXMLDataDate.Text = "Tube XML Data Date: ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 332);
            this.Controls.Add(this.lblXMLDataDate);
            this.Controls.Add(this.dgvTubeLines);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblAppKey);
            this.Controls.Add(this.lblAppId);
            this.Controls.Add(this.tbAppKey);
            this.Controls.Add(this.tbAppId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Tube Line Status";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTubeLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAppId;
        private System.Windows.Forms.TextBox tbAppKey;
        private System.Windows.Forms.Label lblAppId;
        private System.Windows.Forms.Label lblAppKey;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvTubeLines;
        private System.Windows.Forms.Label lblXMLDataDate;
    }
}

