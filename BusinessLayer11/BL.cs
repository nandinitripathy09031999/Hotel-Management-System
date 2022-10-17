using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer11;
using EntityLayer;

namespace BusinessLayer11
{
    public class Business
    {
        

        public bool CustomerCheck(Customers c)
        {
            var res = false;
            var dal = new DataAccess();
            res = dal.Customer_Check(c);
            return res;

        }
       /* public bool CustomerCheckById(int c)
        {
            var res = false;
            var dal = new DataAccess();
            res = dal.Customer_Check_By_Id(c);
            return res;

        }*/
        public bool EmployeeCheck(Employees emp)
        {
            var res = false;
            var dal = new DataAccess();
            res = dal.Employee_Check(emp);
            return res;

        }

        public void CustomerAdd(Customers c)
        {
            var dal = new DataAccess();
            dal.Customer_Add(c);

        }
        public void EmployeeAdd(Employees emp)
        {
            var dal = new DataAccess();
            dal.Employee_Add(emp);

        }

        public void CustomerDelete(int c)
        {
            var dal = new DataAccess();
            dal.Customer_Delete(c);

        }

        public bool RoomAdd(Rooms ro)
        {
            var res = false;
            var dal = new DataAccess();
            res=dal.Room_Add(ro);
            return res;

        }
        public bool RoomDelete(Rooms ro)
        {
            var res = false;
            var dal = new DataAccess();
            if (dal.Room_Delete(ro) == 0)
                res = false;
            else
                res = true;
            return res;

        }

        public bool ReservationDelete(int rid)
        {
            var res = false;
            var dal = new DataAccess();
            if (dal.Reservation_Delete(rid) == 0)
                res = false;
            else
                res = true;
            return res;

        }



        public List<Rooms> GetallRooms()
        {
            var dal = new DataAccess();
            var lstrooo = dal.GetAllRooms();
            
            return lstrooo;
        }
        public List<Customers> GetallCustomers()
        {
            var dal = new DataAccess();
            var lstcust = dal.GetAllCustomers();
            return lstcust;
        }


        public bool CheckOut(Customers c)
        {
            var res = false;
            var dal = new DataAccess();
            if (dal.Check_Out(c) == 0)
                res = false;
            else
                res = true;
            return res;

        }

        public int ReserveRoom(Reservation res)
        {
            int value = 0;
            var dal = new DataAccess();
            value=dal.Reserve_Room(res);      
            return value;
        }
    }
}
