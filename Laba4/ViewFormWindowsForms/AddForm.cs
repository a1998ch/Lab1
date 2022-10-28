using System;
using System.Windows.Forms;

namespace ViewFormWindowsForms
{
    /// <summary>
    /// Класс AddForm
    /// </summary>
    public partial class AddForm : Form
    {
        /// <summary>
        /// Предопределенный делегат, 
        /// который представляет метод обработчика событий для события
        /// </summary>
        internal event EventHandler CloseForm;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public AddForm()
        {
            InitializeComponent();
            #if !DEBUG
            CreateRandomData.Visible = false;
            #endif
        }

        /// <summary>
        /// Загрузка AddForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFormLoad(object sender, EventArgs e)
        {
            ComboBoxChoiceFigure.DropDownStyle = ComboBoxStyle.DropDownList;
            AddFigureOK.Enabled = false;
        }

        /// <summary>
        /// Действия при завершении работы AddForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        /// <summary>
        /// Завершение работы AddForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void ExitClick(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Изменение типа фигуры
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
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

        /// <summary>
        /// Изменение DataGridViewAdd
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void DataGridViewAddCellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAdd.AutoResizeColumns();
            if (dataGridViewAdd.CurrentCell.Value != null && 
                !double.TryParse(dataGridViewAdd.CurrentCell.Value.ToString(), out double _))
            {
                MessageBox.Show("Неправильный ввод данных", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                AddFigureOK.Enabled = false;
                dataGridViewAdd.CurrentCell.Value = null;
                return;
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

        /// <summary>
        /// Удаление строк и столбцов DataGridViewAdd
        /// </summary>
        private void DataGridViewClear()
        {
            int count = dataGridViewAdd.Columns.Count;
            dataGridViewAdd.Rows.Clear();
            for (int i = 0; i < count; i++)
            {
                dataGridViewAdd.Columns.RemoveAt(0);
            }
        }

        /// <summary>
        /// Запись параметров фигуры
        /// </summary>
        /// <returns>Параметры фигуры</returns>
        public double[] FigureParam()
        {
            double[] arrayParametrs = new double[dataGridViewAdd.Columns.Count];
            for (int i = 0; i < arrayParametrs.Length; i++)
            {
                arrayParametrs[i] = 
                    Convert.ToDouble(dataGridViewAdd.Rows[0].Cells[i].Value);
            }
            return arrayParametrs;
        }

        #if DEBUG
        //TODO: директивы условной компиляции
        /// <summary>
        /// Заполнение DataGridViewAdd случайными значениями
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void CreateRandomDataClick(object sender, EventArgs e)
        {
            //TODO: RSDN
            Random random = new Random();
            int randomFigure = random.Next(0, 3);
            ComboBoxChoiceFigure.SelectedIndex = randomFigure;

            for (int i = 0; i < dataGridViewAdd.Columns.Count; i++)
            {
                dataGridViewAdd[i, 0].Value = GetRandomData(random);

                if (dataGridViewAdd.Columns.Count == 3 && i > 0)
                {
                    dataGridViewAdd[i, 0].Value = 
                        (double)dataGridViewAdd[1, 0].Value / 10 + 
                        (double)dataGridViewAdd[i-1, 0].Value;
                }
            }
        }

        //TODO: RSDN
        /// <summary>
        /// Создание случайных параметров фигуры
        /// </summary>
        /// <param name="random">Генератор случайных чисел</param>
        /// <returns>Параметры фигуры</returns>
        private static double GetRandomData(Random random)
        {
            double doubleNamber = random.NextDouble();
            double param = random.Next(1, 100) * doubleNamber;
            return Math.Round(param, 7);
        }
        #endif
    }
}
