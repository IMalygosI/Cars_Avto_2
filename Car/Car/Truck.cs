using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    internal class Truck : Auto
    {
        protected int Body;//То что в кузов загружено
        protected int pogruzka;//Загрузка -- Loading
        protected int razgruz;// Разгрузка - Unloading
        protected double examination;//проверка для топлива
        protected double carrying_Vess; //Вес груза
        protected double koordinata_X_Unloading; //координаты места разгрузки
        protected double koordinata_Y_Unloading;
        protected double Mesto_Razgruz;//расстояние от места погрузки до места рагрузки
        protected double Mesto_Baza; //расстояние от места разгрузки до базы
        protected double koordinata_X_loading;
        protected double pogruzk;
        protected double razgrus;
        protected double kilom;
        int e=0;

        public Truck()
        { 
            Info(cars); 
        }

        protected override void Info(List<Auto> cars) //Информация об автомобиле
        {
            this.type = "Грузовик";
            Console.WriteLine("\n> Выбрать номер грузовика:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_number = Console.ReadLine();
            if (Choice_select_car_number == "1")//Номер машины
            {
                Console.WriteLine("> Введите номер грузовика :");
                this.number_Car = Console.ReadLine();
                Console.WriteLine($"Номер грузовика : {number_Car}\n");
            }//Номер машины
            if (Choice_select_car_number == "2")//Номер машины
            {
                char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                Random rnd = new Random();
                string word = "";
                for (int j = 1; j <= 4; j++)
                {
                    int letter_num = rnd.Next(0, letters.Length - 1);
                    word += letters[letter_num];
                }
                this.number_Car = word;
                Console.WriteLine($"Номер грузовика: {number_Car}\n");
            }//Номер машины
            this.volume_Tank = 80;
            Console.WriteLine($"Объем бака грузовика: {volume_Tank}\n");
            /*
            Console.WriteLine("> Укажите расход топлива :\n1- Ввод вручную\n2- Автоматически");
            string? Choice_select_car_consumption = Console.ReadLine();
            if (Choice_select_car_consumption == "1")//Расход топлива машины
            {
                Console.WriteLine("Расход топлива (на 100 км):");
                this.consumption_Fuel = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            if (Choice_select_car_consumption == "2")//Расход топлива машины
            {
                Random rnd = new Random();
                int consumption = rnd.Next(8, 17);
                this.consumption_Fuel = consumption;
                Console.WriteLine($"Расход топлива (на 100 км): {consumption_Fuel}\n");
            }//Расход топлива машины
            *///Рассход топлива
            Console.WriteLine("> Укажите нынешний уровень топлива:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_Current_quantity_gasoline = Console.ReadLine();
            if (Choice_Current_quantity_gasoline == "1")//текущее количество бензина
            {
                Console.WriteLine("Уровень топлива:");
                this.currentamount_Gasoline = Convert.ToDouble(Console.ReadLine());
                if (volume_Tank >= currentamount_Gasoline)
                {
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    this.currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 
            if (Choice_Current_quantity_gasoline == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(0, 90);
                this.currentamount_Gasoline = currentamount;
                if (volume_Tank >= currentamount)
                {
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
                else
                {
                    currentamount_Gasoline = volume_Tank;
                    Console.WriteLine($"Уровень топлива: {currentamount_Gasoline}");
                }
            }//текущее количество бензина 
            Console.WriteLine("> Укажите Грузоподъёмность:\n1- Ввод вручную\n2- Автоматически");
            string? Choice_carrying = Console.ReadLine();
            if (Choice_carrying == "1")//текущая Грузоподъемность
            {
                Console.WriteLine("Грузоподъемность:");
                this.carrying = Convert.ToInt32(Console.ReadLine());
                if (2000 >= carrying)
                {

                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
                else
                {
                    this.carrying = 2000;
                    Console.WriteLine($"Грузоподъемность: {carrying}");
                }
            }//текущая Грузоподъемность
            if (Choice_carrying == "2")
            {
                Random rnd = new Random();
                int currentamount = rnd.Next(0, 2000);
                this.carrying = currentamount;
                Console.WriteLine($"Грузоподъемность: {carrying}");                
            }//текущая Грузоподъемность
            this.speed = 0;//скорость
            this.interval = 0;//расстояние что проехали
            this.mileage = 0;//пробег
            this.kilometers_Enough_Fuel = 0;//На сколько километров хватит топлива
            this.massa = "4т";
            Console.WriteLine($"\n|Информация по машине|");
            Console.WriteLine("|Автомобиль занесен в базу, теперь его можете выбрать\n");
            Menu(cars);
            Console.WriteLine($"> Номер авто: {number_Car}");
            Console.WriteLine($"> Пробег автомобиля: {mileage} км\n");
        }
        protected override void Path_Information(List<Auto> cars) // вводим информацию по пути 
        {
            Console.WriteLine("> Введите координаты вашего пути");
            Console.WriteLine("Начало-Xa: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Начало-Ya: ");
            this.koordinata_Xa = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Xb: ");
            this.koordinata_Xb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Конец-Yb: ");
            this.koordinata_Yb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Место погрузки: ");
            this.koordinata_X_loading = Convert.ToInt32(Console.ReadLine());


            distance = 2 * (Math.Round(Math.Sqrt(((koordinata_Xb - koordinata_Xa) * (koordinata_Xb - koordinata_Xa)) + ((koordinata_Yb - koordinata_Ya) * (koordinata_Yb - koordinata_Ya))))); //Расстояния до места погрузки груза
            distance = Convert.ToInt32(distance);
            distance = Convert.ToInt32(distance);
            this.pogruzk = 0 + koordinata_X_loading;
            this.razgrus = (distance / 2) - pogruzk;

            this.kilom = 0;
            this.interval = 0;

            kilom = koordinata_X_loading;
            Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
            Console.WriteLine($"Весь путь с дорогой обратно после разгрузки: {distance} Км");
            Console.WriteLine($"Точка погрузки через: {pogruzk} Км");
            Console.WriteLine($"Точка разгрузки через: {distance/2} Км");
            Menu(cars);
        }
        protected void Unloading_Point(List<Auto> cars) // вводим информацию по пути 
        {
            Mesto_Razgruz = Math.Sqrt(Math.Pow(koordinata_X_Unloading - koordinata_Xb, 2) + Math.Pow(koordinata_Y_Unloading - koordinata_Yb, 2)); //расстояние от места погрузки до места рагрузки
            distance = Convert.ToInt32(Mesto_Razgruz);
            e += 1;            
            Console.WriteLine("\nМашина ЗАГРУЖЕНА!");
            Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
            Console.WriteLine($"Точка разгрузки через: {distance-pogruzk} Км\n");
            Menu(cars);
        }
        protected void BAZA_Point(List<Auto> cars) // вводим информацию по пути 
        {
            Mesto_Baza = Math.Sqrt(Math.Pow(koordinata_Xa - koordinata_X_Unloading, 2) + Math.Pow(koordinata_Ya - koordinata_Y_Unloading, 2)); //расстояние от места разгрузки до базы
            //distance = Convert.ToInt32(Mesto_Baza);
            e += 1;
            Console.WriteLine("\nМашина разгружена!");
            Console.WriteLine($"\nОбъем бака: {volume_Tank} Литров\nУровень топлива: {currentamount_Gasoline} Литров");
            
            Menu(cars);
        }
        protected override void Stop(List<Auto> cars)//Остановка
        {
            speed = 0;
            interval = 0;
            Console.WriteLine($"\n> Вы остановились\n");
            Console.WriteLine($"> Пробег автомобиля: {mileage} км");
            Console.WriteLine($"> Вы желаете продолжить или закончить путь ?\n1 - Продолжить\n2 - Закончить\n");
            string? vybor = Console.ReadLine();
            if (vybor == "1")
            {
                Console.WriteLine($"> Номер авто: {number_Car}");
                Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                Drive2(cars);
            }
            else if (vybor == "2")
            {
                return;
            }
        }
        protected override void Razgon(List<Auto> cars) //Разгон
        {
            while (true)
            {
                try //для поиска ошибок try
                {
                    Console.WriteLine("\nВведите значение скорости от 1 до 180 км/ч, до которого хотите разогнаться:\n");
                    speed = Convert.ToDouble(Console.ReadLine());
                    if (speed > 0 && speed <= 180)
                    {
                        Fuel_Consumption(speed);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nВведено значение вне заданного диапазона");
                    }
                    if (carrying > 100 && carrying <= 1000)
                    {
                        speed *= 0.6;
                        Console.WriteLine($"\nС текущим весом груза в {carrying} т скорость уменьшена на 40%.");
                        Fuel_Consumption(speed);
                    }
                    else
                    {
                        if (carrying > 1 && carrying <= 2)
                        {
                            speed *= 0.2;
                            Console.WriteLine($"\nС текущим весом груза в {carrying} т скорость уменьшена на 80%.");
                            Fuel_Consumption(speed);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("\nОшибка");
                }
            }            
        }
        protected override void Drive2(List<Auto> cars) // Метод езды автомобиля
        {
            Razgon(cars);
        }
        protected void Drive()
        {
            if (speed > 0)
            {
                if (currentamount_Gasoline > 0)//currentamount_Gasoline - Текущее количество бензина
                {
                    currentamount_Gasoline -= consumption_Fuel;
                    mileage += 100;
                    interval += 100;
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < 0 & speed > 0)
                {
                    mileage -= 100;
                    interval -= 100;
                    mileage += kilometers_Enough_Fuel;
                    interval += kilometers_Enough_Fuel;
                    currentamount_Gasoline = 0;
                }
                else if (currentamount_Gasoline == 0 || currentamount_Gasoline < consumption_Fuel)
                {
                    interval = 0;
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да / 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
                if (interval >= pogruzk && kilom == pogruzk && e == 0) //Для цели поездки
                {
                    //
                    double vivo = kilom - interval;
                    mileage = pogruzk;
                    speed = 0;
                    distance -= kilom;
                    kilom = razgrus;
                    interval = pogruzk;
                    Console.WriteLine("\nМашина прибыла в точку погрузки");
                    if (carrying_Vess == 0)
                    {
                        mesto_pogruzka();
                        Unloading_Point(cars);
                    }
                }
                else if (interval >= distance && distance != 0 && e == 1) //Для цели поездки
                {
                    double vivo = distance - (interval - 100);
                    mileage = razgrus;
                    speed = 0;
                    distance = 0;
                    interval = 0;
                    Console.WriteLine("\nМашина прибыла в точку Разгрузки");
                    if (carrying_Vess != 0)
                    {
                        carrying_Vess -= carrying_Vess;
                        BAZA_Point(cars);
                    }
                }
                else if(interval >= distance /2 && mileage >= distance && kilom == distance/2 && e == 2) //Для цели поездки
                {
                    mileage = distance;
                    
                    speed = 0;
                    distance = 0;
                    interval = 0;
                    
                    Console.WriteLine("\nВы доехали до базы");
                    Console.WriteLine("\nМашина на базе, Окончить путь ?\n1 - Да\n2 - Нет"); 
                    string? oko = Console.ReadLine();
                    switch (oko)
                    {
                        case "2":
                            Menu(cars); ;
                            break;
                        case "1":
                            CarConclusion.categories(cars);
                            break;
                    }
                }
                if (currentamount_Gasoline < 2 && interval < distance && interval != 0)
                {
                    mileage += kilometers_Enough_Fuel - 100;
                    interval += kilometers_Enough_Fuel - 100;
                    currentamount_Gasoline = 0;
                    speed = 0;
                }
                kilometers_Enough_Fuel = Math.Round((currentamount_Gasoline / consumption_Fuel) * 100); //На сколько километров хватит бензина
                Console.WriteLine($"\n> Вы проехали: {interval} км");// Интервал это то сколько -за раз едем, если остановаится он сбрасывается до 0 ну пробег все еще остается!
                Console.WriteLine($"> Cколько проедем при текущем уровне бензина в баке: {kilometers_Enough_Fuel} км");
                Console.WriteLine($"> Сейчас в баке: {currentamount_Gasoline} литров");
                Console.WriteLine($"> Необходимо проехать: {kilom} км");
                Console.WriteLine($"> Пробег автомобиля: {mileage} км");
                Console.WriteLine($"> Вы ехали со скоростью: {speed} км\n");
                if (currentamount_Gasoline == 0)
                {
                    Console.WriteLine("Требуется заправка!");
                    Console.WriteLine("> Заправиться? (1 - Да, 2 - Нет)\n");
                    string? zapravim = Console.ReadLine();
                    switch (zapravim)
                    {
                        case "1":
                            Zapravka(cars);
                            break;
                        case "2":
                            Stop(cars);
                            break;
                    }
                }
                else
                {
                    Menu(cars);
                }
            }
        }
        protected void Fuel_Consumption(double speed) //рассчет расхода топлива от скорости
        {
            if (speed >= 1 && speed <= 45)
            {
                consumption_Fuel = 12;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive();
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
            else if (speed >= 46 && speed <= 100)
            {
                consumption_Fuel = 9;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive();
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
            else if (speed >= 101 && speed <= 180)
            {
                consumption_Fuel = 12.5;
                if ((currentamount_Gasoline - consumption_Fuel) >= 0)
                {
                    Drive();
                }
                else if ((currentamount_Gasoline - consumption_Fuel) < consumption_Fuel)
                {
                    Zapravka(cars);
                }
            }
        }
        protected void mesto_pogruzka()// Загружаем на точке груз
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите груз в кг, который повезет машина! максимум 2000 кг!:\n");
                    double ves = Convert.ToDouble(Console.ReadLine());
                    if (ves > 1 && ves <= 2000)
                    {
                        carrying_Vess = ves;
                        Console.WriteLine("\nТранспорт заполнен, направляйтесь к точке разгрузки\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nОшибка");
                    }
                }
                catch
                {
                    Console.WriteLine("\nОшибка");
                }
            }
        }
        public override void Menu(List<Auto> cars)//меню выбора
        {
            Console.WriteLine(">> Меню:" +
                             "\n> 1 - Задать цель поездки" +//Выбираем начало и конец координат пути, для определения дистанции пути
                             "\n> 2 - Газ" +
                             "\n> 3 - Останавливаемся" +
                             "\n> 4 - Заправиться" +
                             "\n> 5 - Сменить автомобиль" +
                             "\n> 6 - Вызывть справку по машине" +
                             "\n> 7 - АВАРИЯ");

            string? vybor = Console.ReadLine();
            switch (vybor)
            {
                case "1":
                    Path_Information(cars);
                    break;
                case "2":
                    Razgon(cars);
                    break;
                case "3":
                    Stop(cars);
                    break;
                case "4":
                    Zapravka(cars);
                    break;
                case "5":
                    CarConclusion.categories(cars);
                    break;
                case "6":
                    Out();
                    Menu(cars);
                    break;
                case "7":
                    Crash(cars);
                    break;
                default:
                    Console.WriteLine("\nКоманды с таким номером не существует");
                    break;
            }
        }
    }
}
