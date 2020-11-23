using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //в случае запуска этой программы на другом пк, она сначала создаст файл, запишет туда регулярное выражение а потом будет его же и считывать
            using (FileStream str = new FileStream("my.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(str, Encoding.UTF8))
                {
                    sw.Write(@"^\d{2}\.\d{2}\.\d{4}\s\d*\:\d{2}\:\d{2}\s\S*\s\w*\w*");
                }
            }
                Logger lg = new Logger();
            lg.record("ошибка отказано в доступе к ресурсу","Error");
            lg.record("попытка несанкционированного доступа к ресурсу", "information");
        }
    }
}
