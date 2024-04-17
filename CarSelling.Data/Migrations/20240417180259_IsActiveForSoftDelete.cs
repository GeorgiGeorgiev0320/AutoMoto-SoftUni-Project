using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSelling.Data.Migrations
{
    public partial class IsActiveForSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6b09cd82-ea74-41bf-8e30-033334a4284a"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a2af0037-7bc7-40f1-8cc8-6a88682e5961"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bca2e8b5-2b20-43d7-8f01-0cc6029892ea"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("0eb30c31-3214-446c-87e9-d85dc0654474"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, 0, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("5c19aaf5-7ce8-4da3-a89c-6df64731e773"), null, 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, 0, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("65700234-7493-4aed-b525-91644ef195ac"), null, 3, "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", 0, "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, 0, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("0eb30c31-3214-446c-87e9-d85dc0654474"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5c19aaf5-7ce8-4da3-a89c-6df64731e773"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("65700234-7493-4aed-b525-91644ef195ac"));

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("6b09cd82-ea74-41bf-8e30-033334a4284a"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, 0, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("a2af0037-7bc7-40f1-8cc8-6a88682e5961"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, 0, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("bca2e8b5-2b20-43d7-8f01-0cc6029892ea"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", 0, "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, 0, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
