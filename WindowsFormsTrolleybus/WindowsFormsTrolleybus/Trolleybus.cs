using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsTrolleybus
{
    public class Trolleybus : Bus, IEquatable<Trolleybus>
    {
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
        /// Признак наличия штанги линии
        /// </summary>
        public bool Barbell { private set; get; }
        /// <summary>
        /// Инициализация свойств
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="headlights">Признак наличия фар</param>
        /// <param name="sideLine">Признак наличия боковых линий</param>
        /// <param name="barbell">Признак наличия боковых линий</param>
        public Trolleybus(int maxSpeed, float weight, Color mainColor, Color dopColor,
            bool headlights, bool sideLine, bool barbell) : base(maxSpeed, weight, mainColor, 140, 103)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            Headlights = headlights;
            SideLine = sideLine;
            Barbell = barbell;
        }
        /// <summary>
        /// Конструктор для загрузки с файла
        /// </summary>
        /// <param name="info"></param>
        public Trolleybus(string info) : base(info)
        {
            string[] strs = info.Split(separator);
            if (strs.Length == 7)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Headlights = Convert.ToBoolean(strs[4]);
                SideLine = Convert.ToBoolean(strs[5]);
                Barbell = Convert.ToBoolean(strs[6]);
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTransport(Graphics g)
        {
            Pen black_pen = new Pen(Color.Black);

            int y = -48;

            //Штанга троллейбуса
            if (Barbell)
            {
                g.DrawLine(black_pen, _startPosX + 40, _startPosY - y, _startPosX - 10, _startPosY - 30 - y);
                g.DrawLine(black_pen, _startPosX + 45, _startPosY - y, _startPosX - 5, _startPosY - 30 - y);
            }
            base.DrawTransport(g);

            // Боковая линия
            if (SideLine)
            {
                Brush br_dop = new SolidBrush(DopColor);
                g.DrawRectangle(black_pen, _startPosX, _startPosY + 30 - y, 45, 10);
                g.FillRectangle(br_dop, _startPosX + 1, _startPosY + 31 - y, 44, 9);
                g.DrawRectangle(black_pen, _startPosX + 65, _startPosY + 30 - y, 95, 10);
                g.FillRectangle(br_dop, _startPosX + 66, _startPosY + 31 - y, 94, 9);
            }

            // Фары
            if (Headlights)
            {
                Brush br = new SolidBrush(DopColor);
                g.DrawEllipse(black_pen, _startPosX + 150, _startPosY + 40 - y, 8, 8);
                g.FillEllipse(br, _startPosX + 150, _startPosY + 40 - y, 8, 8);
            }
        }
        /// <summary>
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }

        public override string ToString()
        {
            return
            $"{base.ToString()}{separator}{DopColor.Name}{separator}{Headlights}{separator}{SideLine}{separator}{Barbell}";
        }

        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Trolleybus other)
        {
            var res = base.Equals(other);
            if (!res)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (Headlights != other.Headlights)
            {
                return false;
            }
            if (SideLine != other.SideLine)
            {
                return false;
            }
            if (Barbell != other.Barbell)
            {
                return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is Trolleybus busObj))
            {
                return false;
            }
            else
            {
                return Equals(busObj);
            }
        }

    }
}

