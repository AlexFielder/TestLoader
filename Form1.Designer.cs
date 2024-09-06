namespace TestLoader
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_folderTextBox = new System.Windows.Forms.TextBox();
            this.m_folderButton = new System.Windows.Forms.Button();
            this.m_outputTextBox = new System.Windows.Forms.TextBox();
            this.m_loadButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Extension Folder:";
            // 
            // m_folderTextBox
            // 
            this.m_folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_folderTextBox.Location = new System.Drawing.Point(106, 6);
            this.m_folderTextBox.Name = "m_folderTextBox";
            this.m_folderTextBox.Size = new System.Drawing.Size(224, 20);
            this.m_folderTextBox.TabIndex = 1;
            // 
            // m_folderButton
            // 
            this.m_folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_folderButton.Location = new System.Drawing.Point(336, 6);
            this.m_folderButton.Name = "m_folderButton";
            this.m_folderButton.Size = new System.Drawing.Size(25, 20);
            this.m_folderButton.TabIndex = 2;
            this.m_folderButton.Text = "...";
            this.m_folderButton.UseVisualStyleBackColor = true;
            this.m_folderButton.Click += new System.EventHandler(this.m_folderButton_Click);
            // 
            // m_outputTextBox
            // 
            this.m_outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_outputTextBox.Location = new System.Drawing.Point(12, 76);
            this.m_outputTextBox.Multiline = true;
            this.m_outputTextBox.Name = "m_outputTextBox";
            this.m_outputTextBox.Size = new System.Drawing.Size(346, 132);
            this.m_outputTextBox.TabIndex = 3;
            // 
            // m_loadButton
            // 
            this.m_loadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_loadButton.Location = new System.Drawing.Point(283, 32);
            this.m_loadButton.Name = "m_loadButton";
            this.m_loadButton.Size = new System.Drawing.Size(75, 23);
            this.m_loadButton.TabIndex = 4;
            this.m_loadButton.Text = "Load";
            this.m_loadButton.UseVisualStyleBackColor = true;
            this.m_loadButton.Click += new System.EventHandler(this.m_loadButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 220);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_loadButton);
            this.Controls.Add(this.m_outputTextBox);
            this.Controls.Add(this.m_folderButton);
            this.Controls.Add(this.m_folderTextBox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Load Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_folderTextBox;
        private System.Windows.Forms.Button m_folderButton;
        private System.Windows.Forms.TextBox m_outputTextBox;
        private System.Windows.Forms.Button m_loadButton;
        private System.Windows.Forms.Label label2;
    }
}

