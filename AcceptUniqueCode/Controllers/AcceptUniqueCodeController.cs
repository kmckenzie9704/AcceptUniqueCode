using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcceptUniqueCode.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace AcceptUniqueCode.Controllers
{
    [Route("api/AcceptUniqueCode")]
    public class AcceptUniqueCodeController : Controller
    {
        private DatabaseContext _context;

        public AcceptUniqueCodeController(DatabaseContext context)
        {
            _context = context;
        }
        // GET api/AcceptUniqueCode
        [HttpGet]
        public string Get()
        {
            string strUniqueCode = "Accept Unique Code supplied by applicant.";  // ValidateCode("A638A22F").ToString();

            return strUniqueCode;
        }


        // POST api/AcceptUniqueCode
        [HttpPost]
        public bool Post([FromBody]Applicant applicant)
        {
            bool blnUniqueCodeIsValid = ValidateCode(applicant.appUniqueCode);

            return blnUniqueCodeIsValid;
        }

        private bool ValidateCode(string strUniqueCode)
        {
            bool blnCodeUpdated = false;
            using (_context)
            {
                var unicode = _context.UniqueCodes.FirstOrDefault(c => c.uniCode == strUniqueCode && c.uniAccepted == false);
                if (unicode != null)
                {
                    DateTime datToday = DateTime.Today;
                    unicode.uniAcceptDate = datToday;
                    unicode.uniAccepted = true;
                    _context.SaveChanges();
                    blnCodeUpdated = true;
                }
            }

            return blnCodeUpdated;
        }
    }

}
