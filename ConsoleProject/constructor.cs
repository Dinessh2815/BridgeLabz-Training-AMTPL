using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{

    internal class book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }

        private string password;
        public string Password
        {
            set
            {
                if(value.Length > 8)
                {
                    password = value;
                }
                else
                {
                    Console.Write("password length too short");
                }
            }
        }

        public book(int id, string title, string author)
        {
            Title = title;
            Author = author;

            Console.WriteLine($"Title : {Title} \nauthor : {Author}");
        }


    }
}
