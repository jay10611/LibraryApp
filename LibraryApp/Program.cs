﻿
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
//text file is listOfBooks.txt
namespace LibraryApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] readText = File.ReadAllLines("../../../../listOfBooks.txt");
            List<Book> thelist = TextFileToBooKObject(readText);
            RunIt(thelist);


<<<<<<< HEAD
        public static List<Book> searchIndex()
        {
            Console.WriteLine("1. Author");
            Console.WriteLine("2. Title");
            Console.Write("Please select one of the above items to search by: ");
            int userChoice;
            List<Book> bookSearch = new List<Book>;

            do
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userChoice) && userChoice > 0 && userChoice < 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please select either 1 for Author or 2 for Title: ");
                }
            } while (true);

            switch (userChoice)
            {
                case 1:
                    {
                        Console.Write("Please enter in the last name of the Author you wish to search for: ");
                        string author = Console.ReadLine();

                        foreach (string book in listOfBooks)
                        {
                            if (listOfBooks[0] == author) Console.WriteLine(Book.Title);
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Please enter the Title of the book you are searching for: ");
                        string title = Console.ReadLine();


                    }
            }
                
        }

        public void AddBookTOList(Book newBook)
=======
        }
        public static void OverWritetextFile(List<Book> newList)
>>>>>>> 6b0940dc61225e44e577edbd54ad4d81df38b02d
        {
            foreach (Book book in newList)
            {
                var bookToAdd = $"{book.Author}<{book.Title}<{book.Status}<{book.DueDate}";
                File.WriteAllText("../../../../listOfBooks.txt", bookToAdd);
            }
        }

        public static string DateTimeToString()
        {
            DateTime now = DateTime.Now.AddDays(14);
            string dueDate = now.ToString("yyyy-MM-ddTHH:mm:ss.fff");
            return dueDate;
        }
        public static List<Book> TextFileToBooKObject(string[] readText)
        {
            List<Book> bookList = new List<Book>();
            foreach (string s in readText)
            {
                string[] catagory = s.Split('<');
                bookList.Add(new Book(catagory[0], catagory[1], catagory[2], catagory[3]));
            }
            return bookList;
        }
        public class Book

        {

            public Book()
            {
                Author = string.Empty;
                Title = string.Empty;
                Status = string.Empty;
                DueDate = string.Empty;
               
            }

            public Book(string author, string title, string status, string dueDate)
            {
                Author = author;
                Title = title;
                Status = status;
                DueDate = dueDate;
            }

            public string Author { get; set; }

            public string Title { get; set; }

            public string Status { get; set; }

            public string DueDate { get; set; }
            public string Mainlist { get; set; }
        }
        public static void AddBook()
        {
            var dateAndTime = DateTime.Now;
            Console.WriteLine("What is the name of the book you want to add?");
            string author = Console.ReadLine();
            Console.WriteLine("Please enter the authors name");
            string title = Console.ReadLine();
            string status = "Availible";
            var dueDate = dateAndTime.Date;
            using (StreamWriter addRecord = File.AppendText("../../../../listOfBooks.txt"))
                addRecord.WriteLine($"{title}<{author}<{status}<{dueDate}");
            Console.WriteLine("The book has been added!");
        }
        public static void SearchCatagory(int userChoice,List<Book> thelist)
        {
            var indexToSearch = userChoice -1;
            string[] readText = File.ReadAllLines("../../../../listOfBooks.txt");
            if (indexToSearch == 0)
            {
                Console.WriteLine("Please enter the name of the author you would like to search for");
                var searchCritera = Console.ReadLine();
                {
                    foreach (Book book in thelist)
                    {
                        if (searchCritera.Contains(book.Author, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Author:{book.Author} Title:{book.Title}");
                        }
                    }
                }
            }

            if (indexToSearch == 1)
            {
                Console.WriteLine("Please enter the title you would like to search for");
                var searchCritera = Console.ReadLine();
                {
                    foreach (Book book in thelist)
                    {
                        if (searchCritera.Contains(book.Title, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine($"Author:{book.Author} Title:{book.Title}");
                        }
                    }
                }
            }
            
        }
        public static void DisplayAllBooks(List<Book> thelist)
        {
            foreach (Book book in thelist)
            {
                Console.WriteLine($"Author:{book.Author} Title:{book.Title} Status:{book.Status}");
            }

        }
        public static void DisplayAllAvailibleBooks(List<Book> thelist)
        {
            foreach (Book book in thelist)
            {
                ;
                if(book.Status == "Availible")
                {
                    Console.WriteLine($" Author:{book.Author} Title:{book.Title}");
                }
            }
            
        }  
        public static List<Book> CheckoutABook(List<Book> thelist)
        {
            List<Book> newList = new List<Book>();
            Console.WriteLine("please enter the title of the book would you like to check out?");
            string userChoice = Console.ReadLine();
            foreach (Book book in thelist)
            {
                if (userChoice == book.Title && book.Status == "Availible")
                {
                    Console.WriteLine($"Thank you for checking out {book.Title} by {book.Author}");
                    book.Status = "out";
                }
                newList.Add(new Book(book.Author, book.Title, book.Status, book.DueDate));
            }
            return newList;
        }
        public static List<Book> ReturnABook(List<Book> thelist)
        {
            List<Book> newList = new List<Book>();
            Console.WriteLine("please enter the title of the book would you like to return?");
                string userChoice = Console.ReadLine();
            foreach (Book book in thelist)
            {
                if (userChoice == book.Title && book.Status == "out")
                {
                    Console.WriteLine($"Thank you for returnin {book.Title} by {book.Author}");
                    book.Status = "Availible";
                    
                }
                newList.Add(new Book(book.Author, book.Title, book.Status, book.DueDate));
                
            }
              return newList;
        }
            
        public static void SearchIt(List<Book> thelist)
        {
            int userChoice;
            Console.WriteLine("What would you like to search by");
            Console.WriteLine("[1] Search by author");
            Console.WriteLine("[2] Search by title");

            string userinput = Console.ReadLine();
            if (int.TryParse(userinput, out userChoice) && userChoice > 0 && userChoice < 2)
            {
                SearchCatagory(userChoice, thelist);
            }
            while (true) ;
        }
        public static void RunIt(List<Book> thelist)
        {

            int userChoice;
            Console.WriteLine("Welcome to our library what would you like to do?");
            Console.WriteLine("[1] See all books");
            Console.WriteLine("[2] See all availible books");
            Console.WriteLine("[3] Search books");
            Console.WriteLine("[4] Add a book");
            Console.WriteLine("[5] Checkout a book");
            Console.WriteLine("[6] Return a book");
            string userinput = Console.ReadLine();
            if (int.TryParse(userinput, out userChoice) && userChoice > 0 && userChoice < 7)
            {
                switch (userChoice)
                {
                    case 1:
                        DisplayAllBooks(thelist);
                        break;
                    case 2:
                        DisplayAllAvailibleBooks(thelist);
                        break;
                    case 3:
                        SearchIt(thelist);
                        break;
                    case 4:
                        AddBook();
                        break;
                    case 5:
                        CheckoutABook(thelist);
                        OverWritetextFile(thelist);
                            break;
                    case 6:
                        ReturnABook(thelist);
                        OverWritetextFile(thelist);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            }
             while (true);
        }
    }

}
