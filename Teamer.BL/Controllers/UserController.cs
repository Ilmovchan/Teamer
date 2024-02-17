using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teamer.DATA.Models;

namespace Teamer.BL.Controllers
{
    public class UserController
    {
        private readonly DbContext _context;
        public User CurrentUser { get; private set; }
        public List<User> Users { get; private set; }

        public UserController(DbContext context)
        {
            _context = context;

            Users = _context.Set<User>().ToList();
        }

        public void SetCurrentUser(string name) 
        {
            CurrentUser = Users.SingleOrDefault(u => u.Name == name);

            if (CurrentUser == null)
            {
                AddUser(name);
            }
        }

        public void AddUser(string name)
        {
            CurrentUser = new User(name);
            Users.Add(CurrentUser);
            _context.Set<User>().Add(CurrentUser);
            _context.SaveChanges();
        }

        public void EditUser(string? email, string? phone, string? iconUrl)
        {
            CurrentUser.Email = email;
            CurrentUser.Phone = phone;
            CurrentUser.IconUrl = iconUrl;

            _context.Update(CurrentUser);
            _context.SaveChanges();
        }
    }
}
