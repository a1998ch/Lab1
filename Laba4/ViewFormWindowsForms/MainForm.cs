using ModelLaba4WindowsForms;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ViewFormWindowsForms
{
    /// <summary>
    /// Класс MainForm
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список фигур
        /// </summary>
        private BindingList<FiguresAreaBase> _figuresList =
            new BindingList<FiguresAreaBase>()
        {
            new Circle(10),
            new Rectangle(7, 9),
            new Triangle(3, 2, 4)
        };

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка MainForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            dataGridViewMain.DataSource = _figuresList;
            dataGridViewMain.AutoResizeColumns();
            dataGridViewMain.Columns[0].HeaderText = "Площадь фигуры";
            dataGridViewMain.Columns[1].HeaderText = "Название фигуры";
        }

        /// <summary>
        /// Добавление новой фигуры
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddFigureClick(object sender, EventArgs e)
        {
            this.Hide();
            AddForm addForm = new AddForm();
            addForm.CloseForm += AddSearchFormsClose;
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    switch (addForm.FigureParam().Length)
                    {
                        case 1:
                            _figuresList.Add(new Circle(addForm.FigureParam()[0]));
                            break;
                        case 2:
                            _figuresList.Add(new Rectangle(addForm.FigureParam()[0], 
                                                           addForm.FigureParam()[1]));
                            break;
                        case 3:
                            _figuresList.Add(new Triangle(addForm.FigureParam()[0],
                                addForm.FigureParam()[1], addForm.FigureParam()[2]));
                            break;
                    }
                    RemoveFigure.Enabled = true;
                    SearchFigure.Enabled = true;
                    SaveFile.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddFigureClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Действия при завершении работы AddForm
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void AddSearchFormsClose(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// Удаление фигуры
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void RemoveFigureClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewMain.SelectedRows)
            {
                dataGridViewMain.Rows.RemoveAt(row.Index);
            }
            if (dataGridViewMain.RowCount == 0)
            {
                RemoveFigure.Enabled = false;
                SearchFigure.Enabled = false;
                SaveFile.Enabled = false;
            }
        }

        /// <summary>
        /// Поиск фигуры
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SearchFigureClick(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm(_figuresList);
            searchForm.CloseForm += AddSearchFormsClose;
            this.Hide();
            searchForm.ShowDialog();
        }

        /// <summary>
        /// Сохранение/загрузка данных
        /// </summary>
        /// <param name="saveOpenFile">saveFileDialog or openFileDialog</param>
        /// <returns>Путь для сохранения/загрузки</returns>
        private string WorkWithFile(FileDialog saveOpenFile)
        {
            saveOpenFile.Filter = "FiguresAreaBase (*.fgrbs)|*.fgrbs";
            saveOpenFile.ShowDialog();
            string path = saveOpenFile.FileName;
            return path;
        }

        /// <summary>
        /// Сохранение введённых пользователем данных
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void SaveFileClick(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            string path = WorkWithFile(saveFile);

            if (string.IsNullOrEmpty(path)) { return; }

            var writer = new XmlSerializer(typeof(BindingList<FiguresAreaBase>));
            using (var fail = new StreamWriter(path))
            {
                writer.Serialize(fail, _figuresList);
            }
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void LoadFileClick(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string path = WorkWithFile(openFile);

            if (string.IsNullOrEmpty(path)) { return; }

            var reader = new XmlSerializer(_figuresList.GetType());
            using (var fail = new StreamReader(path))
            {
                try
                {
                    _figuresList = (BindingList<FiguresAreaBase>)reader.Deserialize(fail);
                    dataGridViewMain.DataSource = _figuresList;

                    RemoveFigure.Enabled = true;
                    SearchFigure.Enabled = true;
                    SaveFile.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
