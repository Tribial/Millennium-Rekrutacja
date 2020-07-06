using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.Enums;

namespace Millennium_Rekrutacja.ViewModel
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ArticleStatus Status { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
