using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        public bool ContentStatus { get; set; }
        public int HeadingID { get; set; } //ilişkili class ile aynı isimde olması lazım
        public virtual Heading Heading { get; set; }//ilişkili olan sınıftan  değer alacak

        public int? WriterID { get; set; } //ilişkili class ile aynı isimde olması lazım
        public virtual Writer Writer { get; set; } //ilişkili olan sınıftan değer alacak
    }
}
