using System;

namespace PaymentContext.Domain.Entities
{
    public class PaymentCreditCard : Payment
    {
        public PaymentCreditCard(
            string cardHolderName,
            string cardNumber,
            string lastTransactNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            string document,
            string email,
            string address) : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactNumber = lastTransactNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactNumber { get; private set; }
    }
}