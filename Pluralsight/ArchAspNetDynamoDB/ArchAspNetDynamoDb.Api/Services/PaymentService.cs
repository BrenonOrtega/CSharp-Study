using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArchAspNetDynamoDb.Domain.Models.Entities;
using ArchAspNetDynamoDb.Domain.Repositories;
using ArchAspNetDynamoDb.Domain.Services;

namespace ArchAspNetDynamoDb.Api.Services
{
    public class PaymentRefundService : IPaymentRefundService
    {
        private readonly IRepository<PaymentRefund> _repository;
        public PaymentRefundService(IRepository<PaymentRefund> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }


        public async Task<IEnumerable<PaymentRefund>> GetAllPayments()
        {
            var paymentRefunds = await _repository.GetAllAsync("");

            throw new NotImplementedException();
        }


        public Task<PaymentRefund> GetPayment<T>()
        {
            throw new NotImplementedException();
        }
    }
}