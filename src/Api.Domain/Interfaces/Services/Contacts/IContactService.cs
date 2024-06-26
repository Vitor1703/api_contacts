using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Contacts
{
    public interface IContactService
    {
        Task<ContactsEntity> Get (Guid id);
        Task<IEnumerable<ContactsEntity>> GetAll ();
        Task<ContactsEntity> Post (ContactsEntity user);
        Task<ContactsEntity> Put (ContactsEntity user);
        Task<bool> Delete (Guid id);

    }
}