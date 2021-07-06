namespace SubRed
{
    partial class SettingsForm
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
            this.filenameLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.xLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.originalScriptTextBox = new System.Windows.Forms.TextBox();
            this.syncTextBox = new System.Windows.Forms.TextBox();
            this.originalTranslationTextBox = new System.Windows.Forms.TextBox();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.scriptTypeTextBox = new System.Windows.Forms.TextBox();
            this.collisionTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Location = new System.Drawing.Point(19, 308);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(0, 13);
            this.filenameLabel.TabIndex = 17;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(309, 308);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(390, 308);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.xLabel);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.heightTextBox);
            this.groupBox2.Controls.Add(this.widthTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(453, 79);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Разрешение";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(131, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Файлы";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(7, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(113, 27);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(12, 13);
            this.xLabel.TabIndex = 3;
            this.xLabel.Text = "x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(372, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Из видео";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(131, 20);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(100, 20);
            this.heightTextBox.TabIndex = 1;
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(7, 20);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(100, 20);
            this.widthTextBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.originalScriptTextBox);
            this.groupBox1.Controls.Add(this.syncTextBox);
            this.groupBox1.Controls.Add(this.originalTranslationTextBox);
            this.groupBox1.Controls.Add(this.timerTextBox);
            this.groupBox1.Controls.Add(this.scriptTypeTextBox);
            this.groupBox1.Controls.Add(this.collisionTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 205);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Свойства";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Точка синхронизации";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Таймер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Коллизия";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Тип скрипта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Оригинальный перевод";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Оригинальный скрипт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Наименование";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(202, 19);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(245, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // originalScriptTextBox
            // 
            this.originalScriptTextBox.Location = new System.Drawing.Point(202, 45);
            this.originalScriptTextBox.Name = "originalScriptTextBox";
            this.originalScriptTextBox.Size = new System.Drawing.Size(245, 20);
            this.originalScriptTextBox.TabIndex = 1;
            // 
            // syncTextBox
            // 
            this.syncTextBox.Location = new System.Drawing.Point(202, 175);
            this.syncTextBox.Name = "syncTextBox";
            this.syncTextBox.Size = new System.Drawing.Size(245, 20);
            this.syncTextBox.TabIndex = 6;
            // 
            // originalTranslationTextBox
            // 
            this.originalTranslationTextBox.Location = new System.Drawing.Point(202, 71);
            this.originalTranslationTextBox.Name = "originalTranslationTextBox";
            this.originalTranslationTextBox.Size = new System.Drawing.Size(245, 20);
            this.originalTranslationTextBox.TabIndex = 2;
            // 
            // timerTextBox
            // 
            this.timerTextBox.Location = new System.Drawing.Point(202, 149);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.Size = new System.Drawing.Size(245, 20);
            this.timerTextBox.TabIndex = 5;
            // 
            // scriptTypeTextBox
            // 
            this.scriptTypeTextBox.Location = new System.Drawing.Point(202, 97);
            this.scriptTypeTextBox.Name = "scriptTypeTextBox";
            this.scriptTypeTextBox.Size = new System.Drawing.Size(245, 20);
            this.scriptTypeTextBox.TabIndex = 3;
            // 
            // collisionTextBox
            // 
            this.collisionTextBox.Location = new System.Drawing.Point(202, 123);
            this.collisionTextBox.Name = "collisionTextBox";
            this.collisionTextBox.Size = new System.Drawing.Size(245, 20);
            this.collisionTextBox.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 338);
            this.Controls.Add(this.filenameLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsForm";
            this.Text = "Свойства файла";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox originalScriptTextBox;
        private System.Windows.Forms.TextBox syncTextBox;
        private System.Windows.Forms.TextBox originalTranslationTextBox;
        private System.Windows.Forms.TextBox timerTextBox;
        private System.Windows.Forms.TextBox scriptTypeTextBox;
        private System.Windows.Forms.TextBox collisionTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}