using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParseCSV
{

    //Retirar as colunas:
    //- id
    //- ip

    //Renomear:
    //- nome -> name
    //- email -> email
    //- data_aniversario -> birthdate

    //Campos nome e sobrenome devem ser contatenados com espaço, ex:
    //- John + ' ' + Doe

    //Datas devem ser convertidas para formato ISO, ex:
    //27/03/1989 -> 1989-03-27
    //Deve filtrar todas as linhas onde a pessoa for menor de 18 anos.
    //Salvar um CSV com as especificações acima.


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando o parse");            
            
            var projectDirectory = Environment.CurrentDirectory;
            string path = Directory.GetParent(projectDirectory).Parent.Parent.FullName;
            
            Console.WriteLine("Diretório onde está o arquivo csv: " +  path);
            
            string fileToDeserialize = File.ReadAllText(path + "/" + "test_data.csv");
            var Parser = new CsvParser();            
            var fileDeserialized = Parser.ParserCsv(fileToDeserialize);
            fileDeserialized.RemoveRange(0, 1);

            Console.WriteLine("Finalizando o parse do CSV para objeto person");

            var listPersonTotal = GetPeople(fileDeserialized);
            var listPersonFiltred = listPersonTotal.Where(a => (DateTime.Now.Year - Convert.ToDateTime(a.BirthDate).Year ) >= 18);            
            var listPeopleFinal = Parser.ParseToCsv(listPersonFiltred.ToList());

            Console.WriteLine("Finalizando filtro para idade superior a 18 anos");

            File.WriteAllLines(path + "/" + "test_data_convert.csv", listPeopleFinal);

            Console.WriteLine("Arquivo final criado em: "+  path +"/" + "test_data_convert.csv");
            Console.ReadKey();
        }

        private static List<Model> GetPeople(List<string[]> csvContent)
        {
            var people = new List<Model>();
            foreach (string[] line in csvContent)
            {
                var person = new Model
                {
                    Name = line[1] + " " + line[2],
                    Email = line[3],
                    BirthDate = Convert.ToDateTime(line[6]).ToString("yyyy-MM-dd")
                };
                people.Add(person);
            }
            return people;
        }
    }
}



;