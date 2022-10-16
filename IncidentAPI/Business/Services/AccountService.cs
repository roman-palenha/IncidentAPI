using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AutoMapper;
using Business.DTO;
using Business.Interfaces;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(AccountDto dto)
        {
            var contacts = await _unitOfWork.ContactRepository.GetAllAsync();
            if (contacts.Any(x => x.Email.Equals(dto.Email)))
                throw new IncidentException("Email must be unique");

            var contact = _mapper.Map<Contact>(dto);
            await _unitOfWork.ContactRepository.AddAsync(contact);

            var account = _mapper.Map<Account>(dto);
            account.Contact = contact;
            await _unitOfWork.AccountRepository.AddAsync(account);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            if (account == null)
                throw new IncidentException("Not found");

            await _unitOfWork.AccountRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            var accounts = await _unitOfWork.AccountRepository.GetAllAsync();
            return accounts;
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            var account = await _unitOfWork.AccountRepository.GetByIdAsync(id);
            return account;
        }

        public async Task UpdateAsync(AccountDto dto)
        {
            var contacts = await _unitOfWork.ContactRepository.GetAllAsync();
            if (!contacts.Any(x => x.Email.Equals(dto.Email)))
                throw new IncidentException("Not found contact");

            var contact = _mapper.Map<Contact>(dto);
            _unitOfWork.ContactRepository.Update(contact);

            var account = _mapper.Map<Account>(dto);
            account.Contact = contact;
            _unitOfWork.AccountRepository.Update(account);
            await _unitOfWork.SaveAsync();
        }
    }
}
