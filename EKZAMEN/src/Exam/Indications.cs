
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VY
{

    class Indications : Object
    {
        private float t;
        private string napV;
        private int speed;
        private int count;

        public float T { get => t; set => t = value; }
        public string NapV { get => napV; set => napV = value; }
        public int Speed { get => speed; set => speed = value; }
        public Int32 Count { get => count; set => count = value; }

        public Indications(float t, string napV, int speed, int count)
        {
            this.T = t;
            this.NapV = napV;
            this.Speed = speed;
            this.count = count;
        }
        public Indications()
        {
            this.T = 0;
            this.NapV = "";
            this.Speed = 0;
        }
        public static Indications[] Sort(Indications[] indications)
        {
            {

                for (int i = 0; i < indications.Length; i++)
                {
                    for (int j = i + 1; j < indications.Length; j++)
                    {
                        if ( indications[i].speed < indications[j].speed)
                        {
                            var temp = indications[i].speed;
                            indications[i].speed = indications[j].speed;
                            indications[j].speed = temp;
                        }
                    }
                }

                return indications;
            }
        }

        public static bool SaveAs(string path, Indications[] vet)
        {
            if (File.Exists(path.ToString()))
            {

                Console.WriteLine("Файл уже существует,перезаписать файл?(Y/N)");
                string answer = Console.ReadLine();
                if (answer == "y" || answer == "Y" || answer == "у" || answer == "У" || answer == "д" || answer == "Д")
                {
                    File.Delete(path);
                    TextWriter opnFile = new StreamWriter(path);
                    foreach (var vetr in vet)
                    {
                        opnFile.WriteLine(vet.ToString());
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                using (TextWriter opnFile = new StreamWriter(path.ToString()))
                {
                    foreach (var vetr in vet)
                    {
                        opnFile.WriteLine(vetr.ToString());
                    }
                    opnFile.Close();
                }
                return true;
            }
        }
        public override string ToString()
        {
            return "Температура:" + T + " Напровление ветра:" + NapV + " Скорость ветра:" + Speed + "\n";
        }

    }
}
