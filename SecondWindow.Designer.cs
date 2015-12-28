namespace DB_of_Sportsmans
{
    partial class SecondWindow
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
            this.ColumnFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDataOfBorn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMedCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFIO,
            this.ColumnDataOfBorn,
            this.ColumnKind,
            this.ColumnRank,
            this.ColumnMedCheck});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.Size = new System.Drawing.Size(700, 324);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColumnFIO
            // 
            this.ColumnFIO.HeaderText = "ФИО";
            this.ColumnFIO.Name = "ColumnFIO";
            // 
            // ColumnDataOfBorn
            // 
            this.ColumnDataOfBorn.HeaderText = "Дата рожд.";
            this.ColumnDataOfBorn.Name = "ColumnDataOfBorn";
            // 
            // ColumnKind
            // 
            this.ColumnKind.HeaderText = "Вид";
            this.ColumnKind.Name = "ColumnKind";
            // 
            // ColumnRank
            // 
            this.ColumnRank.HeaderText = "Разряд";
            this.ColumnRank.Name = "ColumnRank";
            // 
            // ColumnMedCheck
            // 
            this.ColumnMedCheck.HeaderText = "Мед. осмотр";
            this.ColumnMedCheck.Name = "ColumnMedCheck";
            this.ColumnMedCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMedCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SecondWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(700, 324);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SecondWindow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Просмотр записей";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDataOfBorn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRank;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnMedCheck;

    }
}