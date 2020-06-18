using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VY
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите кол-во ветров:");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.Write("\n");
                Indications[] indications = new Indications[count];
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("Введите Температуру:");
                    var t = float.Parse(Console.ReadLine());
                    Console.WriteLine("Введите Направление ветра(N,S,W,E):");
                    var napV = Console.ReadLine();
                    Console.WriteLine("Введите Скорость ветра");
                    var speed = Convert.ToInt32(Console.ReadLine());
                    indications[i] = new Indications(t, napV, speed, count);
                }
                indications = Indications.Sort(indications);
                foreach (var indication in indications)
                {
                    Console.WriteLine(indications.ToString());
                }
                Console.WriteLine("Введите путь для сохранения файлов");
                var path = Console.ReadLine();
                path = "Text.txt";
                Indications.SaveAs(path, indications);
                Console.ReadLine();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }

        }
    }
}
