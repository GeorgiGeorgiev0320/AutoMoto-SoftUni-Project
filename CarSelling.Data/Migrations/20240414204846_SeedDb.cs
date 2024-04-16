using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarSelling.Data.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cars And SUVs" },
                    { 2, "Motorbikes" },
                    { 3, "Semi Trucks and Buses" },
                    { 4, "Boats and Yachts" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "MakeName" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Audi" },
                    { 3, "Toyota" },
                    { 4, "Honda" },
                    { 5, "Volkswagen" },
                    { 6, "Mercedes-Benz" },
                    { 7, "Nissan" },
                    { 8, "Tesla" },
                    { 9, "Ford" },
                    { 10, "Kia" },
                    { 11, "Hyundai" },
                    { 12, "Subaru" },
                    { 13, "Fiat" },
                    { 14, "Volvo" },
                    { 15, "Porsche" },
                    { 16, "Jaguar" },
                    { 17, "Land Rover" },
                    { 18, "Mazda" },
                    { 19, "Mitsubishi" },
                    { 20, "Rolls-Royce" },
                    { 21, "Bentley" },
                    { 22, "Ferrari" },
                    { 23, "Lamborghini" },
                    { 24, "Koenigsegg" },
                    { 25, "Chevrolet" },
                    { 26, "Dodge" },
                    { 27, "Cadillac" },
                    { 28, "Lada" },
                    { 29, "Mini Cooper" },
                    { 30, "GMC" },
                    { 31, "Bugatti" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars");

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "BuyerId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_AspNetUsers_BuyerId",
                table: "Cars",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
