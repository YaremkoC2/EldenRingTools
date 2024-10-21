namespace EldenRingLevel1
{
    partial class GearCalc
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
            this.UI_DGV_Weapons = new System.Windows.Forms.DataGridView();
            this.UI_DGV_Spells = new System.Windows.Forms.DataGridView();
            this.UI_cbox_Helmets = new System.Windows.Forms.ComboBox();
            this.UI_lbl_player = new System.Windows.Forms.Label();
            this.UI_table_Stats = new System.Windows.Forms.TableLayoutPanel();
            this.UI_lbl_Helmets = new System.Windows.Forms.Label();
            this.UI_cbox_Common = new System.Windows.Forms.CheckBox();
            this.UI_cbox_tali1 = new System.Windows.Forms.ComboBox();
            this.UI_cbox_tali2 = new System.Windows.Forms.ComboBox();
            this.UI_cbox_tali3 = new System.Windows.Forms.ComboBox();
            this.UI_cbox_tali4 = new System.Windows.Forms.ComboBox();
            this.UI_gbox_talis = new System.Windows.Forms.GroupBox();
            this.UI_gbox_wond = new System.Windows.Forms.GroupBox();
            this.UI_cbox_fai = new System.Windows.Forms.CheckBox();
            this.UI_cbox_Dex = new System.Windows.Forms.CheckBox();
            this.UI_cbox_int = new System.Windows.Forms.CheckBox();
            this.UI_cbox_Str = new System.Windows.Forms.CheckBox();
            this.UI_cbox_All = new System.Windows.Forms.CheckBox();
            this.UI_cbox_2hand = new System.Windows.Forms.CheckBox();
            this.UI_btn_reset = new System.Windows.Forms.Button();
            this.UI_cbox_Godrick = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Weapons)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Spells)).BeginInit();
            this.UI_gbox_talis.SuspendLayout();
            this.UI_gbox_wond.SuspendLayout();
            this.SuspendLayout();
            // 
            // UI_DGV_Weapons
            // 
            this.UI_DGV_Weapons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DGV_Weapons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_Weapons.Location = new System.Drawing.Point(12, 211);
            this.UI_DGV_Weapons.Name = "UI_DGV_Weapons";
            this.UI_DGV_Weapons.RowHeadersVisible = false;
            this.UI_DGV_Weapons.Size = new System.Drawing.Size(508, 189);
            this.UI_DGV_Weapons.TabIndex = 0;
            // 
            // UI_DGV_Spells
            // 
            this.UI_DGV_Spells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UI_DGV_Spells.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UI_DGV_Spells.Location = new System.Drawing.Point(529, 211);
            this.UI_DGV_Spells.Name = "UI_DGV_Spells";
            this.UI_DGV_Spells.RowHeadersVisible = false;
            this.UI_DGV_Spells.Size = new System.Drawing.Size(508, 189);
            this.UI_DGV_Spells.TabIndex = 1;
            // 
            // UI_cbox_Helmets
            // 
            this.UI_cbox_Helmets.FormattingEnabled = true;
            this.UI_cbox_Helmets.Location = new System.Drawing.Point(240, 26);
            this.UI_cbox_Helmets.Name = "UI_cbox_Helmets";
            this.UI_cbox_Helmets.Size = new System.Drawing.Size(280, 21);
            this.UI_cbox_Helmets.TabIndex = 2;
            this.UI_cbox_Helmets.SelectedIndexChanged += new System.EventHandler(this.UI_cbox_Helmets_SelectedIndexChanged);
            // 
            // UI_lbl_player
            // 
            this.UI_lbl_player.AutoSize = true;
            this.UI_lbl_player.Location = new System.Drawing.Point(9, 9);
            this.UI_lbl_player.Name = "UI_lbl_player";
            this.UI_lbl_player.Size = new System.Drawing.Size(110, 13);
            this.UI_lbl_player.TabIndex = 3;
            this.UI_lbl_player.Text = "Player\'s Current Stats:";
            // 
            // UI_table_Stats
            // 
            this.UI_table_Stats.ColumnCount = 2;
            this.UI_table_Stats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UI_table_Stats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.UI_table_Stats.Location = new System.Drawing.Point(12, 26);
            this.UI_table_Stats.Name = "UI_table_Stats";
            this.UI_table_Stats.RowCount = 8;
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.UI_table_Stats.Size = new System.Drawing.Size(200, 179);
            this.UI_table_Stats.TabIndex = 4;
            // 
            // UI_lbl_Helmets
            // 
            this.UI_lbl_Helmets.AutoSize = true;
            this.UI_lbl_Helmets.Location = new System.Drawing.Point(240, 8);
            this.UI_lbl_Helmets.Name = "UI_lbl_Helmets";
            this.UI_lbl_Helmets.Size = new System.Drawing.Size(48, 13);
            this.UI_lbl_Helmets.TabIndex = 5;
            this.UI_lbl_Helmets.Text = "Helmets:";
            // 
            // UI_cbox_Common
            // 
            this.UI_cbox_Common.AutoSize = true;
            this.UI_cbox_Common.Location = new System.Drawing.Point(396, 179);
            this.UI_cbox_Common.Name = "UI_cbox_Common";
            this.UI_cbox_Common.Size = new System.Drawing.Size(147, 17);
            this.UI_cbox_Common.TabIndex = 6;
            this.UI_cbox_Common.Text = "Commoner\'s Garb (Fai +1)";
            this.UI_cbox_Common.UseVisualStyleBackColor = true;
            this.UI_cbox_Common.CheckedChanged += new System.EventHandler(this.UI_cbox_Common_CheckedChanged);
            // 
            // UI_cbox_tali1
            // 
            this.UI_cbox_tali1.FormattingEnabled = true;
            this.UI_cbox_tali1.Location = new System.Drawing.Point(6, 19);
            this.UI_cbox_tali1.Name = "UI_cbox_tali1";
            this.UI_cbox_tali1.Size = new System.Drawing.Size(280, 21);
            this.UI_cbox_tali1.TabIndex = 7;
            // 
            // UI_cbox_tali2
            // 
            this.UI_cbox_tali2.FormattingEnabled = true;
            this.UI_cbox_tali2.Location = new System.Drawing.Point(299, 19);
            this.UI_cbox_tali2.Name = "UI_cbox_tali2";
            this.UI_cbox_tali2.Size = new System.Drawing.Size(280, 21);
            this.UI_cbox_tali2.TabIndex = 8;
            // 
            // UI_cbox_tali3
            // 
            this.UI_cbox_tali3.FormattingEnabled = true;
            this.UI_cbox_tali3.Location = new System.Drawing.Point(6, 69);
            this.UI_cbox_tali3.Name = "UI_cbox_tali3";
            this.UI_cbox_tali3.Size = new System.Drawing.Size(280, 21);
            this.UI_cbox_tali3.TabIndex = 9;
            // 
            // UI_cbox_tali4
            // 
            this.UI_cbox_tali4.FormattingEnabled = true;
            this.UI_cbox_tali4.Location = new System.Drawing.Point(299, 69);
            this.UI_cbox_tali4.Name = "UI_cbox_tali4";
            this.UI_cbox_tali4.Size = new System.Drawing.Size(280, 21);
            this.UI_cbox_tali4.TabIndex = 10;
            // 
            // UI_gbox_talis
            // 
            this.UI_gbox_talis.Controls.Add(this.UI_cbox_tali1);
            this.UI_gbox_talis.Controls.Add(this.UI_cbox_tali2);
            this.UI_gbox_talis.Controls.Add(this.UI_cbox_tali4);
            this.UI_gbox_talis.Controls.Add(this.UI_cbox_tali3);
            this.UI_gbox_talis.Location = new System.Drawing.Point(240, 62);
            this.UI_gbox_talis.Name = "UI_gbox_talis";
            this.UI_gbox_talis.Size = new System.Drawing.Size(592, 100);
            this.UI_gbox_talis.TabIndex = 15;
            this.UI_gbox_talis.TabStop = false;
            this.UI_gbox_talis.Text = "Talismans";
            // 
            // UI_gbox_wond
            // 
            this.UI_gbox_wond.Controls.Add(this.UI_cbox_fai);
            this.UI_gbox_wond.Controls.Add(this.UI_cbox_Dex);
            this.UI_gbox_wond.Controls.Add(this.UI_cbox_int);
            this.UI_gbox_wond.Controls.Add(this.UI_cbox_Str);
            this.UI_gbox_wond.Location = new System.Drawing.Point(838, 62);
            this.UI_gbox_wond.Name = "UI_gbox_wond";
            this.UI_gbox_wond.Size = new System.Drawing.Size(200, 100);
            this.UI_gbox_wond.TabIndex = 16;
            this.UI_gbox_wond.TabStop = false;
            this.UI_gbox_wond.Text = "Wondrous Physick";
            // 
            // UI_cbox_fai
            // 
            this.UI_cbox_fai.AutoSize = true;
            this.UI_cbox_fai.Location = new System.Drawing.Point(103, 69);
            this.UI_cbox_fai.Name = "UI_cbox_fai";
            this.UI_cbox_fai.Size = new System.Drawing.Size(49, 17);
            this.UI_cbox_fai.TabIndex = 3;
            this.UI_cbox_fai.Text = "Faith";
            this.UI_cbox_fai.UseVisualStyleBackColor = true;
            // 
            // UI_cbox_Dex
            // 
            this.UI_cbox_Dex.AutoSize = true;
            this.UI_cbox_Dex.Location = new System.Drawing.Point(103, 23);
            this.UI_cbox_Dex.Name = "UI_cbox_Dex";
            this.UI_cbox_Dex.Size = new System.Drawing.Size(67, 17);
            this.UI_cbox_Dex.TabIndex = 2;
            this.UI_cbox_Dex.Text = "Dexterity";
            this.UI_cbox_Dex.UseVisualStyleBackColor = true;
            // 
            // UI_cbox_int
            // 
            this.UI_cbox_int.AutoSize = true;
            this.UI_cbox_int.Location = new System.Drawing.Point(7, 69);
            this.UI_cbox_int.Name = "UI_cbox_int";
            this.UI_cbox_int.Size = new System.Drawing.Size(80, 17);
            this.UI_cbox_int.TabIndex = 1;
            this.UI_cbox_int.Text = "Intelligence";
            this.UI_cbox_int.UseVisualStyleBackColor = true;
            // 
            // UI_cbox_Str
            // 
            this.UI_cbox_Str.AutoSize = true;
            this.UI_cbox_Str.Location = new System.Drawing.Point(7, 22);
            this.UI_cbox_Str.Name = "UI_cbox_Str";
            this.UI_cbox_Str.Size = new System.Drawing.Size(66, 17);
            this.UI_cbox_Str.TabIndex = 0;
            this.UI_cbox_Str.Text = "Strength";
            this.UI_cbox_Str.UseVisualStyleBackColor = true;
            // 
            // UI_cbox_All
            // 
            this.UI_cbox_All.AutoSize = true;
            this.UI_cbox_All.Location = new System.Drawing.Point(539, 28);
            this.UI_cbox_All.Name = "UI_cbox_All";
            this.UI_cbox_All.Size = new System.Drawing.Size(164, 17);
            this.UI_cbox_All.TabIndex = 17;
            this.UI_cbox_All.Text = "View All Weapons and Spells";
            this.UI_cbox_All.UseVisualStyleBackColor = true;
            this.UI_cbox_All.CheckedChanged += new System.EventHandler(this.UI_cbox_All_CheckedChanged);
            // 
            // UI_cbox_2hand
            // 
            this.UI_cbox_2hand.AutoSize = true;
            this.UI_cbox_2hand.Location = new System.Drawing.Point(240, 179);
            this.UI_cbox_2hand.Name = "UI_cbox_2hand";
            this.UI_cbox_2hand.Size = new System.Drawing.Size(150, 17);
            this.UI_cbox_2hand.TabIndex = 18;
            this.UI_cbox_2hand.Text = "2-Hand Weapon (Str 1.5x)";
            this.UI_cbox_2hand.UseVisualStyleBackColor = true;
            this.UI_cbox_2hand.CheckedChanged += new System.EventHandler(this.UI_cbox_2hand_CheckedChanged);
            // 
            // UI_btn_reset
            // 
            this.UI_btn_reset.Location = new System.Drawing.Point(884, 19);
            this.UI_btn_reset.Name = "UI_btn_reset";
            this.UI_btn_reset.Size = new System.Drawing.Size(124, 33);
            this.UI_btn_reset.TabIndex = 19;
            this.UI_btn_reset.Text = "Reset All";
            this.UI_btn_reset.UseVisualStyleBackColor = true;
            this.UI_btn_reset.Click += new System.EventHandler(this.UI_btn_reset_Click);
            // 
            // UI_cbox_Godrick
            // 
            this.UI_cbox_Godrick.AutoSize = true;
            this.UI_cbox_Godrick.Location = new System.Drawing.Point(550, 179);
            this.UI_cbox_Godrick.Name = "UI_cbox_Godrick";
            this.UI_cbox_Godrick.Size = new System.Drawing.Size(163, 17);
            this.UI_cbox_Godrick.TabIndex = 20;
            this.UI_cbox_Godrick.Text = "Godrick\'s Great Rune (+5 All)";
            this.UI_cbox_Godrick.UseVisualStyleBackColor = true;
            this.UI_cbox_Godrick.CheckedChanged += new System.EventHandler(this.UI_cbox_Godrick_CheckedChanged);
            // 
            // GearCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 414);
            this.Controls.Add(this.UI_cbox_Godrick);
            this.Controls.Add(this.UI_btn_reset);
            this.Controls.Add(this.UI_cbox_2hand);
            this.Controls.Add(this.UI_cbox_All);
            this.Controls.Add(this.UI_gbox_wond);
            this.Controls.Add(this.UI_gbox_talis);
            this.Controls.Add(this.UI_cbox_Common);
            this.Controls.Add(this.UI_lbl_Helmets);
            this.Controls.Add(this.UI_table_Stats);
            this.Controls.Add(this.UI_lbl_player);
            this.Controls.Add(this.UI_cbox_Helmets);
            this.Controls.Add(this.UI_DGV_Spells);
            this.Controls.Add(this.UI_DGV_Weapons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GearCalc";
            this.Text = "Elden Ring Level 1 Gear Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Weapons)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UI_DGV_Spells)).EndInit();
            this.UI_gbox_talis.ResumeLayout(false);
            this.UI_gbox_wond.ResumeLayout(false);
            this.UI_gbox_wond.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UI_DGV_Weapons;
        private System.Windows.Forms.DataGridView UI_DGV_Spells;
        private System.Windows.Forms.ComboBox UI_cbox_Helmets;
        private System.Windows.Forms.Label UI_lbl_player;
        private System.Windows.Forms.TableLayoutPanel UI_table_Stats;
        private System.Windows.Forms.Label UI_lbl_Helmets;
        private System.Windows.Forms.CheckBox UI_cbox_Common;
        private System.Windows.Forms.ComboBox UI_cbox_tali1;
        private System.Windows.Forms.ComboBox UI_cbox_tali2;
        private System.Windows.Forms.ComboBox UI_cbox_tali3;
        private System.Windows.Forms.ComboBox UI_cbox_tali4;
        private System.Windows.Forms.GroupBox UI_gbox_talis;
        private System.Windows.Forms.GroupBox UI_gbox_wond;
        private System.Windows.Forms.CheckBox UI_cbox_fai;
        private System.Windows.Forms.CheckBox UI_cbox_Dex;
        private System.Windows.Forms.CheckBox UI_cbox_int;
        private System.Windows.Forms.CheckBox UI_cbox_Str;
        private System.Windows.Forms.CheckBox UI_cbox_All;
        private System.Windows.Forms.CheckBox UI_cbox_2hand;
        private System.Windows.Forms.Button UI_btn_reset;
        private System.Windows.Forms.CheckBox UI_cbox_Godrick;
    }
}

