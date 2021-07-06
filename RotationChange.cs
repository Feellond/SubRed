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
    public partial class RotationChange : Form
    {
        public RotationChange()
        {
            InitializeComponent();
        }

        public int rotationNumber;

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(rotationTextBox.Text, out int num))
            {
                rotationNumber = num;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Неправильно введено число", "Ошибка числа", MessageBoxButtons.OK);
        }
    }
}
