using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FluentValidationApp.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "İsim alanı boş geçilemez. Attribute")]
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public DateTime? BirthDay { get; set; }

        // Customer.Address[i].Id
        public IList<Address> Addresses { get; set; }
        public Gender Gender { get; set; }
        public CreditCard CreditCard { get; set; }

        public string FullName2()
        {
            return $"{Name}-{Email}-{Age}";
        }
    }
}
