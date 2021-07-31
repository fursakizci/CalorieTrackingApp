﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTrackingApp.UI.Identity
{
    public class IdentityDbContext:IdentityDbContext<User>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options):base(options)
        {

        }
    }
}
