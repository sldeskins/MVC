using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using eManager.Domain;

namespace eManager.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrasturcture.DepartmentDB>
    {
        public Configuration ()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed ( eManager.Web.Infrasturcture.DepartmentDB context )
        {
            context.Departments.AddOrUpdate(d => d.Name,
                new Department()
                {
                    Name = "Engineering"
                },
                new Department()
                {
                    Name = "Sales"
                },
                new Department()
                {
                    Name = "Shipping"
                },
                new Department()
                {
                    Name = "Human Resources"
                }
            );
        }
    }
}
