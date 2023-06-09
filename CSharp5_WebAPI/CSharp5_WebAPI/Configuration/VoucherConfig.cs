﻿using CSharp5_Share.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CSharp5_WebAPI.Configuration
{
    public class VoucherConfig : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.HasKey(x => x.VoucherID);
            builder.Property(x => x.VoucherName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.PercentageDiscount).HasColumnType("int").IsRequired();

        }
    }
}
