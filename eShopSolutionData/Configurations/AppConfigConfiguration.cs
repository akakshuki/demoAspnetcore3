using System;
using System.Collections.Generic;
using System.Text;
using eShopSolutionData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolutionData.Configurations
{
    class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("AppConfig");

            builder.HasKey(x => x.Key);

            builder.Property(x => x.Value).IsRequired(true);

        }
    }
}
