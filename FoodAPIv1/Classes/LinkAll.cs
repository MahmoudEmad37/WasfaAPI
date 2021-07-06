using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodAPIv1.Classes
{
    public class LinkAll
    {
        public int Id { get; set; }
        public string Link { get; set; }

        public LinkAll(int id, string link)
        {
            Id = id;
            Link = link;
        }
    }
}