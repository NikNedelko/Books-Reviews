using System;
using System.ComponentModel.DataAnnotations;

namespace FirstBookStore.Models.DbModels
{
    public class Comment
    {
        public int id { get; set; }
        public int BookId { get; set; }
        //
        [MaxLength(30,ErrorMessage = "Max length of username/name -> 30")]
        public string AuthorOfComment { get; set; }
        //
        //
        [MaxLength(180,ErrorMessage = "Max length of comment -> 180")]
        public string BodyOfComment { get; set; }
        //
        public DateTime DateAdd { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}