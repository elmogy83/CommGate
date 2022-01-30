using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommGate.Data.Migrations
{
    public partial class FixIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "AspNetUsers");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthdate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

          
        }
    }
}
