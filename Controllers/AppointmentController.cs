using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using StacWebApp.Models;
using System.Configuration;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace StacWebApp.Controllers
{
    public class AppointmentController : Controller
    {

        
        private SqlConnection con = new SqlConnection("Server=tcp:stacdb.database.windows.net,1433;Initial Catalog=StacAppDB;PersistSecurityInfo=False;User ID=stacadmin;Password=482SeniorProject;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

        AppointmentModel newAppt = new AppointmentModel();

        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment([Bind]AppointmentModel newAppt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (AddAppt(newAppt))
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

        public bool AddAppt(AppointmentModel obj)
        {
            
            SqlCommand com = new SqlCommand("AddAppDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ApptID", obj.patientID);
            com.Parameters.AddWithValue("@PatientFName", obj.FirstName);
            com.Parameters.AddWithValue("@PatientLName", obj.LastName);
            com.Parameters.AddWithValue("@PatEmail", obj.Email);
            com.Parameters.AddWithValue("@ApptType", obj.ApptType);
            com.Parameters.AddWithValue("@Reason", obj.Reason);
            com.Parameters.AddWithValue("@Calendar", obj.Calendar);
            com.Parameters.AddWithValue("@Insurance", obj.Insurance);
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
