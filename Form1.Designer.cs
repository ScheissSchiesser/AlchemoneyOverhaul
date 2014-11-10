namespace AlchemoneyOverhaul
{
    partial class AlchemoneyOverhaul
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
            this.btnFind = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tblQuery = new System.Windows.Forms.DataGridView();
            this.btnBuildDB = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtNumPots = new System.Windows.Forms.TextBox();
            this.lblCompTime = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnBrewTop = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuery)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(3, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(96, 39);
            this.btnFind.TabIndex = 0;
            this.btnFind.Text = "Find!";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(312, 126);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(844, 476);
            this.dataGridView1.TabIndex = 1;
            // 
            // tblQuery
            // 
            this.tblQuery.AllowUserToAddRows = false;
            this.tblQuery.AllowUserToDeleteRows = false;
            this.tblQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tblQuery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tblQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblQuery.Location = new System.Drawing.Point(26, 12);
            this.tblQuery.Name = "tblQuery";
            this.tblQuery.Size = new System.Drawing.Size(280, 590);
            this.tblQuery.TabIndex = 2;
            this.tblQuery.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblQuery_CellContentClick);
            this.tblQuery.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblQuery_CellEndEdit);
            // 
            // btnBuildDB
            // 
            this.btnBuildDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuildDB.Location = new System.Drawing.Point(3, 3);
            this.btnBuildDB.Name = "btnBuildDB";
            this.btnBuildDB.Size = new System.Drawing.Size(100, 39);
            this.btnBuildDB.TabIndex = 3;
            this.btnBuildDB.Text = "Rebuild Database";
            this.btnBuildDB.UseVisualStyleBackColor = true;
            this.btnBuildDB.Click += new System.EventHandler(this.btnBuildDB_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(3, 48);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 4;
            // 
            // txtNumPots
            // 
            this.txtNumPots.Location = new System.Drawing.Point(105, 13);
            this.txtNumPots.Name = "txtNumPots";
            this.txtNumPots.Size = new System.Drawing.Size(31, 20);
            this.txtNumPots.TabIndex = 5;
            this.txtNumPots.Text = "5";
            this.txtNumPots.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCompTime
            // 
            this.lblCompTime.AutoSize = true;
            this.lblCompTime.Location = new System.Drawing.Point(179, 58);
            this.lblCompTime.Name = "lblCompTime";
            this.lblCompTime.Size = new System.Drawing.Size(95, 13);
            this.lblCompTime.TabIndex = 6;
            this.lblCompTime.Text = "Computation Time:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.btnBrewTop);
            this.pnlLeft.Controls.Add(this.btnFind);
            this.pnlLeft.Controls.Add(this.lblCompTime);
            this.pnlLeft.Controls.Add(this.txtNumPots);
            this.pnlLeft.Location = new System.Drawing.Point(312, 42);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(341, 78);
            this.pnlLeft.TabIndex = 7;
            // 
            // btnBrewTop
            // 
            this.btnBrewTop.Location = new System.Drawing.Point(3, 48);
            this.btnBrewTop.Name = "btnBrewTop";
            this.btnBrewTop.Size = new System.Drawing.Size(96, 23);
            this.btnBrewTop.TabIndex = 7;
            this.btnBrewTop.Text = "Brew Top Potion";
            this.btnBrewTop.UseVisualStyleBackColor = true;
            this.btnBrewTop.Click += new System.EventHandler(this.btnBrewTop_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.Controls.Add(this.btnBuildDB);
            this.pnlRight.Controls.Add(this.progressBar1);
            this.pnlRight.Location = new System.Drawing.Point(1050, 42);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(106, 78);
            this.pnlRight.TabIndex = 8;
            // 
            // AlchemoneyOverhaul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1173, 616);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.tblQuery);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AlchemoneyOverhaul";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Alchemoney Overhaul";
            this.Load += new System.EventHandler(this.AlchemoneyOverhaul_Load);
            this.Resize += new System.EventHandler(this.AlchemoneyOverhaul_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblQuery)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView tblQuery;
        private System.Windows.Forms.Button btnBuildDB;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtNumPots;
        private System.Windows.Forms.Label lblCompTime;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button btnBrewTop;
        private System.Windows.Forms.Panel pnlRight;
    }
}

