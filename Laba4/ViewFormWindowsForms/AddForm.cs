using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelLaba4WindowsForms;
using System.Text.RegularExpressions;

namespace ViewFormWindowsForms
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddFormLoad(object sender, EventArgs e)
        {
            choiceFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AddFigure.Enabled = false;
        }

        private void AddFormFormClosed(object sender, FormClosedEventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void AddFigureClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void choiceFigureSelectedIndexChanged(object sender, EventArgs e)
        {
            const int CircleSelectedIndex = 0;
            switch (choiceFigure.SelectedIndex)
            {
                case CircleSelectedIndex:
                    dataGridViewAdd.Columns.Add("Радиус", "Радиус");
                    dataGridViewAdd.Rows.Add();
                    break;
            }
        }

        private void dataGridViewAddCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAdd.AutoResizeColumns();
            Regex regex = new Regex("[a-z]||[а-я]");
            if (!double.TryParse(dataGridViewAdd.Rows[0].Cells[0].Value.ToString(), out double checkDouble))
            {
                dataGridViewAdd.Rows[0].Cells[0].Value = "";
                AddFigure.Enabled = false;
            }
            else
            {
                AddFigure.Enabled = true;
            }
        }

        public double Radius()
        {
            return Convert.ToDouble(dataGridViewAdd.Rows[0].Cells[0].Value);
        }
    }
}
