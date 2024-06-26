using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Contacts;

namespace Api.Services.Services
{
    public class ContactService : IContactService
    {
        private IRepository<ContactsEntity> _repository;
        public ContactService(IRepository<ContactsEntity> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ContactsEntity> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ContactsEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ContactsEntity> Post(ContactsEntity contact)
        {
            return await _repository.InsertAsync(contact);
        }

        public async Task<ContactsEntity> Put(ContactsEntity contact)
        {
            return await _repository.UpdateAsync(contact);
        }
    }
}