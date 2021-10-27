using System;
using System.Collections.Generic;
using System.Text;

namespace GOCC.Model
{
    public class UserDataModel
    {
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Email;
        public string City;
        public string Day;
        public string Month;
        public string Year;
        public UserDataModel(
            string firstname, 
            string lastname, 
            string phonenumber, 
            string email, string city, 
            string day, 
            string year, 
            string month)
        {
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Email = email;
            City = city;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}
