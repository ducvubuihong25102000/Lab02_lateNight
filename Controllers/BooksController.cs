using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lab02;
using Lab02.Models;

namespace Lab02.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        private List<Book> ListBooks;
        public BooksController()
        {
            ListBooks = new List<Book>();
            ListBooks.Add(new Book(1,"Tôi Thấy Hoa Vàng Trên Cỏ Xanh","Nguyễn Nhật Ánh","Content/Images/ToiThayHoaVangTrenCoXanh.jpg",100000));
            ListBooks.Add(new Book(1, "Cho Tôi Một Vé Đi Tuổi Thơ", "Nguyễn Nhật Ánh", "Content/Images/ChoToiMotVeDiTuoiTho.jpg", 100000));
            ListBooks.Add(new Book(1, "Rừng Na Uy", "Hikaruma", "Content/Images/RungNauy.jpg", 125000));
            ListBooks.Add(new Book(1, "Du Hành Vào Xứ Phẳng", "Adam", "Content/Images/XuPhang.jpg", 80000));
            ListBooks.Add(new Book(1, "Harry Potter và chiếc cốc lửa", "JK.Rowling", "Content/Images/ChiecCocLua.jpg", 168000));
        }

        public ActionResult ListBooks_()
        {
            ViewBag.TitlePageName = "Book view page";
            return View(ListBooks);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Book book = ListBooks.Find(s => s.Id == id);
            if (book == null)
                return HttpNotFound();

            return View(book);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Book book = ListBooks.Find(s => s.Id == id);

            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editbook = ListBooks.Find(b => b.Id == book.Id);
                    editbook.BookName = book.BookName;
                    editbook.Author = book.Author;
                    editbook.Price = book.Price;
                    return View("ListBooks_", ListBooks);
                }
                catch(Exception e)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Input Model not valid");
                return View(book);
            }
            return View();
        }
    }
}