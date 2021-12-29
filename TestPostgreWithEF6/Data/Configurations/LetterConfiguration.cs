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
    public partial class LetterConfiguration : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> entity)
        {
            entity.ToTable("letters");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .UseIdentityAlwaysColumn();

            entity.Property(e => e.Additions)
                .HasColumnType("json")
                .HasColumnName("additions");

            entity.Property(e => e.Alwaysontop).HasColumnName("alwaysontop");

            entity.Property(e => e.Approveddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("approveddate");

            entity.Property(e => e.Attachments)
                .HasColumnType("json")
                .HasColumnName("attachments");

            entity.Property(e => e.Closedate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("closedate");

            entity.Property(e => e.Code).HasColumnName("code");

            entity.Property(e => e.Confidential).HasColumnName("confidential");

            entity.Property(e => e.Createdby)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("createdby");

            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Destinationid).HasColumnName("destinationid");

            entity.Property(e => e.Destinationtypeid).HasColumnName("destinationtypeid");

            entity.Property(e => e.Details)
                .HasColumnType("json")
                .HasColumnName("details");

            entity.Property(e => e.Isapproved)
                .HasColumnName("isapproved")
                .HasDefaultValueSql("false");

            entity.Property(e => e.Letterdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("letterdate");

            entity.Property(e => e.Letterno)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("letterno");

            entity.Property(e => e.Letternoen)
                .HasMaxLength(500)
                .HasColumnName("letternoen");

            entity.Property(e => e.Serialno).HasColumnName("serialno");

            entity.Property(e => e.Sourceid).HasColumnName("sourceid");

            entity.Property(e => e.Sourcetypeid).HasColumnName("sourcetypeid");

            entity.Property(e => e.Subject)
                .IsRequired()
                .HasMaxLength(2044)
                .HasColumnName("subject");

            entity.Property(e => e.Tags)
                .HasColumnType("jsonb")
                .HasColumnName("tags");

            entity.Property(e => e.Topsecret).HasColumnName("topsecret");

            entity.Property(e => e.Typeid).HasColumnName("typeid");

            entity.Property(e => e.Urgent).HasColumnName("urgent");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Letter> entity);
    }
}
