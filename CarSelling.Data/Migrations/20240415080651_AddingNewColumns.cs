using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSelling.Data.Migrations
{
    public partial class AddingNewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2e4f8507-3c2d-4e8c-b4f0-e67b8ceb1865"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("87854bda-a6e6-4631-bebe-7ffb138043a2"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c29ea719-f494-4227-97a8-226f88e7604f"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 15, 8, 6, 51, 493, DateTimeKind.Utc).AddTicks(8602));

            migrationBuilder.AddColumn<int>(
                name: "HorsePower",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("5a17a47b-bc76-4562-b8c9-bc6128be9c12"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, 0, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("8b9555f7-8e6a-44a8-afdb-ee934846101d"), null, 3, "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", 0, "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, 0, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("9f493154-1458-4707-93a8-aafd7fac46c7"), null, 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, 0, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5a17a47b-bc76-4562-b8c9-bc6128be9c12"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8b9555f7-8e6a-44a8-afdb-ee934846101d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9f493154-1458-4707-93a8-aafd7fac46c7"));

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "HorsePower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "MakeId", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("2e4f8507-3c2d-4e8c-b4f0-e67b8ceb1865"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "MakeId", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("87854bda-a6e6-4631-bebe-7ffb138043a2"), null, 3, "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "ImageUrl", "MakeId", "Model", "Price", "SellerId" },
                values: new object[] { new Guid("c29ea719-f494-4227-97a8-226f88e7604f"), null, 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088") });
        }
    }
}
