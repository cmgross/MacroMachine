﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacroMachine.Models
{
    public class ProfileIndexViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }

        public List<SelectListItem> Sexes { get; set; }

        public ProfileIndexViewModel(string userName)
        {
            ApplicationUser = ApplicationUser.Get(userName);
            var sexes = new char?[]{'M', 'F', null};
            Sexes = sexes.Select(s => new SelectListItem
            {
                Text = s.ToString(),
                Value = s.ToString(),
                Selected = s == ApplicationUser.BiologicalSex
            }).ToList();
        }
    }
}