using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StacWebApp.Models;
using System.Data;

namespace StacWebApp.Controllers
{
    public class ContactController : Controller
    {

        private SqlConnection con = new SqlConnection("Server=tcp:stacdb.database.windows.net,1433;Initial Catalog=StacAppDB;PersistSecurityInfo=False;User ID=stacadmin;Password=482SeniorProject;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

        ContactModel newEntry = new ContactModel();


        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact([Bind] ContactModel newEntry)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AddContactEntry(newEntry))
                    {
                        ViewBag.Message = "Appointment details added successfully!";
                    }
                    else
                    {
                        ViewBag.Message = "Appointment details were not added successfully.";
                    }
                }
                return View();
            }

            catch
            {
                return View();
            }

        }

        public bool AddContactEntry(ContactModel obj)
        {

            SqlCommand com = new SqlCommand("AddContactEntry", con);
            com.CommandType = CommandType.StoredProcedure;
            
            com.Parameters.AddWithValue("@FirstName", obj.FName);
            com.Parameters.AddWithValue("@LastName", obj.LName);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Phone", obj.Phone);
            com.Parameters.AddWithValue("@Date", obj.ContactTime);
            com.Parameters.AddWithValue("@Comments", obj.Comments);
             
             
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }
    }
}
