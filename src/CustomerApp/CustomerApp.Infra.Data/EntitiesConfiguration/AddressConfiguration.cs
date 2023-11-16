using CustomerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerApp.Infra.Data.EntitiesConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Logradouro).HasMaxLength(200).IsRequired();
        }
    }
}
