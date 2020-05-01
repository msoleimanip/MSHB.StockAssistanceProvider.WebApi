using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSHB.StockAssistanceProvider.Layers.L02_DataLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrumentUserMapper_T",
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
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrumentUserMapper_T", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrumentUserMapper_T_Board_T_CComVal",
                        column: x => x.CComVal,
                        principalTable: "Board_T",
                        principalColumn: "CComVal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstrumentUserMapper_T_Sector_T_CSecVal",
                        column: x => x.CSecVal,
                        principalTable: "Sector_T",
                        principalColumn: "CSecVal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstrumentUserMapper_T_SubSector_T_CSoSecVal",
                        column: x => x.CSoSecVal,
                        principalTable: "SubSector_T",
                        principalColumn: "CSecVal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstrumentUserMapper_T_User_T_UserId",
                        column: x => x.UserId,
                        principalTable: "User_T",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUserMapper_T_CComVal",
                table: "InstrumentUserMapper_T",
                column: "CComVal");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUserMapper_T_CSecVal",
                table: "InstrumentUserMapper_T",
                column: "CSecVal");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUserMapper_T_CSoSecVal",
                table: "InstrumentUserMapper_T",
                column: "CSoSecVal");

            migrationBuilder.CreateIndex(
                name: "IX_InstrumentUserMapper_T_UserId",
                table: "InstrumentUserMapper_T",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrumentUserMapper_T");
        }
    }
}
