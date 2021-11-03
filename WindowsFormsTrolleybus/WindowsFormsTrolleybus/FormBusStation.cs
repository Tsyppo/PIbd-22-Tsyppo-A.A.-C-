using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTrolleybus
{
    public partial class FormBusStation : Form
    {
        /// <summary>
        /// Объект от класса-автовокзала
        /// </summary>
        private readonly BusStationCollection busstationCollection;
        public FormBusStation()
        {
            InitializeComponent();
            busstationCollection = new BusStationCollection(pictureBoxParking.Width,
            pictureBoxParking.Height);
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
                if (MessageBox.Show($"Удалить парковку { listBoxBusStation.SelectedItem.ToString()}?",
                    "Удаление", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    busstationCollection.DelParking(textBoxNewLevelName.Text);
                    ReloadLevels();
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автобус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetBus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var bus = new Bus(100, 1000, dialog.Color);
                    if ((busstationCollection[listBoxBusStation.SelectedItem.ToString()] + bus) > -1)
                    {
                        Draw();
                    }
                    else
                    {

                        MessageBox.Show("Парковка переполнена");
                    }
                }
            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Припарковать троллейбус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetTrolleybus_Click(object sender, EventArgs e)
        {
            if (listBoxBusStation.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogDop = new ColorDialog();
                    if (dialogDop.ShowDialog() == DialogResult.OK)
                    {
                        var trollebus = new Trolleybus(100, 1000, dialog.Color,
                        dialogDop.Color, true, true, true);

                        if ((busstationCollection[listBoxBusStation.SelectedItem.ToString()] + trollebus) > -1)
                        {
                            Draw();
                        }
                        else
                        {
                            MessageBox.Show("Парковка переполнена");
                        }
                    }
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
                var bus = busstationCollection[listBoxBusStation.SelectedItem.ToString()] -
                Convert.ToInt32(maskedTextBox.Text);
                if (bus != null)
                {
                    FormTrolleybus form = new FormTrolleybus();
                    form.SetBus(bus);
                    form.ShowDialog();
                }
                Draw();
            }
        }
        /// <summary>
        /// Метод обработки выбора элемента на listBoxLevels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxBusStation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}

