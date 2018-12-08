using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class TeamMemberController : BaseController
    {
        private Repository.Interface.GenericRepository<Employee> _employeeRepository;

        public TeamMemberController()
        {
            _employeeRepository = new Repository.GenericRepository<Employee>();
        }
        // GET: TeamMember
        public ActionResult Index()
        {
            var empList = _employeeRepository.GetAll().ToList();
            var model = empList.Select(x => new ModelEmployee()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                BirthDate = x.BirthDate.Value,
                Profession = x.Profession,
                Title = x.Title,
                PhoneNumber = x.PhoneNumber,
                Photo = x.Photo,
                IsParent = x.IsParent,
                Email = x.EmailAddress
            }).ToList();
          
            return View(model);
        }
    }
}