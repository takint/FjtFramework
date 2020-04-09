using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FjtFramework.Cores
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(d => d.Id)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn();
        }
    }
}
