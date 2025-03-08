using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.CardDetail
{
    public class CardDetailDto
    {
        public Guid Id { get; set; }
        public Guid BankDetailId { get; set; }
        public string CardNumber { get; set; }
        public string CardHolderName { get; set; }
        public DateOnly CardExpiryDate { get; set; }
        public string CardCvv { get; set; }
        public string CardType { get; set; }
        public string CardBrand { get; set; }
        public string CardPinNumber { get; set; }
        public DateOnly CardPinExpiryDate { get; set; } = new DateOnly();
    }
}