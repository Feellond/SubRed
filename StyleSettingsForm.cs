using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRed
{
    public partial class StyleSettingsForm : Form
    {
        Subtitle sub;
        string styleFormat;
        string style;
        int index;

        public StyleSettingsForm()
        {
            InitializeComponent();
            index = -1;

            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            foreach (FontFamily fFamily in FontFamily.Families)
            {
                fontStyleComboBox.Items.Add(fFamily.Name);
            }
            fontStyleComboBox.Text = "Arial";
            for (int i = 1; i < 100; i++)
            {
                fontSizeDomainUpDown.Items.Add(i);
                intervalDomainUpDown.Items.Add(i);

                contourDomainUpDown.Items.Add(i);
                shadowDomainUpDown.Items.Add(i);

                intervalDomainUpDown.Items.Add(i);
            }
            for (int i = 0; i < 1000; i++)
            {
                rotationDomainUpDown.Items.Add(i);

                leftDomainUpDown.Items.Add(i);
                rightDomainUpDown.Items.Add(i);
                vertDomainUpDown.Items.Add(i);

                scalexDomainUpDown.Items.Add(i);
                scaleyDomainUpDown.Items.Add(i);

            }

            for (int i = 0; i < 360; i++)
            {
                rotationDomainUpDown.Items.Add(i);
            }

            fontStyleComboBox.SelectedIndex = fontStyleComboBox.Items.IndexOf("Arial");
            if (fontSizeDomainUpDown.Text == "")
                fontSizeDomainUpDown.Text = "24";


            intervalDomainUpDown.Text = "0";

            PreviewLoad();
        }

        public string spaced(string text, int spacing)
        {
            char space = (char)0x200a;
            string spaces = "".PadLeft(spacing, space);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++) sb.Append(text[i] + spaces);
            return sb.ToString().Trim(space);
        }

        public void PreviewLoad()
        {
            pictureBox1.Controls.Clear();

            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp.SetResolution(bmp.HorizontalResolution * Convert.ToInt32(scalexDomainUpDown.Text) / 100, bmp.VerticalResolution * Convert.ToInt32(scaleyDomainUpDown.Text) / 100);

            using (Graphics gfx = Graphics.FromImage(bmp))
            using (SolidBrush brush = new SolidBrush(sampleBackgroundButton.BackColor))
            {
                gfx.FillRectangle(brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }

            Graphics g2 = Graphics.FromImage(bmp);

            g2.SmoothingMode = SmoothingMode.AntiAlias;
            g2.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g2.PixelOffsetMode = PixelOffsetMode.HighQuality;


            string[] textSplit = sampleTextBox.Text.Remove(sampleTextBox.Text.IndexOf("\\n") + 1, 1).Split('\\');
            PictureBox picBox = new PictureBox();
            picBox.Height = pictureBox1.Height;
            picBox.Width = pictureBox1.Width;
            picBox.CreateGraphics();
            int longestStr = 0;
            for (int i = 0; i < textSplit.Length; i++)
                if (textSplit[i].Length > textSplit[longestStr].Length)
                    longestStr = i;

            Font font = new Font(
                   new FontFamily(fontStyleComboBox.Text),
                   Convert.ToInt32(fontSizeDomainUpDown.Text),
                   boldCheckBox.Checked ? FontStyle.Bold : FontStyle.Regular
                   );

            font = new Font(font, cursiveCheckBox.Checked ? font.Style ^ FontStyle.Italic : font.Style);
            font = new Font(font, underlineCheckBox.Checked ? font.Style ^ FontStyle.Underline : font.Style);
            font = new Font(font, crossCheckBox.Checked ? font.Style ^ FontStyle.Strikeout : font.Style);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;

            for (int i = 0; i < textSplit.Length; i++)
            {
                Point p = new Point();
                p.X = pictureBox1.Width / 2;
                p.Y = Convert.ToInt32((i * font.Size + 10) + pictureBox1.Height / 4);



                //рисуем тень
                Point pShadow = new Point(p.X + Convert.ToInt32(shadowDomainUpDown.Text), p.Y + Convert.ToInt32(shadowDomainUpDown.Text));
                GraphicsPath gPath = new GraphicsPath();
                gPath.AddString(
                    spaced(textSplit[i], Convert.ToInt32(intervalDomainUpDown.Text)),             // text to draw
                    font.FontFamily,  // or any other font family
                    (int)font.Style,      // font style (bold, italic, etc.)
                    g2.DpiY * Convert.ToInt32(fontSizeDomainUpDown.Text) / 72,       // em size
                    pShadow,              // location where to draw text
                    format);          // set options here (e.g. center alignment)
                System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(shadowButton.BackColor); //заполнение цветом
                g2.FillPath(brush, gPath);

                g2.Flush();
                g2.DrawImage(bmp, new Point(0, 0));

                // рисуем контур
                gPath.Reset();
                gPath.AddString(
                    spaced(textSplit[i], Convert.ToInt32(intervalDomainUpDown.Text)),             // text to draw
                    font.FontFamily,  // or any other font family
                    (int)font.Style,      // font style (bold, italic, etc.)
                    g2.DpiY * Convert.ToInt32(fontSizeDomainUpDown.Text) / 72,       // em size
                    p,              // location where to draw text
                    format);          // set options here (e.g. center alignment)

                System.Drawing.Pen pen = new System.Drawing.Pen(contourButton.BackColor, (float)Convert.ToDouble(contourDomainUpDown.Text.Replace(".", ",")));  //обводка
                g2.DrawPath(pen, gPath);

                g2.Flush();

                // рисуем текст
                // assuming g is the Graphics object on which you want to draw the text
                gPath.Reset();
                gPath.AddString(
                    spaced(textSplit[i], Convert.ToInt32(intervalDomainUpDown.Text)),             // text to draw
                    font.FontFamily,  // or any other font family
                    (int)font.Style,      // font style (bold, italic, etc.)
                    g2.DpiY * Convert.ToInt32(fontSizeDomainUpDown.Text) / 72,       // em size
                    p,              // location where to draw text
                    format);          // set options here (e.g. center alignment)


                brush = new System.Drawing.SolidBrush(firstButton.BackColor); //заполнение цветом
                g2.FillPath(brush, gPath);

                //System.Drawing.Pen pen = new System.Drawing.Pen(contourButton.BackColor, Convert.ToInt32(contourDomainUpDown.Text));  //обводка
                //g2.DrawPath(pen, gPath);

                g2.Flush();

                int angle = Convert.ToInt32(rotationDomainUpDown.Text);
                //move rotation point to center of image
                g2.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                //rotate
                g2.RotateTransform(angle);
                //move image back
                g2.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
                //draw passed in image onto graphics object

                g2.DrawImage(bmp, new Point(0, 0));

                picBox.Image = bmp;
            }

            //Point point = new Point(pictureBox1.Width / 4, pictureBox1.Height / 2); // размещение на основном Picturebox
            //picBox.Location = point;


            pictureBox1.Controls.Add(picBox);
        }

        public void LoadForm(Subtitle sub)
        {
            this.sub = sub;
        }

        public void LoadForm(string styleFromList, string styleFormat, int index, Subtitle sub)
        {
            this.index = index;
            this.styleFormat = styleFormat;
            this.style = styleFromList;
            this.sub = sub;

            string[] styleFormatSplit = styleFormat.Split(',');
            string[] style = styleFromList.Split(',');
            int num;
            foreach (string format in styleFormatSplit)
            {
                switch (format)
                {
                    case "Name":
                        nameTextBox.Text = style[0];
                        break;
                    case "Fontname":
                        fontStyleComboBox.SelectedIndex = fontStyleComboBox.Items.IndexOf(style[1]);
                        break;
                    case "Fontsize":
                        fontSizeDomainUpDown.Text = style[2];
                        break;
                    case "PrimaryColour":
                        firstButton.BackColor = ColorTranslator.FromHtml(style[3].Replace("&H00", "").Insert(0, "#"));
                        break;
                    case "SecondaryColour":
                        secondButton.BackColor = ColorTranslator.FromHtml(style[4].Replace("&H00", "").Insert(0, "#"));
                        break;
                    case "OutlineColour":
                        contourButton.BackColor = ColorTranslator.FromHtml(style[5].Replace("&H00", "").Insert(0, "#"));
                        break;
                    case "BackColour":
                        shadowButton.BackColor = ColorTranslator.FromHtml(style[6].Replace("&H00", "").Insert(0, "#"));
                        break;
                    case "Bold":
                        num = Convert.ToInt32(style[7]);
                        if (num == 1) boldCheckBox.Checked = true;
                        else boldCheckBox.Checked = false;
                        break;
                    case "Italic":
                        num = Convert.ToInt32(style[8]);
                        if (num == 1) cursiveCheckBox.Checked = true;
                        else cursiveCheckBox.Checked = false;
                        break;
                    case "Underline":
                        num = Convert.ToInt32(style[9]);
                        if (num == 1) underlineCheckBox.Checked = true;
                        else underlineCheckBox.Checked = false;
                        break;
                    case "StrikeOut":
                        num = Convert.ToInt32(style[10]);
                        if (num == 1) crossCheckBox.Checked = true;
                        else crossCheckBox.Checked = false;
                        break;
                    case "ScaleX":
                        scalexDomainUpDown.Text = style[11];
                        break;
                    case "ScaleY":
                        scaleyDomainUpDown.Text = style[12];
                        break;
                    case "Spacing":
                        intervalDomainUpDown.Text = style[13];
                        break;
                    case "Angle":
                        rotationDomainUpDown.Text = style[14];
                        break;
                    case "BorderStyle":
                        break;
                    case "Outline":
                        contourDomainUpDown.Text = style[16];
                        break;
                    case "Shadow":
                        shadowDomainUpDown.Text = style[17];
                        break;
                    case "Alignment":
                        /*if (style[18] == "1") radioButton1.Checked = true;
                        else if (style[18] == "2") radioButton2.Checked = true;
                        else if (style[18] == "3") radioButton3.Checked = true;
                        else if (style[18] == "5") radioButton4.Checked = true;
                        else if (style[18] == "6") radioButton5.Checked = true;
                        else if (style[18] == "7") radioButton6.Checked = true;
                        else if (style[18] == "9") radioButton7.Checked = true;
                        else if (style[18] == "10") radioButton8.Checked = true;
                        else if (style[18] == "11") radioButton9.Checked = true;*/
                        radioButton8.Checked = true;
                        break;
                    case "MarginL":
                        leftDomainUpDown.Text = style[19];
                        break;
                    case "MarginR":
                        rightDomainUpDown.Text = style[20];
                        break;
                    case "MarginV":
                        vertDomainUpDown.Text = style[21];
                        break;
                }
            }
            /*
             * styleFormat = "Name,Fontname,Fontsize,PrimaryColour,SecondaryColour," +
                    "OutlineColour,BackColour,Bold,Italic,Underline,StrikeOut,ScaleX," +
                    "ScaleY,Spacing,Angle,BorderStyle,Outline,Shadow Alignment," +
                    "MarginL,MarginR,MarginV,AlphaLevel,Encoding";
             */
        }

        private void sampleBackgroundButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
            PreviewLoad();
        }

        private void sampleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (sampleTextBox.Text != "")
                PreviewLoad();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            styleFormat = "Name,Fontname,Fontsize,PrimaryColour,SecondaryColour," +
                    "OutlineColor,BackColour,Bold,Italic,Underline,StrikeOut,ScaleX," +
                    "ScaleY,Spacing,Angle,BorderStyle,Outline,Shadow,Alignment," +
                    "MarginL,MarginR,MarginV,AlphaLevel,Encoding";

            string newStyle = "";
            if (style != null && style != "")
            {
                newStyle = style;
            }
            else
            {
                newStyle = ",,,,,,,,,,,,,,,,,,,,,,,";
            }

            string[] newStyleSplit = newStyle.Split(',');
            newStyleSplit[0] = nameTextBox.Text;
            newStyleSplit[1] = fontStyleComboBox.Text;
            newStyleSplit[2] = fontSizeDomainUpDown.Text;
            newStyleSplit[3] = "&H00" + firstButton.BackColor.R.ToString("X2") + firstButton.BackColor.G.ToString("X2") + firstButton.BackColor.B.ToString("X2");
            newStyleSplit[4] = "&H00" + secondButton.BackColor.R.ToString("X2") + secondButton.BackColor.G.ToString("X2") + secondButton.BackColor.B.ToString("X2");
            newStyleSplit[5] = "&H00" + contourButton.BackColor.R.ToString("X2") + contourButton.BackColor.G.ToString("X2") + contourButton.BackColor.B.ToString("X2");
            newStyleSplit[6] = "&H00" + shadowButton.BackColor.R.ToString("X2") + shadowButton.BackColor.G.ToString("X2") + shadowButton.BackColor.B.ToString("X2");
            newStyleSplit[7] = boldCheckBox.Checked ? "1" : "0";
            newStyleSplit[8] = cursiveCheckBox.Checked ? "1" : "0";
            newStyleSplit[9] = underlineCheckBox.Checked ? "1" : "0";
            newStyleSplit[10] = crossCheckBox.Checked ? "1" : "0";
            newStyleSplit[11] = scalexDomainUpDown.Text;
            newStyleSplit[12] = scaleyDomainUpDown.Text;
            newStyleSplit[13] = intervalDomainUpDown.Text;
            newStyleSplit[14] = rotationDomainUpDown.Text;
            newStyleSplit[15] = "1";
            newStyleSplit[16] = contourDomainUpDown.Text;
            newStyleSplit[17] = shadowDomainUpDown.Text;

            int num = 2;
            if (radioButton1.Checked)       num = 5;
            else if (radioButton2.Checked)  num = 6;
            else if (radioButton3.Checked)  num = 7;

            else if (radioButton4.Checked)  num = 9;
            else if (radioButton5.Checked)  num = 10;
            else if (radioButton6.Checked)  num = 11;

            else if (radioButton7.Checked)  num = 1;
            else if (radioButton8.Checked)  num = 2;
            else if (radioButton9.Checked)  num = 3;
            newStyleSplit[18] = num.ToString();
            newStyleSplit[19] = leftDomainUpDown.Text;
            newStyleSplit[20] = rightDomainUpDown.Text;
            newStyleSplit[21] = vertDomainUpDown.Text;
            newStyleSplit[22] = "0";
            newStyleSplit[23] = "0";


            sub.stylesFormat = styleFormat;
            if (index != -1)
            {
                sub.style.RemoveAt(index);
                sub.style.Insert(index, string.Join(",", newStyleSplit));
            }
            else
            {
                sub.style.Add(string.Join(",", newStyleSplit));
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void shadowDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (shadowDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void contourDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (contourDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void scalexDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (scalexDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void scaleyDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (scaleyDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void rotationDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (rotationDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void intervalDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (intervalDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void shadowButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = shadowButton.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                shadowButton.BackColor = colorDialog1.Color;
            }
            PreviewLoad();
        }

        private void contourButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = contourButton.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                contourButton.BackColor = colorDialog1.Color;
            }
            PreviewLoad();
        }

        private void secondButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = secondButton.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                secondButton.BackColor = colorDialog1.Color;
            }
            PreviewLoad();
        }

        private void firstButton_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = firstButton.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                firstButton.BackColor = colorDialog1.Color;
            }

            PreviewLoad();
        }

        private void crossCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreviewLoad();
        }

        private void underlineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreviewLoad();
        }

        private void cursiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreviewLoad();
        }

        private void boldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PreviewLoad();
        }

        private void fontSizeDomainUpDown_SelectedItemChanged(object sender, EventArgs e)
        {
            if (fontSizeDomainUpDown.Text != "")
                PreviewLoad();
        }

        private void fontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fontStyleComboBox.Text != "")
                PreviewLoad();
        }

        private void StyleSettingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
