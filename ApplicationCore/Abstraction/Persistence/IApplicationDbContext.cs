using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Abstraction.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<PluginEffect> Effects { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<ImagePluginEffect> ImagePluginEffects{ get; set; }
        DbSet<StorageReference> StorageReferences {get;set;}

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
