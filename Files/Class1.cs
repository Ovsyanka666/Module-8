using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;

class BinaryExperiment
{
    const string SettingsFileName = "Settings.cfg";
    const string TestFileName = @"D:\SkillFuck\BinaryFile.bin";

    //static void Main()
    //{
    //    // Пишем
    //    WriteValues(TestFileName);
    //    // Считываем
    //    ReadValues(TestFileName);


    //}

    static void WriteValues(string path)
    {
        // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
        using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
        {
            // записываем данные в разном формате
            
            writer.Write($"Файл изменен {DateTime.Now} на компьютере Windows 10");
            
        }
    }

    static void ReadValues(string path)
    {
        
        string StringValue;
        

        if (File.Exists(path))
        {
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                // Применяем специализированные методы Read для считывания соответствующего типа данных.
                
                StringValue = reader.ReadString();
                
            }

            Console.WriteLine("Из файла считано:");

           
            Console.WriteLine("Строка: " + StringValue);
           
        }
    }
}

