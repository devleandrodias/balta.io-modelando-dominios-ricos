using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQuerieTest
    {
        private IList<Student> _students;

        public StudentQuerieTest()
        {
            for (int i = 0; i < 10; i++)
            {
                _students.Add(new Student(
                    new Name("leandro", i.ToString()),
                    new Document("11111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@gmail.com")
                ));
            }
        }

        [TestMethod]
        public void Retornar_nulo_se_o_documento_nao_existir()
        {
            var expression = StudentQueries.GetStudentByDocument("1234567891112");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void Retornar_aluno_se_o_documento_existir_e_for_igual_ao_informado()
        {
            var expression = StudentQueries.GetStudentByDocument("1234567891112");
            var student = _students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}