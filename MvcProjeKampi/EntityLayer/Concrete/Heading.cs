using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public bool HeadingStatus { get; set; }
        public int CategoryID { get; set; } //ilişkili classla aynı olmalı
        public virtual Category Category { get; set; }//ilişkili olan category classından değer alacak

        public int WriterID { get; set; } //ilişkili class ile aynıu olmalı
        public virtual Writer Writer { get; set; }//ilişkili olan writer classından değer alacak

        public ICollection<Content> Contents { get; set; }//
        //Content classıyla ilişki için Content tipinde koleksiyon türünde property oluşturuyoruz

    }
}
