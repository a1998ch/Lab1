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
        /// Информация о фигуре
        /// </summary>
        /// <param name="i">Индекс фигуры</param>
        /// <returns>Название фигуры и её площадь</returns>
        private string Info(int i) => $"{_figuresListCopy[i].FigureArea} " +
                                      $"{_figuresListCopy[i].Type}";

        /// <summary>
        /// Поиск данных
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void TextBoxSearchTextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _figuresListCopy.Count; i++)
            {
                dataGridViewSearch.Rows[i].DefaultCellStyle.BackColor = Color.White;
                if (Info(i).ToString().ToLower().IndexOf(TextBoxSearch.Text.ToLower()) >= 0 
                                                        && TextBoxSearch.Text != String.Empty)
                {
                    dataGridViewSearch.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    dataGridViewSearch.CurrentCell = dataGridViewSearch.Rows[i].Cells[0];
                }
                else
                {
                    dataGridViewSearch.CurrentCell = null;
                }
            }
        }
    }
}
