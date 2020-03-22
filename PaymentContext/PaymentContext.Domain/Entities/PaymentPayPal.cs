using System;

namespace PaymentContext.Domain.Entities
{
    public class PaymentPayPal : Payment
    {
        public PaymentPayPal(
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            string document,
            string email,
            string address) : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}