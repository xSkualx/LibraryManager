using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public  Status BookStatus { get; set; } = Status.NOT_TAKEN;

        public override string ToString()
        {
            return "Name: " + Name + " Author: " + Author + " Category: " + Category +" Language: "+Language+" Publication date: "+ PublicationDate.Year+"-"+PublicationDate.Month+"-"+PublicationDate.Day+" ISBN: "+ISBN+" Status: " + BookStatus;
        }


    }
}
