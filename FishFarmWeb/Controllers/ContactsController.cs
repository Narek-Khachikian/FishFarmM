using FishFarm.Models;
using FishFarm.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishFarmWeb.Controllers
{
    public class ContactsController : Controller
    {

        private readonly IFishFarmRepository _repository;
        
        public ContactsController(IFishFarmRepository repo)
        {
            _repository = repo;
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddContactPhone(Contact contact, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                byte num = 0;
                if (!string.IsNullOrEmpty(contact.Address)) { num++; }
                if (!string.IsNullOrEmpty(contact.Email)) { num++; }
                if (!string.IsNullOrEmpty(contact.PhoneNumber)) { num++; }
                if (!string.IsNullOrEmpty(contact.MobileNumber)) { num++; }
                if (num == 1)
                {
                    contact.LastModifiedByName = User.Identity.Name;
                    await _repository.AddContactAsync(contact);
                }
            }
            
            return LocalRedirect(returnUrl);
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditContactPhone(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                contact.LastModifiedByName = User.Identity.Name;
                result = await _repository.UpdateContactAsync(contact);
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost,AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteContactPhone(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _repository.DeleteContactAsync(contact);
            }
            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddContactMobile(Contact contact, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                byte num = 0;
                if (!string.IsNullOrEmpty(contact.Address)) { num++; }
                if (!string.IsNullOrEmpty(contact.Email)) { num++; }
                if (!string.IsNullOrEmpty(contact.PhoneNumber)) { num++; }
                if (!string.IsNullOrEmpty(contact.MobileNumber)) { num++; }
                if (num == 1)
                {
                    contact.LastModifiedByName = User.Identity.Name;
                    await _repository.AddContactAsync(contact);
                }
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditContactMobile(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                contact.LastModifiedByName = User.Identity.Name;
                result = await _repository.UpdateContactAsync(contact);
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteContactMobile(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _repository.DeleteContactAsync(contact);
            }
            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddContactEmail(Contact contact, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                byte num = 0;
                if (!string.IsNullOrEmpty(contact.Address)) { num++; }
                if (!string.IsNullOrEmpty(contact.Email)) { num++; }
                if (!string.IsNullOrEmpty(contact.PhoneNumber)) { num++; }
                if (!string.IsNullOrEmpty(contact.MobileNumber)) { num++; }
                if (num == 1)
                {
                    contact.LastModifiedByName = User.Identity.Name;
                    await _repository.AddContactAsync(contact);
                }
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditContactEmail(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                contact.LastModifiedByName = User.Identity.Name;
                result = await _repository.UpdateContactAsync(contact);
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteContactEmail(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _repository.DeleteContactAsync(contact);
            }
            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddContactAddress(Contact contact, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                byte num = 0;
                if (!string.IsNullOrEmpty(contact.Address)) { num++; }
                if (!string.IsNullOrEmpty(contact.Email)) { num++; }
                if (!string.IsNullOrEmpty(contact.PhoneNumber)) { num++; }
                if (!string.IsNullOrEmpty(contact.MobileNumber)) { num++; }
                if (num == 1)
                {
                    contact.LastModifiedByName = User.Identity.Name;
                    await _repository.AddContactAsync(contact);
                }
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditContactAddress(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                contact.LastModifiedByName = User.Identity.Name;
                result = await _repository.UpdateContactAsync(contact);
            }

            return LocalRedirect(returnUrl);
        }


        [HttpPost, AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteContactAddress(Contact contact, string returnUrl)
        {
            int result = 0;
            if (ModelState.IsValid)
            {
                result = await _repository.DeleteContactAsync(contact);
            }
            return LocalRedirect(returnUrl);
        }

    }
}
