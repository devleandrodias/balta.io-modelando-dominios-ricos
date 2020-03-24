using System;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _service;

        public SubscriptionHandler(IStudentRepository repository, IEmailService service)
        {
            _repository = repository;
            _service = service;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail, Fast, Validation

            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            // Verificar se documento está cadastrado
            if (_repository.DocumentExists(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o email já está cadastrado
            if (_repository.EmailExists(command.Email))
                AddNotification("Email", "Esse email já está em uso");

            // Gerar os Vos
            Name name = new Name(command.FirstName, command.LastName);
            Document document = new Document(command.Document, EDocumentType.CPF);
            Email email = new Email(command.Email);
            Address address = new Address(command.Street, command.Number, command.Neighbordhood, command.City,
                command.State, command.Country, command.ZipCode);

            // Gerar as entidades
            Student student = new Student(name, document, email);
            Subscription subscription = new Subscription(DateTime.Now.AddMonths(1));
            PaymentBoleto paymentCreditCard = new PaymentBoleto(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.Number, EDocumentType.CPF),
                email,
                address
            );

            //Relacionamentos
            subscription.AddPayment(paymentCreditCard);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, document, email, address, student, subscription, paymentCreditCard);

            // Salvar
            _repository.CreateSubscription(student);

            // Enviar email de boas vindas
            _service.Send(student.Name.ToString(), student.Email.Address, "Assinatura Realizada com Sucesso!",
                "Olá seja bem vindo, você acaba de adquiri a assinatura...");

            // Retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso!");
        }
    }
}