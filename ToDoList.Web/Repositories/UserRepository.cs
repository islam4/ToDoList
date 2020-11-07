using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ToDoList.DAL.Interfaces;
using ToDoList.Web.Interfaces;
using ToDoList.Web.Models;
using ToDoList.Web.Models.Context;
using ToDoList.Web.Repositories;

namespace ToDoList.DAL.Repositories
{
    public class UserRepository 
    {
        internal readonly Repository<ApplicationUser> _repository;
        public UserRepository()
        {
            _repository = new Repository<ApplicationUser>(new ApplicationDbContext());
        }
    }
}
