using Microsoft.EntityFrameworkCore;
using Online_Store_link.Data.Context;
using System.ComponentModel.DataAnnotations;

namespace Online_Store_link.Models;

//public class ValidParentCategoryIDAttribute: ValidationAttribute
//{
//    //readonly OnlineStoreContext context = new();
//    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//    {
//        Course course = context.Course.FirstOrDefault(c => c.Name.ToLower() == value.ToString().ToLower());
//        if (course == null)
//        {
//            return ValidationResult.Success;
//        }
//        return new ValidationResult("This course is already exist");
//    }
//}
