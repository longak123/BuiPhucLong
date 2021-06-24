using baitap3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace baitap3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public string HelloTeacher(string university)
        {
            return "Hello Bui Phuc Long - Unibersity: " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The complete Manual - Author Same Book 1");
            books.Add("biết cần làm");
            books.Add("khôn biết");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???", "/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg "));
            books.Add(new Book(2, "biết gì", "??", "/Content/Images/download.jpg "));
            books.Add(new Book(3, "biết gì", "??", "/Content/Images/mau-bia-sach-dep.jpg "));
            return View(books);

        }
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???", "/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg "));
            books.Add(new Book(2, "biết gì", "??", "/Content/Images/download.jpg "));
            books.Add(new Book(3, "biết gì", "??", "/Content/Images/mau-bia-sach-dep.jpg "));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int Id, string Title, string Author, string Image_cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???", "/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg "));
            books.Add(new Book(2, "biết gì", "??", "/Content/Images/download.jpg "));
            books.Add(new Book(3, "biết gì", "??", "/Content/Images/mau-bia-sach-dep.jpg "));
            if (Id == null)
            {
                return HttpNotFound();
            }
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = Image_cover;
                    break;

                }
            }
            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "Id, Title, Author, Image_cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???", "/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg"));
            books.Add(new Book(2, "biết gì", "??", "/Content/Images/download.jpg"));
            books.Add(new Book(3, "biết gì", "??", "/Content/Images/mau-bia-sach-dep.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
                throw;
            }
            return View("ListBookModel", books);

        }

        public ActionResult DeleteBook(int Id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???", "/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg "));
            books.Add(new Book(2, "biết gì", "??", "/Content/Images/download.jpg "));
            books.Add(new Book(3, "biết gì", "??", "/Content/Images/mau-bia-sach-dep.jpg "));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [HttpPost, ActionName("DeleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "biết gì", "tac gia dau???","/Content/Images/19f5f71b440cdbab667206d951043ef9.jpg"));
            books.Add(new Book(2, "biết gì", "??","/Content/Images/download.jpg"));
            books.Add(new Book(3, "biết gì", "??","/Content/Images/mau-bia-sach-dep.jpg"));
            Book b = books.Find(s => s.Id == Id);
            books.Remove(b);
            return View("ListBookModel", books);
        }

    }


}
