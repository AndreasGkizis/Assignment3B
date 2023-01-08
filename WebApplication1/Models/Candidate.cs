using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Candidate #")]
        public int CandidateNumber { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        [DisplayName("Native Language")]

        public string NativeLanguage { get; set; }
        [DisplayName("Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        [DisplayName("Landline Contact Number")]
        public string LandlineNumber { get; set; }
        [DisplayName("Mobile Contact Number")]

        public string MobileNumber { get; set; }
        [DisplayName("First Street Address")]

        public string Address1 { get; set; }
        [DisplayName("Second Street Address")]

        public string Address2 { get; set; }
        [DisplayName("Country of Residence")]

        public string CountryOfResidence { get; set; }
        [DisplayName("State of Residence")]

        public string StateOfResidence { get; set; }
        [DisplayName("Territory of Residence")]

        public string TerritoryOfResidence { get; set; }
        [DisplayName("Province of Residence")]

        public string ProvinceOfResidence { get; set; }


        [DisplayName("Town of Residence")]

        public string TownOfResidence { get; set; }
        [DisplayName("City of Residence")]

        public string CityOfResidence { get; set; }
        [DisplayName("Postal Code")]

        public string PostalCode { get; set; }
        [DisplayName("Identification Type")]

        public IdTypes PhotoIdType { get; set; }
        [DisplayName("Identification Number")]

        public string PhotoNumber { get; set; }
        [DisplayName("Identification Issue Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PhotoIdIssueDate { get; set; }
    }
}
