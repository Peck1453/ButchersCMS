using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butchers.Data.BEANS
{
    public class MessageBEAN
    {
        [Display(Name = "Subject")]
        public string MessageSubject { get; set; }

        [Display(Name = "Message")]
        public string MessageBody { get; set; }

        [Display(Name = "Author")]
        public string MessageAuthor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Posted")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MessageDate { get; set; }
    }
}
