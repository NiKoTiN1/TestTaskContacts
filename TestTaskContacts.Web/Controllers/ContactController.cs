using Microsoft.AspNetCore.Mvc;
using TestTaskContacts.Services.Interfaces;
using TestTaskContacts.VeiwModels.Models;

namespace TestTaskContacts.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] GetContactsVeiwModel model)
        {
            var contacts = _contactService.GetAll(model);

            return View(contacts);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var contacts = _contactService.GetById(id);

            return View("DetailsPartial", contacts);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View("CreatePartial", new ContactViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateContactViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            await _contactService.Create(model);

            var getContactsModel = new GetContactsVeiwModel();
            var contacts = _contactService.GetAll(getContactsModel);

            return PartialView("ContactListPartial", contacts);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var contact = _contactService.GetById(id);
            return View("UpdatePartial", contact);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(UpdateContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model is not valid!");
            }

            await _contactService.Update(model);

            var getContactsModel = new GetContactsVeiwModel();

            var contacts = _contactService.GetAll(getContactsModel);
            return PartialView("ContactListPartial", contacts);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _contactService.Delete(id);
            var getContactsModel = new GetContactsVeiwModel();

            var contacts = _contactService.GetAll(getContactsModel);
            return PartialView("ContactListPartial", contacts);
        }

        public ActionResult OpenModelPopup()
        {
            return PartialView("Shared/CreatePartial");
        }
    }
}
