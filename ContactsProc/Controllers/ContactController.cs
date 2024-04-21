using ContactsProc.Data;
using ContactsProc.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsProc.Controllers
{
    public class ContactController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContact()
        {
            return View(DataStorage.AllContacts.FirstOrDefault());
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            DataStorage.AddContact(contact);
            return RedirectToAction("GetContact", new { id = contact.Id });
        }

        [HttpGet]
        public IActionResult GetContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var contact = DataStorage.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        public IActionResult EditContact(int id)
        {
            var contact = DataStorage.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(Contact contact)
        {
            DataStorage.UpdateContact(contact);
            return RedirectToAction("GetContact", new { id = contact.Id });
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAllContacts()
        {
            var allContacts = DataStorage.AllContacts;
            return View(allContacts);
        }

        public IActionResult DeleteContact(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            DataStorage.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}
