using bernamji.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DataAccess.Persistence.Configurations;
internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasIndex(u => u.UserName)
            .IsUnique();

        builder.Property(m => m.UserName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Password)
           .IsRequired()
           .HasMaxLength(128);
    }
}
