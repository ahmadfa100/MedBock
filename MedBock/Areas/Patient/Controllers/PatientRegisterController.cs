using MedBock.Areas.Patient.Models;
using MedBock.DBEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MedBock.Areas.Patient.Controllers
{
    [Area("Patient")]
    public class PatientRegisterController : Controller
    {
        private readonly MedBockContext _context;

        public PatientRegisterController(MedBockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("~/Views/Account/Register.cshtml", new PatientRegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewPatient(PatientRegisterViewModel patientModel)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Account/Register.cshtml", patientModel);
            }

            if (await _context.People.AnyAsync(p => p.Email == patientModel.Email))
            {
                ModelState.AddModelError("Email", "A user with this email already exists.");
                return View("~/Views/Account/Register.cshtml", patientModel);
            }

            var person = new DBEntities.Person
            {
                FirstName = patientModel.FirstName,
                LastName = patientModel.LastName,
                Email = patientModel.Email,
                Phone = patientModel.Mobile,
                Role = "Patient",
                CreatedAt = DateTime.UtcNow,
                Gender = patientModel.Gender == "1"
            };

            var hasher = new PasswordHasher<DBEntities.Person>();
            person.PasswordHash = hasher.HashPassword(person, patientModel.Password);

            _context.People.Add(person);
            await _context.SaveChangesAsync(); 

            var patientEntity = new DBEntities.Patient
            {
                PersonId = person.PersonId,
                HasHealthInsurance = patientModel.HasHealthInsurance
            };

            _context.Patients.Add(patientEntity);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account", new { area = "" });
        }
    }
}
