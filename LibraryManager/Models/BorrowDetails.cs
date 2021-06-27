using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager
{
    public class BorrowDetails
    {
       public string ID { get; set; }
       public DateTime TakeTime { get; set; }
       public DateTime ReturnTime { get; set; }
       public Book TakenBook { get; set; }
    }
}
