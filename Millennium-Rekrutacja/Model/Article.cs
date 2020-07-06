using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Millennium_Rekrutacja.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
        public string Tags { get; set; }
    }
}
