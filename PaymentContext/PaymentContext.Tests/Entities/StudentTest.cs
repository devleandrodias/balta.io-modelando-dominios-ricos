using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Payment _payment;

        public StudentTest()
        {
            _name = new Name("Leandro", "Dias"); 
            _document = new Document("13234562345", EDocumentType.CPF);
            _email = new Email("leandrodbdias@gmail.com");
            _address = new Address("Av. Tal", "1890", "Ana Maria", "Porto Alegre", "SC", "Brasil", "31234-234");
            _subscription = new Subscription(DateTime.Now.AddYears(1));
            _student = new Student(_name, _document, _email);
            _payment = new PaymentCreditCard("Leandro", "123123123", "3452345", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Leandro", _document, _email, _address);   
        }

        [TestMethod]
        public void Retornar_um_erro_de_mais_de_uma_assinatura_ativa()
        {            
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Retornar_erro_quando_assinatura_nao_tiver_pagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void Retornar_sucesso_caso_assinatura_esteja_correta_e_pagamento_realizado()
        {
            _student.AddSubscription(_subscription);
            _subscription.AddPayment(_payment);
            Assert.IsTrue(_student.Valid);
        }
    }
}