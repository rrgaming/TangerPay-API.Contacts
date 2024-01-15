using Contracts.Context;
using Contracts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contact
{
    public class RContact : IContact
    {
        private readonly DB_Context _dbc;
        private readonly ILogger<RContact> _logger;
        public RContact(DB_Context dbc, ILogger<RContact> logger) 
        { 
            _dbc = dbc;
            _logger = logger;
        }
        public ContactModel? GetContactById(int id)
        {
            try
            {
                var contact = _dbc.Contact.FirstOrDefault(f => f.Id == id);
                return contact;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in RContact/GetContactById");
                throw;
            }
        }

        public async Task<int> AddContactById(AddContactModel model)
        {
            try
            {
                var lastContact = await _dbc.Contact.LastOrDefaultAsync();
                int newId = lastContact == null ? 1 : lastContact.Id + 1;// increment based on last record
                var newContact = new ContactModel ()
                {
                    Id = newId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                };
                await _dbc.Contact.AddAsync(newContact);
                await _dbc.SaveChangesAsync();
                return newContact.Id;
            }
            catch 
            {
                throw;
            }
        }
    }
}
