
namespace Command
{
    partial class FormWoodMaterial
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
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_WoodFrame = new System.Windows.Forms.ComboBox();
            this.comboBox_WoodCover = new System.Windows.Forms.ComboBox();
            this.comboBox_CountCover = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_OK.Location = new System.Drawing.Point(29, 110);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(80, 30);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Cancel.Location = new System.Drawing.Point(122, 110);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(80, 30);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(30, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Толщина каркаса";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(26, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Толщина обшивки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(8, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество обшивки";
            // 
            // comboBox_WoodFrame
            // 
            this.comboBox_WoodFrame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_WoodFrame.FormattingEnabled = true;
            this.comboBox_WoodFrame.Location = new System.Drawing.Point(161, 9);
            this.comboBox_WoodFrame.Name = "comboBox_WoodFrame";
            this.comboBox_WoodFrame.Size = new System.Drawing.Size(41, 21);
            this.comboBox_WoodFrame.TabIndex = 5;
            // 
            // comboBox_WoodCover
            // 
            this.comboBox_WoodCover.AllowDrop = true;
            this.comboBox_WoodCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_WoodCover.FormattingEnabled = true;
            this.comboBox_WoodCover.Location = new System.Drawing.Point(161, 39);
            this.comboBox_WoodCover.Name = "comboBox_WoodCover";
            this.comboBox_WoodCover.Size = new System.Drawing.Size(41, 21);
            this.comboBox_WoodCover.TabIndex = 6;
            // 
            // comboBox_CountCover
            // 
            this.comboBox_CountCover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_CountCover.FormattingEnabled = true;
            this.comboBox_CountCover.Location = new System.Drawing.Point(161, 71);
            this.comboBox_CountCover.Name = "comboBox_CountCover";
            this.comboBox_CountCover.Size = new System.Drawing.Size(41, 21);
            this.comboBox_CountCover.TabIndex = 7;
            // 
            // FormWoodMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 146);
            this.Controls.Add(this.comboBox_CountCover);
            this.Controls.Add(this.comboBox_WoodCover);
            this.Controls.Add(this.comboBox_WoodFrame);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(230, 185);
            this.MinimumSize = new System.Drawing.Size(230, 185);
            this.Name = "FormWoodMaterial";
            this.Text = "Параметры ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_WoodFrame;
        private System.Windows.Forms.ComboBox comboBox_WoodCover;
        private System.Windows.Forms.ComboBox comboBox_CountCover;
    }
}