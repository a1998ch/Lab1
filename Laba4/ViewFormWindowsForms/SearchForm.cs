using ModelLaba4WindowsForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ViewFormWindowsForms
{
    /// <summary>
    /// Класс SearchForm
    /// </summary>
    public partial class SearchForm : Form
    {
        /// <summary>
        /// Список фигур
        /// </summary>
        private readonly BindingList<FiguresAreaBase> _figuresListCopy;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="list">Список фигур</param>
        public SearchForm(BindingList<FiguresAreaBase> list)
        {
            _figuresListCopy = list;
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка SearchForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFormLoad(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            dataGridViewSearch.DataSource = _figuresListCopy;
            dataGridViewSearch.AutoResizeColumns();
        }

        /// <summary>
        /// Действия при завершении работы SearchForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Form mainForm = Application.OpenForms[0];
            mainForm.Show();
        }

        /// <summary>
        /// Поиск данных
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void TextBoxSearchTextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewSearch.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewSearch.ColumnCount; j++)
                {
                    dataGridViewSearch.Rows[i].Cells[j].Style.BackColor = Color.White;
                    if (dataGridViewSearch.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridViewSearch.Rows[i].Cells[j].Value.ToString().ToLower().IndexOf(
                            TextBoxSearch.Text.ToLower()) >= 0 && TextBoxSearch.Text != String.Empty)
                        {
                            dataGridViewSearch.Rows[i].Cells[j].Style.BackColor = Color.Green;
                            dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[j];
                        }
                        else
                        {
                            dataGridViewSearch.CurrentCell = null;
                        }
                    }
                }
            }
            for (int i = 0; i < dataGridViewSearch.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewSearch.ColumnCount; j++)
                {
                    if (dataGridViewSearch.Rows[i].Cells[j].Style.BackColor == Color.Green)
                    {
                        dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[j];
                    }
                }
            }
        }
    }
}
