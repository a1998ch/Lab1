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
        /// Предопределенный делегат, 
        /// который представляет метод обработчика событий для события
        /// </summary>
        internal event EventHandler CloseForm;

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
            dataGridViewSearch.DataSource = _figuresListCopy;
            dataGridViewSearch.AutoResizeColumns();
        }

        /// <summary>
        /// Действия при завершении работы SearchForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        /// <summary>
        /// Поиск данных
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void TextBoxSearchTextChanged(object sender, EventArgs e)
        {
            //TODO Выполнить поиск в листе
            for (int i = 0; i < dataGridViewSearch.RowCount; i++)
            {
                for (int j = 0; j < dataGridViewSearch.ColumnCount; j++)
                {
                    dataGridViewSearch.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    if (dataGridViewSearch.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridViewSearch.Rows[i].Cells[j].Value.ToString().ToLower().IndexOf(
                            TextBoxSearch.Text.ToLower()) >= 0 && TextBoxSearch.Text != String.Empty)
                        {
                            dataGridViewSearch.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[j];
                            break;
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
                    if (dataGridViewSearch.Rows[i].DefaultCellStyle.BackColor == Color.Green)
                    {
                        dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[j];
                    }
                }
            }
        }
    }
}
