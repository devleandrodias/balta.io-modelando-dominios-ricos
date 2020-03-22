using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscription;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscription = new List<Subscription>();
        }

        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions
        {
            get
            {
                return _subscription.ToArray();
            }
        }

        public void AddSubscription(Subscription subscription)
        {
            // -- Regras de Negócio -- 
            // Se já tiver uma assinatura ativa, cancela
            // Cancela todas as outras assinaturas e coloca essa como principal

            foreach (var sub in Subscriptions)
                sub.Inactivate();

            _subscription.Add(subscription);
        }
    }
}