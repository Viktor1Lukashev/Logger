using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//для упрощения я для записи передаю тип сообщения и само сообщение в конструкторе Logger. 
namespace Logger
{
    class Logger
    {
        private string path = "logger.txt";//куда будут записываться данные
        private string type;//тип сообщения
        string rx; // переменная куда будет считано регулярное выражение из файла
  
        private string GetSettings()
        {
          
            try
            {
                using (FileStream file = new FileStream("my.txt",FileMode.Open)) //открываем файл с шаблоном выражения
                {
                    using (StreamReader rider = new StreamReader(file, Encoding.UTF8))
                    {
                        string settings = rider.ReadToEnd();//считываем данные в переменную и возвращаем ее вызывающему методу
                        return settings;
                           
                    }
                }
            }
            catch(Exception ex)
            {
                return "none";
            }
        }
        public void record(string TextExeption,string TypeExeption)
        {
            rx = GetSettings();//получаем регулярное выражение

            string streaming = Convert.ToString(DateTime.Now) + " " + (string)Environment.UserName + " "  + TypeExeption + " " + TextExeption;//получаем строку которую нужно записать в файл
            Regex reg = new Regex(rx);
            if (reg.IsMatch(streaming)) //сравниваем записываемую строку с шаблоном регулярного выражения
            {
                try
                {
                    //записываем данные в поток
                    Console.WriteLine("попытка записи данных в файл...");
                    using (FileStream file = new FileStream(path, FileMode.Append))
                    {

                        using (StreamWriter wr = new StreamWriter(file, Encoding.UTF8))
                        {
                            wr.WriteLine(streaming);
                            
                        }

                    }
                    Console.WriteLine("данные успешно записаны и сохранены!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //в случае несоответствия записываемой строки и регулярного выражения выводим соответствующее сообщение
                Console.WriteLine("Incorrected data for Regex");
                Console.WriteLine(streaming);
                Console.WriteLine(rx);

            }
        }
    }
}
