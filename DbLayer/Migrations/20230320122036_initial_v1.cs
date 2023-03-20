using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbLayer.Migrations
{
    /// <inheritdoc />
    public partial class initial_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    All = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<long>(type: "bigint", nullable: false),
                    Humidity = table.Column<long>(type: "bigint", nullable: false),
                    TempMin = table.Column<double>(type: "float", nullable: false),
                    TempMax = table.Column<double>(type: "float", nullable: false),
                    Percepita = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sunrise = table.Column<long>(type: "bigint", nullable: false),
                    Sunset = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Deg = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoordId = table.Column<long>(type: "bigint", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainId = table.Column<long>(type: "bigint", nullable: false),
                    Visibility = table.Column<long>(type: "bigint", nullable: false),
                    WindId = table.Column<long>(type: "bigint", nullable: false),
                    CloudsId = table.Column<long>(type: "bigint", nullable: false),
                    Dt = table.Column<long>(type: "bigint", nullable: false),
                    SysId = table.Column<long>(type: "bigint", nullable: false),
                    Cod = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherData_Clouds_CloudsId",
                        column: x => x.CloudsId,
                        principalTable: "Clouds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherData_Coord_CoordId",
                        column: x => x.CoordId,
                        principalTable: "Coord",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherData_Main_MainId",
                        column: x => x.MainId,
                        principalTable: "Main",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherData_Sys_SysId",
                        column: x => x.SysId,
                        principalTable: "Sys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeatherData_Wind_WindId",
                        column: x => x.WindId,
                        principalTable: "Wind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Visibility = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeatherDataId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_WeatherData_WeatherDataId",
                        column: x => x.WeatherDataId,
                        principalTable: "WeatherData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherDataId",
                table: "Weather",
                column: "WeatherDataId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_CloudsId",
                table: "WeatherData",
                column: "CloudsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_CoordId",
                table: "WeatherData",
                column: "CoordId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_MainId",
                table: "WeatherData",
                column: "MainId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_SysId",
                table: "WeatherData",
                column: "SysId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherData_WindId",
                table: "WeatherData",
                column: "WindId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherData");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}
