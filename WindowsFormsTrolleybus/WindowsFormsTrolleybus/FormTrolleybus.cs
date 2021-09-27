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
    public partial class FormTrolleybus : Form
    {
        private ITransport trolleybus;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormTrolleybus()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки троллейбуса
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTrolleybus.Width, pictureBoxTrolleybus.Height);
            Graphics gr = Graphics.FromImage(bmp);
            trolleybus.DrawTransport(gr);
            pictureBoxTrolleybus.Image = bmp;
        }

        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateBus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            trolleybus = new Bus(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            trolleybus.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTrolleybus.Width,
            pictureBoxTrolleybus.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать троллейбус"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTrolleybus_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            trolleybus = new Trolleybus(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
            Color.Yellow, true, true, true);
            trolleybus.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTrolleybus.Width,
            pictureBoxTrolleybus.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    trolleybus.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    trolleybus.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    trolleybus.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    trolleybus.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
