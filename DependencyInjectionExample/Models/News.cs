using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionExample.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string FileName { get; set; }

        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
