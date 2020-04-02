using Estate_Manager.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estate_Manager.API.Data.Services
{
    public interface IEstateRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<IEnumerable<Estate>> GetEstates();
        Task<IEnumerable<HomeOwner>> GetHomeOwners(int estateId);
        Task<HomeOwner> GetHomeOwner(int estateId, int homeId);

        Task<IEnumerable<Occupant>> GetOccupants(int estateId);
        Task<Occupant> GetOccupant(int estateId, int OccupantId);

        Task<IEnumerable<Staff>> GetStaff(int estateId);
        Task<Staff> GetAStaff(int estateId, int StaffId);
        Task<IEnumerable<User>> GetAllUsers();

        Task<Estate> GetEstate(int estateId);
        Task<IEnumerable<Road>> GetEstateRoads(int estateId);
        Task<Road> GetEstateRoad(int roadId);

        Task<bool> SaveChanges();
    }
}
