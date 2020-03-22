using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void Adicionar_uma_assinatura()
        {
            Student student = new Student("Leandro", "Dias", "152.234.512-23", "teste@gmail.com");
            Subscription subscription = new Subscription(null);
            student.AddSubscription(subscription);
        }
    }
}