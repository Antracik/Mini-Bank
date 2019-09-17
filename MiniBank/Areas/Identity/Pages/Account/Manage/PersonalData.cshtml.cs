using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Bank.Models;
using Mini_Bank.Models.ViewModels.SharedViewModels;
using Services.Models;
using Services.Services;

namespace Mini_Bank.Areas.Identity.Pages.Account.Manage
{
    public class PersonalDataModel : PageModel
    {

        private readonly IRegistrantService _registrantService;
        private readonly IUserService _userService;
        private readonly INomenclatureService _nomenclatureService;
        private readonly IMapper _mapper;

        public PersonalDataModel(IRegistrantService registrantService, 
                                    IUserService userService, 
                                    INomenclatureService nomenclatureService,
                                    IMapper mapper)
        {
            _registrantService = registrantService;
            _userService = userService;
            _nomenclatureService = nomenclatureService;
            _mapper = mapper;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public List<CountryModel> Countries { get; set; } 

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            public string Adress { get; set; }

            [Required]
            [Display(Name = "Country")]
            public int CountryId { get; set; }
        }

       

        public IActionResult OnGet()
        {
            string usesId = _userService.GetUserId(User);

            var registrant = _registrantService.GetRegistrantByUserId(int.Parse(usesId));

            if(registrant == null)
            {
                StatusMessage = "No personal info was found, please enter it now";

                Input = new InputModel();
            }
            else
            {
                Input = new InputModel()
                {
                    Adress = registrant.Address,
                    FirstName = registrant.FirstName,
                    LastName = registrant.LastName,
                    CountryId = registrant.Country
                };
            }

            var countryServiceModels = _nomenclatureService.GetCountries();
            Countries = _mapper.Map<List<CountryModel>>(countryServiceModels);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                int userId = int.Parse(_userService.GetUserId(User));

                var registrant = _registrantService.GetRegistrantByUserId(userId);

                if (registrant == null)
                {
                    registrant = new RegistrantServiceModel
                    {
                        FirstName = Input.FirstName,
                        LastName = Input.LastName,
                        Address = Input.Adress,
                        Country = Input.CountryId,

                        CreatedById = userId,
                        UserId = userId
                    };

                    _registrantService.CreateRegistrant(registrant);
                }
                else
                {
                    registrant.FirstName = Input.FirstName;
                    registrant.LastName = Input.LastName;
                    registrant.Address = Input.Adress;

                    registrant.CountryRelation = null; // setting relation to null so EF doesn't revert changes
                    registrant.Country = Input.CountryId;

                    registrant.EditedById = userId;

                    _registrantService.UpdateRegistrant(registrant);
                }

                StatusMessage = "Info successfuly updated";
            }

            var countryServiceModels = _nomenclatureService.GetCountries();
            Countries = _mapper.Map<List<CountryModel>>(countryServiceModels);

            return Page();
        }
    }
}