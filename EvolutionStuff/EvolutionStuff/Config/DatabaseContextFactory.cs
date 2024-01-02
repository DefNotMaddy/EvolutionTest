using EvolutionStuff.ServiceModel.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace EvolutionStuff
{
    public class DatabaseContextFactory(DbContextOptions<DatabaseContext> dbContextOptions)
    {
        private readonly DbContextOptions<DatabaseContext> _dbContextOptions = dbContextOptions;

        public DatabaseContext Create()
        {
            return new DatabaseContext(_dbContextOptions);
        }
    }
}