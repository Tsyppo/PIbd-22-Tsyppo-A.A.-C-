using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace WindowsFormsTrolleybus
{/// <summary>
 /// Параметризованный класс для хранения набора объектов от интерфейса ITransport
 /// </summary>
 /// <typeparam name="T"></typeparam>
    public class BusStation<T> : IEnumerator<T>, IEnumerable<T> where T : class, ITransport
    {
        /// <summary>
        /// Список объектов, которые храним
        /// </summary>
        private readonly List<T> _places;
        /// <summary>
        /// Максимальное количество мест на парковке
        /// </summary>
        private readonly int _maxCount;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Размер парковочного места (ширина)
        /// </summary>
        private readonly int _placeSizeWidth = 210;
        /// <summary>
        /// Размер парковочного места (высота)
        /// </summary>
        private readonly int _placeSizeHeight = 97;

        /// <summary>
        /// Текущий элемент для вывода через IEnumerator (будет обращаться по своему индексу к ключу словаря, по которму будет возвращаться запись)
        /// </summary>
        
        private int _currentIndex;
        public T Current => _places[_currentIndex];
        object IEnumerator.Current => _places[_currentIndex];

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="picWidth">Рамзер парковки - ширина</param>
        /// <param name="picHeight">Рамзер парковки - высота</param>
        public BusStation(int picWidth, int picHeight)
        {
            int width = picWidth / _placeSizeWidth;
            int height = picHeight / _placeSizeHeight;
            _maxCount = width * height;
            pictureWidth = picWidth;
            pictureHeight = picHeight;
            _places = new List<T>();
            _currentIndex = -1;
        }
        /// <summary>
        /// Перегрузка оператора сложения
        /// Логика действия: на парковку добавляется автобус
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="bus">Добавляемый автобус</param>
        /// <returns></returns>
        public static int operator +(BusStation<T> p, T bus)
        {
            if (p._places.Count >= p._maxCount)
            {
                throw new BusStationOverflowException();
            }
            if (p._places.Contains(bus))
            {
                throw new BusStationAlreadyHaveException();
            }
            for (int i = 0; i < p._maxCount; i++)
            {
                if (!p._places.Contains(bus))
                {
                    p._places.Add(bus);
                    p._places[i].SetPosition(15 + i % 4 * p._placeSizeWidth, i / 4 * p._placeSizeHeight - 7,
                    p.pictureWidth, p.pictureHeight);
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Перегрузка оператора вычитания
        /// Логика действия: с парковки забираем автобус
        /// </summary>
        /// <param name="p">Парковка</param>
        /// <param name="index">Индекс места, с которого пытаемся извлечь объект</param>
        /// <returns></returns>
        public static T operator - (BusStation<T> p, int index)
        {
            if (index < -1 || index > p._places.Count)
            {
                throw new BusStationNotFoundException(index);
            }

            if (p._places.Count < p._maxCount)
            {
                if (p._places[index] != null)
                {
                    T bus = p._places[index];
                    p._places.RemoveAt(index);
                    return bus;
                }
            }
            return null; 
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Count; ++i)
            {
                _places[i].SetPosition(15 + i % 4 * _placeSizeWidth, i / 4 * _placeSizeHeight - 7,
                pictureWidth, pictureHeight);
                _places[i].DrawTransport(g);
            }
        }
        /// <summary>
        /// Метод отрисовки разметки парковочных мест
        /// </summary>
        /// <param name="g"></param>
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            for (int i = 0; i < pictureWidth / _placeSizeWidth; i++)
            {
                for (int j = 0; j < pictureHeight / _placeSizeHeight + 1; ++j)
                {//линия рамзетки места
                    g.DrawLine(pen, i * _placeSizeWidth + 5, j * _placeSizeHeight + 10, 
                        i * _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight + 10);
                }
                g.DrawLine(pen, i * _placeSizeWidth + 5, 10, i * _placeSizeWidth + 5,
                (pictureHeight / _placeSizeHeight) * _placeSizeHeight + 10);
            }
        }
        /// <summary>
        /// Функция получения элементы из списка
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetNext(int index)
        {
            if (index < 0 || index >= _places.Count)
            {
                return null;
            }
            return _places[index];
        }

        /// <summary>
        /// Сортировка автомобилей на парковке
        /// </summary>
        public void Sort() => _places.Sort((IComparer<T>)new BusComparer());

        /// <summary>
        /// Метод интерфейса IEnumerator, вызываемый при удалении объекта
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Метод интерфейса IEnumerator для перехода к следующему элементу или началу коллекции
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            // Реализовать логику
            _currentIndex++;
            if (_currentIndex >= _places.Count)
            {
                Reset();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Метод интерфейса IEnumerator для сброса и возврата к началу коллекции
        /// </summary>
        public void Reset()
        {
            _currentIndex = -1;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        /// <summary>
        /// Метод интерфейса IEnumerable
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
    }
}
