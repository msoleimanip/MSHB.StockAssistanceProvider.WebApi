using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.StockAssistanceProvider.Layers.L02_DataLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board_T",
                columns: table => new
                {
                    CComVal = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LBoard = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board_T", x => x.CComVal);
                });

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
                name: "MarketValue_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketValuePrice = table.Column<decimal>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketValue_T", x => x.Id);
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
                name: "Sector_T",
                columns: table => new
                {
                    CSecVal = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LSecVal = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sector_T", x => x.CSecVal);
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
                    SerialNumber = table.Column<string>(maxLength: 450, nullable: true),
                    LastLockoutDate = table.Column<DateTime>(nullable: true),
                    LastPasswordChangedDate = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastVisit = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastLoggedIn = table.Column<DateTimeOffset>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    AvailableUserType = table.Column<int>(nullable: true),
                    GroupAuthId = table.Column<long>(nullable: true)
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
                name: "SubSector_T",
                columns: table => new
                {
                    CSecVal = table.Column<long>(nullable: false),
                    CSoSecVal = table.Column<long>(nullable: true),
                    LSoSecVal = table.Column<string>(nullable: true),
                    DEven = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSector_T", x => x.CSecVal);
                    table.ForeignKey(
                        name: "FK_SubSector_T_Sector_T_CSecVal",
                        column: x => x.CSecVal,
                        principalTable: "Sector_T",
                        principalColumn: "CSecVal",
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

            migrationBuilder.CreateTable(
                name: "Instrument_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentState = table.Column<int>(nullable: true),
                    InstrumentType = table.Column<int>(nullable: false),
                    DEVen = table.Column<int>(nullable: false),
                    InsCode = table.Column<long>(nullable: false),
                    InstrumentID = table.Column<string>(nullable: true),
                    CValMne = table.Column<string>(nullable: true),
                    LVal18 = table.Column<string>(nullable: true),
                    CSocCSAC = table.Column<string>(nullable: true),
                    LSoc30 = table.Column<string>(nullable: true),
                    LVal18AFC = table.Column<string>(nullable: true),
                    LVal30 = table.Column<string>(nullable: true),
                    CIsin = table.Column<string>(nullable: true),
                    QNmVlo = table.Column<decimal>(nullable: false),
                    ZTitad = table.Column<decimal>(nullable: false),
                    DESop = table.Column<int>(nullable: false),
                    YOPSJ = table.Column<int>(nullable: false),
                    CGdSVal = table.Column<string>(nullable: true),
                    CGrValCot = table.Column<string>(nullable: true),
                    DInMar = table.Column<int>(nullable: false),
                    YUniExpP = table.Column<int>(nullable: false),
                    YMarNSC = table.Column<string>(nullable: true),
                    CComVal = table.Column<long>(nullable: true),
                    CSecVal = table.Column<long>(nullable: true),
                    CSoSecVal = table.Column<long>(nullable: true),
                    YDeComp = table.Column<int>(nullable: false),
                    PSaiSMaxOkValMdinOccurs = table.Column<decimal>(nullable: false),
                    PSaiSMinOkValMdinOccurs = table.Column<decimal>(nullable: false),
                    BaseVol = table.Column<long>(nullable: false),
                    YVal = table.Column<int>(nullable: false),
                    QPasCotFxeVal = table.Column<int>(nullable: false),
                    QQtTranMarVal = table.Column<int>(nullable: false),
                    Flow = table.Column<int>(nullable: false),
                    QtitMinSaiOmProd = table.Column<long>(nullable: false),
                    QtitMaxSaiOmProd = table.Column<long>(nullable: false),
                    Valid = table.Column<short>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    CloseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instrument_T_Board_T_CComVal",
                        column: x => x.CComVal,
                        principalTable: "Board_T",
                        principalColumn: "CComVal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instrument_T_Sector_T_CSecVal",
                        column: x => x.CSecVal,
                        principalTable: "Sector_T",
                        principalColumn: "CSecVal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instrument_T_SubSector_T_CSoSecVal",
                        column: x => x.CSoSecVal,
                        principalTable: "SubSector_T",
                        principalColumn: "CSecVal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentAnalayzeBuy_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    AnalyzeType = table.Column<int>(nullable: false),
                    IsSoftDeleted = table.Column<bool>(nullable: true),
                    AnalyzeState = table.Column<int>(nullable: false),
                    AnalyzerUserId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    InstrumentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentAnalayzeBuy_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentAnalayzeBuy_T_User_T_AnalyzerUserId",
                        column: x => x.AnalyzerUserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentAnalayzeBuy_T_Instrument_T_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentAnalayzeSell_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: true),
                    AnalyzeState = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: true),
                    ToDate = table.Column<DateTime>(nullable: true),
                    AnalyzeType = table.Column<int>(nullable: false),
                    AnalyzerUserId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    InstrumentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentAnalayzeSell_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentAnalayzeSell_T_User_T_AnalyzerUserId",
                        column: x => x.AnalyzerUserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentAnalayzeSell_T_Instrument_T_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentCycle_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<long>(nullable: false),
                    SenderUserId = table.Column<Guid>(nullable: false),
                    InstrumentState = table.Column<int>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentCycle_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentCycle_T_Instrument_T_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentCycle_T_User_T_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentInformation_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    InstrumentInformationType = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentInformation_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentInformation_T_Instrument_T_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstrumentInformation_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<long>(nullable: false),
                    SenderUserId = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_T_Instrument_T_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instrument_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_T_User_T_SenderUserId",
                        column: x => x.SenderUserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentDescriptionBuy_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeBuyId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentDescriptionBuy_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentDescriptionBuy_T_InstrumentAnalayzeBuy_T_InstrumentAnalayzeBuyId",
                        column: x => x.InstrumentAnalayzeBuyId,
                        principalTable: "InstrumentAnalayzeBuy_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialInstrumentAnalayzedBuy_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeBuyId = table.Column<long>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialInstrumentAnalayzedBuy_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialInstrumentAnalayzedBuy_T_InstrumentAnalayzeBuy_T_InstrumentAnalayzeBuyId",
                        column: x => x.InstrumentAnalayzeBuyId,
                        principalTable: "InstrumentAnalayzeBuy_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialInstrumentAnalayzedBuy_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRankInstrumentBuy_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeBuyId = table.Column<long>(nullable: false),
                    RankNumber = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRankInstrumentBuy_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRankInstrumentBuy_T_InstrumentAnalayzeBuy_T_InstrumentAnalayzeBuyId",
                        column: x => x.InstrumentAnalayzeBuyId,
                        principalTable: "InstrumentAnalayzeBuy_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRankInstrumentBuy_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstrumentDescriptionSell_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeSellId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentDescriptionSell_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentDescriptionSell_T_InstrumentAnalayzeSell_T_InstrumentAnalayzeSellId",
                        column: x => x.InstrumentAnalayzeSellId,
                        principalTable: "InstrumentAnalayzeSell_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialInstrumentAnalayzedSell_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeSellId = table.Column<long>(nullable: true),
                    IsSoftDeleted = table.Column<bool>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialInstrumentAnalayzedSell_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialInstrumentAnalayzedSell_T_InstrumentAnalayzeSell_T_InstrumentAnalayzeSellId",
                        column: x => x.InstrumentAnalayzeSellId,
                        principalTable: "InstrumentAnalayzeSell_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialInstrumentAnalayzedSell_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRankInstrumentSell_T",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentAnalayzeSellId = table.Column<long>(nullable: false),
                    RankNumber = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRankInstrumentSell_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRankInstrumentSell_T_InstrumentAnalayzeSell_T_InstrumentAnalayzeSellId",
                        column: x => x.InstrumentAnalayzeSellId,
                        principalTable: "InstrumentAnalayzeSell_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRankInstrumentSell_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Instrument_T_CComVal",
                table: "Instrument_T",
                column: "CComVal");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_T_CSecVal",
                table: "Instrument_T",
                column: "CSecVal");

            migrationBuilder.CreateIndex(
                name: "IX_Instrument_T_CSoSecVal",
                table: "Instrument_T",
                column: "CSoSecVal");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentAnalayzeBuy_T_AnalyzerUserId",
                table: "InstrumentAnalayzeBuy_T",
                column: "AnalyzerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentAnalayzeBuy_T_InstrumentId",
                table: "InstrumentAnalayzeBuy_T",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentAnalayzeSell_T_AnalyzerUserId",
                table: "InstrumentAnalayzeSell_T",
                column: "AnalyzerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentAnalayzeSell_T_InstrumentId",
                table: "InstrumentAnalayzeSell_T",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentCycle_T_InstrumentId",
                table: "InstrumentCycle_T",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentCycle_T_InstrumentState",
                table: "InstrumentCycle_T",
                column: "InstrumentState");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentCycle_T_SenderUserId",
                table: "InstrumentCycle_T",
                column: "SenderUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentDescriptionBuy_T_InstrumentAnalayzeBuyId",
                table: "InstrumentDescriptionBuy_T",
                column: "InstrumentAnalayzeBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentDescriptionSell_T_InstrumentAnalayzeSellId",
                table: "InstrumentDescriptionSell_T",
                column: "InstrumentAnalayzeSellId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentInformation_T_InstrumentId",
                table: "InstrumentInformation_T",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentInformation_T_UserId",
                table: "InstrumentInformation_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportStructure_T_ReportId",
                table: "ReportStructure_T",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_T_InstrumentId",
                table: "Request_T",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_T_SenderUserId",
                table: "Request_T",
                column: "SenderUserId");

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
                name: "IX_SpecialInstrumentAnalayzedBuy_T_InstrumentAnalayzeBuyId",
                table: "SpecialInstrumentAnalayzedBuy_T",
                column: "InstrumentAnalayzeBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInstrumentAnalayzedBuy_T_UserId",
                table: "SpecialInstrumentAnalayzedBuy_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInstrumentAnalayzedSell_T_InstrumentAnalayzeSellId",
                table: "SpecialInstrumentAnalayzedSell_T",
                column: "InstrumentAnalayzeSellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialInstrumentAnalayzedSell_T_UserId",
                table: "SpecialInstrumentAnalayzedSell_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_GroupAuthId",
                table: "User_T",
                column: "GroupAuthId");

            migrationBuilder.CreateIndex(
                name: "IX_User_T_Id",
                table: "User_T",
                column: "Id");

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
                name: "IX_UserRankInstrumentBuy_T_InstrumentAnalayzeBuyId",
                table: "UserRankInstrumentBuy_T",
                column: "InstrumentAnalayzeBuyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRankInstrumentBuy_T_UserId",
                table: "UserRankInstrumentBuy_T",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRankInstrumentSell_T_InstrumentAnalayzeSellId",
                table: "UserRankInstrumentSell_T",
                column: "InstrumentAnalayzeSellId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRankInstrumentSell_T_UserId",
                table: "UserRankInstrumentSell_T",
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
                name: "InstrumentCycle_T");

            migrationBuilder.DropTable(
                name: "InstrumentDescriptionBuy_T");

            migrationBuilder.DropTable(
                name: "InstrumentDescriptionSell_T");

            migrationBuilder.DropTable(
                name: "InstrumentInformation_T");

            migrationBuilder.DropTable(
                name: "Log_T");

            migrationBuilder.DropTable(
                name: "MarketValue_T");

            migrationBuilder.DropTable(
                name: "ReportStructure_T");

            migrationBuilder.DropTable(
                name: "Request_T");

            migrationBuilder.DropTable(
                name: "SpecialInstrumentAnalayzedBuy_T");

            migrationBuilder.DropTable(
                name: "SpecialInstrumentAnalayzedSell_T");

            migrationBuilder.DropTable(
                name: "UserConfiguration_T");

            migrationBuilder.DropTable(
                name: "UserRankInstrumentBuy_T");

            migrationBuilder.DropTable(
                name: "UserRankInstrumentSell_T");

            migrationBuilder.DropTable(
                name: "UserRole_T");

            migrationBuilder.DropTable(
                name: "UserToken_T");

            migrationBuilder.DropTable(
                name: "InstrumentAnalayzeBuy_T");

            migrationBuilder.DropTable(
                name: "InstrumentAnalayzeSell_T");

            migrationBuilder.DropTable(
                name: "Role_T");

            migrationBuilder.DropTable(
                name: "User_T");

            migrationBuilder.DropTable(
                name: "Instrument_T");

            migrationBuilder.DropTable(
                name: "GroupAuth_T");

            migrationBuilder.DropTable(
                name: "Board_T");

            migrationBuilder.DropTable(
                name: "SubSector_T");

            migrationBuilder.DropTable(
                name: "Sector_T");
        }
    }
}
