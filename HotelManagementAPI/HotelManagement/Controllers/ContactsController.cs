using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;

namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        #region Field

        private IContactBL _contactsBL;

        #endregion

        #region Constructor

        public ContactsController(IContactBL contactsBL)
        {
            _contactsBL = contactsBL;
        }

        #endregion

        #region Method

        // Get all contacts
        //[Authorize]
        [HttpPost("getall")]
        public IActionResult GetAllContacts()
        {
            try
            {
                var getAllContacts = _contactsBL.GetAllContacts();
                if (getAllContacts != null)
                {
                    return StatusCode(200, getAllContacts);
                }
                else
                {
                    return StatusCode(404, "No contacts found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Filter contacts
        //[Authorize]
        [HttpPost("filter")]
        public IActionResult FilterContacts([FromBody] FilterContacts filterContacts)
        {
            try
            {
                var filteredContacts = _contactsBL.GetFilteredContacts(filterContacts);
                if (filteredContacts != null)
                {
                    return StatusCode(200, filteredContacts);
                }
                else
                {
                    return StatusCode(404, "No contacts found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Insert new contact
        //[Authorize]
        [HttpPost("insert")]
        public IActionResult InsertContact([FromBody] Contact record)
        {
            try
            {
                int insertedId = _contactsBL.InsertContact(record);

                if (insertedId > 0)
                {
                    return StatusCode(201, insertedId);
                }
                else
                {
                    return StatusCode(500, "Error inserting contact.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Update contact by id
        //[Authorize]
        [HttpPut("update/{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact record)
        {
            try
            {
                bool updated = _contactsBL.UpdateContact(id, record);

                if (updated)
                {
                    return StatusCode(200, "Contact updated successfully.");
                }
                else
                {
                    return StatusCode(404, "Contact not found.");
                }
            }
            catch (ValidateException ex)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Data
                };
                return StatusCode(400, res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Delete contact by id
        //[Authorize]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            try
            {
                bool deleted = _contactsBL.DeleteContact(id);

                if (deleted)
                {
                    return StatusCode(200, "Contact deleted successfully.");
                }
                else
                {
                    return StatusCode(404, "Contact not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion
    }
}
