﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class PleaseConfirmEmailModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}
