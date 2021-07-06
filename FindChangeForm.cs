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
    public partial class FindChangeForm : Form
    {
        public FindChangeForm()
        {
            InitializeComponent();
        }

        DataGridView table;
        Color defaultColor;
        int currentIndex;

        public void LoadForm(DataGridView t)
        {
            table = t;
            defaultColor = t.Rows[0].DefaultCellStyle.BackColor;
            currentIndex = 0;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            for (int i = 0 + currentIndex; i < table.RowCount; i++)
            {
                if (i >= 0)
                    table.Rows[i].DefaultCellStyle.BackColor = defaultColor;
            }

            bool notFound = true;
            if (findTextBox.Text != "")
            {
                int i;
                for (i = 0 + currentIndex; i < table.RowCount; i++)
                {
                    if (i >= 0)
                    {
                        if (table.Rows[i].Cells[10].Value.ToString().Contains(findTextBox.Text) && i != currentIndex)
                        {
                            if (notFound)
                            {
                                currentIndex = i;
                                table.FirstDisplayedScrollingRowIndex = i;
                                table.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                                notFound = false;
                                break;
                            }
                        }
                    }
                }

                if (i >= table.RowCount)
                {
                    MessageBox.Show("Вхождений более не найдено", "Вхождений не найдено", MessageBoxButtons.OK);
                    currentIndex = 0;
                }
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text != "" && changeTextBox.Text != "")
            {
                table.Rows[currentIndex].Cells[10].Value = table.Rows[currentIndex].Cells[10].Value.ToString().Replace(findTextBox.Text, changeTextBox.Text);
            }
        }

        private void changeAllButton_Click(object sender, EventArgs e)
        {
            if (findTextBox.Text != "" && changeTextBox.Text != "")
            {
                for (int i = 0; i < table.RowCount; i++)
                {
                    if (table.Rows[i].Cells[10].Value.ToString().Contains(findTextBox.Text))
                    {
                        table.Rows[i].Cells[10].Value = table.Rows[i].Cells[10].Value.ToString().Replace(findTextBox.Text, changeTextBox.Text);
                    }
                }
            }
        }

        private void FindChangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0 + currentIndex; i < table.RowCount; i++)
            {
                if (i >= 0)
                    table.Rows[i].DefaultCellStyle.BackColor = defaultColor;
            }
        }

        private void findTextBox_TextChanged(object sender, EventArgs e)
        {
            currentIndex = -1;
        }
    }
}
