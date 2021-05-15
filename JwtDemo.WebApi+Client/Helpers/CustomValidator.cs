using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace JwtDemo.WebApi_Client.Helpers
{
    public class CustomValidator
    {
        public static List<string> GetErrorsByModel(ModelStateDictionary modelState)
        {
            List<string> errors = new List<string>();

            var result = modelState.Where(x => x.Value.Errors.Count > 0).
                ToDictionary(x => x.Key, x => x.Value.Errors.Select(x => x.ErrorMessage));

            foreach (var item in result)
            {
                errors.Add(item.Value.ToString());
            }

            return errors;
        }

        public static List<string> GetErrorsByIdentityResult(IdentityResult result)
        {
            var errors = new List<string>();
            foreach (var item in result.Errors)
            {
                errors.Add(item.Description);
            }
            return errors;
        }
    }
}
