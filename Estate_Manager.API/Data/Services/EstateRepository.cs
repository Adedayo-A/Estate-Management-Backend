using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Estate_Manager.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Estate_Manager.API.Data.Services
{
    public class EstateRepository : IEstateRepository
    {
        private readonly DataContext data;
        private readonly UserManager<User> manager;

        public EstateRepository(DataContext data, UserManager<User> manager)
        {
            this.data = data;
            this.manager = manager;
        }

        public void Add<T>(T entity) where T : class
        {
            data.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            data.Remove(entity);
        }

        public async Task<Estate> GetEstate(int estateId)
        {
            return await data.Estates.FindAsync(estateId);
            //return await data.Estates.Where(e => e.EstateId == estateId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HomeOwner>> GetHomeOwners(int estateId)
        {
            //return await data.HomeOwners.FindAsync(estateId);
            return await data.HomeOwners.Where(e => e.EstateId == estateId).ToArrayAsync();
        }

        public async Task<IEnumerable<Occupant>> GetOccupants(int estateId)
        {
            //return await data.HomeOwners.FindAsync(estateId);
            return await data.Occupants.Where(e => e.EstateId == estateId).ToArrayAsync();
        }

        public async Task<IEnumerable<Estate>> GetEstates()
        {
            return await data.Estates.ToArrayAsync();
        }

        public async Task<HomeOwner> GetHomeOwner(int estateId, int homeId)
        {
            return await data.HomeOwners.FindAsync(estateId, homeId);
        }

        public async Task<Occupant> GetOccupant(int estateId, int OccupantId)
        {
            return await data.Occupants.FindAsync(estateId, OccupantId);
        }

        public async Task<IEnumerable<Staff>> GetStaff(int estateId)
        {
            return await data.Staff.Where(e => e.EstateId == estateId).ToArrayAsync();
        }

        public async Task<Staff> GetAStaff(int estateId, int StaffId)
        {
            return await data.Staff.FindAsync(estateId, StaffId);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await manager.Users.ToArrayAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return await data.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Road>> GetEstateRoads(int estateId)
        {
            return await data.Roads.Where(r => r.EstateId == estateId).ToArrayAsync();
        }

        public async Task<Road> GetEstateRoad(int roadId)
        {
            return await data.Roads.Where(r => r.RoadId == roadId).FirstOrDefaultAsync();
        }
    }
}
