using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WindowsFormsTrolleybus
{
    /// <summary>
    /// Класс-коллекция парковок
    /// </summary>
    public class BusStationCollection
    {
        /// <summary>
        /// Словарь (хранилище) с парковками
        /// </summary>
        readonly Dictionary<string, BusStation<Vehicle>> parkingStages;
       
        /// <summary>
        /// Возвращение списка названий праковок
        /// </summary>
        public List<string> Keys => parkingStages.Keys.ToList();
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        private readonly int pictureWidth;
        /// <summary>
        /// Высота окна отрисовки
        /// </summary>
        private readonly int pictureHeight;
        /// <summary>
        /// Разделитель для записи информации в файл
        /// </summary>
        private readonly char separator = ':';
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="pictureWidth"></param>
        /// <param name="pictureHeight"></param>
        public BusStationCollection(int pictureWidth, int pictureHeight)
        {
            parkingStages = new Dictionary<string, BusStation<Vehicle>>();
            this.pictureWidth = pictureWidth;
            this.pictureHeight = pictureHeight;
        }
        /// <summary>
        /// Добавление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void AddParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                return;
            }
            parkingStages.Add(name, new BusStation<Vehicle>(pictureWidth, pictureHeight));
            // Прописать логику для добавления
        }
        /// <summary>
        /// Удаление парковки
        /// </summary>
        /// <param name="name">Название парковки</param>
        public void DelParking(string name)
        {
            if (parkingStages.ContainsKey(name))
            {
                parkingStages.Remove(name);
            }
            // Прописать логику для удаления
        }
        /// <summary>
        /// Доступ к парковке
        /// </summary>
        /// <param name="ind"></param>
        /// <returns></returns>
        public BusStation<Vehicle> this[string ind]
        {
            get
            {
                if (parkingStages.ContainsKey(ind))
                {
                    return parkingStages[ind];
                }
                return null;
            }
            // Продумать логику для индексатора
        }
        /// <summary>
        /// Сохранение информации по автобусам на автовокзалах из файла
        /// </summary>
        /// <param name="filename">Путь и имя файла</param>
        /// <returns></returns>
        public bool SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine($"BusStationCollection{Environment.NewLine}", sw);
                foreach (var level in parkingStages)
                {
                    //Начинаем парковку
                    sw.WriteLine($"BusStation{separator}{level.Key}{Environment.NewLine}", sw);
                    ITransport bus = null;
                    for (int i = 0; (bus = level.Value.GetNext(i)) != null; i++)
                    {
                        if (bus != null)
                        {
                            //если место не пустое
                            //Записываем тип машины
                            //Записываемые параметры
                            if (bus.GetType().Name == "Bus")
                            {
                                sw.WriteLine($"Bus{separator}" + bus + Environment.NewLine, sw);
                            }
                            if (bus.GetType().Name == "Trolleybus")
                            {
                                sw.WriteLine($"Trolleybus{separator}" + bus + Environment.NewLine, sw);
                            }
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Загрузка нформации по автобусам на автовокзалах из файла
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }

            using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
            {
                string line;
                if (sr.ReadLine().Contains("BusStationCollection"))
                {
                    //очищаем записи
                    parkingStages.Clear();
                }
                else
                {
                    //если нет такой записи, то это не те данные
                    return false;
                }
                Vehicle bus = null;
                string key = string.Empty;
                for (int i = 1; (line = sr.ReadLine()) != null; ++i)
                {
                    //идем по считанным записям
                    if (line.Contains("BusStation"))
                    {
                        //начинаем новую парковку
                        key = line.Split(separator)[1];
                        parkingStages.Add(key, new BusStation<Vehicle>(pictureWidth, pictureHeight));
                        continue;
                    }
                    else if (line.Contains(separator))
                    {
                        if (line.Contains("Bus"))
                        {
                            bus = new Bus(line.Split(separator)[1]);
                        }
                        else if (line.Contains("Trolleybus"))
                        {
                            bus = new Trolleybus(line.Split(separator)[1]);
                        }
                        var result = parkingStages[key] + bus;
                        if (!(result == 0))
                        {
                            return false;
                        }
                    }

                }
             
            }
            return true;
        }
    }
}