using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPDFExample.Models
{
    public class Person
    {
        [Key]
        public Guid PersonId { get; set; }
        public string UserName { get; set; }
        public int LuckyNumber { get; set; }
    }
}