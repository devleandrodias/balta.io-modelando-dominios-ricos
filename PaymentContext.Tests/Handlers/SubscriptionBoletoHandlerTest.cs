using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionBoletoHandlerTest
    {
        [TestMethod]
        public void Retornar_um_erro_quando_o_documento_ja_existir()
        {
            SubscriptionHandler handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            CreateBoletoSubscriptionCommand command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Leandro";
            command.LastName = "Dias";
            command.Document = "99999999999";
            command.Email = "teste2@gmail.com";
            command.BarCode = "2342342";
            command.BoletoNumber = "123456";
            command.PaymentNumber = "123456";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Leandro Dias";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "teste@gmail.com";
            command.Street = "Av. Logo ali";
            command.Number = "123";
            command.Neighbordhood = "Ali do lado";
            command.City = "Franca";
            command.State = "RS";
            command.Country = "França";
            command.ZipCode = "15235-234";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}