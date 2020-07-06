using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.Enums;

namespace Millennium_Rekrutacja.BindingModel
{
    public class ArticleUpdateBindingModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ArticleStatus Status { get; set; }
        public string Tags { get; set; }
    }
}
