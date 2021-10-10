using ApplicationCore.Abstraction;
using ApplicationCore.Abstraction.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class DatabaseContext: DbContext, IApplicationDbContext
    {
        private readonly IAuthorizationContext _authorizationContext;
        private readonly IDateTime _dateTime;

        public DatabaseContext(DbContextOptions dbContext,IAuthorizationContext authorizationContext,IDateTime dateTime): base(dbContext)
        {
            _authorizationContext = authorizationContext;
            _dateTime = dateTime;
        }

        public DbSet<PluginEffect> Effects { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<StorageReference> StorageReferences { get; set; }
        public DbSet<ImagePluginEffect> ImagePluginEffects { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleSoftDelete();
            UpdateAuditFields();

            return base.SaveChangesAsync(cancellationToken);
        }



        public void HandleSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries().Where(s => s.State is EntityState.Deleted))
            {
                if (!entry.Entity.GetType().IsAssignableTo(typeof(ISoftDeleteEntity)))
                    continue;
                var entity = (ISoftDeleteEntity)entry.Entity;
                entity.Deleted = true;
                entry.State = EntityState.Modified;
            }
        }

        public void UpdateAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries().Where(s => s.State is EntityState.Added or EntityState.Modified))
            {
                if (!entry.Entity.GetType().IsAssignableTo(typeof(IAuditEntity)))
                    continue;

                var entity = (IAuditEntity)entry.Entity;

                entity.UpdatedBy = _authorizationContext.UserId;
                entity.UpdatedDate = _dateTime.UtcNow;



                if (entry.State != EntityState.Added) continue;

                entity.CreatedBy = _authorizationContext.UserId;
                entity.CreatedDate = _dateTime.UtcNow;
            }
        }
    }
}
