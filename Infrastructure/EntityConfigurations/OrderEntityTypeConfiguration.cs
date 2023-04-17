using Domain.Aggregates.CustomerAggregate;
using Domain.Aggregates.FlightAggregate;
using Domain.Aggregates.OrderAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityConfigurations
{
    public class OrderEntityTypeConfiguration : BaseEntityTypeConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);

            builder.Property("ReferenceNo").IsRequired();
            builder.Property("PlacedAt").IsRequired();
            builder.Property("Status").IsRequired();

            builder.HasIndex(o => o.ReferenceNo).IsUnique();

            builder.HasOne(f => f.Customer)
                .WithMany()
                .IsRequired()
                .HasForeignKey("CustomerId");

            builder.HasOne(f => f.FlightRate)
                .WithMany()
                .IsRequired()
                .HasForeignKey("FlightRateId");
        }
    }
}
