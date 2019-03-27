using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StormLight2.Models
{
    public class CharacterModel
    {
        public int Character_Id { get; set; }
        public string Character_Name { get; set; }
        public string Abilities { get; set; }
        public string Bonded_With { get; set; }
        public string Titles { get; set; }
        public string Groups { get; set; }
        public string Knight_Orders_Name { get; set; }
        public string Surges { get; set; }
        public string Character_Image { get; set; }
    }
}
