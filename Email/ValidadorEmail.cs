using EmailService.Interfaces;
using System.Text.RegularExpressions;

namespace EmailService
{
    public class ValidadorEmail : IValidadorEmail
    {

        private string expressaoRegular = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$";

        //private string expressaoRegular = @"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}";

        public bool EmailValido(string email)
        {            
            Regex expressaoRegex = new Regex(expressaoRegular);
            return expressaoRegex.IsMatch(email);                        
        }
    }
}