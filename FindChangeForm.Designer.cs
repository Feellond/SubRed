namespace SubRed
{
    partial class FindChangeForm
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
            this.changeAllButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.changeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // changeAllButton
            // 
            this.changeAllButton.Location = new System.Drawing.Point(339, 39);
            this.changeAllButton.Name = "changeAllButton";
            this.changeAllButton.Size = new System.Drawing.Size(89, 23);
            this.changeAllButton.TabIndex = 13;
            this.changeAllButton.Text = "Заменить все";
            this.changeAllButton.UseVisualStyleBackColor = true;
            this.changeAllButton.Click += new System.EventHandler(this.changeAllButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(258, 39);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 12;
            this.changeButton.Text = "Заменить";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // changeTextBox
            // 
            this.changeTextBox.Location = new System.Drawing.Point(88, 41);
            this.changeTextBox.Name = "changeTextBox";
            this.changeTextBox.Size = new System.Drawing.Size(164, 20);
            this.changeTextBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Заменить на";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(224, 10);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 9;
            this.nextButton.Text = "Следующий";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // findTextBox
            // 
            this.findTextBox.Location = new System.Drawing.Point(54, 12);
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(164, 20);
            this.findTextBox.TabIndex = 8;
            this.findTextBox.TextChanged += new System.EventHandler(this.findTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Найти";
            // 
            // FindChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 73);
            this.Controls.Add(this.changeAllButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.changeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.findTextBox);
            this.Controls.Add(this.label1);
            this.Name = "FindChangeForm";
            this.Text = "Найти и заменить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button changeAllButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.TextBox changeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.TextBox findTextBox;
        private System.Windows.Forms.Label label1;
    }
}