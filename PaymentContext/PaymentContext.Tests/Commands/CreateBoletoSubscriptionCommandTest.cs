using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {
       [TestMethod] 
       public void Validar_quando_o_primeiro_nome_vem_vazio()
       {
           CreateBoletoSubscriptionCommand command = new CreateBoletoSubscriptionCommand();

           command.FirstName = "";
           
           Assert.IsTrue(command.Invalid);
       }
    }
}