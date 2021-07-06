using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubRed
{
    class EditSubtitleClass
    {
        List<string> editList;
        int currentNum;

        public EditSubtitleClass()
        {
            editList = new List<string>();
            currentNum = 0;
        }

        /// <summary>
        /// Добавление в список
        /// </summary>
        /// <param name="where">Активный контрол</param>
        /// <param name="effect">Действие</param>
        /// <param name="position">Позиция</param>
        /// <param name="phrase">Фраза</param>
        public void EditListAdd(string where, string effect, int position, string phrase)
        {
            editList.Insert(0, where + "&&" + effect + "&&" + position.ToString() + "&&" + phrase);
            //editList.Add(where + "&&" + effect + "&&" + position.ToString() + "&&" + phrase);
            if (currentNum != editList.Count)
            {
                for (int i = editList.Count - 1; i > currentNum; i--)
                {
                    editList.RemoveAt(i);
                }
            }
            currentNum = editList.Count;
            ListRecount();
        }

        /// <summary>
        /// Запускать при нажатии клавиш Ctrl+Z (отменить)
        /// </summary>
        public void Undo(Subtitle sub, TextBox textBox, DataGridView table)
        {
            try
            {
                string[] str = editList[currentNum].Split(new string[] { "&&" }, 4, StringSplitOptions.RemoveEmptyEntries);
                if (str[0] == textBox.Name) // "editedSubTextBox"
                {
                    switch (str[1])
                    {
                        case "Вырезание":
                        case "Удаление":
                            textBox.Text = textBox.Text.Insert(Convert.ToInt32(str[2]), str[3]);
                            break;
                        case "Вставка":
                        case "Ввод":
                            textBox.Text = textBox.Text.Remove(Convert.ToInt32(str[2]), str[3].Length);
                            break;
                    }
                }
                else if (str[0] == table.Name) // "dataGridView1"
                {
                    string[] rowSplit = str[3].Split(new string[] { ":" }, 2, StringSplitOptions.None);
                    string[] cellsSplit = rowSplit[1].Split(new string[] { "," }, StringSplitOptions.None);

                    switch (str[1])
                    {
                        case "Вырезание":
                        case "Удаление":
                            table.Rows.Insert(Convert.ToInt32(str[2]), TableRow(cellsSplit, sub.TextFormat.Split(',')));
                            break;
                        case "Вставка":
                        case "Ввод":
                            table.Rows.RemoveAt(Convert.ToInt32(str[2]));
                            break;
                    }
                }

                currentNum--;
            }
            catch { }
        }

        /// <summary>
        /// Запускать при нажатии клавиш Ctrl+Y (вернуть)
        /// </summary>
        public void Return(Subtitle sub, TextBox textBox, DataGridView table)
        {
            try
            {
                string[] str = editList[currentNum].Split(new string[] { "&&" }, 4, StringSplitOptions.RemoveEmptyEntries);
                if (str[0] == textBox.Name) // "editedSubTextBox"
                {
                    switch (str[1])
                    {
                        case "Вырезание":
                        case "Удаление":
                            textBox.Text = textBox.Text.Remove(Convert.ToInt32(str[2]), str[3].Length);
                            break;
                        case "Вставка":
                        case "Ввод":
                            textBox.Text = textBox.Text.Insert(Convert.ToInt32(str[2]), str[3]);
                            break;
                    }
                }
                else if (str[0] == table.Name) // "dataGridView1"
                {
                    string[] rowSplit = str[3].Split(new string[] { ":" }, 2, StringSplitOptions.None);
                    string[] cellsSplit = rowSplit[1].Split(new string[] { "," }, StringSplitOptions.None);

                    switch (str[1])
                    {
                        case "Вырезание":
                        case "Удаление":
                            table.Rows.RemoveAt(Convert.ToInt32(str[2]));
                            break;
                        case "Вставка":
                        case "Ввод":
                            table.Rows.Insert(Convert.ToInt32(str[2]), TableRow(cellsSplit, sub.TextFormat.Split(',')));
                            break;
                    }
                }

                currentNum++;
            }
            catch { }
        }

        /// <summary>
        /// Удаление лишнего из списка
        /// </summary>
        public void ListRecount()
        {
            if (editList.Count > 30)
                editList.RemoveAt(editList.Count - 1);
        }

        public string[] TableRow(string[] textSplit, string[] textFormatSplit)
        {
            string[] row = new string[10];
            string[] format = new string[] { "Layer", "Start", "End", "Style", "Name", "Effect", "MarginL", "MarginR", "MarginV", "Text" };
            for (int step = 0; step < row.Length; step++)
            {
                for (int i = 0; i < textFormatSplit.Length; i++)
                {
                    if (textFormatSplit[i] == format[step])
                        row[step] = textSplit[i];
                }
            }

            return row;
        }
    }
}
