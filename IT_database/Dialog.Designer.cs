
namespace IT_database
{
    partial class Dialog
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
            this.ofdOpenDB = new System.Windows.Forms.OpenFileDialog();
            this.messageLabel = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofdOpenDB
            // 
            this.ofdOpenDB.Filter = "TXT files|*.txt|All files|*.*";
            this.ofdOpenDB.InitialDirectory = "C:\\";
            this.ofdOpenDB.RestoreDirectory = true;
            // 
            // messageLabel
            // 
            this.messageLabel.Location = new System.Drawing.Point(12, 52);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(100, 23);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Message";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(160, 52);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 22);
            this.textBox.TabIndex = 1;
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(160, 140);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(62, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Visible = false;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Path (import data)";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Enabled = false;
            this.path.Visible = false;
            this.path.Location = new System.Drawing.Point(166, 99);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(81, 17);
            this.path.TabIndex = 4;
            this.path.Text = "not obvious";
            // 
            // selectPathButton
            // 
            this.selectPathButton.Enabled = false;
            this.selectPathButton.Visible = false;
            this.selectPathButton.Location = new System.Drawing.Point(307, 96);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(75, 23);
            this.selectPathButton.TabIndex = 5;
            this.selectPathButton.Text = "Select path";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 191);
            this.Controls.Add(this.selectPathButton);
            this.Controls.Add(this.path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.messageLabel);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog ofdOpenDB;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Button selectPathButton;
    }
}