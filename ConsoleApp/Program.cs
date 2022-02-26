using ConsoleApp.Commands;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            PersonsClient client = new PersonsClient("https://localhost:7198");

            string path = "/api/persons";

            // 1. Get Datas
            //await client.GetAll(path);

            // 2. Get Data By Id
            //await client.GetById(path);

            // 3.Post Data
            //await client.Add(path);

            //4.Update Data
            await client.Put(path);

            // 5.Delete Data
            //await client.Delete(path);

            Console.ReadKey();
        }
    }
}
