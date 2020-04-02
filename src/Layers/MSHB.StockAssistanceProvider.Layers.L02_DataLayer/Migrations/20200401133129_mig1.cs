﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.StockAssistanceProvider.Layers.L02_DataLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupAuth_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAuth_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log_T",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    LogLevel = table.Column<string>(nullable: true),
                    Logger = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    StateJson = table.Column<string>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportStructure_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportId = table.Column<string>(maxLength: 40, nullable: false),
                    Configuration = table.Column<string>(nullable: true),
                    ProtoType = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    LastUpdatedDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportStructure_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_T", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User_T",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 450, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 500, nullable: true),
                    LastName = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Location = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    LastLockoutDate = table.Column<DateTime>(nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastVisit = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastLoggedIn = table.Column<DateTimeOffset>(nullable: true),
                    SerialNumber = table.Column<string>(maxLength: 450, nullable: true),
                    SajadUserName = table.Column<string>(maxLength: 200, nullable: true),
                    IsPresident = table.Column<int>(nullable: true),
                    GroupAuthId = table.Column<long>(nullable: true),
                    UserConfigurationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_T_GroupAuth_T_GroupAuthId",
                        column: x => x.GroupAuthId,
                        principalTable: "GroupAuth_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupAuthRole_T",
                columns: table => new
                {
                    GroupAuthId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupAuthRole_T", x => new { x.GroupAuthId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_GroupAuthRole_T_GroupAuth_T_GroupAuthId",
                        column: x => x.GroupAuthId,
                        principalTable: "GroupAuth_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupAuthRole_T_Role_T_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FileAddress_T",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false, defaultValueSql: "NEWID()"),
                    FileType = table.Column<string>(maxLength: 20, nullable: true),
                    FileSize = table.Column<long>(nullable: true),
                    FilePath = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAddress_T", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileAddress_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConfiguration_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    Configuration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfiguration_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserConfiguration_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole_T",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole_T", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_T_Role_T_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessTokenHash = table.Column<string>(nullable: true),
                    AccessTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    RefreshTokenIdHash = table.Column<string>(maxLength: 450, nullable: false),
                    RefreshTokenIdHashSource = table.Column<string>(maxLength: 450, nullable: true),
                    RefreshTokenExpiresDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileAddress_T_FileId",
                table: "FileAddress_T",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAddress_T_UserId",
                table: "FileAddress_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupAuthRole_T_RoleId",
                table: "GroupAuthRole_T",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStructure_T_ReportId",
                table: "ReportStructure_T",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_T_Id",
                table: "Role_T",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Role_T_Name",
                table: "Role_T",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_T_GroupAuthId",
                table: "User_T",
                column: "GroupAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_Id",
                table: "User_T",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_UserConfigurationId",
                table: "User_T",
                column: "UserConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_Username",
                table: "User_T",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserConfiguration_T_UserId",
                table: "UserConfiguration_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_T_RoleId",
                table: "UserRole_T",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_T_UserId",
                table: "UserRole_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_T_UserId",
                table: "UserToken_T",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileAddress_T");

            migrationBuilder.DropTable(
                name: "GroupAuthRole_T");

            migrationBuilder.DropTable(
                name: "Log_T");

            migrationBuilder.DropTable(
                name: "ReportStructure_T");

            migrationBuilder.DropTable(
                name: "UserConfiguration_T");

            migrationBuilder.DropTable(
                name: "UserRole_T");

            migrationBuilder.DropTable(
                name: "UserToken_T");

            migrationBuilder.DropTable(
                name: "Role_T");

            migrationBuilder.DropTable(
                name: "User_T");

            migrationBuilder.DropTable(
                name: "GroupAuth_T");
        }
    }
}
