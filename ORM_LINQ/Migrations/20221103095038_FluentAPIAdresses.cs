using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORM_LINQ.Migrations
{
    public partial class FluentAPIAdresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_Addresses_AddressesAddressId",
                table: "AddressCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "addresses");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "addresses",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "addresses",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "addresses",
                newName: "address_id");

            migrationBuilder.RenameColumn(
                name: "AddressesAddressId",
                table: "AddressCustomer",
                newName: "AddressesMyAddressId");

            migrationBuilder.AlterColumn<string>(
                name: "city",
                table: "addresses",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "postal_code",
                table: "addresses",
                type: "varchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_addresses_AddressesMyAddressId",
                table: "AddressCustomer",
                column: "AddressesMyAddressId",
                principalTable: "addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressCustomer_addresses_AddressesMyAddressId",
                table: "AddressCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Addresses",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                table: "Addresses",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "address_id",
                table: "Addresses",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "AddressesMyAddressId",
                table: "AddressCustomer",
                newName: "AddressesAddressId");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2000)",
                oldMaxLength: 2000)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressCustomer_Addresses_AddressesAddressId",
                table: "AddressCustomer",
                column: "AddressesAddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
