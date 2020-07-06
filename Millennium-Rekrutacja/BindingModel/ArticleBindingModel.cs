using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Millennium_Rekrutacja.Common.Enums;

namespace Millennium_Rekrutacja.BindingModel
{
    public class ArticleBindingModel
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }
        [StringLength(1024)]
        public string Content { get; set; }
        [Required]
        public ArticleStatus Status { get; set; }
        [StringLength(128)]
        public string Tags { get; set; }
    }
}
