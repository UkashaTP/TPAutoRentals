using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TPAutoRentals.Server.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandWebLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CusUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CusPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CusProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CusLicenseClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Use = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Algorithm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsX509Certificate = table.Column<bool>(type: "bit", nullable: false),
                    DataProtected = table.Column<bool>(type: "bit", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffPassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StaffRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutletID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenseRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LReqImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LReqStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CusID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LicenseRequests_Customers_CusID",
                        column: x => x.CusID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseRequests_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Outlets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutletAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outlets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Outlets_Staffs_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Staffs",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelBodyStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelSeater = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelFuel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelTransmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelCostHourly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelCostDaily = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportID = table.Column<int>(type: "int", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Models_Brands_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brands",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_Transports_TransportID",
                        column: x => x.TransportID,
                        principalTable: "Transports",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModelColours",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MCName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MCHexCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MCImgFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MCImgSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MCImgBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelColours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ModelColours_Models_ModelID",
                        column: x => x.ModelID,
                        principalTable: "Models",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehPlateNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehAvailability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutletID = table.Column<int>(type: "int", nullable: false),
                    MCID = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicles_ModelColours_MCID",
                        column: x => x.MCID,
                        principalTable: "ModelColours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Outlets_OutletID",
                        column: x => x.OutletID,
                        principalTable: "Outlets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookPayment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookDTIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookDTOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutletExReturn = table.Column<int>(type: "int", nullable: false),
                    CusID = table.Column<int>(type: "int", nullable: false),
                    StaffID = table.Column<int>(type: "int", nullable: true),
                    VehID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CusID",
                        column: x => x.CusID,
                        principalTable: "Customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Outlets_OutletExReturn",
                        column: x => x.OutletExReturn,
                        principalTable: "Outlets",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Bookings_Vehicles_VehID",
                        column: x => x.VehID,
                        principalTable: "Vehicles",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "22f4f49e-81b1-4dd3-8bc0-1716d9f3e8de", "admin@localhost.com", false, false, null, "Admin", "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEMI4VCGp7WLMw97rv4ZDb7BgeQun73PuAPNy6+ZflgPXJvQzUABkT5wH0gpOZpqRnA==", null, false, "b256d1b8-569a-4514-b7dd-25f93c5cee1a", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "ID", "BrandContactNumber", "BrandCountry", "BrandIcon", "BrandName", "BrandWebLink", "CreatedBy", "DateCreated", "DateUpdated", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "83298748", "Japan", "", "Toyota", "https://www.toyota.com.sg/", "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2635), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2650), "System" },
                    { 2, "83294810", "Germany", "", "BMW", "https://www.bmw.com.sg/", "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2653), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2653), "System" },
                    { 3, "83294810", "USA", "", "Ford", "https://www.regentmotors.com.sg/", "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2655), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(2655), "System" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "CreatedBy", "CusLicenseClass", "CusName", "CusPassword", "CusProfileImage", "CusUsername", "DateCreated", "DateUpdated", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", "NO LICENSE", "John Tan", "John1234", null, "John1234", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3036), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3036), "System" },
                    { 2, "System", "NO LICENSE", "Shaun Goh", "Shaun1234", null, "Shaun1234", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3038), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3039), "System" },
                    { 3, "System", "NO LICENSE", "Alvin Lim", "Alvin1234", null, "Alvin1234", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3040), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3041), "System" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DateUpdated", "OutletID", "StaffName", "StaffPassword", "StaffProfileImage", "StaffRole", "StaffStatus", "StaffUsername", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4132), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4133), 1, "Bryan Tan", "Bryan1234", "", "Manager", "Available", "Bryan1234", "System" },
                    { 2, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4135), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4136), 2, "Ukasha Putra Samad", "Ukasha1234", "", "Manager", "Available", "Ukasha1234", "System" },
                    { 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4138), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4138), 3, "Tom", "Tom1234", "", "Chauffeur", "Available", "Tom1234", "System" },
                    { 4, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4140), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4141), 1, "James", "James1234", "", "Chauffeur", "Available", "James1234", "System" },
                    { 5, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4142), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4143), 3, "Harry", "Harry1234", "", "Chauffeur", "Available", "Harry1234", "System" }
                });

            migrationBuilder.InsertData(
                table: "Transports",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DateUpdated", "TransportName", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4335), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4336), "Cars", "System" },
                    { 2, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4337), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4337), "Vans", "System" },
                    { 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4339), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4339), "Trucks", "System" },
                    { 4, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4340), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(4341), "Buses", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "ID", "BrandID", "CreatedBy", "DateCreated", "DateUpdated", "ModelBodyStyle", "ModelCostDaily", "ModelCostHourly", "ModelFuel", "ModelImage", "ModelName", "ModelSeater", "ModelTransmission", "ModelYear", "TransportID", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3497), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3497), "Sedan", "88", "6", "Hybrid Petrol", "prius.jpg", "Prius", "5-Seater", "Automatic", "2018", 1, "System" },
                    { 2, 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3504), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3504), "Sedan", "70", "5", "Petrol", "vios.png", "Vios", "5-Seater", "Automatic", "2020", 1, "System" },
                    { 3, 2, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3507), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3507), "SUV", "130", "10", "Petrol", "X5.jpg", "X5", "7-Seater", "Automatic", "2022", 2, "System" },
                    { 4, 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3510), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3510), "Station Wagon", "60", "4", "Petrol", "focus.jpg", "Focus", "5-Seater", "Manual", "1998", 1, "System" },
                    { 5, 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3512), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3513), "Coupe", "250", "15", "Petrol", "mustang.jpg", "Mustang", "5-Seater", "Automatic", "2020", 1, "System" }
                });

            migrationBuilder.InsertData(
                table: "Outlets",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DateUpdated", "ManagerID", "OutletAddress", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3708), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3709), 1, "Pasir Ris", "System" },
                    { 2, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3711), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3711), 2, "Tampines", "System" },
                    { 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3713), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3713), 3, "Woodlands", "System" }
                });

            migrationBuilder.InsertData(
                table: "ModelColours",
                columns: new[] { "ID", "CreatedBy", "DateCreated", "DateUpdated", "MCHexCode", "MCImgBack", "MCImgFront", "MCImgSide", "MCName", "ModelID", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3276), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3277), "#ff0000", null, null, "prius.jpg", "Red", 1, "System" },
                    { 2, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3280), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3280), "#0000ff", null, null, "vios.png", "Blue", 2, "System" },
                    { 3, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3282), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3283), "#00ff00", null, null, "X5.jpg", "Green", 3, "System" },
                    { 4, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3284), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3284), "#ffff00", null, null, "focus.jpg", "Yellow", 4, "System" },
                    { 5, "System", new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3286), new DateTime(2024, 2, 3, 20, 51, 15, 233, DateTimeKind.Local).AddTicks(3286), "#ff00ff", null, null, "mustang.jpg", "Magenta", 5, "System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CusID",
                table: "Bookings",
                column: "CusID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OutletExReturn",
                table: "Bookings",
                column: "OutletExReturn");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StaffID",
                table: "Bookings",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_VehID",
                table: "Bookings",
                column: "VehID");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_Keys_Use",
                table: "Keys",
                column: "Use");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRequests_CusID",
                table: "LicenseRequests",
                column: "CusID");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseRequests_StaffID",
                table: "LicenseRequests",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_ModelColours_ModelID",
                table: "ModelColours",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_BrandID",
                table: "Models",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Models_TransportID",
                table: "Models",
                column: "TransportID");

            migrationBuilder.CreateIndex(
                name: "IX_Outlets_ManagerID",
                table: "Outlets",
                column: "ManagerID",
                unique: true,
                filter: "[ManagerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_ConsumedTime",
                table: "PersistedGrants",
                column: "ConsumedTime");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_MCID",
                table: "Vehicles",
                column: "MCID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OutletID",
                table: "Vehicles",
                column: "OutletID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "LicenseRequests");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ModelColours");

            migrationBuilder.DropTable(
                name: "Outlets");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
