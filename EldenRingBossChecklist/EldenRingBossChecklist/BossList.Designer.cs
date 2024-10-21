namespace EldenRingBossChecklist
{
    partial class BossList
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
            this.UI_DGV_bosses = new System.Windows.Forms.DataGridView();
            this.UI_gbox_filters = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.UI_cbox_Hide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_bosses)).BeginInit();
            this.UI_gbox_filters.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_DGV_bosses
            // 
            this.UI_DGV_bosses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DGV_bosses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_bosses.Location = new System.Drawing.Point(0, 97);
            this.UI_DGV_bosses.Name = "UI_DGV_bosses";
            this.UI_DGV_bosses.RowHeadersVisible = false;
            this.UI_DGV_bosses.Size = new System.Drawing.Size(800, 353);
            this.UI_DGV_bosses.TabIndex = 0;
            // 
            // UI_gbox_filters
            // 
            this.UI_gbox_filters.Controls.Add(this.UI_cbox_Hide);
            this.UI_gbox_filters.Dock = System.Windows.Forms.DockStyle.Top;
            this.UI_gbox_filters.Location = new System.Drawing.Point(0, 0);
            this.UI_gbox_filters.Name = "UI_gbox_filters";
            this.UI_gbox_filters.Size = new System.Drawing.Size(800, 66);
            this.UI_gbox_filters.TabIndex = 1;
            this.UI_gbox_filters.TabStop = false;
            this.UI_gbox_filters.Text = "Filters";
            // 
            // UI_cbox_Hide
            // 
            this.UI_cbox_Hide.AutoSize = true;
            this.UI_cbox_Hide.Location = new System.Drawing.Point(7, 20);
            this.UI_cbox_Hide.Name = "UI_cbox_Hide";
            this.UI_cbox_Hide.Size = new System.Drawing.Size(118, 17);
            this.UI_cbox_Hide.TabIndex = 0;
            this.UI_cbox_Hide.Text = "Hide Found Bosses";
            this.UI_cbox_Hide.UseVisualStyleBackColor = true;
            this.UI_cbox_Hide.CheckedChanged += new System.EventHandler(this.UI_cbox_Hide_CheckedChanged);
            // 
            // BossList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UI_gbox_filters);
            this.Controls.Add(this.UI_DGV_bosses);
            this.Name = "BossList";
            this.Text = "Elden Ring Boss Checklist";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_bosses)).EndInit();
            this.UI_gbox_filters.ResumeLayout(false);
            this.UI_gbox_filters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DGV_bosses;
        private System.Windows.Forms.GroupBox UI_gbox_filters;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox UI_cbox_Hide;
    }
}

