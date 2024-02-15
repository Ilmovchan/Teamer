using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Teamer.DATA.Models;

namespace Teamer.BL.Controllers
{
    public class TaskController
    {
        private readonly DbContext _context;
        public List<TeamUser> TeamUsers { get; set; }

        public TaskController(DbContext context)
        {
            _context = context;

            TeamUsers = _context.Set<TeamUser>().ToList();
        }

        public void AddTask(Team team, User user, Task task)
        {
            var teamUser = TeamUsers.SingleOrDefault(tu => tu.Team == team && tu.User == user);

            if (teamUser != null)
            {
                task.UserId = user.Id;
                task.TeamId = team.Id;

                teamUser.Tasks.Add(task);
                _context.Set<TeamUser>().Update(teamUser);
                _context.SaveChanges();
            }
        }
    }
}
