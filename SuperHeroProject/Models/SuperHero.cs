using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroProject.Models
{
    public class SuperHero
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "Superhero Name")]
        public string SuperHeroName { get; set; }
        [Display(Name = "Alter Ego")]
        public string AlterEgo { get; set; }
        [Display(Name = "Primary Ability")]
        public string PrimaryAbility { get; set; }
        [Display(Name = "Secondary Ability")]
        public string SecondaryAbility { get; set; }
        [Display(Name = "Catchphrase")]
        public string Catchphrase { get; set; }



    }
}
