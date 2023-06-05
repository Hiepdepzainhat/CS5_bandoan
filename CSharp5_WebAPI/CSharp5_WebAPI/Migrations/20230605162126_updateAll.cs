using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharp5_WebAPI.Migrations
{
    public partial class updateAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Chefs",
                columns: table => new
                {
                    ChefID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChefName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    ChefDescription = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chefs", x => x.ChefID);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComboItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComboName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImgCombo = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboID);
                });

            migrationBuilder.CreateTable(
                name: "Nationals",
                columns: table => new
                {
                    NationalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalName = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationals", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    TiTlePost = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    ImgPost = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    VoucherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoucherName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PercentageDiscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.VoucherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    ImgUser = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Nationals_NationalID",
                        column: x => x.NationalID,
                        principalTable: "Nationals",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productss",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProducerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChefID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdVoucher = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    EntryPrice = table.Column<int>(type: "int", nullable: false),
                    DateOfManufacture = table.Column<DateTime>(type: "Date", nullable: false),
                    Expired = table.Column<DateTime>(type: "Date", nullable: false),
                    ImPortDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productss", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Productss_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productss_Chefs_ChefID",
                        column: x => x.ChefID,
                        principalTable: "Chefs",
                        principalColumn: "ChefID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productss_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productss_Vouchers_IdVoucher",
                        column: x => x.IdVoucher,
                        principalTable: "Vouchers",
                        principalColumn: "VoucherID");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bills_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComboItems",
                columns: table => new
                {
                    ComboItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboItems", x => x.ComboItemID);
                    table.ForeignKey(
                        name: "FK_ComboItems_Combos_ComboItemID",
                        column: x => x.ComboItemID,
                        principalTable: "Combos",
                        principalColumn: "ComboID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboItems_Productss_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Productss",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    BillDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BillID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComboID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.BillDetailID);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_BillID",
                        column: x => x.BillID,
                        principalTable: "Bills",
                        principalColumn: "BillID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillDetails_Productss_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Productss",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    CDID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComboID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ToTal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.CDID);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_UserID",
                        column: x => x.UserID,
                        principalTable: "Carts",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Combos_ComboID",
                        column: x => x.ComboID,
                        principalTable: "Combos",
                        principalColumn: "ComboID");
                    table.ForeignKey(
                        name: "FK_CartDetails_Productss_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Productss",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_BillID",
                table: "BillDetails",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_ProductID",
                table: "BillDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_UserID",
                table: "Bills",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ComboID",
                table: "CartDetails",
                column: "ComboID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ProductID",
                table: "CartDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_UserID",
                table: "CartDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ComboItems_ProductID",
                table: "ComboItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_CategoryID",
                table: "Productss",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_ChefID",
                table: "Productss",
                column: "ChefID");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_IdVoucher",
                table: "Productss",
                column: "IdVoucher");

            migrationBuilder.CreateIndex(
                name: "IX_Productss_ProducerID",
                table: "Productss",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalID",
                table: "Users",
                column: "NationalID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "ComboItems");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Productss");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Chefs");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Nationals");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
