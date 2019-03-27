using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StormLight2.Models
{
    public class BookModel
    {
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public string Published { get; set; }
        public string Book_Cover { get; set; }
        public string Book_Image { get; set; }
        public int Character_Id { get; set; }
        public string Character_Name { get; set; }

    }
}