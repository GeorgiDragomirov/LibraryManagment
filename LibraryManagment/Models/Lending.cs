using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagment.Models
{
    public class Lending
    {
        // Class to record the lending process in the college
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public  DateTime LendingDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool AmountPaid { get; set; }

        //Navigational Properties
        public Book Book { get; set; }
        public Member Member { get; set; }
    }
}
