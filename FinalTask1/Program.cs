using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;


class Task
{
    static void Main()
    {        
        DirectoryInfo testFolder = new DirectoryInfo(@"C:\test");  //вызов метода для очисти папки
        Cleaning30min(testFolder);
    }

    public static void Cleaning30min(DirectoryInfo dir)
    {
        if (dir.Exists) //проверяем наличие папки
        {

            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();

            foreach (DirectoryInfo di in dirs)   //удаляем старые папки
            {
                DateTime now = DateTime.Now;
                if (now.Subtract(di.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine($"{di.Name} was deleted");
                    di.Delete(true);
                }
                else
                {
                    Cleaning30min(di);
                }
            }

            foreach (FileInfo file in files)
            {
                DateTime now = DateTime.Now;
                if (now.Subtract(file.LastAccessTime) > TimeSpan.FromMinutes(30))
                {
                    Console.WriteLine($"{file.Name} was deleted");
                    file.Delete();
                }
            }
        }

        else Console.WriteLine("Папки по указанному пути не существует");

    }
}