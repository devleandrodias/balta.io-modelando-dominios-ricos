using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void Deve_retornar_um_erro_quando_o_cpf_for_invalido()
        {
            Document document = new Document("1234", EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("23423452623")]
        [DataRow("37453657345")]
        [DataRow("23745834752")]
        public void Deve_retornar_um_sucesso_quando_o_cpf_for_valido(string cpf)
        {
            Document document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        public void Deve_retornar_um_erro_quando_o_cnpj_for_invalido()
        {
             Document document = new Document("144235", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        public void Deve_retornar_um_sucesso_quando_o_cnpj_for_valido()
        {
             Document document = new Document("23467345678934", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }        
    }
}