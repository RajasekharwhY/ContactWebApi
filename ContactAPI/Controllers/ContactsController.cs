using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using AutoMapper;
using ContactAPI.Context;
using ContactAPI.DbRepos;
using ContactAPI.Enums;
using ContactAPI.Models;

namespace ContactAPI.Controllers
{
    public class ContactsController : ApiController 
    {

        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();
        //Creating a method to return Json data   
        private IContactRepository contactRepository;
        public ContactsController(IContactRepository contactRepo)
        {
            contactRepository = new ContactRepository(db);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {               
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Contact, ContactModel>();
                });
                
                IMapper iMapper = config.CreateMapper();
                var contactEnities = contactRepository.GetContacts();
                var destination = iMapper.Map<ContactModel[]>(contactEnities);
                
                return Ok(destination);
                              
                
            }
            catch (Exception ex)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError(ex);
            }
           
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {

                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<Contact, ContactModel>();
                });

                IMapper iMapper = config.CreateMapper();
                var contactEnity = contactRepository.GetContat(id);
                if(contactEnity == null)
                {
                    return NotFound();
                }
                var destination = iMapper.Map<Contact, ContactModel>(contactEnity);

                return Ok(destination);                            
                               
            }
            catch (Exception ex)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError(ex);
            }
           
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Contact contact)
        {
            try
            {
                Contact existingContact = contactRepository.GetContat(id);
                if (existingContact == null)
                {
                     return NotFound();
                }
                contactRepository.UpdateContact(id, contact);
                contactRepository.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
               return InternalServerError();
            }
            
        }

        [HttpPost]
        public IHttpActionResult Post(Contact contactModel)
        {
            try
            {
                var error = validatePostedContact(contactModel);
                if (error.Length > 0)
                {
                    var Errors = error.Split('+');
                    foreach (var err in Errors)
                    {
                        ModelState.AddModelError("key",err);
                    }
                }         
                               
                if ( ModelState.IsValid)
                {
                    contactRepository.AddContact(contactModel);
                    if(contactRepository.SaveChanges())
                    {
                       // var model = iMapper.Map<ContactModel>(destination);
                        return Created("location", contactModel);
                    }
                }
            }
            catch (Exception ex)
            { 
                return InternalServerError(ex);
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Contact existingContact = contactRepository.GetContat(id);
                if (existingContact == null)
                {
                    return NotFound();
                }
                contactRepository.DeleteContact(existingContact);
                if (contactRepository.SaveChanges())
                {
                    return Ok("Deleted");
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception)
            {               
                return InternalServerError();
            }
        }

        private string validatePostedContact(Contact contactModel)
        {
            string errors = String.Empty;
            if (!contactModel.Email.EndsWith(".com"))
            {
                errors = "Not a valid email id+";
            }
            if (!Regex.IsMatch(contactModel.Phone.Number, @"^(\d{3}-)?\d{3}-\d{4}$"))
            {
                errors += "Not a valid phone number+";          
            }
            if (!Enum.IsDefined(typeof(PhoneTypes), contactModel.Phone.Type))
            {
                errors += "Not a valid phone Type";
            }
            return errors;

        }
    }
}
