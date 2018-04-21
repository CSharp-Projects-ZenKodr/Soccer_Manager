﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using DAL;
using DAL.Model_Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository_Realisation
{
    public class TeamRepository : IRepository<Team> 
    {
        private readonly SoccerContext _dataContext;
        private readonly DbSet<Team> _dbset;


        public TeamRepository(DataContextProvider dcProvider)
        {
            _dataContext = dcProvider.Get();
            _dbset = _dataContext.Teams;
        }

        public void Add(Team team)
        {
            _dbset.Add(team);
            _dataContext.SaveChanges();
        }

        public void Update(Team team)
        {
            _dataContext.Entry(team).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        public void Delete(Team team)
        {
            _dbset.Remove(team);
            _dataContext.SaveChanges();
        }

        public void Delete(Expression<Func<Team, bool>> where)
        {
            _dbset.Where(where)
               .ForEachAsync(entity => _dbset.Remove(entity));
            _dataContext.SaveChanges();
        }

        public Team Get(long id)
        {
            var teams = _dbset.Include(t => t.Players)
                .Include(t => t.TeamTournaments).ThenInclude(tt => tt.Tournament);

            return teams.First(t => t.TeamId == id);
        }

        public Team Get(Expression<Func<Team, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<Team>();
        }

        public IEnumerable<Team> GetMany(Expression<Func<Team, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public IEnumerable<Team> GetAll()
        {
            var lst = _dbset.Include(t => t.Players)
                .Include(t => t.TeamTournaments).ThenInclude(tt => tt.Tournament).ToList();

            return lst;
        }

        public void AddTeamTournaments(Team team, Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }

}
