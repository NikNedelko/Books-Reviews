using System;
using System.ComponentModel.DataAnnotations;

namespace FirstBookStore.Models.DbModels
{
    public class Book
    {
        public int id { get; set; }
        [Required(ErrorMessage = "put name !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "put author here !")]
        public string Author { get; set; }
        [Required(ErrorMessage = "put description !")]
        public string Description { get; set; }
        [Range(0,100000,ErrorMessage = "put correct cost in !")]
        public int WasBuy { get; set; }
        public DateTime DateCreate { get; set; }
        public string LinkToPict { get; set; }
    }
}