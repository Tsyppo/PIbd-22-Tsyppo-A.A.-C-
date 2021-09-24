using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTrolleybus
{
    public class Trolleybus
    {
        /// <summary>
        /// Левая координата отрисовки троллейбуса
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки троллейбуса
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private int _pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки троллейбуса
        /// </summary>
        private readonly int trolleybusWidth = 100;
        /// <summary>
        /// Высота отрисовки троллейбуса
        /// </summary>
        private readonly int trolleybusHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес троллейбуса
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия фар
        /// </summary>
        public bool Headlights { private set; get; }
        /// <summary>
        /// Признак наличия боковой линии
        /// </summary>
        public bool SideLine { private set; get; }
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
        bool headlights, bool sideLine)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Headlights = headlights;
            SideLine = sideLine;
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;

            // Продумать логику
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - trolleybusWidth)
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
                    if (_startPosY + step > step)
                    {
                        _startPosY -= step;
                    }
                    // Продумать логику
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - trolleybusHeight)
                    {
                        _startPosY += step;
                    }
                    break;

            }
        }

        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawTransport(Graphics g)
        {
            Pen black_pen = new Pen(Color.Black);

            //Кузов троллейбуса
            Brush br = new SolidBrush(MainColor);
            g.DrawRectangle(black_pen, _startPosX, _startPosY, 160, 50);
            g.FillRectangle(br, _startPosX + 1, _startPosY + 1, 159, 49);

            // Боковой спойлер 
            if (SideLine)
            {
                Brush br_dop = new SolidBrush(DopColor);
                g.DrawRectangle(black_pen, _startPosX, _startPosY + 15, 160, 10);
                g.DrawRectangle(black_pen, _startPosX, _startPosY + 30, 160, 10);
                g.FillRectangle(br_dop, _startPosX + 1, _startPosY + 16, 159, 9);
                g.FillRectangle(br_dop, _startPosX + 1, _startPosY + 31, 159, 9);
            }

            //Дверь
            g.DrawRectangle(black_pen, _startPosX + 45, _startPosY + 20, 20, 30);
            g.FillRectangle(br, _startPosX + 46, _startPosY + 21, 19, 29);

            //Колёса троллейбуса
            Brush brWhite = new SolidBrush(Color.White);
            g.DrawEllipse(black_pen, _startPosX + 20, _startPosY + 45, 20, 20);
            g.DrawEllipse(black_pen, _startPosX + 120, _startPosY + 45, 20, 20);
            g.FillEllipse(brWhite, _startPosX + 21, _startPosY + 46, 18, 18);
            g.FillEllipse(brWhite, _startPosX + 121, _startPosY + 46, 18, 18);


            Pen blue_pen = new Pen(Color.CornflowerBlue);
            //Окна
            g.DrawEllipse(blue_pen, _startPosX + 3, _startPosY + 5, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 24, _startPosY + 5, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 68, _startPosY + 5, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 92, _startPosY + 5, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 116, _startPosY + 5, 18, 25);
            g.DrawEllipse(blue_pen, _startPosX + 140, _startPosY + 5, 18, 25);
            g.FillEllipse(brWhite, _startPosX + 4, _startPosY + 6, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 25, _startPosY + 6, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 69, _startPosY + 6, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 93, _startPosY + 6, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 117, _startPosY + 6, 17, 23);
            g.FillEllipse(brWhite, _startPosX + 141, _startPosY + 6, 17, 23);

            // Фары
            if (Headlights)
            {
                br = new SolidBrush(DopColor);
                g.DrawEllipse(black_pen, _startPosX + 150, _startPosY + 40, 8, 8);
                g.FillEllipse(br, _startPosX + 150, _startPosY + 40, 8, 8);


            }
           
            
        }
    }
}
