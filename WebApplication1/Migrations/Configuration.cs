﻿namespace WebApplication1.Migrations
{
    using WebApplication1.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AppContextDikoMou>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
