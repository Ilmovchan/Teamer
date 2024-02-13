using Microsoft.EntityFrameworkCore;
using Teamer.BL.Controllers;
using Teamer.DATA.Models;
using Teamer.DATA.Repository;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var _context = new DataContext())
            {
                UserController userController = new UserController("Bodya", _context);
                TeamController teamController = new TeamController(_context);
                /*
                                foreach (var user in userController.Users)
                                {
                                    Console.WriteLine(user.Name);
                                }*/

                teamController.AddUser(teamController.Teams[2], userController.CurrentUser);

                foreach (var teamUser in _context.TeamUsers.ToList())
                {
                    Console.WriteLine(teamUser);
                }
            }
        }
    }
}
