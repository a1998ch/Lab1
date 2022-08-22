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
            ComboBoxChoiceFigure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AddFigureOK.Enabled = false;
        }

        private void AddFormClosing(object sender, FormClosingEventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void ExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChoiceFigureSelectedIndexChanged(object sender, EventArgs e)
        {
            const int CircleSelectedIndex = 0;
            const int RectangleSelectedIndex = 1;
            const int TriangleSelectedIndex = 2;
            switch (ComboBoxChoiceFigure.SelectedIndex)
            {
                case CircleSelectedIndex:
                    DataGridViewClear();
                    dataGridViewAdd.Columns.Add("Радиус", "Радиус");
                    dataGridViewAdd.Rows.Add();
                    break;
                case RectangleSelectedIndex:
                    DataGridViewClear();
                    dataGridViewAdd.Columns.Add("Сторона А", "Сторона А");
                    dataGridViewAdd.Columns.Add("Сторона В", "Сторона В");
                    dataGridViewAdd.Rows.Add();
                    break;
                case TriangleSelectedIndex:
                    DataGridViewClear();
                    dataGridViewAdd.Columns.Add("Сторона А", "Сторона А");
                    dataGridViewAdd.Columns.Add("Сторона В", "Сторона В");
                    dataGridViewAdd.Columns.Add("Сторона С", "Сторона С");
                    dataGridViewAdd.Rows.Add();
                    break;
            }
        }

        private void DataGridViewAddCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAdd.AutoResizeColumns();
            Regex regex = new Regex("[a-z]||[а-я]");
            for (int i = 0; i < dataGridViewAdd.Columns.Count; i++)
            {
                if (dataGridViewAdd.Rows[0].Cells[i].Value != null && 
                    !double.TryParse(dataGridViewAdd.Rows[0].Cells[i].Value.ToString(), out double checkDouble))
                {
                    dataGridViewAdd.Rows[0].Cells[i].Value = "";
                    AddFigureOK.Enabled = false;
                }
            }
            for (int i = 0, j = 0; i < dataGridViewAdd.Columns.Count; i++)
            {
                if (dataGridViewAdd[i, 0].Value != null &&
                    dataGridViewAdd[i, 0].Value.ToString() != "")
                {
                    j++;
                }
                if (j == dataGridViewAdd.Columns.Count)
                {
                    AddFigureOK.Enabled = true;
                }
            }
        }

        private void DataGridViewClear()
        {
            int count = dataGridViewAdd.Columns.Count;
            dataGridViewAdd.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dataGridViewAdd.Columns.RemoveAt(0);
            }
        }

        public double[] FigureParam()
        {
            double[] arrayParametrs = new double[dataGridViewAdd.Columns.Count];
            for (int i = 0; i < arrayParametrs.Length; i++)
            {
                arrayParametrs[i] = Convert.ToDouble(dataGridViewAdd.Rows[0].Cells[i].Value);
            }
            return arrayParametrs;
        }
    }
}
