using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class csFriend : ISeed<csFriend>
	{
        [Key]
        public Guid FriendId {get; set;}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }

        //Navigation props
        public csAdress Adress { get; set; } = null;    //null = no adress        

        public List<csPet> Pets { get; set; } = null;      //null = no pets 

        public List<csQuote> Quotes { get; set; } = null;


        public string FullName => $"{FirstName} {LastName}";
        public override string ToString()
        {
            var sRet = FullName;

            if (Adress != null)
            {
                sRet += $". lives at {Adress}";
            }

            if (Pets != null)
            {
                sRet += $". Has pets ";
                foreach (var pet in Pets)
                {
                    sRet += $"{pet}, ";
                }
            }
            return sRet;
        }

        #region Random Seeding
        public bool Seeded { get; set; } = false;

        public csFriend Seed(csSeedGenerator _seeder)
        {
            var fn = _seeder.FirstName;
            var ln = _seeder.LastName;
            var country = _seeder.Country;

            return new csFriend
            {
                FriendId = Guid.NewGuid(),

                FirstName = fn,
                LastName = ln,
                Email = _seeder.Email(fn, ln),
                Birthday = _seeder.Bool ?_seeder.DateAndTime(1950, 2020) : null,

                Seeded = true
            };
        }
        #endregion
    }
}

