﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using TestPostgreWithEF6.Data;
using TestPostgreWithEF6.Models;

namespace TestPostgreWithEF6.Data.Configurations
{
    public partial class MemologConfiguration : IEntityTypeConfiguration<Memolog>
    {
        public void Configure(EntityTypeBuilder<Memolog> entity)
        {
            entity.HasKey(e => e.Logid)
                .HasName("memologs_pkey");

            entity.ToTable("memologs");

            entity.Property(e => e.Logid)
                .HasColumnName("logid")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Createdby)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("createdby");

            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");

            entity.Property(e => e.Letterid).HasColumnName("letterid");

            entity.Property(e => e.Memoid).HasColumnName("memoid");

            entity.Property(e => e.Message)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("message");

            entity.HasOne(d => d.Memo)
                .WithMany(p => p.Memologs)
                .HasForeignKey(d => d.Memoid)
                .HasConstraintName("fk_memos_logs");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Memolog> entity);
    }
}
