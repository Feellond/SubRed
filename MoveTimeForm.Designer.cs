namespace SubRed
{
    partial class MoveTimeForm
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
            this.allButton = new System.Windows.Forms.Button();
            this.milliTextBox = new System.Windows.Forms.TextBox();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.hoursTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // allButton
            // 
            this.allButton.Location = new System.Drawing.Point(135, 173);
            this.allButton.Name = "allButton";
            this.allButton.Size = new System.Drawing.Size(80, 34);
            this.allButton.TabIndex = 25;
            this.allButton.Text = "Все";
            this.allButton.UseVisualStyleBackColor = true;
            this.allButton.Click += new System.EventHandler(this.allButton_Click);
            // 
            // milliTextBox
            // 
            this.milliTextBox.Location = new System.Drawing.Point(89, 134);
            this.milliTextBox.Name = "milliTextBox";
            this.milliTextBox.Size = new System.Drawing.Size(53, 20);
            this.milliTextBox.TabIndex = 24;
            this.milliTextBox.Text = "0";
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.Location = new System.Drawing.Point(89, 103);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.Size = new System.Drawing.Size(53, 20);
            this.secondsTextBox.TabIndex = 23;
            this.secondsTextBox.Text = "5";
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(89, 72);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(53, 20);
            this.minutesTextBox.TabIndex = 22;
            this.minutesTextBox.Text = "0";
            // 
            // hoursTextBox
            // 
            this.hoursTextBox.Location = new System.Drawing.Point(89, 41);
            this.hoursTextBox.Name = "hoursTextBox";
            this.hoursTextBox.Size = new System.Drawing.Size(53, 20);
            this.hoursTextBox.TabIndex = 21;
            this.hoursTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Миллисекунды";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Секунды";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Минуты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Часы";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Прибавить",
            "Отнять"});
            this.comboBox1.Location = new System.Drawing.Point(89, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.Text = "Прибавить";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Сместить на";
            // 
            // selectedButton
            // 
            this.selectedButton.Location = new System.Drawing.Point(8, 173);
            this.selectedButton.Name = "selectedButton";
            this.selectedButton.Size = new System.Drawing.Size(80, 34);
            this.selectedButton.TabIndex = 14;
            this.selectedButton.Text = "Выделенные";
            this.selectedButton.UseVisualStyleBackColor = true;
            this.selectedButton.Click += new System.EventHandler(this.selectedButton_Click);
            // 
            // MoveTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 222);
            this.Controls.Add(this.allButton);
            this.Controls.Add(this.milliTextBox);
            this.Controls.Add(this.secondsTextBox);
            this.Controls.Add(this.minutesTextBox);
            this.Controls.Add(this.hoursTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectedButton);
            this.Name = "MoveTimeForm";
            this.Text = "Сместить время";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button allButton;
        private System.Windows.Forms.TextBox milliTextBox;
        private System.Windows.Forms.TextBox secondsTextBox;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.TextBox hoursTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectedButton;
    }
}