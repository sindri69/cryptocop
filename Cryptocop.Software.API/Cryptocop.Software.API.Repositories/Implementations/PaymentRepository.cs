using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Repositories.Contexts;
using AutoMapper;
using System.Linq;
using Cryptocop.Software.API.Models.Entities;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private IMapper _mapper;

        public PaymentRepository(CryptocopDbContext dbContext, IMapper mapper)
        {
        _dbContext = dbContext;
        _mapper = mapper;
        }

        public void AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {


            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;

            var paymentCardEntity = new PaymentCard
            {
                CardholderName = paymentCard.CardholderName,
                CardNumber = paymentCard.CardNumber,
                Month = paymentCard.Month,
                Year = paymentCard.Year,
                UserId = userId
            };
            _dbContext.PaymentCards.Add(paymentCardEntity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            var userId = _dbContext.Users.FirstOrDefault(u => u.Email == email).Id;
            var paymentCards = _dbContext.PaymentCards.Where(p => p.UserId == userId);
            //throw error if there are no addresses?
            //skilar empty enumerable if thetta er tomt
            return _mapper.Map<IEnumerable<PaymentCardDto>>(paymentCards);
        }
    }
}