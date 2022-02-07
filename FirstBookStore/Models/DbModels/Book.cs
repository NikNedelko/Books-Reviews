using System;
using System.ComponentModel.DataAnnotations;

namespace FirstBookStore.Models.DbModels
{
    public class Book
    {
        public int id { get; set; }
        [Required(ErrorMessage = "put name !")]
        public string name { get; set; }
        [Required(ErrorMessage = "put author here !")]
        public string author { get; set; }
        [Required(ErrorMessage = "put description !")]
        public string description { get; set; }
        [Range(0,100000,ErrorMessage = "put cost in !")]
        public int wasBuy { get; set; }
        public DateTime dateCreate { get; set; }
    }
}