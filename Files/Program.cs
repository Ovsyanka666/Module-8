using System;
using System.IO;
class FileWriter
{

    
    public static void Main()
    {
        DirectoryInfo test = new DirectoryInfo(@"D:\VS Projects");        
        DirectoryInfo test2 = new DirectoryInfo(@"D:\Рисунки");
        

        FileInfo config = new FileInfo(@"C:\test\Config.txt");

        using (StreamWriter sw = config.AppendText())
        {
            WriteFolderInfo(test, sw);
            WriteFileInfo(test2.GetFiles(), sw);
        }

            var fileInfo1 = new FileInfo(@"D:\VS Projects\SkillFac\Module 8\Files\Program.cs");
        using (StreamWriter sw = fileInfo1.AppendText())
        {
            sw.WriteLine("//Последний запуск " + DateTime.Now);
        }
    }

    public static long DirSize(DirectoryInfo dir, StreamWriter sw)
    {
        long size = 0;

        FileInfo[] files = dir.GetFiles();
        foreach (FileInfo file in files)
        {
            size += file.Length;
        }

        DirectoryInfo[] nextDir = dir.GetDirectories();
        foreach (DirectoryInfo directory in nextDir)
        {
            size += DirSize(directory, sw);

        }
        return size;
    }
    public static void WriteFolderInfo(DirectoryInfo dir, StreamWriter sw)
    {
        sw.WriteLine();
        sw.WriteLine("Папки: ");
        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo di in dirs)
        {
            sw.WriteLine(di.Name + " - размер в байтах " + DirSize(di, sw));
        }
    }

    public static void WriteFileInfo(FileInfo[] files, StreamWriter sw)
    {
        sw.WriteLine();
        sw.WriteLine("Файлы: ");
        foreach (FileInfo file in files)
            sw.WriteLine(file.Name + " - размер в байтах " + file.Length);
    }
    
}
//Последний запуск 18.08.2022 20:02:26
//Последний запуск 18.08.2022 20:02:42
//Последний запуск 18.08.2022 20:30:46
//Последний запуск 18.08.2022 20:34:17
//Последний запуск 18.08.2022 20:35:24
//Последний запуск 18.08.2022 21:29:52
//Последний запуск 18.08.2022 21:30:46
//Последний запуск 18.08.2022 21:53:02
//Последний запуск 18.08.2022 21:54:08
//Последний запуск 18.08.2022 21:55:04
//Последний запуск 18.08.2022 21:55:43
//Последний запуск 18.08.2022 21:56:06
