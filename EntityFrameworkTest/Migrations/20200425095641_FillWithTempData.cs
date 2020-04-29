using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkTest.Migrations
{
    public partial class FillWithTempData : Migration
    {
        private static Random _random = new Random();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Data10",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data4",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data5",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data6",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data7",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data8",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data9",
                table: "Team",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Team",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Data10",
                table: "Audit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data7",
                table: "Audit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data8",
                table: "Audit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data9",
                table: "Audit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data10",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data5",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data6",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data7",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data8",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Data9",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql(@"
DELETE FROM Audit;
DELETE FROM AccountTeam;
DELETE FROM Team;
DELETE FROM Accounts;
");

            // Accounts
            migrationBuilder.Sql(@"SET IDENTITY_INSERT Accounts ON;");

            for (int accountId = 1; accountId <= 10; accountId++)
            {
                migrationBuilder.Sql($@"
INSERT INTO Accounts (Id, FirstName, LastName, DeletedAt, Data5, Data6, Data7, Data8, Data9, Data10)
VALUES ({accountId}, '{RandomString(5)}', '{RandomString(7)}', '{(_random.Next(0, 2) == 1 ? DateTime.UtcNow.ToString("s") : "NULL")}', {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)} , {_random.Next(1, 100)});");
            }

            migrationBuilder.Sql(@"SET IDENTITY_INSERT Accounts OFF;");

            // Teams
            migrationBuilder.Sql(@"SET IDENTITY_INSERT Team ON;");

            for (int teamId = 1; teamId <= 10; teamId++)
            {
                migrationBuilder.Sql($@"
INSERT INTO Team (Id, Name, DeletedAt, Data4, Data5, Data6, Data7, Data8, Data9, Data10)
VALUES ({teamId}, 'Team {teamId}', '{(_random.Next(0, 2) == 1 ? DateTime.UtcNow.ToString("s") : "NULL")}', {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)} , {_random.Next(1, 100)});");
            }

            migrationBuilder.Sql(@"SET IDENTITY_INSERT Team OFF;");

            // Relation between Account and Teams
            for (int accountId = 1; accountId <= 10; accountId++)
            {
                var teams = new List<int>();
                for (int i = 1; i <= 3; i++)
                {
                    int teamId;

                    while(true)
                    {
                        teamId = _random.Next(1, 11);
                        if (!teams.Contains(teamId)) break;
                    }

                    teams.Add(teamId);

                    migrationBuilder.Sql($"INSERT INTO AccountTeam (AccountId, TeamId) VALUES ({accountId}, {teamId})");
                }
            }

            // Audit Logs
            for (int accountId = 1; accountId <= 10; accountId++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    migrationBuilder.Sql($@"
INSERT INTO Audit (AuditCodeType, ObjectId, Date, Details, AccountId, Data7, Data8, Data9, Data10)
VALUES ({_random.Next(0, 100)}, {_random.Next(0, 100)}, '{DateTime.UtcNow.AddDays(_random.Next(1, 100)):s}', '{RandomString(50)}', {accountId}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)}, {_random.Next(1, 100)})");
                }
            }


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data10",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data4",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data5",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data6",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data7",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data8",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data9",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "Data10",
                table: "Audit");

            migrationBuilder.DropColumn(
                name: "Data7",
                table: "Audit");

            migrationBuilder.DropColumn(
                name: "Data8",
                table: "Audit");

            migrationBuilder.DropColumn(
                name: "Data9",
                table: "Audit");

            migrationBuilder.DropColumn(
                name: "Data10",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Data5",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Data6",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Data7",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Data8",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Data9",
                table: "Accounts");
        }

        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}
