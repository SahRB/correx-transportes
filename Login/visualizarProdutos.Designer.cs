
namespace Login
{
    partial class visualizarProdutos
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
            this.components = new System.ComponentModel.Container();
            this.correxbdDataSet = new Login.correxbdDataSet();
            this.correxbdDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.correxbdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.correxbdDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // correxbdDataSet
            // 
            this.correxbdDataSet.DataSetName = "correxbdDataSet";
            this.correxbdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // correxbdDataSetBindingSource
            // 
            this.correxbdDataSetBindingSource.DataSource = this.correxbdDataSet;
            this.correxbdDataSetBindingSource.Position = 0;
            // 
            // visualizarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 538);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "visualizarProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "visualizarProdutos";
            ((System.ComponentModel.ISupportInitialize)(this.correxbdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.correxbdDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource correxbdDataSetBindingSource;
        private correxbdDataSet correxbdDataSet;
    }
}