using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_First_MemberShip_Provider.Validations
{
    public class ValidateFileAttribute : ValidationAttribute
    {
        
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 2; //2 MB
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

            var ImageFile = value as HttpPostedFileBase;

            if (ImageFile == null)
                return false;
            else if (!AllowedFileExtensions.Contains(ImageFile.FileName.Substring(ImageFile.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (ImageFile.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}