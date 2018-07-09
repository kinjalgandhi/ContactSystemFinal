using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactSystem.Models;
using DataContract.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ContactSystem.Controllers
{
    public class ContactController : ApiController
    {
        ContactModel contactModel = new ContactModel();
        // GET: Contact
        public IEnumerable<Contact> GetAllContacts()
        {
            return contactModel.GetAllContacts();
        }

        public Contact GetContact(int id)
        {
            if (id > 0)
            {
                var product = contactModel.GetContact(id);
                if (product == null)
                {
                    return null;
                }
                return product;
            }
            else
            {
                return null;
            }

        }

        public HttpResponseMessage Post([FromBody] ContactModel contactModel)
        {
            SaveEnum SaveEnum = SaveEnum.NotFound;
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            try
            {
                if (contactModel != null && !string.IsNullOrEmpty(contactModel.FirstName) && !string.IsNullOrEmpty(contactModel.Email))
                {

                    string email = contactModel.Email;
                    if (contactModel.IsEmailAlreadyExist(email))
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.Conflict);
                        return httpResponseMessage;
                    }

                    int MaxID = ContactModel.ContactsList.Max(x => x.Id);
                    contactModel.Id = MaxID + 1;
                    SaveEnum = contactModel.AddContact(contactModel);
                    if (SaveEnum == SaveEnum.Success)
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.Created);
                        httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (contactModel.Id).ToString());

                    }

                    else if (SaveEnum == SaveEnum.Error)
                    {

                        httpResponseMessage = Request.CreateResponse(404);
                    }
                    return httpResponseMessage;

                }
                else
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                    return httpResponseMessage;
                }
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                httpResponseMessage.ReasonPhrase = ex.Message.ToString();
                throw new HttpResponseException(httpResponseMessage);
            }



        }

        public HttpResponseMessage Put([FromBody] ContactModel contactModel)
        {

            SaveEnum SaveEnum = SaveEnum.NotFound;
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            try
            {
                if (contactModel != null && contactModel.Id > 0 && !string.IsNullOrEmpty(contactModel.FirstName) && !string.IsNullOrEmpty(contactModel.Email))
                {

                    string email = contactModel.Email;
                    if (contactModel.IsEmailAlreadyExist(email, contactModel.Id))
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.Conflict, "Email ID exist.");
                    }


                    SaveEnum = contactModel.UpdateContact(contactModel);
                    if (SaveEnum == SaveEnum.Success)
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                        httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (contactModel.Id).ToString());

                    }
                    else if (SaveEnum == SaveEnum.NotFound)
                    {

                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else if (SaveEnum == SaveEnum.Error)
                    {

                        httpResponseMessage = Request.CreateResponse(404);
                    }
                    return httpResponseMessage;

                }
                else
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                    return httpResponseMessage;
                }

            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                httpResponseMessage.ReasonPhrase = ex.Message.ToString();
                throw new HttpResponseException(httpResponseMessage);
            }

        }
        public HttpResponseMessage Delete(int Id)
        {
            SaveEnum SaveEnum = SaveEnum.NotFound;
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            try
            {

                if (Id > 0)
                {

                    SaveEnum = contactModel.RemoveContact(Id);
                    if (SaveEnum == SaveEnum.Success)
                    {
                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK);
                        httpResponseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + (contactModel.Id).ToString());

                    }
                    else if (SaveEnum == SaveEnum.NotFound)
                    {

                        httpResponseMessage = Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else if (SaveEnum == SaveEnum.Error)
                    {

                        httpResponseMessage = Request.CreateResponse(404);
                    }
                    return httpResponseMessage;

                }
                else
                {
                    httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                    return httpResponseMessage;
                }
            }
            catch (Exception ex)
            {
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest);
                httpResponseMessage.ReasonPhrase = ex.Message.ToString();
                throw new HttpResponseException(httpResponseMessage);
            }


        }
    }
}

//{
//        "Id": 1,
//        "FirstName": "Ross",
//        "LastName": "Weaver",
//        "Email": "Ross.Weaver@hotmail.com",
//        "PhoneNumber": "0001 253 569",
//        "Status": true
//    }
