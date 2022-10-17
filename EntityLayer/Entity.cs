using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customers
    {
        public int cid { get; set; }
        public string cname { get; set; }
        
        public string cpassword { get; set; }
        
    }
    public class Employees
    {
        public int eid { get; set; }
        public string ename { get; set; }
        
        public string epassword { get; set; }
    }
    public class Rooms
    {
        public int rno { get; set; }
        public string rtype { get; set; }
        //public int roomprice { get; set; }
    }
    public class Reservation
    {
        public int rcid { get; set; }
        public int rdays { get; set; }

        public int roomno { get; set; }
    }
}
