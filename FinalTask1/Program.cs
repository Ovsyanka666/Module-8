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
        DirectoryInfo testFolder = new DirectoryInfo(@"C:\test");

        Console.WriteLine($"Размер папки {testFolder.Name} " + DirSize(testFolder) + " байт"); //используем метод для вычисления размера папки
        MeasureAndClean(testFolder);  //вызов метода для вывода размера папки и её очистки
        
        //Cleaning30min(testFolder);  //вызов метода для очисти папки
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

    public static void QuietCleaning30min(DirectoryInfo dir)
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
                    file.Delete();
                }
            }
        }

        else Console.WriteLine("Папки по указанному пути не существует");

    }   //делает то же, что и предыдущий метод, но не выводит в консоль сообщения об удалении файлов/папок

    public static long DirSize(DirectoryInfo dir)
    {
        long size = 0;
        if (dir.Exists)
        {
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] nextDir = dir.GetDirectories();
            foreach (DirectoryInfo directory in nextDir)
            {
                size += DirSize(directory);

            }
        }
        else Console.WriteLine("Папки по указанному пути не существует");
        return size;
    }       //метод для вычисления размера папки (задание 2)

    public static void MeasureAndClean(DirectoryInfo dir)
    {
        if (dir.Exists)
        {
            long sizeBefore = DirSize(dir);
            Console.WriteLine($"Размер папки {dir.Name} до очистки {sizeBefore} байт");
            int filesBefore = FileCounter(dir);
            QuietCleaning30min(dir);
            int filesAfter = FileCounter(dir);
            long sizeAfter = DirSize(dir);

            Console.WriteLine($"Было удалено {filesBefore - filesAfter} файлов весом {sizeBefore - sizeAfter} байт");
            Console.WriteLine($"Размер папки {dir.Name} после очистки {sizeAfter} байт");
        }

        else Console.WriteLine("Папки по указанному пути не существует");
    }      //вычисление размера папки и очистка (задание 3)

    public static int FileCounter(DirectoryInfo dir)
    {
        int count = 0;

        if (dir.Exists)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();


            foreach (FileInfo file in files)
                count++;

            foreach (DirectoryInfo di in dirs)
                count += FileCounter(di);
        }
        else Console.WriteLine("Папки по указанному пути не существует");
        return count;
    }     //метод для подсчёта файлов в папке
}