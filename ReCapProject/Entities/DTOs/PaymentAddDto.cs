using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentAddDto:IDto
    {
        public string RentalId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public decimal MoneyPaid { get; set; }
    }
}
