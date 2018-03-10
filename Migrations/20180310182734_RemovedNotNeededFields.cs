using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hack242018API.Migrations
{
    public partial class RemovedNotNeededFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "Locality",
                table: "Establishments");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Establishments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressLine",
                table: "Establishments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "Establishments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Establishments",
                nullable: true);
        }
    }
}
