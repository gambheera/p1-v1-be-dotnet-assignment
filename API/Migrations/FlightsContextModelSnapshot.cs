﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Migrations
{
    [DbContext(typeof(FlightsContext))]
    partial class FlightsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Aggregates.AirportAggregate.Airport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Domain.Aggregates.CustomerAggregate.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Domain.Aggregates.FlightAggregate.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("Arrival")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Departure")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DestinationAirportId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OriginAirportId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("DestinationAirportId");

                    b.HasIndex("OriginAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Domain.Aggregates.FlightAggregate.FlightRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Available")
                        .HasColumnType("integer");

                    b.Property<Guid>("FlightId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("FlightRates");
                });

            modelBuilder.Entity("Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FlightRateId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset>("PlacedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("ReferenceNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("FlightRateId");

                    b.HasIndex("ReferenceNo")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Aggregates.FlightAggregate.Flight", b =>
                {
                    b.HasOne("Domain.Aggregates.AirportAggregate.Airport", "DestinationAirport")
                        .WithMany()
                        .HasForeignKey("DestinationAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Aggregates.AirportAggregate.Airport", "OriginAirport")
                        .WithMany()
                        .HasForeignKey("OriginAirportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Aggregates.FlightAggregate.FlightRate", b =>
                {
                    b.HasOne("Domain.Aggregates.FlightAggregate.Flight", null)
                        .WithMany("Rates")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Common.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("FlightRateId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Currency")
                                .HasColumnType("integer");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric");

                            b1.HasKey("FlightRateId");

                            b1.ToTable("FlightRates");

                            b1.WithOwner()
                                .HasForeignKey("FlightRateId");
                        });
                });

            modelBuilder.Entity("Domain.Aggregates.OrderAggregate.Order", b =>
                {
                    b.HasOne("Domain.Aggregates.CustomerAggregate.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Aggregates.FlightAggregate.FlightRate", null)
                        .WithMany()
                        .HasForeignKey("FlightRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
