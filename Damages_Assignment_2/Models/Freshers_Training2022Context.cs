using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Damages_Assignment_2.Models
{
    public partial class Freshers_Training2022Context : DbContext
    {

        public Freshers_Training2022Context(DbContextOptions<Freshers_Training2022Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ShubhankarAssetInspectionDamage> ShubhankarAssetInspectionDamage { get; set; }
        public virtual DbSet<ShubhankarAssetInspectionEvidence> ShubhankarAssetInspectionEvidence { get; set; }
        public virtual DbSet<ShubhankarLkpDamageEvidence> ShubhankarLkpDamageEvidence { get; set; }
        public virtual DbSet<ShubhankarLkpDamageType> ShubhankarLkpDamageType { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShubhankarAssetInspectionDamage>(entity =>
            {
                entity.HasKey(e => e.DamageId)
                    .HasName("PK__Shubhank__FA307D71A05CEFD0");

                entity.ToTable("Shubhankar_AssetInspectionDamage");

                entity.Property(e => e.DamageId)
                    .HasColumnName("Damage_Id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("Created_On")
                    .HasColumnType("datetime");

                entity.Property(e => e.EstimateOfDamages).HasColumnName("Estimate_Of_Damages");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IsRoofDamage)
                    .HasColumnName("Is_Roof_Damage")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsSlidingDamage)
                    .HasColumnName("Is_Sliding_Damage")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.IsStructuralDamage)
                    .HasColumnName("Is_Structural_Damage")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("Modified_On")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ShubhankarAssetInspectionEvidence>(entity =>
            {
                entity.HasKey(e => e.EvidenceId)
                    .HasName("PK__Shubhank__A33BD749F35193A1");

                entity.ToTable("Shubhankar_AssetInspectionEvidence");

                entity.Property(e => e.EvidenceId).HasColumnName("Evidence_Id");

                entity.Property(e => e.DamageEvidence).HasColumnName("Damage_Evidence");

                entity.Property(e => e.DamageId).HasColumnName("Damage_Id");

                entity.Property(e => e.DamageType).HasColumnName("Damage_Type");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SpecifyOthers)
                    .HasColumnName("Specify_Others")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.DamageEvidenceNavigation)
                    .WithMany(p => p.ShubhankarAssetInspectionEvidence)
                    .HasForeignKey(d => d.DamageEvidence)
                    .HasConstraintName("FK__Shubhanka__Damag__772C6562");

                entity.HasOne(d => d.Damage)
                    .WithMany(p => p.ShubhankarAssetInspectionEvidence)
                    .HasForeignKey(d => d.DamageId)
                    .HasConstraintName("FK__Shubhanka__Damag__707F67D3");

                entity.HasOne(d => d.DamageTypeNavigation)
                    .WithMany(p => p.ShubhankarAssetInspectionEvidence)
                    .HasForeignKey(d => d.DamageType)
                    .HasConstraintName("FK__Shubhanka__Damag__76384129");
            });

            modelBuilder.Entity<ShubhankarLkpDamageEvidence>(entity =>
            {
                entity.HasKey(e => e.DamageEvidenceId)
                    .HasName("PK__Shubhank__11A3B0FA3262B647");

                entity.ToTable("Shubhankar_Lkp_Damage_Evidence");

                entity.Property(e => e.DamageEvidenceId).HasColumnName("Damage_Evidence_Id");

                entity.Property(e => e.DamageLevel)
                    .HasColumnName("Damage_Level")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DamageTypeId).HasColumnName("Damage_Type_Id");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.DamageType)
                    .WithMany(p => p.ShubhankarLkpDamageEvidence)
                    .HasForeignKey(d => d.DamageTypeId)
                    .HasConstraintName("FK__Shubhanka__Evide__7820899B");
            });

            modelBuilder.Entity<ShubhankarLkpDamageType>(entity =>
            {
                entity.HasKey(e => e.DamageTypeId)
                    .HasName("PK__Shubhank__1A333EC6269D8F11");

                entity.ToTable("Shubhankar_Lkp_Damage_Type");

                entity.Property(e => e.DamageTypeId).HasColumnName("Damage_Type_Id");

                entity.Property(e => e.DamageValue)
                    .HasColumnName("Damage_Value")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("Is_Deleted")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
