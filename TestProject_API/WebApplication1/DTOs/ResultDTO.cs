using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestProject.Entity;

namespace TestProject.DTOs
{

    public class ResultDTO
    {
       
        public int? CompanyID { get; set; }
        public string CompanyName { get; set; }
        public int? CountryID { get; set; }
        public string CountryName { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }      
        public  List<User> Users { get; set; }
    }
}
