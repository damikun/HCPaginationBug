using System;
using Microsoft.EntityFrameworkCore;
using Domain.Core.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Aplication.Interfaces {

    public interface IAppDbContext {

        DbSet<User> Users { get; set; }
              Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
