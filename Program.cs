using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using System.Text.Json;
using Newtonsoft.Json;


namespace Redo_Wk8Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create a book object and serialize it to a json file
            Book myBook = new Book
            {
                // create a book object with title, author, and year
                Title = "Dragon Ball",
                Author = "Akira Toriyama",
                Year = 1984
            };

            // serialize the book object to a json file
            string filePath = "book.json";
            SerializeBookToJson(myBook, filePath);

            // deserialize the json file to a book object
            Book deserializedBook = DeserializeJsonToBook(filePath);
            // print the deserialized book object
            Console.WriteLine("Title: " + deserializedBook.Title);
            Console.WriteLine("Author: " + deserializedBook.Author);
            Console.WriteLine("Year: " + deserializedBook.Year);
        }
        // craete a class called Book with properties Title, Author, and Year
        public class Book 
        {
            // properties
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }
        // creating method to serialize the book object to a json file
        public static void SerializeBookToJson(Book book, string filePath)
        {
            // serialize the book object to a json string
            // using System.Text.Json
            // string jsonString = JsonSerializer.Serialize(book);

            // using Newtonsoft.Json
            string jsonString = JsonConvert.SerializeObject(book, Formatting.Indented);
            // write the json string to a file
            File.WriteAllText(filePath, jsonString);
        }
        // creating method to deserialize the json file to a book object
        public static Book DeserializeJsonToBook(string filePath)
        {
            // read the json string from the file
            string jsonString = File.ReadAllText(filePath);
            // deserialize the json string to a book object using System.Text.Json
            // Book book = JsonSerializer.Deserialize<Book>(jsonString);

            // using Newtonsoft.Json
            Book book = JsonConvert.DeserializeObject<Book>(jsonString);
            return book;
        }
    }
}
