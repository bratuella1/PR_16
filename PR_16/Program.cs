//*************************
// практическая работа №16*
// выполнил: Ханов Артур  *
//*************************
using System;
using System.IO;


namespace PR_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filepath;//строка для хранения пути
            Console.WriteLine("Введите n");//выводим запрос
            int n = int.Parse(Console.ReadLine());//вводим с клавиатуры n - число элементов файла
            Random r = new Random();//создаем экземпляр класса для генерации случайных чисел
            double a;
            //Console.WriteLine("Введите путь к файлу");
            //filepath = Console.ReadLine();
            filepath = @"C:\123.txt";
            try
            {
                FileStream F = new FileStream(filepath, FileMode.Create);
                StreamWriter wr = new StreamWriter(F);//создаем поток-писатель
                for (int i = 0; i < n; i++)
                {
                    a = Convert.ToDouble(r.Next(-551, 102) / 100.0);//генерируем случайное число и делаем его дробным
                    wr.WriteLine(a);//записываем его в файл
                }
                wr.Close();//закрываем поток
                int nomer = 0, kol = 0;
                Console.WriteLine("Элементы из файла:");
                FileStream F1 = new FileStream(filepath, FileMode.Open);
                StreamReader rd = new StreamReader(F1);//создаем поток-читатель
                while (!rd.EndOfStream)//цикл - пока не конец файла
                {
                    a = double.Parse(rd.ReadLine());//считываем элемент из файла
                    Console.Write("{0:f2}  ", a);// выводим его на экран
                    nomer++;//подсчитываем номер позиции
                    if (nomer % 2 == 0 && a < 0)//если номер четный и число отрицательное
                        kol++;
                }
                Console.WriteLine();
                rd.Close();//закрываем поток
                Console.WriteLine("Количество отрицательных элементов на четных позициях {0}", kol);//выводим на экран
            }
            catch (IOException e)//обработка исключения 
            {
                Console.WriteLine("Ошибка файла " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
