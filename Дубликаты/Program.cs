using System;
using System.Linq;

namespace datagile_testtask_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите массив чисел через запятую:");
            var arr = Console.ReadLine().Replace(" ", "").Trim(',').Replace(",,", ",").Split(',').Select(Int32.Parse).ToArray();
            //Trim, Replace добавлены во избежание ошибок при случайных опечатках

            var duplicates = arr.GroupBy(x => x).Where(i => i.Count() > 1)
              .Select(j => new { Item = j.Key, Count = j.Count()-1 })
              .ToList();

            Console.WriteLine("\nДубликаты введенного массива:\n");
            foreach(var d in duplicates)
            {
                Console.WriteLine(String.Join("\n", "Значение: " + d.Item + "\t" + "Кол-во: " + d.Count));
            }
        }
    }
}
