using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTO;
using Business.Interfaces;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IncidentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(IncidentDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            var account = (await _unitOfWork.AccountRepository.GetAllAsync())
                .FirstOrDefault(x => x.Name.Equals(dto.AccountName));
            if (account == null)
                throw new IncidentException("No valid account");
            var contact = (await _unitOfWork.ContactRepository.GetAllAsync())
                .FirstOrDefault(x => x.Email.Equals(dto.Email));
            if (contact != null)
            {
                _mapper.Map(dto, contact);
                _unitOfWork.ContactRepository.Update(contact);
            }
            else
            {
                var newContact = _mapper.Map<Contact>(dto);
                newContact.Email = dto.Email;
                account.Contact = newContact;
                await _unitOfWork.ContactRepository.AddAsync(newContact);
            }

            var incident = _mapper.Map<Incident>(dto);
            incident.Account = account;
            incident.Id = Guid.NewGuid();
            await _unitOfWork.IncidentRepository.AddAsync(incident);
            await _unitOfWork.SaveAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            var incident = await _unitOfWork.IncidentRepository.GetByIdAsync(id);
            if (incident == null)
                throw new IncidentException("Not found");
            await _unitOfWork.IncidentRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Incident>> GetAllAsync()
        {
            var incidents = await _unitOfWork.IncidentRepository.GetAllAsync();
            return incidents;
        }

        public async Task<Incident> GetByIdAsync(Guid id)
        {
            var incident = await _unitOfWork.IncidentRepository.GetByIdAsync(id);
            return incident;
        }

        public async Task UpdateAsync(IncidentUpdateDto dto)
        {
            var account = (await _unitOfWork.AccountRepository.GetAllAsync())
                .FirstOrDefault(x => x.Name.Equals(dto.AccountName));
            if (account == null)
                throw new IncidentException("No valid account");
            var incident = _mapper.Map<Incident>(dto);
            incident.Account = account;
            _unitOfWork.IncidentRepository.Update(incident);
            await _unitOfWork.SaveAsync();
        }
    }
}
