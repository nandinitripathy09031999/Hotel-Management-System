using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer11
{
    public class DataAccess
    {
        SqlConnection con;
        public DataAccess()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
        }

        public int AddEmployee(Employees emp)
        {
            int recordsAffected = 0;
            try
            {
                //INSERT operation 
                //2. Configure the SqlCommand for INSERT statement
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                //3. specify the command text for INSERT
                cmd.CommandText = "insert into tbl_employees values(@ec,@en,@sal,@did)";
                //4. specify the values for the parameters
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", emp.eid);
                cmd.Parameters.AddWithValue("@en", emp.ename);
                cmd.Parameters.AddWithValue("@sal", emp.epassword);
                //5. open the connection
                con.Open();
                //6. attach the connection with the command
                cmd.Connection = con;
                //7. execute the command 
                recordsAffected = cmd.ExecuteNonQuery();
                
                if (recordsAffected == 0)
                {
                    throw new Exception("Registration unsuccessful");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }

            return recordsAffected;
        }

         public bool Customer_Check(Customers c)
         {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                string query = "SELECT * FROM customer WHERE id=@userid AND password=@userpwd";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@userid", c.cid));
                cmd.Parameters.Add(new SqlParameter("@userpwd", c.cpassword));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }
        }

        public bool Customer_Check_By_Id(int c)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                string query = "SELECT * FROM customer WHERE id=@userid";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("@userid",c));
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
                if (dr.HasRows == true)
                    return true;
                else
                    return false;
            }
           
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }

        }


        public bool Employee_Check(Employees emp)
        {
            try { 
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
            con.Open();
            string query = "SELECT * FROM employee WHERE id=@userid AND password=@userpwd";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@userid", emp.eid));
            cmd.Parameters.Add(new SqlParameter("@userpwd", emp.epassword));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
                return true;
            else
                return false; 
        }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }
        }



        public void Customer_Add(Customers c)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO customer VALUES('"+c.cname+"','"+c.cpassword+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Employee_Add(Employees emp)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO employee VALUES('" + emp.ename + "','" + emp.epassword + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public bool Room_Add(Rooms ro)
        {
            bool b = false;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                if(ro.rtype.Equals("A") || ro.rtype.Equals("N"))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO room VALUES('" + ro.rtype + "')", con);
                    cmd.ExecuteNonQuery();
                    b = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }
            return b;
        }

        public int Room_Delete(Rooms ro)
        {
            int recordsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from room where no=@roomnumber";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@roomnumber", ro.rno);
                cmd.Connection = con; 
                con.Open();
                recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Entered room doesn't exist");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return recordsAffected;
        }

        public int Reservation_Delete(int rid)
        {
            int recordsAffected = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reservation where reservationid=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", rid);
                cmd.Connection = con;
                con.Open();
                recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("No reservation found to delete!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return recordsAffected;
        }



        public List<Rooms> GetAllRooms()
        {
                    List<Rooms> lstRooms = new List<Rooms>();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select * from room";
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Rooms rom = new Rooms
                        {
                            rno = (int)sdr[0],
                            rtype = sdr[1].ToString(),
                        };
                        lstRooms.Add(rom);
                    }
                    sdr.Close();
                    con.Close();
                    return lstRooms;  
        }

        public List<Customers> GetAllCustomers()
        {
            List<Customers> lstCustomers = new List<Customers>();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from customer";
            cmd.Connection = con;
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Customers custom = new Customers
                {
                    cid = (int)sdr[0],
                    cname = sdr[1].ToString(),
                    cpassword= sdr[2].ToString(),
                };
                lstCustomers.Add(custom);
            }
            sdr.Close();
            con.Close();
            return lstCustomers;
        }

        public int Check_Out(Customers c)
        {
            int recordsAffected = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reservation where customerid=@number";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@number", c.cid);
                cmd.Connection = con;
                recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("No reservation found");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

            return recordsAffected;
        }

        public void Customer_Delete(int c)
        {
            int recordsAffected = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from reservation where customerid=@number";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@number", c);
                cmd.Connection = con;
                recordsAffected = cmd.ExecuteNonQuery();
                if (recordsAffected == 0)
                {
                    throw new Exception("Payment failed...Couldn't checkout!!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }


        public int Reserve_Room(Reservation res)
        {
            int recordsAffected = 0;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into reservation values(@a,@b,@c)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@a", res.rdays);
                cmd.Parameters.AddWithValue("@b", res.roomno);
                cmd.Parameters.AddWithValue("@c", res.rcid);
                cmd.Connection = con;
                recordsAffected = cmd.ExecuteNonQuery();
                
                if (recordsAffected == 0)
                {
                    throw new Exception("Reservation unsuccessful");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                //8. close the connection
                con.Close();
            }
            return recordsAffected;
        }














        //UNDER CONSTRUCTION
        /* public int Reserve_Room(Reservation res)
         {
             int result = 0;
             int recordsAffected = 0;
             List<int>rr=new List<int>();
             try
             {
                 SqlConnection con = new SqlConnection();
                 con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HMS;Integrated Security=True;";
                 con.Open();

                 SqlCommand cmd = new SqlCommand();
                 cmd.Connection = con;
                 cmd.CommandType = CommandType.Text;
                 string query2 = "declare @usertype varchar(100) not null";
                 string query3 = "declare @usertype1 varchar(100) not null";
                 cmd = new SqlCommand(query2, con);
                 cmd = new SqlCommand(query3, con);
                 string query = "SELECT MAX(SELECT no FROM room WHERE type=@usertype AND no NOT EXISTS(SELECT reservation.roomno FROM reservation WHERE EXISTS (SELECT room.no FROM room WHERE room.type=@usertype1))))";
                 cmd = new SqlCommand(query, con);
                 cmd.Parameters.Add(new SqlParameter("@usetype", res.roomtype));
                 cmd.Parameters.Add(new SqlParameter("@usetype1", res.roomtype));

                 //con.Open();
                 SqlDataReader sdr = cmd.ExecuteReader();
                 int no;
                 while (sdr.Read())
                 {
                     object v = sdr[0];
                     no = (int)v;
                     rr.Add(no);
                 }

                 foreach (int v in rr)
                     result += v;
                 if (result != 0) { 
                 SqlCommand cmd1 = new SqlCommand();
                 cmd1.CommandType = CommandType.Text;
                 cmd1.CommandText = "insert into reservation values(@a,@b,@c)";
                 cmd1.Parameters.Clear();
                 cmd1.Parameters.AddWithValue("@a", res.rdays);
                 cmd1.Parameters.AddWithValue("@b", rr);
                 cmd1.Parameters.AddWithValue("@c", res.rcid);
                 recordsAffected = cmd.ExecuteNonQuery();
             }
                 if (recordsAffected == 0)
                 {
                     throw new Exception("Registration unsuccessful");
                 }
             }
             catch (Exception ex)
             {
                 throw;
             }
             finally
             {
                 //8. close the connection
                 con.Close();
             }
             return result;
         }*/

    }
}
