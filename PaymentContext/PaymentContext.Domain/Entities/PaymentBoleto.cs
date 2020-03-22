using System;

namespace PaymentContext.Domain.Entities
{
    public class PaymentBoleto : Payment
    {
        public PaymentBoleto(
            string barCode,
            string boletoNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            string document,
            string email,
            string address)
            : base(paidDate, expireDate, total, totalPaid, payer, document, email, address)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}