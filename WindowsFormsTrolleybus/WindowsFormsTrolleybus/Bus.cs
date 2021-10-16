using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTrolleybus
{
    public class Bus : Vehicle
    {
        /// <summary>
        /// Ширина отрисовки троллейбуса
        /// </summary>
        protected readonly int TrolleybusWidth = 150;
        /// <summary>
        /// Высота отрисовки троллейбуса
        /// </summary>
        protected readonly int TrolleybusHeight = 105;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес троллейбуса</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Bus(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }
        /// <summary>
        /// Конструкторс изменением размеров машины
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес троллейбуса</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="TrolleybusWidth">Ширина отрисовки троллейбуса</param>
        /// <param name="TrolleybusHeight">Высота отрисовки троллейбуса</param>
        protected Bus(int maxSpeed, float weight, Color mainColor, int TrolleybusWidth, int
        TrolleybusHeight)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            this.TrolleybusWidth = TrolleybusWidth;
            this.TrolleybusHeight = TrolleybusHeight;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {

                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - TrolleybusWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX + step > step)
                    {
                        _startPosX -= step;
                    }
                    // Продумать логику
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY + step > 0)
                    {
                        _startPosY -= step;
                    }
                    // Продумать логику
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - TrolleybusHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public override void DrawTransport(Graphics g)
        {
            int y = -48;
            Pen black_pen = new Pen(Color.Black);
            //Кузов троллейбуса
            Brush br = new SolidBrush(MainColor);
            g.DrawRectangle(black_pen, _startPosX, _startPosY - y, 160, 50);
            g.FillRectangle(br, _startPosX + 1, _startPosY + 1 - y, 159, 49);

            //Дверь
            g.DrawRectangle(black_pen, _startPosX + 45, _startPosY + 20 - y, 20, 30);
            g.FillRectangle(br, _startPosX + 46, _startPosY + 21 - y, 19, 29);

            //Колёса троллейбуса
            Brush brWhite = new SolidBrush(Color.White);
            g.DrawEllipse(black_pen, _startPosX + 20, _startPosY + 45 - y, 20, 20);
            g.DrawEllipse(black_pen, _startPosX + 120, _startPosY + 45 - y, 20, 20);
            g.FillEllipse(brWhite, _startPosX + 21, _startPosY + 46 - y, 18, 18);
            g.FillEllipse(brWhite, _startPosX + 121, _startPosY + 46 - y, 18, 18);


            Pen blue_pen = new Pen(Color.CornflowerBlue);
            //Окна
            g.DrawEllipse(blue_pen, _startPosX + 3, _startPosY + 5 - y, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 24, _startPosY + 5 - y, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 68, _startPosY + 5 - y, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 92, _startPosY + 5 - y, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 116, _startPosY + 5 - y, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 140, _startPosY + 5 - y, 18, 25);
            g.FillEllipse(brWhite, _startPosX + 4, _startPosY + 6 - y, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 25, _startPosY + 6 - y, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 69, _startPosY + 6 - y, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 93, _startPosY + 6 - y, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 117, _startPosY + 6 - y, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 141, _startPosY + 6 - y, 17, 23);

        }
    }
}
