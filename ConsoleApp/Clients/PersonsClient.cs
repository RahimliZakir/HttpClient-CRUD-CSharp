using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Commands
{
    public class PersonsClient
    {
        HttpClient client = new HttpClient();

        public PersonsClient(string apiLink)
        {
            this.client.BaseAddress = new Uri(apiLink);
        }

        async public Task GetAll(string path)
        {
            HttpResponseMessage getResponse = await client.GetAsync(path);

            if (getResponse.IsSuccessStatusCode)
            {
                string data = await getResponse.Content.ReadAsStringAsync();

                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine($"Xəta baş verdi: {getResponse.StatusCode}.");
            }
        }

        async public Task GetById(string path)
        {
        againId:
            Console.Write("Çağırılmasını istədiyiniz məlumatın Id-sini daxil edin: ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
                goto againId;

            bool result = int.TryParse(text, out int intText);
            if (result == false)
                goto againId;

            int id = intText;

            path = $"{path}/{id}";

            HttpResponseMessage getResponse = await client.GetAsync(path);

            if (getResponse.IsSuccessStatusCode)
            {
                string data = await getResponse.Content.ReadAsStringAsync();

                Console.WriteLine(data);
            }
            else
            {
                Console.WriteLine($"Xəta baş verdi: {getResponse.StatusCode}.");
            }
        }

        async public Task Add(string path)
        {
        nameAgain:
            Console.Write("Person adını daxil edin: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                goto nameAgain;

            surnameAgain:
            Console.Write("Person soyadını daxil edin: ");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
                goto surnameAgain;

            ageAgain:
            Console.Write("Person yaşını daxil edin: ");
            string age = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(age))
                goto ageAgain;

            bool result = int.TryParse(age, out int intAge);
            if (!result)
                goto ageAgain;

            var obj = new
            {
                name,
                surname,
                age = intAge
            };

            string serializedObj = JsonConvert.SerializeObject(obj);

            StringContent content = new StringContent(serializedObj, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage postResponse = await client.PostAsync(path, content);

            if (postResponse.IsSuccessStatusCode)
            {
                string text = await postResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Person uğurla yaradıldı!");
            }
            else
            {
                Console.WriteLine($"Xəta baş verdi: {postResponse.StatusCode}.");
            }
        }

        async public Task Put(string path)
        {
        againId:
            Console.Write("Çağırılmasını istədiyiniz məlumatın Id-sini daxil edin: ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
                goto againId;

            bool result = int.TryParse(text, out int intText);
            if (result == false)
                goto againId;

            int id = intText;

            path = $"{path}/{id}";

        nameAgain:
            Console.Write("Person adını daxil edin: ");
            string name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                goto nameAgain;

            surnameAgain:
            Console.Write("Person soyadını daxil edin: ");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
                goto surnameAgain;

            ageAgain:
            Console.Write("Person yaşını daxil edin: ");
            string age = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(age))
                goto ageAgain;

            bool resultAge = int.TryParse(age, out int intAge);
            if (resultAge != true)
                goto ageAgain;

            var person = new
            {
                id,
                name,
                surname,
                age = intAge,
                createdDate = "2021-12-22T22:51:11.447Z"
            };

            string serializedObj = JsonConvert.SerializeObject(person);

            StringContent content = new StringContent(serializedObj, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpResponseMessage putResponse = await client.PutAsync(path, content);

            if (putResponse.IsSuccessStatusCode)
            {
                string readed = await putResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Person uğurla yeniləndi!");
            }
            else
            {
                Console.WriteLine($"Xəta baş verdi: {putResponse.StatusCode}.");
            }
        }

        async public Task Delete(string path)
        {
        againId:
            Console.Write("Çağırılmasını istədiyiniz məlumatın Id-sini daxil edin: ");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
                goto againId;

            bool result = int.TryParse(text, out int intText);
            if (result == false)
                goto againId;

            int id = intText;

            path = $"{path}/{id}";

            HttpResponseMessage deleteResponse = await client.DeleteAsync(path);

            if (deleteResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Seçdiyiniz məlumat uğurla silindi!");
            }
            else
            {
                Console.WriteLine($"Xəta baş verdi: ${deleteResponse.StatusCode}.");
            }
        }
    }
}
