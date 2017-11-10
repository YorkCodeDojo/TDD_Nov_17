namespace WordChainsUI
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.cmdDepth = new System.Windows.Forms.Button();
            this.cmdBreadth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(97, 31);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(199, 29);
            this.txtFrom.TabIndex = 1;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(389, 31);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(199, 29);
            this.txtTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "To";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(31, 80);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(109, 21);
            this.lblAnswer.TabIndex = 4;
            this.lblAnswer.Text = "Press a button";
            // 
            // cmdDepth
            // 
            this.cmdDepth.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdDepth.Location = new System.Drawing.Point(604, 27);
            this.cmdDepth.Name = "cmdDepth";
            this.cmdDepth.Size = new System.Drawing.Size(88, 34);
            this.cmdDepth.TabIndex = 5;
            this.cmdDepth.Text = "Depth";
            this.cmdDepth.UseVisualStyleBackColor = true;
            this.cmdDepth.Click += new System.EventHandler(this.cmdGo_Click);
            // 
            // cmdBreadth
            // 
            this.cmdBreadth.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdBreadth.Location = new System.Drawing.Point(712, 26);
            this.cmdBreadth.Name = "cmdBreadth";
            this.cmdBreadth.Size = new System.Drawing.Size(88, 34);
            this.cmdBreadth.TabIndex = 6;
            this.cmdBreadth.Text = "Breadth";
            this.cmdBreadth.UseVisualStyleBackColor = true;
            this.cmdBreadth.Click += new System.EventHandler(this.cmdBreadth_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.cmdDepth;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 136);
            this.Controls.Add(this.cmdBreadth);
            this.Controls.Add(this.cmdDepth);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Word Chains";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Button cmdDepth;
        private System.Windows.Forms.Button cmdBreadth;
    }
}

