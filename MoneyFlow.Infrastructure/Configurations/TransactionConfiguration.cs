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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //Configure Title property
            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            //Configure Description property
            builder.Property(t => t.Description)
                .HasMaxLength(500)
                .IsRequired();

            //Configure value object Money
            builder.OwnsOne(t => t.Amount, money =>
            {
                money.Property(m => m.Amount)
                .IsRequired();
            });
        }
    }
}
