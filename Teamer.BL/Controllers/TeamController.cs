using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Teamer.DATA.Models;

namespace Teamer.BL.Controllers
{
    public class TeamController
    {
        private readonly DbContext _context;
        public List<Team> Teams { get; private set; }

        public TeamController(DbContext context) 
        {
            _context = context;

            Teams = _context.Set<Team>().ToList();
        }

        public void CreateTeam(User admin ,string name, string? description, string? iconUrl)
        {
            var team = new Team(admin, name, description, iconUrl);
            Teams.Add(team);
            _context.Add(team);
            _context.SaveChanges();
        }

        public void DeleteTeam(Team team)
        {
            Teams.Remove(team);
            _context.Remove(team);
            _context.SaveChanges();
        }

        public void EditTeam(Team team, string name, string? description, string iconUrl)
        {
            team.Name = name;
            team.Description = description;
            team.IconUrl = iconUrl;
            _context.Update(team);
            _context.SaveChanges();
        }

        public void AddUser(Team team, User user)
        {
            var teamUser = new TeamUser { Team = team , User = user };
            _context.Add(teamUser);
            _context.SaveChanges();
        }

        public void RemoveUser(Team team, User user)
        {
            var teamUser = _context.Set<TeamUser>()
                .SingleOrDefault(tu => tu.TeamId == team.Id && tu.UserId == user.Id);

            if (teamUser != null)
            {
                _context.Remove(teamUser);
                _context.SaveChanges();
            }
        }

        public Team GetByName(string name)
        {
            return Teams.SingleOrDefault(n => n.Name == name);
        }
    }
}
