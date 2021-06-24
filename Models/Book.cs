using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab02.Models
{
    public class Book
    {
        public Book(int id, string bookName, string author,  string img, double price)
        {
            Id = id;
            BookName = bookName;
            Author = author;
            this.Price = price;
            Img = img;
        }
        public Book() { }

        [Key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public double Price { get; set; }
        public string Img { get; set; }
    }
}