using System;
using System.Collections.Generic;

#nullable disable

namespace TestProject.Entity
{
    public partial class City
    {
        public City()
        {
            Companies = new HashSet<Company>();
        }

        public int CityId { get; set; }
        public string CountryCode { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
