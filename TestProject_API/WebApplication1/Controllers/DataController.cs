using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.DTOs;
using TestProject.Entity;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        TestProjectDBContext context = new TestProjectDBContext();


        [HttpGet("getallcountry")]
        public IActionResult GetAllCountry()
        {
            try
            {
                var AllCountry = context.Countries.ToList();
                return Ok(AllCountry);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getallcity")]
        public IActionResult GetAllCity()
        {
            try
            {
                var AllCity = context.Cities.ToList();
                return Ok(AllCity);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getallcompany")]
        public IActionResult GetAllCompany()
        {
            try
            {
                var AllCompany = context.Companies.ToList();
                return Ok(AllCompany);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getalluser")]
        public IActionResult GetAllUser()
        {
            try
            {
                var AllUser = context.Users.ToList();
                return Ok(AllUser);
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getcompanywithtype")]
        public IActionResult GetCompanyWithType()
        {
            try
            {
                var result = from p in context.Companies
                             join u in context.CompanyTypes
                             on p.TypeId equals u.TheId
                             join c in context.Cities
                             on p.CityId equals c.CityId
                             join d in context.Countries
                             on c.CountryCode equals d.CountryCode

                             select new CompanyWithTypeDTO
                             {

                                 CompanyId = p.CompanyId,
                                 Name = p.Name,
                                 Type = u,
                                 Address = p.Address,
                                 City = c.CityName,
                                 Country = d.CountryName,
                                 Phone = p.Phone,
                                 EmailId = p.EmailId,
                                 Website = p.Website,
                                 HowComeToKnow = p.HowComeToKnow,
                                 Others = p.Others,
                                 Status = p.Status,
                                 Created = p.Created,
                                 Modified = p.Modified

                             };
                return Ok(result.ToList());
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpGet("getresults")]
        public IActionResult GetResults()
        {

            var result = from d in context.Companies.ToList()
                         join u in context.Users.ToList()
                         on d.CompanyId equals u.CompanyId into users
                         join con in context.Countries.ToList()
                         on d.CountryId equals con.CountryId
                         join cty in context.Cities.ToList()
                         on d.CityId equals cty.CityId

                         select new ResultDTO
                         {
                             CompanyID = d.CompanyId,
                             CompanyName = d.Name,
                             CountryID = con.CountryId,
                             CountryName = con.CountryName,
                             CityID = cty.CityId,
                             CityName = cty.CityName,
                             Users = users.ToList(),
                         };

            return Ok(result.ToList());

        }

    }
}
