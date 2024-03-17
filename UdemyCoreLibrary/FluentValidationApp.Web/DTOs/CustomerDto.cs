using System;

namespace FluentValidationApp.Web.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Eposta { get; set; }
        public int Yas { get; set; }

        public string FullName { get; set; } // Get varsa otamatik eşleşiyor

        public string Number { get; set; } //ClassProperty
        public DateTime ValidDate { get; set; } //ClassProperty 

        /* İçerisinde class barındıran ana classı sadece propertylerden oluşan classa dönüştürdük.*/
    }
}
