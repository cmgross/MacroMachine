using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacroMachine.Models
{
    public class ProfileIndexViewModel
    {
        public string UserName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Birthday { get; set; }
        public int Age => GetAge(Birthday);

        public bool Metric { get; set; }
        public decimal? Height { get; set; }

        public List<SelectListItem> Sexes { get; set; }
        public string BiologicalSex { get; set; }

        public ProfileIndexViewModel(string userName)
        {
            var user = ApplicationUser.Get(userName);
            var sexes = new[]{"M", "F", null};
            Sexes = sexes.Select(s => new SelectListItem
            {
                Text = s,
                Value = s,
                Selected = s == user.BiologicalSex
            }).ToList();

            Birthday = user.Birthday;
            UserName = user.UserName;
            BiologicalSex = user.BiologicalSex;
            Metric = user.Metric;
            Height = user.Height;
        }

        private static int GetAge(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue) return 0;
            var now = DateTime.UtcNow;
            return now.Year - dateOfBirth.Value.Year -
                (
                    now.Month > dateOfBirth.Value.Month ||
                    (now.Month == dateOfBirth.Value.Month && now.Day >= dateOfBirth.Value.Day) ? 0 : 1
                );
        }
    }
}