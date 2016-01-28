   using System;
   using System.Collections.Generic;
   using System.ComponentModel.DataAnnotations;
   using System.Linq;
   using System.Web;

namespace MSP_Rwanda.Models
{
    public class StudentValidation
    {
        [Display(Name="First Name")]
                    [Required(ErrorMessage="Please provide First Name", AllowEmptyStrings = false)]
                    public string StudentFName { get; set; }

                    [Display(Name="Last Name")] // Its not required
                    public string StudentLName { get; set; }

                    [Display(Name="Contact Number")]
                    [Required(ErrorMessage="Please provide Last Name", AllowEmptyStrings=false)]
                    public string ContactNumber { get; set; }

                    [Display(Name="Email Adress")]
                    [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
                        ErrorMessage="Email not valid")]
                    public string EmailID { get; set; }

                    //[Display(Name="Country")]
                    //[Required(ErrorMessage = "Please select country")]
                    //public int CountryID { get; set; }

                    //[Display(Name = "State")]
                    //[Required(ErrorMessage = "Please select state")]
                    //public int StateID { get; set; }
                }


                [MetadataType(typeof(StudentValidation))] // Apply validation
                public partial class student

                {
                }
    }
