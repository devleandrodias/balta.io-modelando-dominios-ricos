using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string documents)
        {
            if (documents == "99999999999")
                return true;

            else
                return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "teste@gmail.com")
                return true;

            else
                return false;
        }
    }
}