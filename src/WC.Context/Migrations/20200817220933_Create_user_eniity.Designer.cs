﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WC.Context;

namespace WC.Context.Migrations
{
    [DbContext(typeof(WildCrittersDBContext))]
    [Migration("20200817220933_Create_user_eniity")]
    partial class Create_user_eniity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WC.Model.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActivationCode")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset>("DateOfCreation")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTimeOffset>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Mail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Pass")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("User");
                });
#pragma warning restore 612, 618
        }
    }
}
