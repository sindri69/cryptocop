using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Cryptocop.Software.API.Repositories.Helpers
{
    public class PaymentCardHelper
    {
        public static string MaskPaymentCard(string paymentCardNumber)
        {
            string visable = paymentCardNumber.Substring(paymentCardNumber.Length - 4);
            var masked = "";
            string star = "*";
            var maskLength = paymentCardNumber.Length - 4;
            for(var i = 0; i < maskLength; i++)
            {
                masked = masked + star;
            }
            Console.WriteLine(masked);
            return masked + visable;
        }
    }
}