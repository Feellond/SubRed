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
    public partial class StyleListForm : Form
    {
        public StyleListForm()
        {
            InitializeComponent();
        }

        PluginBase pbBase;
        DataGridView table;

        public void LoadForm(PluginBase pbBase, DataGridView table)
        {
            this.table = table;
            this.pbBase = pbBase;
            int index = 0;
            string[] strSplit = pbBase.subtitles.stylesFormat.Split(',');
            for (index = 0; index < strSplit.Length; index++)
            {
                if (strSplit[index] == "Name")
                    break;
            }

            if (index < strSplit.Length)
            {
                listBox1.Items.Clear();
                foreach (string style in pbBase.subtitles.style)
                {
                    strSplit = style.Split(',');
                    listBox1.Items.Add(strSplit[index]);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            StyleSettingsForm ssForm = new StyleSettingsForm();
            ssForm.LoadForm(pbBase.subtitles);
            if (ssForm.ShowDialog() == DialogResult.OK)
            {
                LoadForm(pbBase, table);
            }
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                StyleSettingsForm ssForm = new StyleSettingsForm();
                ssForm.LoadForm(pbBase.subtitles.style[listBox1.SelectedIndex], pbBase.subtitles.stylesFormat, listBox1.SelectedIndex, pbBase.subtitles);
                if (ssForm.ShowDialog() == DialogResult.OK)
                {
                    LoadForm(pbBase, table);
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                listBox1.Items.Add(listBox1.SelectedItem);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены что хотите удалить" + listBox1.Items[listBox1.SelectedIndex] + "?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // применить к выделенным
            for (int i = 0; i < table.SelectedRows.Count; i++)
            {
                var index = table.SelectedRows[i].Index;
                table.Rows[index].Cells[4].Value = pbBase.subtitles.style[listBox1.SelectedIndex];
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // применить ко всем
            for (int i = 0; i < table.RowCount; i++)
            {
                table.Rows[i].Cells[4].Value = pbBase.subtitles.style[listBox1.SelectedIndex];
            }
        }
    }
}
