namespace Flux.Display {
    partial class DebugForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.btnDestroy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point( 216, 13 );
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size( 90, 23 );
            this.btnDestroy.TabIndex = 0;
            this.btnDestroy.Text = "Destroy Ball";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler( this.btnDestroy_Click );
            // 
            // DebugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 318, 288 );
            this.Controls.Add( this.btnDestroy );
            this.Name = "DebugForm";
            this.Text = "DebugForm";
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.Button btnDestroy;
    }
}