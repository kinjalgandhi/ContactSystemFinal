using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract.Models;
namespace DataContract.Interface
{
  public  interface IContact
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContact(int id);
        SaveEnum AddContact(Contact Contact);
        SaveEnum UpdateContact(Contact Contact);
        SaveEnum RemoveContact(int Id);
      
    }
}
