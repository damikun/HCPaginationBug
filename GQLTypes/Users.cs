using HotChocolate;
using HotChocolate.Types;
using Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types.Relay;
using System.Collections.Generic;
using Domain.Core.Models;
using Aplication.Interfaces;

namespace Aplication.GraphQL.Types {

    /// <summary>
    /// User GraphQL querry type
    /// </summary>
    public partial class Querry {

        /// <summary>
        /// Provide IQueryable schema on User object type
        /// </summary>
        /// <returns>IQueryable of User</returns>
        [UsePaging]
        [UseSelection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers(
            [Service] IAppDbContext context) =>
                context.Users.AsNoTracking();
    }   

    /// <summary>
    /// Graphql UserType
    /// </summary>
    public class UserType : ObjectType<User> {

        protected override void Configure(IObjectTypeDescriptor<User> descriptor) {

            descriptor.Field(t => t.ID).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Name).Type<StringType>();
            
        }
    }
}
