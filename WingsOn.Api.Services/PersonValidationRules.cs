using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Common.Exceptions;

namespace WingsOn.Api.Services
{
    public class PersonValidationRules
    {
        public const int MaxAddrerssLength = 200;

        public static void ValidateAddress(int personId, string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                return;
            }

            if(address.Length > MaxAddrerssLength)
            {
                throw new ValidationException($"Person with id '{personId}' has too long address. Max length is {MaxAddrerssLength}");
            }
        }
    }
}
