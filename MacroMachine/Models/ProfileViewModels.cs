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
        public string BiologicalSex { get; set; }

        #region MetricFields
        public bool Metric { get; set; }
        public decimal? Height { get; set; }
        #endregion

        public int? HeightFeet { get; set; }
        public int? HeightInches { get; set; }


        #region CalcualtedFields
        public int Age => GetAge(Birthday);
        public decimal? HeightInchesTotal => GetHeightInInches(Height ?? 0);
        #endregion
        #region SelectLists
        public List<SelectListItem> Sexes { get; set; }
        public List<SelectListItem> Feet { get; set; }
        public List<SelectListItem> Inches { get; set; }
        #endregion



        public ProfileIndexViewModel(string userName)
        {
            var user = ApplicationUser.Get(userName);
            var sexes = new[] { "M", "F", null };
            var feet = new[] { "4", "5", "6" };
            var inches = Enumerable.Range(0, 11);
            //TODO convert metric Height here

            var userFeet = (int)(HeightInchesTotal/12);
            var userInches = HeightInchesTotal%12;

            Sexes = sexes.Select(s => new SelectListItem
            {
                Text = s,
                Value = s,
                Selected = s == user.BiologicalSex
            }).ToList();
            Feet = feet.Select(f => new SelectListItem
            {
                Text = f,
                Value = f,
                Selected = f == userFeet.ToString()
            }).ToList();
            Inches = inches.Select(i => new SelectListItem
            {
                Text = i.ToString(),
                Value = i.ToString(),
                Selected = i.ToString() == userInches.ToString()
            }).ToList();

            Birthday = user.Birthday;
            UserName = user.UserName;
            BiologicalSex = user.BiologicalSex;
            Metric = user.Metric;
            Height = user.Height;
        }

        #region ConversionMethods
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

        private static decimal GetHeightInInches(decimal heightInCm)
        {
            return 74;
            var inches = (double)heightInCm * 0.393701;
            return (decimal)inches;

        }
        #endregion
    }
}