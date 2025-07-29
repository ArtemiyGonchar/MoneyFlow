using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Infrastructure.Configurations
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        //Configuring UserProfile entity for db
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //Name property
            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            //CreatedAt property
            builder.Property(u => u.CreatedAt)
                .IsRequired();

            //Configuring One to Many property with Category
            builder.HasMany(u => u.Categories)
                .WithOne(c => c.UserProfile)
                .HasForeignKey(c => c.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            //Configuring One to Many property with Transaction
            builder.HasMany(u => u.Transactions)
                .WithOne(t => t.UserProfile)
                .HasForeignKey(t => t.UserProfileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
