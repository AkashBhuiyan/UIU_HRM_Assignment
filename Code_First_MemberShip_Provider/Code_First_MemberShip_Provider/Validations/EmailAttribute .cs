using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Code_First_MemberShip_Provider.Validations
{
    public class EmailAttribute:RegularExpressionAttribute
    {

        public EmailAttribute()
            : base(@"[a-zA-Z0-9._%+-]+@gmail.com")
        {
            this.ErrorMessage = "Please provide a valid email address";
        }
    }
}