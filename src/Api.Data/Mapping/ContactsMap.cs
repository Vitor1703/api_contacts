using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ContactsMap : IEntityTypeConfiguration<ContactsEntity>
    {
        public void Configure(EntityTypeBuilder<ContactsEntity> builder)
        {
            builder.ToTable("Contacts");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Phone)
                .IsUnique();

            builder.Property(u => u.Phone)
                .HasMaxLength(11);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(60);

        }
    }
}