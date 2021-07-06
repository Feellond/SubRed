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
    public partial class EffectsForm : Form
    {
        public EffectsForm()
        {
            InitializeComponent();
        }

        private void EffectsForm_Load(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        DataGridView table;

        public void LoadForm(DataGridView table)
        {
            this.table = table;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 1:
                case 3:
                    if (index == 3) label1.Text = "Эффект прокрутки текста вниз по экрану.";
                    else label1.Text = "Эффект прокрутки текста вверх по экрану.";
                    label1.Text += Environment.NewLine + "Параметры отделяются от имени эффекта и друг от друга “точкой с запятой”";

                    textBox1.Text = "Scroll up;y1;y2;delay;fadeawayheight";
                    break;
                case 2:
                    label1.Text = "Эффект горизонтального перемещения текста вдоль экрана справа на лево."
                        + Environment.NewLine + " Текст будет показан в одну строку независимо от длины и кодов переноса строки";

                    textBox1.Text = "Banner;delay;lefttoright;fadeawaywidth";
                    break;
                default:
                    label1.Text = "";
                    break;
            }
        }

        public string EffectToString()
        {
            string[] effectSplit = textBox1.Text.Split(';');
            string[] paramsSplit = textBox2.Text.Split(';');

            for (int i = 0; i < paramsSplit.Count(); i++)
            {
                effectSplit[i + 1] = paramsSplit[i];
            }

            return String.Join(";", effectSplit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // применить ко всем
            string effect = EffectToString();
            for (int i = 0; i < table.RowCount; i++)
            {
                table.Rows[i].Cells[4].Value = effect;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // применить к выделенным
            string effect = EffectToString();
            for (int i = 0; i < table.SelectedRows.Count; i++)
            {
                var index = table.SelectedRows[i].Index;
                table.Rows[index].Cells[4].Value = effect;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Величины y1 и y2 определяют вертикальные границы области прокрутки. Задаются в пикселях от верхней границы кадра. " +
                "Последовательность значения не имеет, прокрутка будет осуществляться от большей границы к меньшей." + Environment.NewLine +
                "Параметр delay определяет скорость прокрутки и может находиться в пределах от 0 до 100. Чем больше значение, тем медленнее скорость." + Environment.NewLine +
                "Параметр lefttoright может иметь значения 0 или 1. Значение 0 означает перемещение справа на лево и может отсутствовать." +
                "Значение 1 означает перемещение слева на право." + Environment.NewLine +
                "Параметы fadeawayheight и fadeawaywidth определяют длину (в пикселях) промежутка, на котором субтитры постепенно появляются и постепенно исчезают." + Environment.NewLine + Environment.NewLine +
                "Ввод значений параметров ставить через точку с запятой без пробелов"
                , "Помощь");
        }
    }
}
