using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSelling.Data.Migrations
{
    public partial class addmigrationfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("093b8572-a783-4014-9b9c-2d15cb165777"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bed43a30-6088-4294-80ab-62fef9733559"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c4e3b3cc-4fbd-40b0-a37c-fb5f9a47b27a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 12, 15, 46, 541, DateTimeKind.Utc).AddTicks(4873),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 16, 8, 40, 31, 535, DateTimeKind.Utc).AddTicks(605));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("568c63c0-8ca6-4f33-8af0-11cd0e5bed2d"), null, 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, 0, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("8afa63e4-8ccb-45cc-b50a-5a84a2dd6c37"), null, 3, "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", 0, "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, 0, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("9c40ccf7-9e6f-497c-9123-83968d855569"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, 0, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("568c63c0-8ca6-4f33-8af0-11cd0e5bed2d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("8afa63e4-8ccb-45cc-b50a-5a84a2dd6c37"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9c40ccf7-9e6f-497c-9123-83968d855569"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 16, 8, 40, 31, 535, DateTimeKind.Utc).AddTicks(605),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 16, 12, 15, 46, 541, DateTimeKind.Utc).AddTicks(4873));

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("093b8572-a783-4014-9b9c-2d15cb165777"), null, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://autobild.bg/wp-content/uploads/2018/01/Gebrauchte-Edel-Kombis-bis-10-000-Euro-1200x800-91458492c53dfda5.jpg", 2, 0, "A6", 27000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("bed43a30-6088-4294-80ab-62fef9733559"), new Guid("a3116cf0-1ed6-4c4c-2bc8-08dc5cb89100"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "It is very good car with low mileage and very economical engine, it is a diesel engine with 235 horsepower!", 0, "https://upload.wikimedia.org/wikipedia/commons/d/df/BMW_5er-E60.jpg", 1, 0, "5 series", 13000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BuyerId", "CategoryId", "CreatedOn", "Description", "HorsePower", "ImageUrl", "MakeId", "Mileage", "Model", "Price", "SellerId", "Year" },
                values: new object[] { new Guid("c4e3b3cc-4fbd-40b0-a37c-fb5f9a47b27a"), null, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spacious bus with really comfortable seat, good music and pretty stewardess for your long journeys!", 0, "https://www.daimlertruck.com/fileadmin/press/6/5/D652811/cms.jpeg", 6, 0, "Mercedes-benz bus", 123000.00m, new Guid("a3573af0-47bd-495e-a90a-b5941782c088"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
