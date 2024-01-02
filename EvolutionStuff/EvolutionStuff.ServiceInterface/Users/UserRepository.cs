using EvolutionStuff.ServiceInterface.Extensions;
using EvolutionStuff.ServiceModel.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using ServiceStack.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolutionStuff.ServiceInterface.Users
{
    public interface IUserRepository
    {
        public void UpsertUsers(List<UserDb> Users);
        public void AddUsers(List<UserDb> Users);
        public void Update(UserDb user);
        public void UpdateRange(List<UserDb> users);
        public Task Delete(int id);
        public Task<UserDb> GetOne(int userId);
        public List<UserDb> GetAll();
    }
    public class UserRepository(DatabaseContext context, ILog log) : IUserRepository
    {
        private readonly DatabaseContext _context = context;
        private readonly ILog _log = log;

        public void UpsertUsers(List<UserDb> users)
        {
            foreach (var user in users)
            {
                user.Company?.SetIds(user);
                user.Address?.SetIds(user);
                user.Address?.Geo?.SetIds(user);
            }
            _context.UpsertUsers(users);
            _context.SaveChanges();
        }

        public void AddUsers(List<UserDb> users)
        {
            foreach (var user in users)
            {
                user.Address?.SetIds(user);
                user.Company?.SetIds(user);
                user.Address?.Geo?.SetIds(user);
            }
            _context.AddRange(users);
            _context.SaveChanges();

        }

        public void UpdateRange(List<UserDb> users)
        {
            UpdateEntities(users);
        }

        public void Update(UserDb user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;

            _context.SaveChanges();
        }

        private void UpdateEntities(List<UserDb> users)
        {
            foreach (var user in users)
            {
                _context.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public async Task Delete(int userId)
        {
            var userToRemove = await _context.Users.FindAsync(userId);

            if (userToRemove != null)
            {
                var companyToRemove = await _context.Companies.FindAsync(userId);
                var addressToRemove = await _context.Addresses.FindAsync(userId);
                var geoToRemove = await _context.Geos.FindAsync(userId);

                UserDb userToBeRemoved = userToRemove;
                userToBeRemoved.Company = companyToRemove;
                userToBeRemoved.Address = addressToRemove;
                userToBeRemoved.Address.Geo = geoToRemove;
                _log.Info($"Entity to be deleted: {userToBeRemoved.ToJson()}");

                if (companyToRemove != null)
                {
                    _context.Companies.Remove(companyToRemove);
                }

                if (addressToRemove != null)
                {
                    _context.Addresses.Remove(addressToRemove);
                }

                if (geoToRemove != null)
                {
                    _context.Geos.Remove(geoToRemove);
                }

                _context.Users.Remove(userToRemove);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserDb> GetOne(int userId)
        {
            var userToRetrieve = await _context.Users
                .Include(u => u.Company)
                .Include(u => u.Address)
                    .ThenInclude(a => a.Geo)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return userToRetrieve;
        }


        public List<UserDb> GetAll()
        {
            List<UserDb> users =
            [
                .. _context.Users.
                                Include(u => u.Company).
                                Include(u => u.Address).
                                    ThenInclude(a => a.Geo).
                                Select(u => new UserDb
                                {
                                    Id = u.Id,
                                    AdditionalColumn = u.AdditionalColumn,
                                    Address = new AddressDb
                                    {
                                        City = u.Address.City,
                                        Street = u.Address.Street,
                                        Suite = u.Address.Suite,
                                        Zipcode = u.Address.Zipcode,
                                        Geo = u.Address.Geo
                                    },
                                    Company = u.Company,
                                    Email = u.Email,
                                    Name = u.Name,
                                    Phone = u.Phone,
                                    Username = u.Username,
                                    Website = u.Website
                                }),
            ];
            return users;
        }
    }
}
