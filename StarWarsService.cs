using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace Homework_25_03
{
    public class StarWarsService
    {
        public void Run()
        {
            const string PATH = ""; //на всякий случай
            const string FILE_NAME = "file.xml";

            JsonToXml jsonToXml = new JsonToXml();
            List<People> peoples = new List<People>();
            WebClient webClient = new WebClient();
            while (true)
            {
                int personInt;
                Console.WriteLine("\nВведите идентификатор персонажа \"Зведных войн\"");
                if(int.TryParse(Console.ReadLine(), out personInt))
                {
                    string jsonStr = webClient.DownloadString($"https://swapi.co/api/people/{personInt}");
                    People newPerson = JsonConvert.DeserializeObject<People>(jsonStr);
                    if(!People.IsExist(peoples, newPerson))
                    {
                        jsonToXml.WriteToFile(PATH + FILE_NAME, jsonStr);
                        peoples.Add(newPerson);
                        Console.WriteLine("Добавление в файл");
                        newPerson.Print();
                    }
                    else
                    {
                        Console.WriteLine("Уже существует");
                        foreach(var p in peoples)
                        {
                            if(p.Name == newPerson.Name)
                            {
                                p.Print();
                            }
                        }
                    }
                }
            }
        }
    }
}
