using ModelLaba4WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewFormWindowsForms
{
    public partial class SearchForm : Form
    {
        private readonly BindingList<FiguresAreaBase> _figuresListCopy;

        public SearchForm(BindingList<FiguresAreaBase> list)
        {
            _figuresListCopy = list;
            InitializeComponent();
        }

        private void SearchFormLoad(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            dataGridViewSearch.DataSource = _figuresListCopy;
            dataGridViewSearch.AutoResizeColumns();
        }

        private void SearchFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        private void textBoxSearchTextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSearch.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewSearch.ColumnCount; j++)
                {
                    dataGridViewSearch.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (dataGridViewSearch.Rows[i].Cells[j].Value != null && textBoxSearch.Text != "")
                    {
                        if (dataGridViewSearch.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBoxSearch.Text.ToLower()))
                        {
                            dataGridViewSearch.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[j];
                        }
                    }
                    else
                    {
                        dataGridViewSearch.Rows[i].Cells[j].Style.BackColor = Color.White;
                        dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[0].Cells[0];
                    }
                }
            }
        }
    }
}
