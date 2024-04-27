﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infrastructure.Database;

#nullable disable

namespace infrastructure.Migrations
{
    [DbContext(typeof(BContext))]
    [Migration("20240427145905_InitialCreate1")]
    partial class InitialCreate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("infrastructure.Database.ChassisEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Height")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Length")
                        .HasColumnType("TEXT");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Weight")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Width")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChassisEntity", (string)null);
                });

            modelBuilder.Entity("infrastructure.Database.ComponentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BlueprintId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ChassisId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("EngineId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Manufactured")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OptionPackId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderEntityId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("UsedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Warehouse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChassisId");

                    b.HasIndex("EngineId");

                    b.HasIndex("OptionPackId");

                    b.HasIndex("OrderEntityId");

                    b.ToTable("ComponentEntity", (string)null);
                });

            modelBuilder.Entity("infrastructure.Database.EngineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Capacity")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<byte>("CylinderNo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EngineEntity", (string)null);
                });

            modelBuilder.Entity("infrastructure.Database.OptionPackEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OptionPackEntity", (string)null);
                });

            modelBuilder.Entity("infrastructure.Database.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OrderNo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SerialNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("OrderEntity", (string)null);
                });

            modelBuilder.Entity("infrastructure.Database.ComponentEntity", b =>
                {
                    b.HasOne("infrastructure.Database.ChassisEntity", "Chassis")
                        .WithMany()
                        .HasForeignKey("ChassisId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("infrastructure.Database.EngineEntity", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("infrastructure.Database.OptionPackEntity", "OptionPack")
                        .WithMany()
                        .HasForeignKey("OptionPackId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("infrastructure.Database.OrderEntity", "OrderEntity")
                        .WithMany("ComponentEntities")
                        .HasForeignKey("OrderEntityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Chassis");

                    b.Navigation("Engine");

                    b.Navigation("OptionPack");

                    b.Navigation("OrderEntity");
                });

            modelBuilder.Entity("infrastructure.Database.OrderEntity", b =>
                {
                    b.Navigation("ComponentEntities");
                });
#pragma warning restore 612, 618
        }
    }
}