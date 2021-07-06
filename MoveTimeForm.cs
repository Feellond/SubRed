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
    public partial class MoveTimeForm : Form
    {
        public MoveTimeForm()
        {
            InitializeComponent();
        }

        DataGridView table;

        public void LoadForm(DataGridView t)
        {
            table = t;
        }

        public void ConvertTime(int i)
        {
            TimeSpan convertedTimeBegin, convertedTimeEnd;

            convertedTimeBegin = TimeSpan.Parse(table.Rows[i].Cells[2].Value.ToString());
            convertedTimeEnd = TimeSpan.Parse(table.Rows[i].Cells[3].Value.ToString());

            convertedTimeBegin += TimeSpan.FromMilliseconds(Convert.ToDouble(milliTextBox.Text));
            convertedTimeBegin += TimeSpan.FromSeconds(Convert.ToDouble(secondsTextBox.Text));
            convertedTimeBegin += TimeSpan.FromMinutes(Convert.ToDouble(minutesTextBox.Text));
            convertedTimeBegin += TimeSpan.FromHours(Convert.ToDouble(hoursTextBox.Text));

            convertedTimeEnd += TimeSpan.FromMilliseconds(Convert.ToDouble(milliTextBox.Text));
            convertedTimeEnd += TimeSpan.FromSeconds(Convert.ToDouble(secondsTextBox.Text));
            convertedTimeEnd += TimeSpan.FromMinutes(Convert.ToDouble(minutesTextBox.Text));
            convertedTimeEnd += TimeSpan.FromHours(Convert.ToDouble(hoursTextBox.Text));

            string mili = convertedTimeBegin.TotalMilliseconds.ToString();

            if (mili.Length < 3)
            {
                if (mili.Length < 2)
                    mili.Insert(0, "00");
                else
                    mili.Insert(0, "0");
            }
            else
                mili = mili.Substring(mili.Length - 3);

            table.Rows[i].Cells[2].Value = convertedTimeBegin.ToString().Split('.')[0] + '.' + mili;

            //
            mili = convertedTimeEnd.TotalMilliseconds.ToString();

            if (mili.Length < 3)
            {
                if (mili.Length < 2)
                    mili.Insert(0, "00");
                else
                    mili.Insert(0, "0");
            }
            else
                mili = mili.Substring(mili.Length - 3);

            table.Rows[i].Cells[3].Value = convertedTimeEnd.ToString().Split('.')[0] + '.' + mili;
        }

        private void selectedButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.SelectedRows.Count; i++)
            {
                ConvertTime(table.SelectedRows[i].Index);
            }
        }

        private void allButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                ConvertTime(i);
            }
        }
    }
}
