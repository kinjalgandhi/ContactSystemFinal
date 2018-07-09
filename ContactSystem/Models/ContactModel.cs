using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataContract.Models;
using DataContract.Interface;

namespace ContactSystem.Models
{
    public class ContactModel : Contact, IContact
    {
        public static List<Contact> ContactsList = new List<Contact>();
        
         static ContactModel()
        {
            Contact ObjContactModel = new Contact { Id = 1, FirstName = "Ross", LastName = "Weaver", Email = "Ross.Weaver@hotmail.com", PhoneNumber = "0001 253 569", Status = true };
            ContactsList.Add(ObjContactModel);
            ObjContactModel = new Contact { Id = 2, FirstName = "Dan", LastName = "Radomira", Email = "Dan.Radomira@hotmail.com", PhoneNumber = "0001 253 569", Status = true };
            ContactsList.Add(ObjContactModel);
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return ContactModel.ContactsList;
        }

        public Contact GetContact(int id)
        {
            var product = ContactModel.ContactsList.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return null;
            }
            return product;


        }

        public bool IsEmailAlreadyExist(string emailID,int id=0)
        {
            Contact contact = new Contact();
            bool IsExist = false;
            if (id == 0)
            {
                //Post/Add
                contact = ContactsList.Where(x => x.Email == emailID).FirstOrDefault();
            }
            else
            {
                //Put/Edit
                contact = ContactsList.Where(x => x.Email == emailID && x.Id != id).FirstOrDefault();
            }
            if(contact != null && contact.Id>0)
            {
                IsExist = true;
            }
            return IsExist;
        }

        public SaveEnum AddContact(Contact contactModel)
        {
            SaveEnum SaveEnum = SaveEnum.Error;
            try
            {
                ContactsList.Add(contactModel);
                SaveEnum = SaveEnum.Success;
                return SaveEnum;
            }
            catch(Exception ex)
            {
                return SaveEnum.Error;
            }
            
        }

        public SaveEnum UpdateContact(Contact contactModel)
        {
            SaveEnum SaveEnum = SaveEnum.NotFound;
            try
            {
                var product = ContactsList.FirstOrDefault((p) => p.Id == contactModel.Id);
                if (product != null)
                {
                    ContactsList.Remove(product);
                    ContactsList.Add(contactModel);
                    SaveEnum = SaveEnum.Success;
                }               
                
                return SaveEnum;
            }
            catch (Exception ex)
            {
                return SaveEnum.Error;
            }

        }
        public SaveEnum RemoveContact(int Id)
        {           
            SaveEnum SaveEnum = SaveEnum.NotFound;
            try
            {

                var contactData= ContactsList.FirstOrDefault((p) => p.Id == Id);
                if (contactData != null)
                {
                    ContactsList.Remove(contactData);
                    SaveEnum = SaveEnum.Success;
                }
                
                return SaveEnum;
            }
            catch (Exception ex)
            {
                return SaveEnum.Error;
            }

        }
    }
}