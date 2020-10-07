using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mini_Bank.Migrations
{
    public partial class PrepForImmedis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedById", "DateCreated", "DateEdited", "EditedById", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 5, 0, "ad78677a-6545-4774-bab1-a9e332e21490", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4608), null, null, "test2@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 19, 0, "bfc551be-bdf9-4c4e-9225-429ed7246042", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(5016), null, null, "test16@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 18, 0, "851db757-91d0-4c0f-9197-372c1c1aa363", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4994), null, null, "test15@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 17, 0, "a9e7ea8d-3215-4212-8ece-77e80b64159b", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4885), null, null, "test14@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 16, 0, "613021a2-5306-4511-b236-8addb7c260fd", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4858), null, null, "test13@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 15, 0, "f85ed93a-0975-40b5-a1b0-2d6dd6ecbd00", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4838), null, null, "test12@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 14, 0, "99dd9cc3-91e5-4e0e-92db-59337d5ee12e", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4818), null, null, "test11@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 13, 0, "d0a90359-d71f-42ed-a2ef-d8c188eb004b", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4798), null, null, "test10@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 12, 0, "16ac7534-2cfc-4987-a1bd-22a78e67cbbd", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4776), null, null, "test9@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 11, 0, "107f9eff-7f6d-4461-8fa7-bc550afb8310", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4756), null, null, "test8@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 10, 0, "d4df252a-f1b3-4e56-842f-50cc1484f001", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4735), null, null, "test7@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 9, 0, "3082155b-6deb-4e6a-83a7-16797c3225ab", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4713), null, null, "test6@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 8, 0, "7822515b-baba-4753-9f6b-df98d957a6b9", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4672), null, null, "test5@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 7, 0, "f8b6634d-31da-4795-8ca5-9d5f93f1ca8e", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4651), null, null, "test4@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 6, 0, "c352c94d-5136-4866-9bac-26564c0c9cfc", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4629), null, null, "test3@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 20, 0, "a9f88bcc-1cbe-48dd-aab8-47226ed1ce86", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(5037), null, null, "test17@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 21, 0, "799e7713-d66f-41c6-b167-0fedebc5137a", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(5058), null, null, "test18@gmail.com", false, false, null, null, null, null, null, false, null, false, null },
                    { 3, 0, "a1c2ea1d-9d72-41a1-8075-2d91bd183598", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4536), null, null, "petar.marchev@mail.bg", false, false, null, null, null, null, null, false, null, false, "PetarMarchev" },
                    { 2, 0, "999b6989-817c-4f95-b3a1-446e88611b98", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4491), null, null, "stefan.dimitrov@abv.bg", false, false, null, null, null, null, null, false, null, false, "StefanDimitrov" },
                    { 1, 0, "c9ed4f19-bc46-462b-9644-76f119f1504c", null, new DateTime(2020, 10, 3, 12, 57, 23, 620, DateTimeKind.Local).AddTicks(6029), null, null, "preslav.miroslavov@gmail.com", false, false, null, null, null, null, null, false, null, false, "PreslavPanaiotov" },
                    { 4, 0, "5964b971-ead4-4185-b652-3cffefd739b0", null, new DateTime(2020, 10, 3, 12, 57, 23, 623, DateTimeKind.Local).AddTicks(4586), null, null, "test1@gmail.com", false, false, null, null, null, null, null, false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Italy" },
                    { 6, "France" },
                    { 5, "England" },
                    { 4, "Greece" },
                    { 3, "Germany" },
                    { 2, "Romania" },
                    { 1, "Bulgaria" }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "GBP" },
                    { 2, "USD" },
                    { 1, "BGN" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Blocked" },
                    { 1, "Okay" }
                });

            migrationBuilder.InsertData(
                table: "Registrant",
                columns: new[] { "Id", "Address", "CountryId", "CreatedById", "DateCreated", "DateEdited", "EditedById", "FirstName", "LastName", "UserId" },
                values: new object[,]
                {
                    { 1, "ul. Street 42", 1, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(3606), null, null, "Preslav", "Panayotov", 1 },
                    { 19, "Test48", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5165), null, null, "Test46", "Test47", 19 },
                    { 18, "Test45", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5145), null, null, "Test43", "Test44", 18 },
                    { 17, "Test42", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5124), null, null, "Test40", "Test41", 17 },
                    { 16, "Test39", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5103), null, null, "Test37", "Test38", 16 },
                    { 15, "Test36", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5082), null, null, "Test34", "Test35", 15 },
                    { 14, "Test33", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5061), null, null, "Test31", "Test32", 14 },
                    { 13, "Test30", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5039), null, null, "Test28", "Test29", 13 },
                    { 12, "Test27", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5018), null, null, "Test25", "Test26", 12 },
                    { 20, "Test51", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5288), null, null, "Test49", "Test50", 20 },
                    { 11, "Test24", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4995), null, null, "Test22", "Test23", 11 },
                    { 9, "Test18", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4952), null, null, "Test16", "Test17", 9 },
                    { 8, "Test15", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4931), null, null, "Test13", "Test14", 8 },
                    { 7, "Test12", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4909), null, null, "Test10", "Test11", 7 },
                    { 6, "Test9", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4887), null, null, "Test7", "Test8", 6 },
                    { 5, "Test6", 3, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4866), null, null, "Test4", "Test5", 5 },
                    { 4, "Test3", 1, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4843), null, null, "Test1", "Test2", 4 },
                    { 3, "Liberman 12", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4803), null, null, "Petar", "Marchev", 3 },
                    { 2, "8-mi Primorski", 3, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4774), null, null, "Stefan", "Dimitrov", 2 },
                    { 10, "Test21", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(4974), null, null, "Test19", "Test20", 10 },
                    { 21, "Test54", 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 624, DateTimeKind.Local).AddTicks(5312), null, null, "Test52", "Test53", 21 }
                });

            migrationBuilder.InsertData(
                table: "Wallet",
                columns: new[] { "Id", "CreatedById", "DateCreated", "DateEdited", "EditedById", "IsVerified", "Number", "RegistrantId", "WalletStatusId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(1681), null, null, true, 4188, 1, 1 },
                    { 34, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3118), null, null, true, 2624, 12, 2 },
                    { 35, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3127), null, null, true, 5657, 12, 2 },
                    { 36, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3136), null, null, true, 6506, 12, 2 },
                    { 37, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3144), null, null, true, 5944, 13, 2 },
                    { 38, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3153), null, null, true, 7455, 13, 2 },
                    { 39, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3161), null, null, true, 3720, 13, 2 },
                    { 40, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3169), null, null, true, 7688, 14, 2 },
                    { 41, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3178), null, null, true, 8358, 14, 2 },
                    { 42, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3188), null, null, true, 6685, 14, 2 },
                    { 43, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3197), null, null, true, 6881, 15, 2 },
                    { 44, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3206), null, null, true, 5241, 15, 2 },
                    { 45, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3215), null, null, true, 7305, 15, 2 },
                    { 46, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3224), null, null, true, 5054, 16, 2 },
                    { 33, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3109), null, null, true, 4464, 11, 2 },
                    { 47, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3234), null, null, true, 8738, 16, 2 },
                    { 49, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3252), null, null, true, 9332, 17, 2 },
                    { 50, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3261), null, null, true, 7909, 17, 2 },
                    { 51, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3270), null, null, true, 1542, 17, 2 },
                    { 52, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3368), null, null, true, 1693, 18, 2 },
                    { 53, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3378), null, null, true, 3368, 18, 2 },
                    { 54, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3388), null, null, true, 2449, 18, 2 },
                    { 55, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3396), null, null, true, 1294, 19, 2 },
                    { 56, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3406), null, null, true, 9689, 19, 2 },
                    { 57, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3415), null, null, true, 8006, 19, 2 },
                    { 58, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3425), null, null, true, 9307, 20, 2 },
                    { 59, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3434), null, null, true, 6857, 20, 2 },
                    { 60, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3443), null, null, true, 2463, 20, 2 },
                    { 61, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3453), null, null, true, 6265, 21, 2 },
                    { 48, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3243), null, null, true, 3087, 16, 2 },
                    { 62, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3462), null, null, true, 5996, 21, 2 },
                    { 32, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3100), null, null, true, 7008, 11, 2 },
                    { 30, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3082), null, null, true, 9206, 10, 2 },
                    { 2, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2808), null, null, false, 948, 1, 1 },
                    { 3, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2838), null, null, false, 9809, 1, 1 },
                    { 4, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2848), null, null, true, 9458, 2, 2 },
                    { 5, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2857), null, null, true, 1889, 2, 1 },
                    { 6, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2865), null, null, false, 6703, 2, 2 },
                    { 7, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2874), null, null, true, 9890, 3, 1 },
                    { 8, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2882), null, null, false, 1018, 3, 1 },
                    { 9, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2890), null, null, true, 9066, 3, 2 },
                    { 10, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2902), null, null, true, 3834, 4, 1 },
                    { 11, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2911), null, null, false, 3870, 4, 1 },
                    { 12, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2920), null, null, false, 7602, 4, 1 },
                    { 13, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2929), null, null, true, 4709, 5, 2 },
                    { 14, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2939), null, null, true, 8530, 5, 1 },
                    { 31, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3091), null, null, true, 1973, 11, 2 },
                    { 15, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2947), null, null, false, 6683, 5, 2 },
                    { 17, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2965), null, null, false, 4352, 6, 1 },
                    { 18, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2975), null, null, true, 8641, 6, 2 },
                    { 19, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2984), null, null, true, 2489, 7, 2 },
                    { 20, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2993), null, null, true, 3295, 7, 2 },
                    { 21, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3002), null, null, true, 3546, 7, 2 },
                    { 22, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3011), null, null, true, 4295, 8, 2 },
                    { 23, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3019), null, null, true, 7640, 8, 2 },
                    { 24, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3029), null, null, true, 1195, 8, 2 },
                    { 25, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3038), null, null, true, 4035, 9, 2 },
                    { 26, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3047), null, null, true, 5965, 9, 2 },
                    { 27, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3056), null, null, true, 7712, 9, 2 },
                    { 28, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3065), null, null, true, 7531, 10, 2 },
                    { 29, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3074), null, null, true, 4221, 10, 2 },
                    { 16, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(2956), null, null, true, 3571, 6, 1 },
                    { 63, null, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(3471), null, null, true, 5526, 21, 2 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "StatusId", "Balance", "CreatedById", "CurrencyId", "DateCreated", "DateEdited", "EditedById", "IBAN", "WalletId" },
                values: new object[,]
                {
                    { 1, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 625, DateTimeKind.Local).AddTicks(9760), null, null, "BG27TTBB94008486163628", 1 },
                    { 121, 1, 5443m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3431), null, null, "DE42500105173178734641", 41 },
                    { 122, 1, 1455m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3440), null, null, "DE42500105173178734641", 41 },
                    { 123, 1, 7197m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3449), null, null, "DE42500105173178734641", 41 },
                    { 124, 1, 9214m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3458), null, null, "DE42500105173178734641", 42 },
                    { 125, 1, 8163m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3467), null, null, "DE42500105173178734641", 42 },
                    { 126, 1, 1230m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3476), null, null, "DE42500105173178734641", 42 },
                    { 127, 1, 5767m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3486), null, null, "DE42500105173178734641", 43 },
                    { 128, 1, 5487m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3495), null, null, "DE42500105173178734641", 43 },
                    { 129, 1, 8588m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3504), null, null, "DE42500105173178734641", 43 },
                    { 130, 1, 3072m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3513), null, null, "DE42500105173178734641", 44 },
                    { 131, 1, 5099m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3522), null, null, "DE42500105173178734641", 44 },
                    { 132, 1, 3303m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3532), null, null, "DE42500105173178734641", 44 },
                    { 133, 1, 9791m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3541), null, null, "DE42500105173178734641", 45 },
                    { 134, 1, 4073m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3550), null, null, "DE42500105173178734641", 45 },
                    { 135, 1, 4700m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3560), null, null, "DE42500105173178734641", 45 },
                    { 136, 1, 8614m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3569), null, null, "DE42500105173178734641", 46 },
                    { 137, 1, 3541m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3578), null, null, "DE42500105173178734641", 46 },
                    { 138, 1, 5882m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3587), null, null, "DE42500105173178734641", 46 },
                    { 139, 1, 6747m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3596), null, null, "DE42500105173178734641", 47 },
                    { 120, 1, 9770m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3421), null, null, "DE42500105173178734641", 40 },
                    { 119, 1, 8023m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3410), null, null, "DE42500105173178734641", 40 },
                    { 118, 1, 889m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3401), null, null, "DE42500105173178734641", 40 },
                    { 117, 1, 7322m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3392), null, null, "DE42500105173178734641", 39 },
                    { 97, 1, 21m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3203), null, null, "DE42500105173178734641", 33 },
                    { 98, 1, 2717m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3212), null, null, "DE42500105173178734641", 33 },
                    { 99, 1, 7848m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3221), null, null, "DE42500105173178734641", 33 },
                    { 100, 1, 636m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3231), null, null, "DE42500105173178734641", 34 },
                    { 101, 1, 6011m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3242), null, null, "DE42500105173178734641", 34 },
                    { 102, 1, 8936m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3251), null, null, "DE42500105173178734641", 34 },
                    { 103, 1, 5586m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3260), null, null, "DE42500105173178734641", 35 },
                    { 104, 1, 4465m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3270), null, null, "DE42500105173178734641", 35 },
                    { 105, 1, 5009m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3280), null, null, "DE42500105173178734641", 35 },
                    { 140, 1, 6834m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3605), null, null, "DE42500105173178734641", 47 },
                    { 106, 1, 5634m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3289), null, null, "DE42500105173178734641", 36 },
                    { 108, 1, 7662m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3308), null, null, "DE42500105173178734641", 36 },
                    { 109, 1, 2991m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3318), null, null, "DE42500105173178734641", 37 },
                    { 110, 1, 3213m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3327), null, null, "DE42500105173178734641", 37 },
                    { 111, 1, 242m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3335), null, null, "DE42500105173178734641", 37 },
                    { 112, 1, 3023m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3344), null, null, "DE42500105173178734641", 38 },
                    { 113, 1, 6687m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3353), null, null, "DE42500105173178734641", 38 },
                    { 114, 1, 868m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3362), null, null, "DE42500105173178734641", 38 },
                    { 115, 1, 5072m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3372), null, null, "DE42500105173178734641", 39 },
                    { 116, 1, 2159m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3382), null, null, "DE42500105173178734641", 39 },
                    { 107, 1, 5003m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3298), null, null, "DE42500105173178734641", 36 },
                    { 141, 1, 6243m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3615), null, null, "DE42500105173178734641", 47 },
                    { 142, 1, 3176m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3625), null, null, "DE42500105173178734641", 48 },
                    { 143, 1, 4681m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3635), null, null, "DE42500105173178734641", 48 },
                    { 168, 1, 2614m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3937), null, null, "DE42500105173178734641", 56 },
                    { 169, 1, 6167m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3946), null, null, "DE42500105173178734641", 57 },
                    { 170, 1, 6456m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3955), null, null, "DE42500105173178734641", 57 },
                    { 171, 1, 8616m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3964), null, null, "DE42500105173178734641", 57 },
                    { 172, 1, 1440m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3973), null, null, "DE42500105173178734641", 58 },
                    { 173, 1, 4140m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3982), null, null, "DE42500105173178734641", 58 },
                    { 174, 1, 1190m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3991), null, null, "DE42500105173178734641", 58 },
                    { 175, 1, 3528m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4000), null, null, "DE42500105173178734641", 59 },
                    { 176, 1, 2267m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4009), null, null, "DE42500105173178734641", 59 },
                    { 167, 1, 3230m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3927), null, null, "DE42500105173178734641", 56 },
                    { 177, 1, 6773m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4018), null, null, "DE42500105173178734641", 59 },
                    { 179, 1, 8356m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4037), null, null, "DE42500105173178734641", 60 },
                    { 180, 1, 5299m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4047), null, null, "DE42500105173178734641", 60 },
                    { 181, 1, 3844m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4056), null, null, "DE42500105173178734641", 61 },
                    { 182, 1, 3993m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4065), null, null, "DE42500105173178734641", 61 },
                    { 183, 1, 8810m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4075), null, null, "DE42500105173178734641", 61 },
                    { 184, 1, 5522m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4084), null, null, "DE42500105173178734641", 62 },
                    { 185, 1, 940m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4093), null, null, "DE42500105173178734641", 62 },
                    { 186, 1, 5968m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4102), null, null, "DE42500105173178734641", 62 },
                    { 187, 1, 8609m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4111), null, null, "DE42500105173178734641", 63 },
                    { 178, 1, 8547m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4027), null, null, "DE42500105173178734641", 60 },
                    { 96, 1, 9455m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3194), null, null, "DE42500105173178734641", 32 },
                    { 166, 1, 6937m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3919), null, null, "DE42500105173178734641", 56 },
                    { 164, 1, 9917m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3901), null, null, "DE42500105173178734641", 55 },
                    { 144, 1, 8649m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3645), null, null, "DE42500105173178734641", 48 },
                    { 145, 1, 858m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3654), null, null, "DE42500105173178734641", 49 },
                    { 146, 1, 2864m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3663), null, null, "DE42500105173178734641", 49 },
                    { 147, 1, 7384m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3672), null, null, "DE42500105173178734641", 49 },
                    { 148, 1, 1774m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3682), null, null, "DE42500105173178734641", 50 },
                    { 149, 1, 6675m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3691), null, null, "DE42500105173178734641", 50 },
                    { 150, 1, 3067m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3768), null, null, "DE42500105173178734641", 50 },
                    { 151, 1, 2133m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3779), null, null, "DE42500105173178734641", 51 },
                    { 152, 1, 9130m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3788), null, null, "DE42500105173178734641", 51 },
                    { 165, 1, 8112m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3910), null, null, "DE42500105173178734641", 55 },
                    { 153, 1, 4693m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3797), null, null, "DE42500105173178734641", 51 },
                    { 155, 1, 5191m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3815), null, null, "DE42500105173178734641", 52 },
                    { 156, 1, 4556m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3825), null, null, "DE42500105173178734641", 52 },
                    { 157, 1, 1739m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3836), null, null, "DE42500105173178734641", 53 },
                    { 158, 1, 6371m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3845), null, null, "DE42500105173178734641", 53 },
                    { 159, 1, 6301m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3855), null, null, "DE42500105173178734641", 53 },
                    { 160, 1, 3779m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3864), null, null, "DE42500105173178734641", 54 },
                    { 161, 1, 9866m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3873), null, null, "DE42500105173178734641", 54 },
                    { 162, 1, 9515m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3883), null, null, "DE42500105173178734641", 54 },
                    { 163, 1, 9072m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3892), null, null, "DE42500105173178734641", 55 },
                    { 154, 1, 8076m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3807), null, null, "DE42500105173178734641", 52 },
                    { 188, 1, 1716m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4121), null, null, "DE42500105173178734641", 63 },
                    { 95, 1, 5225m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3184), null, null, "DE42500105173178734641", 32 },
                    { 93, 1, 2642m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3165), null, null, "DE42500105173178734641", 31 },
                    { 26, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1117), null, null, "DE69500105171238446744", 9 },
                    { 27, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1125), null, null, "DE42500105173178734641", 9 },
                    { 28, 1, 8863m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2297), null, null, "BG27TTBB94008486163628", 10 },
                    { 29, 1, 2068m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2483), null, null, "BG77TTBB94006739924496", 10 },
                    { 30, 1, 6513m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2495), null, null, "BG82BNPA94402678339673", 10 },
                    { 31, 1, 3487m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2505), null, null, "BG11TTBB94009636993256", 11 },
                    { 32, 1, 2317m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2514), null, null, "BG84IORT80944383911889", 11 },
                    { 33, 1, 3192m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2524), null, null, "BG30STSA93001743638279", 11 },
                    { 34, 1, 198m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2533), null, null, "BG61TTBB94002569752388", 12 },
                    { 35, 1, 7362m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2544), null, null, "BG79BNPA94401326493795", 12 },
                    { 36, 1, 6551m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2554), null, null, "BG71BNPA94403364212612", 12 },
                    { 37, 1, 5468m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2562), null, null, "BE98798249248593", 13 },
                    { 38, 1, 4223m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2572), null, null, "BE39519894248419", 13 },
                    { 39, 1, 4374m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2581), null, null, "BE51999467219162", 13 },
                    { 40, 1, 6512m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2591), null, null, "BE27812249819173", 14 },
                    { 41, 1, 7126m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2600), null, null, "BE86549411157550", 14 },
                    { 42, 1, 2666m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2610), null, null, "BE45999614884989", 14 },
                    { 43, 1, 3211m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2619), null, null, "BE08735678488413", 15 },
                    { 44, 1, 8866m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2628), null, null, "BE80978224831777", 15 },
                    { 25, 1, 0m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1109), null, null, "DE69500105171238446744", 9 },
                    { 24, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1100), null, null, "DE66500105177765152229", 8 },
                    { 23, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1092), null, null, "DE85500105175574577219", 8 },
                    { 22, 2, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1084), null, null, "DE09500105171626724371", 8 },
                    { 2, 2, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(887), null, null, "BG77TTBB94006739924496", 1 },
                    { 3, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(915), null, null, "BG82BNPA94402678339673", 1 },
                    { 4, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(925), null, null, "BG11TTBB94009636993256", 2 },
                    { 5, 1, 0m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(934), null, null, "BG84IORT80944383911889", 2 },
                    { 6, 2, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(943), null, null, "BG30STSA93001743638279", 2 },
                    { 7, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(952), null, null, "BG61TTBB94002569752388", 3 },
                    { 8, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(960), null, null, "BG79BNPA94401326493795", 3 },
                    { 9, 1, 0m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(969), null, null, "BG71BNPA94403364212612", 3 },
                    { 10, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(977), null, null, "BE98798249248593", 4 },
                    { 45, 1, 6917m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2636), null, null, "BE59549568634626", 15 },
                    { 11, 2, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(986), null, null, "BE39519894248419", 4 },
                    { 13, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1005), null, null, "BE27812249819173", 5 },
                    { 14, 2, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1013), null, null, "BE86549411157550", 5 },
                    { 15, 2, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1022), null, null, "BE45999614884989", 5 },
                    { 16, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1030), null, null, "BE08735678488413", 6 },
                    { 17, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1039), null, null, "BE80978224831777", 6 },
                    { 18, 2, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1047), null, null, "BE59549568634626", 6 },
                    { 19, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1056), null, null, "DE73500105172747763277", 7 },
                    { 20, 1, 0m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1065), null, null, "DE73500105175222722351", 7 },
                    { 21, 1, 0m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(1074), null, null, "DE19500105179421415465", 7 },
                    { 12, 1, 0m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(996), null, null, "BE51999467219162", 4 },
                    { 46, 1, 5139m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2646), null, null, "DE73500105172747763277", 16 },
                    { 47, 1, 7998m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2655), null, null, "DE73500105175222722351", 16 },
                    { 48, 1, 5901m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2664), null, null, "DE19500105179421415465", 16 },
                    { 73, 1, 7235m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2899), null, null, "DE42500105173178734641", 25 },
                    { 74, 1, 3815m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2908), null, null, "DE42500105173178734641", 25 },
                    { 75, 1, 2529m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2918), null, null, "DE42500105173178734641", 25 },
                    { 76, 1, 5120m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2928), null, null, "DE42500105173178734641", 26 },
                    { 77, 1, 6020m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2937), null, null, "DE42500105173178734641", 26 },
                    { 78, 1, 7640m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2950), null, null, "DE42500105173178734641", 26 },
                    { 79, 1, 4708m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2959), null, null, "DE42500105173178734641", 27 },
                    { 80, 1, 713m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2968), null, null, "DE42500105173178734641", 27 },
                    { 81, 1, 7552m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2978), null, null, "DE42500105173178734641", 27 },
                    { 72, 1, 8408m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2889), null, null, "DE42500105173178734641", 24 },
                    { 82, 1, 9127m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2987), null, null, "DE42500105173178734641", 28 },
                    { 84, 1, 1757m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3007), null, null, "DE42500105173178734641", 28 },
                    { 85, 1, 2469m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3015), null, null, "DE42500105173178734641", 29 },
                    { 86, 1, 1247m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3029), null, null, "DE42500105173178734641", 29 },
                    { 87, 1, 840m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3038), null, null, "DE42500105173178734641", 29 },
                    { 88, 1, 7671m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3046), null, null, "DE42500105173178734641", 30 },
                    { 89, 1, 1864m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3056), null, null, "DE42500105173178734641", 30 },
                    { 90, 1, 1100m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3134), null, null, "DE42500105173178734641", 30 },
                    { 91, 1, 5887m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3145), null, null, "DE42500105173178734641", 31 },
                    { 92, 1, 4072m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3155), null, null, "DE42500105173178734641", 31 },
                    { 83, 1, 348m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2998), null, null, "DE42500105173178734641", 28 },
                    { 94, 1, 1749m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(3174), null, null, "DE42500105173178734641", 32 },
                    { 71, 1, 5301m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2880), null, null, "DE42500105173178734641", 24 },
                    { 69, 1, 315m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2861), null, null, "DE42500105173178734641", 23 },
                    { 49, 1, 8515m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2674), null, null, "DE09500105171626724371", 17 },
                    { 50, 1, 311m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2684), null, null, "DE85500105175574577219", 17 },
                    { 51, 1, 4044m, null, 3, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2694), null, null, "DE66500105177765152229", 17 },
                    { 52, 1, 2240m, null, 2, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2703), null, null, "DE69500105171238446744", 18 },
                    { 53, 1, 1478m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2712), null, null, "DE69500105171238446744", 18 },
                    { 54, 1, 5519m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2722), null, null, "DE42500105173178734641", 18 },
                    { 55, 1, 8332m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2731), null, null, "DE42500105173178734641", 19 },
                    { 56, 1, 6262m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2741), null, null, "DE42500105173178734641", 19 },
                    { 57, 1, 665m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2750), null, null, "DE42500105173178734641", 19 },
                    { 70, 1, 4051m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2870), null, null, "DE42500105173178734641", 24 },
                    { 58, 1, 1396m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2759), null, null, "DE42500105173178734641", 20 },
                    { 60, 1, 2625m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2778), null, null, "DE42500105173178734641", 20 },
                    { 61, 1, 1287m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2787), null, null, "DE42500105173178734641", 21 },
                    { 62, 1, 7670m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2796), null, null, "DE42500105173178734641", 21 },
                    { 63, 1, 2645m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2806), null, null, "DE42500105173178734641", 21 },
                    { 64, 1, 494m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2815), null, null, "DE42500105173178734641", 22 },
                    { 65, 1, 1019m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2824), null, null, "DE42500105173178734641", 22 },
                    { 66, 1, 6282m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2833), null, null, "DE42500105173178734641", 22 },
                    { 67, 1, 9126m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2842), null, null, "DE42500105173178734641", 23 },
                    { 68, 1, 9061m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2851), null, null, "DE42500105173178734641", 23 },
                    { 59, 1, 1581m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(2769), null, null, "DE42500105173178734641", 20 },
                    { 189, 1, 8881m, null, 1, new DateTime(2020, 10, 3, 12, 57, 23, 626, DateTimeKind.Local).AddTicks(4130), null, null, "DE42500105173178734641", 63 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currency",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Wallet",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Registrant",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
