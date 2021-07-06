using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRed
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private double x1_h;
        private double x2_w;

        private bool isOpenVideo;
        Subtitle pBase;
        Sub_formats.SubFormats sf;
        DataGridView table;
        string filepath;
        bool isMultipleFiles;

        private void button1_Click(object sender, EventArgs e)
        {
            if (isOpenVideo)
            {
                DialogResult result;
                result = MessageBox.Show("Подстроить разрешение под видео?", "Подтверждение изменения", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        resize(x1_h / Convert.ToDouble(pBase.playResX), x2_w / Convert.ToDouble(pBase.playResY), this.pBase, this.isMultipleFiles);

                        heightTextBox.Text = x1_h.ToString();
                        widthTextBox.Text = x2_w.ToString();

                        if (filepath != null && filepath != "")
                        {
                            string[] splitStr = filepath.Split('.');
                            sf.SelectFormat(filepath, pBase.getSubtitlesString(), false);
                        }
                    }
                    catch { }
                }
            }
        }

        public void LoadSettings(Subtitle pBase, double x1_reader_h, double x2_reader_w, DataGridView dGrid, bool isOpenVideo, string filepath, bool tf)
        {
            x1_h = x1_reader_h; x2_w = x2_reader_w;
            table = dGrid;

            this.isOpenVideo = isOpenVideo;
            this.pBase = pBase;
            this.filepath = filepath;
            this.isMultipleFiles = tf;

            nameTextBox.Text = pBase.title;
            scriptTypeTextBox.Text = pBase.originalScript;
            originalTranslationTextBox.Text = pBase.originalTranslation;
            scriptTypeTextBox.Text = pBase.scriptType;
            collisionTextBox.Text = pBase.collisions;
            timerTextBox.Text = pBase.timer;
            syncTextBox.Text = pBase.syncPoint;

            if (pBase.playResX != "" || pBase.playResX != null) widthTextBox.Text = pBase.playResX;
            if (pBase.playResY != "" || pBase.playResY != null) heightTextBox.Text = pBase.playResY;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resize(Convert.ToDouble(widthTextBox.Text) / Convert.ToDouble(pBase.playResX),
                Convert.ToDouble(heightTextBox.Text) / Convert.ToDouble(pBase.playResY),
                this.pBase, this.isMultipleFiles);

            string[] splitStr = filepath.Split('.');
            sf.SelectFormat(filepath, pBase.getSubtitlesString(), false); 
        }

        public void resize(double w_mult, double h_mult, Subtitle pBase, bool isMultipleFiles)
        {
            string str = "";
            int index, startIndex;
            if (!isMultipleFiles)
            {
                for (int i = 0; i < table.RowCount; i++)
                {

                    if (table.Rows[i].Cells[10].Value != null)
                    {
                        str = table.Rows[i].Cells[10].Value.ToString(); //проход по всем текстам таблицы
                        index = 0; startIndex = 0;
                        do
                        {
                            index = str.IndexOf("\\fs", startIndex);    //нахождение первого вхождения размера шрифта
                            if (index != -1)
                            {
                                for (int j = index + 3; j < str.Length; j++)
                                {
                                    if (str[j] == '\\' || str[j] == '}')
                                    {
                                        int number = Convert.ToInt32(str.Substring(index + 3, j - index - 3));
                                        number = Convert.ToInt32(Convert.ToDouble(number) * h_mult);           //вычисление значения

                                        string fontSizeChange = "\\fs" + number.ToString();
                                        str = str.Remove(index, j - index);
                                        str = str.Insert(index, fontSizeChange); //замена размера шрифта

                                        startIndex = index + fontSizeChange.Length; //индекс начала следующего поиска размера шрифта
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                index = str.IndexOf("\\pos(", startIndex);
                                if (index != -1)
                                {
                                    for (int j = index + 5; j < str.Length; j++)
                                    {
                                        if (str[j] == '\\' || str[j] == '}')
                                        {
                                            try
                                            {
                                                string subNumbers = str.Substring(index + 5, j - index - 5);
                                                string[] splitNumbers = subNumbers.Split(',');
                                                int number1 = Convert.ToInt32(splitNumbers[0]);
                                                int number2 = Convert.ToInt32(splitNumbers[1]);

                                                number1 = Convert.ToInt32(Convert.ToDouble(number1) * (h_mult));           //вычисление значения
                                                number2 = Convert.ToInt32(Convert.ToDouble(number2) * (h_mult));

                                                string fontSizeChange = "\\pos(" + number1.ToString() + "," + number2.ToString() + ")";
                                                str = str.Remove(index, j - index);
                                                str = str.Insert(index, fontSizeChange); //замена размера шрифта


                                                startIndex = index + fontSizeChange.Length; //индекс начала следующего поиска размера шрифта
                                                break;
                                            }
                                            catch
                                            {
                                                startIndex = index + 1;
                                            }
                                        }
                                    }
                                }
                            }
                        } while (startIndex < str.Length && index != -1);

                        table.Rows[i].Cells[10].Value = str;
                    }
                }
            }

            string[] textMassive = pBase.TextFormat.Split(',');
            int indexForTextMassive;
            for (indexForTextMassive = 0; indexForTextMassive < textMassive.Count(); indexForTextMassive++)  // поиск элемента с Text
            {
                if (textMassive[indexForTextMassive].Trim() == "Text")
                    break;
            }

            if (indexForTextMassive >= textMassive.Count())
                indexForTextMassive = -1;

            if (indexForTextMassive != -1)
            {
                int textListIndex = 0;
                List<string> listText = new List<string>(pBase.text);
                foreach (string text in listText)
                {
                    textMassive = text.Split(',');
                    str = textMassive[indexForTextMassive];
                    index = 0; startIndex = 0;
                    do
                    {
                        index = str.IndexOf("\\fs", startIndex);    //нахождение первого вхождения размера шрифта
                        if (index != -1)
                        {
                            for (int j = index + 3; j < str.Length; j++)
                            {
                                if (str[j] == '\\' || str[j] == '}')
                                {
                                    int number = Convert.ToInt32(str.Substring(index + 3, j - index - 3));
                                    number = Convert.ToInt32(Convert.ToDouble(number) * (h_mult));           //вычисление значения

                                    string fontSizeChange = "\\fs" + number.ToString();
                                    str = str.Remove(index, j - index);
                                    str = str.Insert(index, fontSizeChange); //замена размера шрифта

                                    startIndex = index + fontSizeChange.Length; //индекс начала следующего поиска размера шрифта
                                    break;
                                }
                            }
                        }
                    } while (startIndex < str.Length && index != -1);

                    textMassive[indexForTextMassive] = str;

                    pBase.text.RemoveAt(textListIndex);
                    pBase.text.Insert(textListIndex, string.Join(",", textMassive));

                    textListIndex++;
                }
            }

            string[] styleMassive = pBase.stylesFormat.Split(',');
            int[] countMassive = new int[6];
            for (int i = 0; i < countMassive.Length; i++)
                countMassive[i] = -1;

            for (index = 0; index < styleMassive.Count(); index++)  // поиск элемента с Fontsize
            {
                if (styleMassive[index].Trim() == "Fontsize")
                    countMassive[0] = index;
                else if (styleMassive[index].Trim() == "MarginL")
                    countMassive[1] = index;
                else if (styleMassive[index].Trim() == "MarginR")
                    countMassive[2] = index;
                else if (styleMassive[index].Trim() == "MarginV")
                    countMassive[3] = index;
                else if (styleMassive[index].Trim() == "ScaleX")
                    countMassive[4] = index;
                else if (styleMassive[index].Trim() == "ScaleY")
                    countMassive[5] = index;
            }

            int styleIndex = 0;
            List<string> list = new List<string>(pBase.style);
            foreach (string style in list)
            {
                styleMassive = style.Split(',');

                if (countMassive[0] != -1)
                    styleMassive[countMassive[0]] = (Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[0]]) * h_mult)).ToString(); // умножение числа и запись обратно
                if (countMassive[1] != -1)
                    styleMassive[countMassive[1]] = Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[1]]) * w_mult).ToString();
                if (countMassive[2] != -1)
                    styleMassive[countMassive[2]] = Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[2]]) * w_mult).ToString();
                if (countMassive[3] != -1)
                    styleMassive[countMassive[3]] = Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[3]]) * w_mult).ToString();
                if (countMassive[4] != -1)
                {
                    double max1 = w_mult / h_mult;
                    double max2 = h_mult / w_mult;
                    if (max1 < max2)
                        max1 = max2;
                    styleMassive[countMassive[4]] = Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[4]]) * max1).ToString();
                }
                if (countMassive[5] != -1)
                {
                    double max1 = (w_mult) / (h_mult);
                    double max2 = (h_mult) / (w_mult);
                    if (max1 < max2)
                        max1 = max2;
                    styleMassive[countMassive[5]] = Convert.ToInt32(Convert.ToDouble(styleMassive[countMassive[5]]) * (max1)).ToString();
                }


                pBase.style.RemoveAt(styleIndex);
                pBase.style.Insert(styleIndex, string.Join(",", styleMassive));
                styleIndex++;
            }

            pBase.playResX = widthTextBox.Text;
            pBase.playResY = heightTextBox.Text;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            pBase.title = nameTextBox.Text;
            pBase.originalScript = scriptTypeTextBox.Text;
            pBase.originalTranslation = originalTranslationTextBox.Text;
            pBase.scriptType = scriptTypeTextBox.Text;
            pBase.collisions = collisionTextBox.Text;
            pBase.timer = timerTextBox.Text;
            pBase.syncPoint = syncTextBox.Text;
            this.Close();
        }

        public void hideButton(string filename)
        {
            button3.Visible = false;
            this.isMultipleFiles = true;
            filenameLabel.Text = "Filename: " + filename;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                List<Subtitle> subsList = new List<Subtitle>();
                //List<PluginBase> pListBase = new List<PluginBase>();
                foreach (string filename in openFileDialog1.FileNames)
                {
                    Subtitle sub = new Subtitle();
                    sub.setSubtitleString(sf.SelectFormat(filename, "", true));

                    subsList.Add(sub);
                    //pListBase.Add(pBase);
                }

                ResizeGridForm rgForm = new ResizeGridForm();
                rgForm.LoadForm(subsList, openFileDialog1.FileNames, x2_w, x1_h);
                rgForm.ShowDialog();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            sf = new Sub_formats.SubFormats();
        }
    }
}
