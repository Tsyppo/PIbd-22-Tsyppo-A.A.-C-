using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WindowsFormsTrolleybus
{
    public partial class FormBusStation : Form
    {
        /// <summary>
        /// Объект от класса-автовокзала
        /// </summary>
        private readonly BusStationCollection busstationCollection;

        /// <summary>
        /// Логгер
        /// </summary>
        private readonly Logger logger;

        public FormBusStation()
        {
            InitializeComponent();
            busstationCollection = new BusStationCollection(pictureBoxParking.Width,
            pictureBoxParking.Height);
            logger = LogManager.GetCurrentClassLogger();
        }
        /// <summary>
        /// Заполнение listBoxLevels
        /// </summary>
        private void ReloadLevels()
        {
            int index = listBoxBusStation.SelectedIndex;
            listBoxBusStation.Items.Clear();
            for (int i = 0; i < busstationCollection.Keys.Count; i++)
            {
                listBoxBusStation.Items.Add(busstationCollection.Keys[i]);
            }
            if (listBoxBusStation.Items.Count > 0 && (index == -1 || index >=
            listBoxBusStation.Items.Count))
            {
                listBoxBusStation.SelectedIndex = 0;
            }
            else if (listBoxBusStation.Items.Count > 0 && index > -1 && index <
            listBoxBusStation.Items.Count)
            {
                listBoxBusStation.SelectedIndex = index;
            }
        }
        /// <summary>
        /// Метод отрисовки автовоказала
        /// </summary>
        private void Draw()
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {//если выбран один из пуктов в listBox (при старте программы ни один пункт
             //не будет выбран и может возникнуть ошибка, если мы попытаемся обратиться к элементу
             //listBox)
                Bitmap bmp = new Bitmap(pictureBoxParking.Width,
                pictureBoxParking.Height);
                Graphics gr = Graphics.FromImage(bmp);
                busstationCollection[listBoxBusStation.SelectedItem.ToString()].Draw(gr);
                pictureBoxParking.Image = bmp;

            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Добавить автовокзал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddBusStation_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
            {
                MessageBox.Show("Введите название парковки", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            logger.Info($"Добавили автовокзал {textBoxNewLevelName.Text}");
            busstationCollection.AddParking(textBoxNewLevelName.Text);
            ReloadLevels();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Удалить автовокзал"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelBusStation_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {
                if (MessageBox.Show($"Удалить автовокзал { listBoxBusStation.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    logger.Info($"Удалили автовокзал { listBoxBusStation.SelectedItem.ToString()}");
                    busstationCollection.DelParking(textBoxNewLevelName.Text);
                    ReloadLevels();
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void buttonTakeBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1 && maskedTextBox.Text != "")
            {
                try
                {
                    var bus = busstationCollection[listBoxBusStation.SelectedItem.ToString()] -
                    Convert.ToInt32(maskedTextBox.Text);
                    if (bus != null)
                    {
                        FormTrolleybus form = new FormTrolleybus();
                        form.SetBus(bus);
                        form.ShowDialog();
                        logger.Info($"Изъят автобус {bus} с места { maskedTextBox.Text}");

                        Draw();
                    }
                }
                catch (BusStationNotFoundException ex)
                {
                    logger.Warn($"Автобус { maskedTextBox.Text} не найден");
                    MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная ошибка");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxBusStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Перешли на парковку { listBoxBusStation.SelectedItem.ToString()}");
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить машину"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddBus_Click(object sender, EventArgs e)
        {
            var formTrolleybusConfig = new FormTrolleybusConfig();
            formTrolleybusConfig.AddEvent(AddBus);
            formTrolleybusConfig.Show();
        }

        /// <summary>
        /// Метод добавления машины
        /// </summary>
        /// <param name="bus"></param>
        private void AddBus(Vehicle bus)
        {
            try
            {
                if (bus != null && listBoxBusStation.SelectedIndex > -1)
                {
                    if (((busstationCollection[listBoxBusStation.SelectedItem.ToString()]) + bus) != -1)
                    {
                        Draw();
                        logger.Info($"Добавлен автобус {bus}");
                    }
                    else
                    {
                        MessageBox.Show("Автобус не удалось поставить");
                    }
                }
                Draw();
            }
            catch (BusStationOverflowException ex)
            {
                logger.Warn($"Автовокзал переполнен");
                MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    busstationCollection.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно", "Результат", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная ошибка при сохранении");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    busstationCollection.LoadData(openFileDialog.FileName);

                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK,

                    MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                    ReloadLevels();
                    Draw();
                }
                catch (Exception ex)
                {
                    logger.Warn($"Неизвестная ошибка при загрузке");
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

