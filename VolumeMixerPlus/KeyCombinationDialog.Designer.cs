namespace VolumeMixerPlus
{
    partial class KeyCombinationDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyCombinationDialog));
            this._acceptButton = new System.Windows.Forms.Button();
            this._keyCombinationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _acceptButton
            // 
            this._acceptButton.Location = new System.Drawing.Point(160, 46);
            this._acceptButton.Name = "_acceptButton";
            this._acceptButton.Size = new System.Drawing.Size(75, 23);
            this._acceptButton.TabIndex = 0;
            this._acceptButton.Text = "Accept";
            this._acceptButton.UseVisualStyleBackColor = true;
            this._acceptButton.Click += new System.EventHandler(this._acceptButton_Click);
            // 
            // _keyCombinationLabel
            // 
            this._keyCombinationLabel.AutoSize = true;
            this._keyCombinationLabel.Location = new System.Drawing.Point(12, 9);
            this._keyCombinationLabel.Name = "_keyCombinationLabel";
            this._keyCombinationLabel.Size = new System.Drawing.Size(10, 13);
            this._keyCombinationLabel.TabIndex = 1;
            this._keyCombinationLabel.Text = "-";
            // 
            // KeyCombinationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 81);
            this.Controls.Add(this._keyCombinationLabel);
            this.Controls.Add(this._acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeyCombinationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setup key combination";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyCombinationDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _acceptButton;
        private System.Windows.Forms.Label _keyCombinationLabel;
    }
}