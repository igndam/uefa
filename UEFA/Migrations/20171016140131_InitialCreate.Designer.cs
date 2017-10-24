using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using UEFA.Models;

namespace UEFA.Migrations
{
    [DbContext(typeof(UEFAContext))]
    [Migration("20171016140131_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UEFA.Models.UEFAteam", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Manager");

                    b.Property<string>("country");

                    b.Property<string>("currentPhase");

                    b.Property<string>("currentRecord");

                    b.Property<string>("name");

                    b.Property<bool>("neededQualification");

                    b.Property<bool>("previousWinner");

                    b.HasKey("id");

                    b.ToTable("UEFAteams");
                });
        }
    }
}
