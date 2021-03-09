using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StacWebApp.Models
{
    public class AppointmentModel
    {
        public int patientID { get; set; }
        
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter an appointment type.")]
        public string ApptType { get; set; }
        
        [Required(ErrorMessage = "Please enter the reason for an appointment.")]
        public string Reason { get; set; }
        
        [Required(ErrorMessage = "Please enter a date for the appoinment.")]
        public string Calendar { get; set; }
        
        [Required(ErrorMessage = "Insurance number is required.")]
        public int Insurance { get; set; }

        [Required(ErrorMessage = "Please choose a Doctor.")]
        public string Doctor { get; set; }

        [Required(ErrorMessage = "Please choose a location.")]
        public string Location { get; set; }


    }
}
