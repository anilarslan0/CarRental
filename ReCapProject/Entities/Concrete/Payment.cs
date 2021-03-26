using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntitiy
    {
        public int Id { get; set; }
        public int RentalId { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public decimal MoneyPaid { get; set; }
    }
}
