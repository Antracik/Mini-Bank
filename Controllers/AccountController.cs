using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mini_Bank.FileRepo;
using Mini_Bank.FileRepo.Models;
using Mini_Bank.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mini_Bank.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<AccountRepoModel> _accounts;
        private readonly IMapper _mapper;

        public AccountController(ILogger<AccountController> logger, IRepository<AccountRepoModel> accounts, IMapper mapper)
        {
            _logger = logger;
            _accounts = accounts;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayAccounts()
        {
            try
            {
                _logger.LogInformation("Entering display accounts and starting file read");

                var accountsRepo = _accounts.Get();

                _logger.LogInformation($"Read : {accountsRepo.ToList().Count} accounts");
                var accountsModel = _mapper.Map<List<AccountModel>>(accountsRepo);

                return View(accountsModel);
            }
            catch(FileLoadException eIOExc)
            {
                displayAccountsErrCntr++;

                _logger.LogError(eIOExc, "Error?");

                return View("Error", new ErrorViewModel { RequestId = eIOExc.Message });
            }
            catch(FileNotFoundException eFNotFoundExc)
            {
                displayAccountsErrCntr++;

                _logger.LogError(eFNotFoundExc, "Error?");

                return View("Error", new ErrorViewModel { RequestId = "There was an error processing your request :(" });
            }
            catch (System.Exception e)
            {
                displayAccountsErrCntr++;

                _logger.LogError(e, "Empty");

                return View("Error", new ErrorViewModel { RequestId = "Unspecified  Error, Please report to the admin" });
            }
            finally
            {
                displayAccountsReqCntr++;
            }
        }

        public IActionResult DetailsAccount(int id)
        {
            var accountRepo = _accounts.Get().FirstOrDefault(ac => ac.Id == id);

            var accountModel = _mapper.Map<AccountModel>(accountRepo);

            return View(accountModel); 
        }

        static int displayAccountsReqCntr = 0;
        static  int displayAccountsErrCntr = 0;
    }
}