using System;
using System.Collections.Generic;

#nullable disable

namespace TestProject.Entity
{
    public partial class Country
    {
        public Country()
        {
            Companies = new HashSet<Company>();
        }

        public int CountryId { get; set; }
        public string RegionCode { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
