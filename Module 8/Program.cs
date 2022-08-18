using System;
using System.IO;

class DiskInfo
{
    string name;
    int space;
    int freeSpace;

    public DiskInfo(string name, int space, int freeSpace)
    {
        Name = name;
        Space = space;
        FreeSpace = freeSpace;
    }

    public string Name
    {
        get { return name; }
        set { name = Name; }
    }

    public int Space
    {
        get { return space; }
        set
        {
            if (value > 0)
                space = value;
            else Console.WriteLine("Error");
        }
    }

    public int FreeSpace
    {
        get { return freeSpace; }
        set
        {
            if (value <= space)
                freeSpace = value;
            else Console.WriteLine("Error");
        }
    }
}

public class Folder
{
    public List<string> Files { get; set; } = new List<string>();

    Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

    public void CreateFolder(string name)
    {
        Folders.Add(name, new Folder());
        Console.WriteLine("New folder {0} was created", name);
    }
      
    
}


namespace DriveManager
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCatalogs(); //   Вызов метода получения директорий
        }

        static void GetCatalogs()
        {
            string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталогa

                int dirsCount = dirs.Length;

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);
                   

                


                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                int filesCount = files.Length;

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);

                int count = dirsCount + filesCount;

                Console.WriteLine("Files number = " + filesCount);
                Console.WriteLine("Dirs and files number = " + count);

                //DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Users\");

                //if (!dirInfo.Exists)
                //    dirInfo.Create();

                //Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);

                //dirInfo.CreateSubdirectory("NewFolder3");

                //Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                //Console.ReadKey();
                //dirInfo.Delete(true); // Удаление со всем содержимым
                //Console.WriteLine("Каталог удален");

                DirectoryInfo table = new DirectoryInfo(@"C:\test");
                if (!table.Exists)
                    table.Create();

                table.CreateSubdirectory("testFolder");
                Console.ReadKey();

                if (table.Exists && !Directory.Exists(@"C:\$Recycle.Bin"));
                                
                table.MoveTo(@"C:\$Recycle.Bin\testFolder1");
                
            }
            //Напишите метод, который считает количество файлов и папок в корне вашего диска и выводит итоговое количество объектов.
        }
    }
}


