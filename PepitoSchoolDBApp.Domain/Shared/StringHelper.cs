using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PepitoSchoolDBApp.Domain.Shared
{
    public static class StringHelper
    {
        public static void PhoneValidation(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("El numero de telefono no puede ser null o vacio");
            }
            if (!Regex.IsMatch(phone, @"\A[0-9]{4}(\-)[0-9]{4}\Z"))
            {
                throw new ArgumentException("Número de telefono invalido");
            }
        }
        public static void EmailValidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("El email no puede ser null o vacio");
            }
            if (!Regex.IsMatch(email, @"\A(\w+\.?\w*\@\w+\.)(com)\Z"))
            {
                throw new ArgumentException("Correo electronico invalido");
            }
        }
        public static void CarnetValidation(string carnet)
        {
            if (string.IsNullOrWhiteSpace(carnet))
            {
                throw new ArgumentException("El carnet no puede ser null o vacio");
            }
            if (!Regex.IsMatch(carnet, @"\A[0-9]{4}-[0-9]{4}U\Z"))
            {
                throw new ArgumentException("Carnet invalido");
            }
        }
    }
}
