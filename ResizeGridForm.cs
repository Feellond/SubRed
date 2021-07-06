using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRed
{
    public partial class ResizeGridForm : Form
    {
        public ResizeGridForm()
        {
            InitializeComponent();
        }

        public void resize(double w_mult, double h_mult, Subtitle pBase)
        {
            string str = "";
            int index, startIndex;

            string[] textMassive = pBase.TextFormat.Split(',');
            int indexForTextMassive;
            for (indexForTextMassive = 0; indexForTextMassive < textMassive.Count(); indexForTextMassive++)  // поиск элемента с Text
            {
                if (textMassive[indexForTextMassive].Trim() == "Text")
                    break;
            }

            if (indexForTextMassive >= textMassive.Count())
                indexForTextMassive = -1;
            progressBar1.Value = 10;

            if (indexForTextMassive != -1)
            {
                int textListIndex = 0;
                List<string> listText = new List<string>(pBase.text);
                foreach (string text in listText)
                {
                    textMassive = text.Split(new char[] { ',' }, textMassive.Count());
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
                                    try
                                    {
                                        int number = Convert.ToInt32(str.Substring(index + 3, j - index - 3));
                                        number = Convert.ToInt32(Convert.ToDouble(number) * (h_mult));           //вычисление значения

                                        string fontSizeChange = "\\fs" + number.ToString();
                                        str = str.Remove(index, j - index);
                                        str = str.Insert(index, fontSizeChange); //замена размера шрифта
                                    

                                    startIndex = index + fontSizeChange.Length; //индекс начала следующего поиска размера шрифта
                                    break;
                                    }
                                    catch {
                                        startIndex = index + 1;
                                    }
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
                                            string subNumbers = str.Substring(index + 5, j - index - 6);
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

                    textMassive[indexForTextMassive] = str;
                    pBase.text.RemoveAt(textListIndex);
                    pBase.text.Insert(textListIndex, string.Join(",", textMassive));

                    textListIndex++;
                }
            }

            progressBar1.Value = 60;

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

            progressBar1.Value = 80;

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

            pBase.playResX = xtextBox.Text;
            pBase.playResY = ytextBox.Text;

            progressBar1.Value = 100;
        }

        List<Subtitle> subsList;
        Sub_formats.SubFormats sf;
        string[] fileNames;
        double xVideoSize, yVideoSize;

        public void LoadForm(List<Subtitle> subsList, string[] files, double xVideoSize, double yVideoSize)
        {
            this.subsList = subsList;
            fileNames = files;

            this.xVideoSize = xVideoSize;
            this.yVideoSize = yVideoSize;

            dataGridView1.Rows.Clear();
            int index = 0;
            foreach (Subtitle sub in subsList)
            {
                dataGridView1.Rows.Add();
                string[] file = fileNames[index].Split('\\');

                dataGridView1.Rows[index].Cells[0].Value = file[file.Length - 1];
                dataGridView1.Rows[index].Cells[2].Value = sub.playResX + "x" + sub.playResY;
                index++;
            }
        }

        public void formShow()
        {
            SettingsForm sForm = new SettingsForm();
            sForm.LoadSettings(subsList[dataGridView1.CurrentRow.Index], xVideoSize, yVideoSize, dataGridView1, true, fileNames[dataGridView1.CurrentRow.Index], true);
            string[] file = fileNames[dataGridView1.CurrentRow.Index].Split('\\');
            sForm.hideButton(file[file.Length - 1]);
            sForm.Show();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            formShow();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            formShow();
        }

        private void ResizeGridForm_Load(object sender, EventArgs e)
        {
            sf = new Sub_formats.SubFormats();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (xtextBox.Text != null && xtextBox.Text != "" && ytextBox.Text != null && ytextBox.Text != "")
            {
                // pListBase.AsParallel().ForAll(delegate (PluginBase pBase)
                //{
                foreach (Subtitle pBase in subsList)
                {
                    progressBar1.Value = 0;
                    resize(Convert.ToDouble(xtextBox.Text) / Convert.ToDouble(pBase.playResX),
                        Convert.ToDouble(ytextBox.Text) / Convert.ToDouble(pBase.playResY),
                        pBase);
                }
                //});

                int i = 0;
                foreach (Subtitle plBase in subsList)
                {
                    string[] splitStr = fileNames[i].Split('.');


                    sf.SelectFormat(fileNames[i], plBase.getSubtitlesString(), false);

                    dataGridView1.Rows[i].Cells[1].Value = "Да";
                    i++;
                }
            }
        }
    }
}
