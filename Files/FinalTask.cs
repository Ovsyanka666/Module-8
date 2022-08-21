using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {            
            string path = @"C:\Users\Pisiyshka\Downloads\Students.dat";
            Sorting(path);
        }
           
        static void Sorting(string Path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using FileStream fs = new FileStream(Path, FileMode.OpenOrCreate);
            {
                try
                {
                    Student[] Students = (Student[])formatter.Deserialize(fs);

                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    DirectoryInfo dirinfo = new DirectoryInfo(desktopPath + @"\Students");
                    if (!dirinfo.Exists) dirinfo.Create();

                    string dirFullName = dirinfo.FullName;

                    foreach (Student stud in Students)
                    {
                        string filePath = dirFullName + @"\" + stud.Group + ".txt";
                        string strToWrite = stud.Name + ", " + stud.DateOfBirth.ToString();
                                                
                        FileInfo fileInfo = new FileInfo(filePath);
                        using (StreamWriter sw = fileInfo.AppendText())
                        {
                            sw.WriteLine(strToWrite);
                        }   
                    }

                    Console.WriteLine("Sorting complete.");
                    Console.ReadKey();
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }        
    }
}