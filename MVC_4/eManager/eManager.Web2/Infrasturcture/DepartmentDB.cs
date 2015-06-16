using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using eManager.Domain;

namespace eManager.Web.Infrasturcture
{
    public class DepartmentDB : DbContext, IDepartmentDataSource
    {
        public DepartmentDB ()  : base("EConnection")
        {

        }
        public DbSet<Employee> Employees
        {
            get;
            set;
        }
        public DbSet<Department> Departments
        {
            get;
            set;
        }

        IQueryable<Employee> IDepartmentDataSource.Employees
        {
            get
            {
                return Employees;
            }
        }

        IQueryable<Department> IDepartmentDataSource.Departments
        {
            get
            {
                return Departments;
            }
        }


        void IDepartmentDataSource.Save ()
        {
            SaveChanges();
        }
    }
}