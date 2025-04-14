﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Persistence.Data;

#nullable disable

namespace api.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Entities.Attacks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AttackMode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("attack_mode");

                    b.Property<string>("AttackType1")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("attack_type1");

                    b.Property<string>("AttackType2")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("attack_type2");

                    b.Property<decimal>("Damage")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("damage");

                    b.Property<decimal>("ExtraDamage")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("extra_damage");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("TricksterWeaponId")
                        .HasColumnType("integer")
                        .HasColumnName("trickster_weapon_id");

                    b.Property<int>("extra_damage_count")
                        .HasColumnType("integer")
                        .HasColumnName("extra_damage_count");

                    b.HasKey("Id");

                    b.HasIndex("TricksterWeaponId");

                    b.ToTable("attacks");
                });

            modelBuilder.Entity("api.Models.Entities.Bosses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BloodEchoes")
                        .HasColumnType("integer")
                        .HasColumnName("blood_echoes");

                    b.Property<int>("Health")
                        .HasColumnType("integer")
                        .HasColumnName("health");

                    b.Property<bool>("IsInterruptible")
                        .HasColumnType("boolean")
                        .HasColumnName("is_interruptible");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("boolean")
                        .HasColumnName("is_required");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("bosses");
                });

            modelBuilder.Entity("api.Models.Entities.Firearms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArcaneAttack")
                        .HasColumnType("integer")
                        .HasColumnName("arcane_attack");

                    b.Property<int>("ArcaneRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("arcane_requirement");

                    b.Property<int>("BloodAttack")
                        .HasColumnType("integer")
                        .HasColumnName("blood_attack");

                    b.Property<int>("BloodtingeRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("bloodtinge_requirement");

                    b.Property<int>("BoltAttack")
                        .HasColumnType("integer")
                        .HasColumnName("bolt_attack");

                    b.Property<int>("BulletUse")
                        .HasColumnType("integer")
                        .HasColumnName("bullet_use");

                    b.Property<int>("FireAttack")
                        .HasColumnType("integer")
                        .HasColumnName("fire_attack");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("Imprints")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("imprints");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("PhysicalAttack")
                        .HasColumnType("integer")
                        .HasColumnName("physical_attack");

                    b.Property<int>("ScalingId")
                        .HasColumnType("integer")
                        .HasColumnName("scaling_id");

                    b.Property<int>("SkillRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("skill_requirement");

                    b.Property<int>("StrengthRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("strength_requirement");

                    b.HasKey("Id");

                    b.HasIndex("ScalingId")
                        .IsUnique();

                    b.ToTable("firearms");
                });

            modelBuilder.Entity("api.Models.Entities.Scalings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ArcaneScaling")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("arcane_scaling");

                    b.Property<decimal>("ArcaneStep")
                        .HasPrecision(3, 3)
                        .HasColumnType("numeric(3,3)")
                        .HasColumnName("arcane_step");

                    b.Property<decimal>("BloodtingeScaling")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("bloodtinge_scaling");

                    b.Property<decimal>("BloodtingeStep")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("bloodtinge_step");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<decimal>("SkillScaling")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("skill_scaling");

                    b.Property<decimal>("SkillStep")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("skill_step");

                    b.Property<decimal>("StrengthScaling")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("strength_scaling");

                    b.Property<decimal>("StrengthStep")
                        .HasPrecision(3, 2)
                        .HasColumnType("numeric(3,2)")
                        .HasColumnName("strength_step");

                    b.HasKey("Id");

                    b.ToTable("scalings");
                });

            modelBuilder.Entity("api.Models.Entities.TricksterWeapons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArcaneAttack")
                        .HasColumnType("integer")
                        .HasColumnName("arcane_attack");

                    b.Property<int>("ArcaneRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("arcane_requirement");

                    b.Property<int>("BloodAttack")
                        .HasColumnType("integer")
                        .HasColumnName("blood_attack");

                    b.Property<int>("BloodtingeRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("bloodtinge_requirement");

                    b.Property<int>("BoltAttack")
                        .HasColumnType("integer")
                        .HasColumnName("bolt_attack");

                    b.Property<int>("BulletUse")
                        .HasColumnType("integer")
                        .HasColumnName("bullet_use");

                    b.Property<int>("FireAttack")
                        .HasColumnType("integer")
                        .HasColumnName("fire_attack");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<string>("ImprintsLost")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("imprints_lost");

                    b.Property<string>("ImprintsNormal")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("imprints_normal");

                    b.Property<string>("ImprintsUncanny")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("imprints_uncanny");

                    b.Property<int>("MaxUpgradeAttack")
                        .HasColumnType("integer")
                        .HasColumnName("max_upgrade_attack");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("PhysicalAttack")
                        .HasColumnType("integer")
                        .HasColumnName("physical_attack");

                    b.Property<int>("Rally")
                        .HasColumnType("integer")
                        .HasColumnName("rally");

                    b.Property<int>("RapidPoison")
                        .HasColumnType("integer")
                        .HasColumnName("rapid_poison");

                    b.Property<int>("ScalingId")
                        .HasColumnType("integer")
                        .HasColumnName("scaling_id");

                    b.Property<int>("SkillRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("skill_requirement");

                    b.Property<int>("StrengthRequirement")
                        .HasColumnType("integer")
                        .HasColumnName("strength_requirement");

                    b.HasKey("Id");

                    b.HasIndex("ScalingId")
                        .IsUnique();

                    b.ToTable("trickster_weapons");
                });

            modelBuilder.Entity("api.Models.Entities.Attacks", b =>
                {
                    b.HasOne("api.Models.Entities.TricksterWeapons", "TricksterWeapons")
                        .WithMany("Attacks")
                        .HasForeignKey("TricksterWeaponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TricksterWeapons");
                });

            modelBuilder.Entity("api.Models.Entities.Firearms", b =>
                {
                    b.HasOne("api.Models.Entities.Scalings", "Scalings")
                        .WithOne("Firearms")
                        .HasForeignKey("api.Models.Entities.Firearms", "ScalingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scalings");
                });

            modelBuilder.Entity("api.Models.Entities.TricksterWeapons", b =>
                {
                    b.HasOne("api.Models.Entities.Scalings", "Scalings")
                        .WithOne("TricksterWeapons")
                        .HasForeignKey("api.Models.Entities.TricksterWeapons", "ScalingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scalings");
                });

            modelBuilder.Entity("api.Models.Entities.Scalings", b =>
                {
                    b.Navigation("Firearms")
                        .IsRequired();

                    b.Navigation("TricksterWeapons")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Entities.TricksterWeapons", b =>
                {
                    b.Navigation("Attacks");
                });
#pragma warning restore 612, 618
        }
    }
}
