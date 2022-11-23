using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_LINQ.Models {
    public class Address_Configuration : IEntityTypeConfiguration<Address> {
        public void Configure(EntityTypeBuilder<Address> address) {
            address.ToTable(name: "addresses");
            address.Property(a => a.MyAddressId).HasColumnName("address_id");
            address.HasKey(a => a.MyAddressId);
            address.Property(a => a.PostalCode).IsRequired().HasMaxLength(2000).HasColumnName("postal_code");
            address.Property(a => a.City).IsRequired().HasMaxLength(200).HasColumnName("city");

        }
    }
}
