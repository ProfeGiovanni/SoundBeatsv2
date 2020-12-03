using System;
using Microsoft.AspNetCore.Identity;

namespace SoundBeatsV2.Infrastructure.Identity
{
    public class SoundBeatsUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public string Address { get; set; }

    }
}
