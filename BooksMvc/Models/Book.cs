using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMvc.Models {
    public class Book {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        
        public string ISBN { get; set; }

        public Book() { 
        }

        public Book(string name, string author, string iSBN) {
            Name = name;
            Author = author;
            ISBN = iSBN;
        }
    }
}
