using EvolutionStuff.ServiceModel.Models.DbModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EvolutionStuff.ServiceInterface.Extensions
{
    public static class DbContextExtensions
    {
        public static void UpsertUsers(this DatabaseContext context, List<UserDb> users)
        {
            foreach (var user in users)
            {
                var existingUser = context.Users
                    .Include(u => u.Company)
                    .Include(u => u.Address)
                        .ThenInclude(a => a.Geo)
                    .FirstOrDefault(u => u.Id == user.Id);

                if (existingUser != null)
                {
                    context.Entry(existingUser).CurrentValues.SetValues(user);
                    context.UpsertNestedObjects(existingUser, user);
                }
                else
                {
                    context.Add(user);
                }
            }
        }

        private static void UpsertNestedObjects<T>(this DatabaseContext context, T existingObject, T newObject)
            where T : class
        {
            foreach (var property in typeof(T).GetProperties())
            {
                var existingValue = property.GetValue(existingObject);
                var newValue = property.GetValue(newObject);

                if (property.PropertyType.Namespace != null && property.PropertyType.Namespace.Equals("EvolutionStuff.ServiceModel.Models.DbModel"))
                {
                    context.UpsertNestedObjects(existingValue, newValue);
                }
                else
                {
                    property.SetValue(existingObject, newValue);
                }
            }
        }
    }

}
