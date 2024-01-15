using Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Contact
{
    public interface IContact
    {
        ContactModel? GetContactById(int id);
        Task<int> AddContactById(AddContactModel model);
    }
}
