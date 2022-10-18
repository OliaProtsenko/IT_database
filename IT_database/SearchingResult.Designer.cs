
namespace IT_database
{
    partial class SearchingResult
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
            this.searchingResultView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.searchingResultView)).BeginInit();
            this.SuspendLayout();
            // 
            // searchingResultView
            // 
            this.searchingResultView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchingResultView.Location = new System.Drawing.Point(0, 0);
            this.searchingResultView.Name = "searchingResultView";
            this.searchingResultView.RowHeadersWidth = 51;
            this.searchingResultView.RowTemplate.Height = 24;
            this.searchingResultView.Size = new System.Drawing.Size(800, 455);
            this.searchingResultView.TabIndex = 0;
            // 
            // SearchingResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchingResultView);
            this.Name = "SearchingResult";
            this.Text = "SearchingResult";
            ((System.ComponentModel.ISupportInitialize)(this.searchingResultView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView searchingResultView;
    }
}