using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    public partial class InitDB : Migration
    {
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
                    HasApprovedTerms = table.Column<bool>(type: "bit", nullable: true),
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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PrepTime = table.Column<int>(type: "int", nullable: false),
                    CookTime = table.Column<int>(type: "int", nullable: false),
                    Servings = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DietId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Recipes_Diets_DietId",
                        column: x => x.DietId,
                        principalTable: "Diets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Instructions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StepNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instructions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecipeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", "9924acbf-7bf0-4b90-8625-14a66134ae17", "Admin", "ADMIN" },
                    { "00000000-0000-0000-0000-000000000002", "b83e3fe4-9124-45a1-9de5-4ac6bf9c0580", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "HasApprovedTerms", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "admin@imi.be", true, null, false, null, "ADMIN@IMI.BE", "IMIADMIN", "AQAAAAEAACcQAAAAEPtDTkLU06I+YQy7jSvZS4/h2rMA91aGU+paPPBytJDJa5IWHnxPZzw2fnQDJPsWWw==", null, false, "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "ImiAdmin" },
                    { "00000000-0000-0000-0000-000000000002", 0, "2b3ba136-4654-49c1-8329-1e266a1f7453", "user@imi.be", true, true, false, null, "USER@IMI.BE", "IMIUSER", "AQAAAAEAACcQAAAAEKCACHdSz3e8sntPjaNj7cjQZUNOLlgMK02tdmIWsLVH/G0e00yXxwKW8PC3KQlmwA==", null, false, "WWPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "ImiUser" },
                    { "00000000-0000-0000-0000-000000000003", 0, "fad66526-654c-4000-b7b3-30349c41f171", "refuser@imi.be", true, false, false, null, "REFUSER@IMI.BE", "IMIREFUSER", "AQAAAAEAACcQAAAAEBT2V93bk+EArCe3xSeiNC9iL+PJYqN6Z3+ABINgH9xbCwdGnKwNMaNiTCKn85hYGg==", null, false, "YYPCRDAS3MJWQD5CSW2GWPRADBXEZINA", false, "ImiRefuser" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("47e6d388-7265-49fe-98e6-ff81c8191721"), "side dish" },
                    { new Guid("5731b9da-0e5e-4ef6-87f8-284573493e7e"), "snack" },
                    { new Guid("636a054a-f350-4675-b641-315d211a0f53"), "lunch" },
                    { new Guid("68cd9404-7f0c-4247-a7a1-6f8c2f120e78"), "beverage" },
                    { new Guid("c4df166c-75e1-4888-8395-7d9751dd0fb0"), "dessert" },
                    { new Guid("da9c469c-aef9-428a-9b19-c90276f5e96f"), "dinner" },
                    { new Guid("f0c3843a-2aee-43e4-af44-365a7f2868d2"), "breakfast" }
                });

            migrationBuilder.InsertData(
                table: "Diets",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("911b0e25-57ff-4b44-9b82-962a9a66d659"), "keto" },
                    { new Guid("a88c70b9-4e14-4ece-9c2a-8ae80b56afcd"), "vegan" },
                    { new Guid("d0b9aaed-62c3-4c37-91f7-6bbc57aff51a"), "paleo" },
                    { new Guid("ec107ba9-769f-412b-be15-fbab5a77ff1c"), "vegetarian" },
                    { new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "anything" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("02b4cb46-2f3f-410b-9e42-eb8cf66a4a01"), "carrots" },
                    { new Guid("033291a3-b3ec-4771-a1f0-a3e4456efad2"), "lean ground beef" },
                    { new Guid("055c9cbf-a0ae-4d21-99f4-9181d181f54b"), "green beans" },
                    { new Guid("153eb14b-d583-42b3-b81b-b3d9a60bef24"), "baking powder" },
                    { new Guid("1ebb27d0-d452-4b42-a6c3-081412c58fc7"), "balsemic vinegar" },
                    { new Guid("21799d42-c1c9-44ec-b2a0-41e199d57944"), "kosher salt" },
                    { new Guid("21bb0aa8-bfb2-474c-82d6-c9cbc618654e"), "peanut butter" },
                    { new Guid("231fe3ab-d192-4ee2-9ad6-1def1c5bb298"), "vanilla" },
                    { new Guid("23ef218b-e374-471f-9968-b1df6987a48d"), "vanilla ice cream" },
                    { new Guid("25b4bd2f-c70e-49ef-9dd3-365e4317a568"), "yellow onion" },
                    { new Guid("28ad0e27-a012-4030-bdb5-e91c5fb848d0"), "peas" },
                    { new Guid("2e48fed1-fdcf-4421-8ac0-6649670accc3"), "smoked paprika" },
                    { new Guid("2e680992-51a9-4993-885b-4cb0da5dfd31"), "turmeric" },
                    { new Guid("30d52d32-4c30-43f6-8cb1-73cb044b721e"), "celery" },
                    { new Guid("31eaa15a-7c94-4206-a588-e2536fa0b399"), "red onion" },
                    { new Guid("375627f6-719d-40fc-afd1-2ad4b7418642"), "dried oregano" },
                    { new Guid("3c9dbd1a-5890-4aea-8e8c-f6846ec0b311"), "heavy cream" },
                    { new Guid("4370914a-555c-47d7-a40f-a757e5280d79"), "basil" },
                    { new Guid("4e6cdcf9-3ff7-44a9-ae73-14177d0b0ce7"), "romaine lettuce" },
                    { new Guid("5226e4fb-7360-4234-92a0-fa190a24b1be"), "maple syrup" },
                    { new Guid("559d2ce2-5f6e-4f8e-b85f-a8def3fb8650"), "celery stalks" },
                    { new Guid("56469591-0026-4890-a8e7-562f13f8b69c"), "strawberries" },
                    { new Guid("571dcf9c-d268-4018-81b5-8f49ac3d26f5"), "unsweetened cacao powder" },
                    { new Guid("619729eb-e375-419e-bf7c-c67941a98753"), "lemon" },
                    { new Guid("645dcd09-9191-42ca-a1e1-8585680c8342"), "whipped topping" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("64c972c0-bd32-4f82-94ae-2942305ee1ec"), "protein powder" },
                    { new Guid("67b9885f-c3cd-439e-9c63-bea9906b25a8"), "white sugar" },
                    { new Guid("682e2bfb-7d18-448f-b695-14db95997088"), "potatoe" },
                    { new Guid("686bd9dd-ff1c-4a8e-97b3-2057c6279652"), "jalapenos" },
                    { new Guid("6d065d6b-6bfd-4ba7-9221-96d2a26fadf8"), "ground cumin" },
                    { new Guid("7023c350-e78b-48fe-b62f-93ebedca6f97"), "bacon" },
                    { new Guid("76ad7715-89bb-46b3-9f14-7840c2e18317"), "all-purpose flour" },
                    { new Guid("7af60fc5-2248-4444-bea5-6428fae6b26e"), "blackberries" },
                    { new Guid("7f12e6c4-d2ae-4d17-b8a1-c86be4a4d8c9"), "firm tofu" },
                    { new Guid("8066eade-199f-4b52-8e2b-f84a9f28c050"), "lime" },
                    { new Guid("8145feec-0dfb-4fe8-b647-1ec357f37d25"), "greek yogurt" },
                    { new Guid("8c71cf76-965d-4f46-8555-40474a43d95d"), "sesame oil" },
                    { new Guid("8dc954e5-a92a-4000-8bdc-878dfb9af389"), "milk" },
                    { new Guid("a07a2c48-a9de-44ef-a52a-20bae5821b2f"), "avocado" },
                    { new Guid("a344772e-11a8-4a6d-bf47-3d9a6935825b"), "salt" },
                    { new Guid("a5bb32ae-5086-41e7-a00f-780e4f61c2f3"), "keto chocolate chips" },
                    { new Guid("a7926359-306b-4582-b28a-d9ee4bba88b8"), "tuna" },
                    { new Guid("a8592ecf-9e7a-4d5c-8de4-224f50c3bd79"), "raspberries" },
                    { new Guid("b0b19759-885a-436a-8992-51bb0ced01f4"), "banana" },
                    { new Guid("b2f155d5-161f-45d3-8143-d98f1d7a1fd8"), "sprinkles" },
                    { new Guid("b469f796-8a51-4b24-ae61-419961f06180"), "pepper" },
                    { new Guid("bcc4460e-e664-4b69-9171-151b636adf74"), "honey" },
                    { new Guid("ccb17653-ae3f-40b4-98f0-c44e24fbb7be"), "kalamata olive" },
                    { new Guid("d7ec5abd-cbd6-4b4a-9b08-3c71a17194ab"), "butter" },
                    { new Guid("d7f1c8aa-eb8b-4606-91ed-3c0d63b55981"), "chili powder" },
                    { new Guid("da652f59-19d8-48bc-a197-81ed0596d660"), "green onion" },
                    { new Guid("dc93cdaa-3392-47c2-846e-35e9b41547ed"), "oat milk" },
                    { new Guid("dffe97a7-a724-4676-addc-800c1f947004"), "almond milk" },
                    { new Guid("e5256e0b-305f-461e-8682-15987b4f300d"), "egg" },
                    { new Guid("e9608381-4253-4f4d-b1e2-fa537e5594e0"), "bell pepper" },
                    { new Guid("ec15c23a-5748-42a5-b6ee-5cea71198c78"), "chocolate chips" },
                    { new Guid("eebbe687-a467-4662-80bc-85059642bbc6"), "soy sauce" },
                    { new Guid("f0ba43a5-f6af-43c8-87d3-999662121166"), "cherry tomato" },
                    { new Guid("f52dba50-7832-437a-ad7e-95024fe3ec88"), "garlic" },
                    { new Guid("f852c5d5-3d69-4969-a460-757a59c8d159"), "rapeseed oil" },
                    { new Guid("fa6e2093-48d0-42bb-9f29-5a32a309e9e2"), "nutritional yeast" },
                    { new Guid("fe772d41-bfe6-4280-8dc3-f338d815b70b"), "brown rice" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1ed4ac46-1a54-4240-b8d7-ad6672c35e1c"), "block" },
                    { new Guid("2f048952-7c04-4d58-9509-cb94500ecb05"), "cup" },
                    { new Guid("81311dec-3196-4045-9372-3dc4e7dc2543"), "clove" },
                    { new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459"), "grams" },
                    { new Guid("a6d6a4d0-2942-46ca-b6c5-8c47960a1388"), "garnish" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644"), "tsp" },
                    { new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e"), "piece" },
                    { new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd"), "tbsp" },
                    { new Guid("c90d0134-d29d-45e4-ac10-f753cd40f408"), "ml" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "sub", "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001" },
                    { 2, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "ImiAdmin", "00000000-0000-0000-0000-000000000001" },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "admin@imi.be", "00000000-0000-0000-0000-000000000001" },
                    { 4, "hasApprovedTerms", "", "00000000-0000-0000-0000-000000000001" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "00000000-0000-0000-0000-000000000001" },
                    { 6, "sub", "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002" },
                    { 7, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "ImiUser", "00000000-0000-0000-0000-000000000002" },
                    { 8, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "user@imi.be", "00000000-0000-0000-0000-000000000002" },
                    { 9, "hasApprovedTerms", "True", "00000000-0000-0000-0000-000000000002" },
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "00000000-0000-0000-0000-000000000002" },
                    { 11, "sub", "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000003" },
                    { 12, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", "ImiRefuser", "00000000-0000-0000-0000-000000000003" },
                    { 13, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", "refuser@imi.be", "00000000-0000-0000-0000-000000000003" },
                    { 14, "hasApprovedTerms", "False", "00000000-0000-0000-0000-000000000003" },
                    { 15, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "00000000-0000-0000-0000-000000000003" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000002" },
                    { "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000003" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "ApplicationUserId", "CategoryId", "CookTime", "Description", "DietId", "ImgURL", "PrepTime", "Servings", "Title" },
                values: new object[,]
                {
                    { new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), "00000000-0000-0000-0000-000000000002", new Guid("f0c3843a-2aee-43e4-af44-365a7f2868d2"), 30, "A healthy vegan breakfast", new Guid("a88c70b9-4e14-4ece-9c2a-8ae80b56afcd"), "https://simpleveganblog.com/wp-content/uploads/2022/07/tofu-scramble-1.jpg", 15, 2, "Scrambled Tofu" },
                    { new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), "00000000-0000-0000-0000-000000000003", new Guid("5731b9da-0e5e-4ef6-87f8-284573493e7e"), 5, "If you’re still buying protein bars at the store, this quick and simple vegan protein bar recipe might completely change your life…", new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "https://images.unsplash.com/photo-1622484212850-eb596d769edc?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", 5, 10, "Easy Homemade Protein Bars" },
                    { new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), "00000000-0000-0000-0000-000000000002", new Guid("c4df166c-75e1-4888-8395-7d9751dd0fb0"), 15, "I found this pancake recipe in my Grandma's recipe book. Judging from the weathered look of this recipe card, this was a family favorite.", new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "https://images.unsplash.com/photo-1565299543923-37dd37887442?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=781&q=80", 5, 8, "Good Old-Fashioned Pancakes" },
                    { new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), "00000000-0000-0000-0000-000000000002", new Guid("636a054a-f350-4675-b641-315d211a0f53"), 60, "Easy, 10-ingredient vegan fried rice that’s loaded with vegetables, crispy baked tofu, and tons of flavor! A healthy, satisfying plant-based side dish or entrée.", new Guid("a88c70b9-4e14-4ece-9c2a-8ae80b56afcd"), "https://shortgirltallorder.com/wp-content/uploads/2020/03/veggie-fried-rice-square-4.jpg", 15, 4, "Easy Vegan Fried Rice" },
                    { new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), "00000000-0000-0000-0000-000000000003", new Guid("47e6d388-7265-49fe-98e6-ff81c8191721"), 10, "A vegetarian Niçoise salad, that's packed with goodness - fibre, folate, iron, vitamin c and gluten-free too", new Guid("ec107ba9-769f-412b-be15-fbab5a77ff1c"), "https://images.unsplash.com/photo-1512621776951-a57141f2eefd?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80", 10, 2, "Egg Niçoise salad" },
                    { new Guid("90047163-0479-45c6-835a-d1f50167031f"), "00000000-0000-0000-0000-000000000002", new Guid("c4df166c-75e1-4888-8395-7d9751dd0fb0"), 60, "This keto mousse gets its rich, creamy texture from avocados.", new Guid("911b0e25-57ff-4b44-9b82-962a9a66d659"), "https://thebigmansworld.com/wp-content/uploads/2022/07/keto-chocolate-mousse.jpg", 15, 2, "Keto Chocolate Mousse" },
                    { new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), "00000000-0000-0000-0000-000000000002", new Guid("68cd9404-7f0c-4247-a7a1-6f8c2f120e78"), 5, "This easy milkshake recipe gives you the perfect ratio of milk to ice cream and is completely customizable! ", new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "https://images.unsplash.com/photo-1568901839119-631418a3910d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8bWlsa3NoYWtlfGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60", 5, 1, "Easy Vanilla Milkshake" },
                    { new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), "00000000-0000-0000-0000-000000000003", new Guid("68cd9404-7f0c-4247-a7a1-6f8c2f120e78"), 10, "A smoothie containing 3 types of berries", new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "https://cookingformysoul.com/wp-content/uploads/2022/05/mixed-berry-smoothie-2-min.jpg", 5, 2, "Tripple berry smoothie" },
                    { new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), "00000000-0000-0000-0000-000000000002", new Guid("636a054a-f350-4675-b641-315d211a0f53"), 5, "A fast and healthy lunch, packed with protein, for people in a hurry", new Guid("f2dd17b2-45bf-4fba-9c9a-d519dbcac9e3"), "https://www.wholesomeyum.com/wp-content/uploads/2019/05/wholesomeyum-avocado-tuna-salad-recipe-1.jpg", 5, 2, "Tuna avocado salad" },
                    { new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), "00000000-0000-0000-0000-000000000002", new Guid("da9c469c-aef9-428a-9b19-c90276f5e96f"), 40, "A hearty bowl of chili is the perfect dinner for a blustery winter day.", new Guid("d0b9aaed-62c3-4c37-91f7-6bbc57aff51a"), "https://www.laurafuentes.com/wp-content/uploads/2013/10/Paleo_chili_recipe-card_1-2.jpg", 15, 2, "Paleo Chili" }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Id", "Description", "RecipeId", "StepNumber" },
                values: new object[,]
                {
                    { new Guid("0e266aa8-9df5-4d8a-b02c-156a2a1218f3"), "Heat 1 tablespoon of oil on medium heat in a pan. Caramelize the chopped red onions", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 2 },
                    { new Guid("1055fe83-c5c6-45b9-a5fd-63739f6a47dc"), "Pour into a glass and garnish with whipped topping, sprinkles, cacao powder and a cherry.", new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 2 },
                    { new Guid("204fc10b-5784-45e8-bc8a-3e9ea9ba0f83"), "Scramble the block of tofu with your hands (see picture above) into small and bigger pieces.", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 1 },
                    { new Guid("377c8d52-cba8-4c8b-9309-c5f238c72396"), "Mix the dressing ingredients together in a small bowl with 1 tbsp water.", new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 1 },
                    { new Guid("37db896f-3fa5-411a-9de2-255c7f636591"), "In the meantime wrap tofu in a clean, absorbent towel and set something heavy on top (such as a cast iron skillet) to press out the liquid.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 2 },
                    { new Guid("45cc3320-2826-45ce-ad07-b5c79195fb5d"), "Once the oven is preheated, dice tofu into 1/4-inch cubes and arrange on baking sheet. Bake for 26-30 minutes. You’re looking for golden brown edges and a texture that’s firm to the touch. The longer it bakes, the firmer and crispier it will become, so if you’re looking for softer tofu remove from the oven around the 26-28 minute mark. I prefer crispy tofu, so I bake mine the full 30 minutes. Set aside.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 3 },
                    { new Guid("4d27dc97-349a-4569-9f8b-decf6c440445"), "Divide between 2 cups and top with blackberries, if desired.", new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 2 },
                    { new Guid("4d3d72f9-f286-4795-b822-dc2c0b5360a4"), "In a food processor or blender, blend all ingredients except chocolate curls until smooth.", new Guid("90047163-0479-45c6-835a-d1f50167031f"), 1 },
                    { new Guid("5646611e-5ea4-45cf-8009-5d77bd97fc61"), "When there is only a small amount of milk remaining, add all of the remaining ingredients and stir for another 3-4 minutes on low to medium heat.", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 5 },
                    { new Guid("5b60d81a-b143-469f-aae0-f5729324cd40"), "Once the tofu is done baking, add directly to the sauce and marinate for 5 minutes, stirring occasionally", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 6 },
                    { new Guid("649cdf98-ace4-4451-aaf5-5e349766d8e7"), "Toss the beans, potatoes and remaining salad ingredients, except the eggs, together in a large bowl with half the dressing. Arrange the eggs on top and drizzle over the remaining dressing.", new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 3 },
                    { new Guid("72afa0b3-04ec-4bbd-96d1-3338b8c9f4f7"), "Ladle into bowls and top with reserved bacon, jalapeños, cilantro, and avocado.", new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 4 },
                    { new Guid("74afbeb8-4457-4b81-aa56-e36da41c97c5"), "Stir all ingredients except optional chips to form a dough. Either shape into bars with your hands or smooth into a lined 8×8 pan, refrigerate until chilled, then cut into bars.", new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 1 },
                    { new Guid("7ac340d9-a837-4faf-a81f-6a751d3112e0"), "Push vegetables to one side of the pan and add beef. Cook, stirring occasionally, until no pink remains. Drain fat and return to heat.", new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2 },
                    { new Guid("7cc433c8-ea61-4880-83d1-8f05c49ed705"), "Add the scrambled tofu and stir for 1 minute.", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 3 },
                    { new Guid("7d246619-c7b8-46f8-8d4d-6dfc86f01c68"), "Serve with fresh bread.", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 6 },
                    { new Guid("7f88e4d8-caa6-4d93-9de5-573dd6b520e0"), "Meanwhile boil the potatoes for 7 mins, add the beans and boil 5 mins more or until both are just tender, then drain. Boil 2 eggs for 8 minutes then shell and halve.", new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 2 },
                    { new Guid("82551662-d25f-4f53-a3a1-e3ca287d3764"), "Heat a lightly oiled griddle or pan over medium-high heat. Pour or scoop the batter onto the griddle, using approximately 1/4 cup for each pancake; cook until bubbles form and the edges are dry, about 2 to 3 minutes. Flip and cook until browned on the other side. Repeat with remaining batter.", new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 2 },
                    { new Guid("93233cc4-52b4-410f-a08c-ee1e8a937c25"), "Add cooked rice, tofu, and remaining sauce and stir. Cook over medium-high heat for 3-4 minutes, stirring frequently.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 9 },
                    { new Guid("967daf09-a092-47d9-bd31-62e906fce65b"), "Add the 1/2 cup of oat milk and stir until the tofu has soaked up most of it.", new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 4 },
                    { new Guid("9b665ac9-c848-43f4-9eac-4be718378a8f"), "Preheat oven to 400 degrees F (204 C) and line a baking sheet with parchment paper (or lightly grease with non-stick spray).", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1 },
                    { new Guid("a114d0bb-154b-4f1f-9e23-55acbcdf0c53"), "While the tofu bakes prepare your rice by bringing 12 cups of water to a boil in a large pot. Once boiling, add rinsed rice and stir. Boil on high uncovered for 30 minutes, then strain for 10 seconds and return to pot removed from the heat. Cover with a lid and let steam for 10 minutes*.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 4 },
                    { new Guid("af48ebb8-d285-4176-ab2c-76b36fc92b3d"), "In a blender, combine all ingredients and blend until smooth.", new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 1 },
                    { new Guid("af5da275-bb8c-4da8-aa34-8322ab48ac41"), "For the optional chocolate coating, spread the melted chocolate over the pan before chilling. (I usually stir 2 tsp oil into the melted chocolate for a smoother sauce, but it's not required.) Or you can dip the bars into the chocolate sauce individually and then chill to set.", new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 2 },
                    { new Guid("bd076174-7975-428a-b529-980923a78ad5"), "In a blender, blend together ice cream and milk.", new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 1 },
                    { new Guid("bdb410d1-bd56-4301-acdb-398056738541"), "Transfer to serving glasses and refrigerate 30 minutes and up to 1 hour. Garnish with chocolate curls if using.", new Guid("90047163-0479-45c6-835a-d1f50167031f"), 2 },
                    { new Guid("ca2a3a73-58fb-4da2-9f7f-59fb4cf23b49"), "To the still hot pan add garlic, green onion, peas and carrots. Sauté for 3-4 minutes, stirring occasionally, and season with 1 Tbsp (15 ml) tamari or soy sauce", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 8 },
                    { new Guid("cccc8024-8a65-40fb-a02b-8d35f0a0aa98"), "Heat a large metal or cast iron skillet over medium heat. Once hot, use a slotted spoon to scoop the tofu into the pan leaving most of the sauce behind. Cook for 3-4 minutes, stirring occasionally, until deep golden brown on all sides (see photo). Lower heat if browning too quickly. Remove from pan and set aside.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 7 },
                    { new Guid("ce761ab4-7276-4bb9-ba6b-8b21657b6a8b"), "Add chili powder, cumin, oregano, and paprika and season with salt and pepper. Stir to combine and cook 2 minutes more. Add tomatoes and broth and bring to a simmer. Let cook 10 to 15 more minutes, until chili has thickened slightly. ", new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 3 },
                    { new Guid("d204ffbf-638b-4770-a61e-7bb3206909fc"), "While rice and tofu are cooking, prepare sauce by adding all ingredients to a medium-size mixing bowl and whisking to combine. Taste and adjust flavor as needed, adding more tamari or soy sauce for saltiness, peanut butter for creaminess, brown sugar for sweetness, or chili garlic sauce for heat.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 5 },
                    { new Guid("e34fa00d-df53-4057-868a-5522ce62e611"), "Sift flour, baking powder, sugar, and salt together in a large bowl. Make a well in the center and add milk, melted butter, and egg; mix until smooth.", new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1 },
                    { new Guid("e381dcce-e003-4e57-a5ad-d38635632ffa"), "In a large pot over medium heat, cook bacon. When bacon is crisp, remove from pot with a slotted spoon. Add onion, celery, and peppers to pot and cook until soft, 6 minutes. Add garlic and cook until fragrant, 1 minute more.", new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 1 },
                    { new Guid("e7f2d930-1b22-4903-80a3-eea0403ef530"), "Add the tuna, cilantro, red onion, celery, and jalapeños (if using). Stir everything together, breaking apart any large pieces of tuna as needed.", new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 2 },
                    { new Guid("f432738e-0d14-4048-8e15-fe0013011b77"), "Serve immediately with extra chili garlic sauce or sriracha for heat (optional). Crushed salted, roasted peanuts or cashews make a lovely additional garnish. Leftovers keep well in the refrigerator for 3-4 days, though best when fresh. Reheat in a skillet over medium heat or in the microwave.", new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 10 },
                    { new Guid("f44820e1-efd0-4f8b-a2ba-7912b0eab29f"), "Adjust salt and jalapeños to taste if needed. Serve immediately.", new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 3 },
                    { new Guid("f7577784-675c-49a2-8f59-99121822c101"), "Mash the avocado and lime juice together with sea salt.", new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 1 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Amount", "UnitId" },
                values: new object[,]
                {
                    { new Guid("02b4cb46-2f3f-410b-9e42-eb8cf66a4a01"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 0.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("033291a3-b3ec-4771-a1f0-a3e4456efad2"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 0.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("055c9cbf-a0ae-4d21-99f4-9181d181f54b"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 200.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("153eb14b-d583-42b3-b81b-b3d9a60bef24"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 3.5, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("1ebb27d0-d452-4b42-a6c3-081412c58fc7"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 1.0, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("21799d42-c1c9-44ec-b2a0-41e199d57944"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 0.5, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Amount", "UnitId" },
                values: new object[,]
                {
                    { new Guid("21bb0aa8-bfb2-474c-82d6-c9cbc618654e"), new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 1.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("21bb0aa8-bfb2-474c-82d6-c9cbc618654e"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("231fe3ab-d192-4ee2-9ad6-1def1c5bb298"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 1.0, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("23ef218b-e374-471f-9968-b1df6987a48d"), new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 1.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("25b4bd2f-c70e-49ef-9dd3-365e4317a568"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 0.5, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("28ad0e27-a012-4030-bdb5-e91c5fb848d0"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 0.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("2e48fed1-fdcf-4421-8ac0-6649670accc3"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("2e680992-51a9-4993-885b-4cb0da5dfd31"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 0.75, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("30d52d32-4c30-43f6-8cb1-73cb044b721e"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 3.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("31eaa15a-7c94-4206-a588-e2536fa0b399"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 0.5, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("31eaa15a-7c94-4206-a588-e2536fa0b399"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 3.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("375627f6-719d-40fc-afd1-2ad4b7418642"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2.0, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("3c9dbd1a-5890-4aea-8e8c-f6846ec0b311"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 0.75, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("4370914a-555c-47d7-a40f-a757e5280d79"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 0.0, new Guid("a6d6a4d0-2942-46ca-b6c5-8c47960a1388") },
                    { new Guid("4e6cdcf9-3ff7-44a9-ae73-14177d0b0ce7"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 15.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("5226e4fb-7360-4234-92a0-fa190a24b1be"), new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 0.25, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("5226e4fb-7360-4234-92a0-fa190a24b1be"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("5226e4fb-7360-4234-92a0-fa190a24b1be"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 2.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("559d2ce2-5f6e-4f8e-b85f-a8def3fb8650"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("56469591-0026-4890-a8e7-562f13f8b69c"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 150.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("571dcf9c-d268-4018-81b5-8f49ac3d26f5"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 3.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("571dcf9c-d268-4018-81b5-8f49ac3d26f5"), new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 0.5, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("619729eb-e375-419e-bf7c-c67941a98753"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 1.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("645dcd09-9191-42ca-a1e1-8585680c8342"), new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 0.0, new Guid("a6d6a4d0-2942-46ca-b6c5-8c47960a1388") },
                    { new Guid("64c972c0-bd32-4f82-94ae-2942305ee1ec"), new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 0.75, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("67b9885f-c3cd-439e-9c63-bea9906b25a8"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("682e2bfb-7d18-448f-b695-14db95997088"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 250.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("686bd9dd-ff1c-4a8e-97b3-2057c6279652"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 1.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("6d065d6b-6bfd-4ba7-9221-96d2a26fadf8"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2.0, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("7023c350-e78b-48fe-b62f-93ebedca6f97"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 1.0, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("76ad7715-89bb-46b3-9f14-7840c2e18317"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("7af60fc5-2248-4444-bea5-6428fae6b26e"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 150.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("7f12e6c4-d2ae-4d17-b8a1-c86be4a4d8c9"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 1.0, new Guid("1ed4ac46-1a54-4240-b8d7-ad6672c35e1c") },
                    { new Guid("7f12e6c4-d2ae-4d17-b8a1-c86be4a4d8c9"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1.0, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("8066eade-199f-4b52-8e2b-f84a9f28c050"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 2.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("8145feec-0dfb-4fe8-b647-1ec357f37d25"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 200.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("8c71cf76-965d-4f46-8555-40474a43d95d"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1.0, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("8dc954e5-a92a-4000-8bdc-878dfb9af389"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1.25, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("8dc954e5-a92a-4000-8bdc-878dfb9af389"), new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 1.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("a07a2c48-a9de-44ef-a52a-20bae5821b2f"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 2.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("a07a2c48-a9de-44ef-a52a-20bae5821b2f"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 2.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("a344772e-11a8-4a6d-bf47-3d9a6935825b"), new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 0.5, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "Amount", "UnitId" },
                values: new object[,]
                {
                    { new Guid("a344772e-11a8-4a6d-bf47-3d9a6935825b"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 0.25, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("a344772e-11a8-4a6d-bf47-3d9a6935825b"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 0.5, new Guid("a754048a-1cf4-467c-8294-0d2ce7cc3644") },
                    { new Guid("a5bb32ae-5086-41e7-a00f-780e4f61c2f3"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 0.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("a7926359-306b-4582-b28a-d9ee4bba88b8"), new Guid("cea7bbf3-19d2-48be-b3ca-fdb0806c6a47"), 140.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("a8592ecf-9e7a-4d5c-8de4-224f50c3bd79"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 150.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("b0b19759-885a-436a-8992-51bb0ced01f4"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 1.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("b2f155d5-161f-45d3-8143-d98f1d7a1fd8"), new Guid("b14e9199-5a34-4185-9807-20e905a76a32"), 0.0, new Guid("a6d6a4d0-2942-46ca-b6c5-8c47960a1388") },
                    { new Guid("bcc4460e-e664-4b69-9171-151b636adf74"), new Guid("90047163-0479-45c6-835a-d1f50167031f"), 0.25, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("ccb17653-ae3f-40b4-98f0-c44e24fbb7be"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 6.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("d7ec5abd-cbd6-4b4a-9b08-3c71a17194ab"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 3.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("d7f1c8aa-eb8b-4606-91ed-3c0d63b55981"), new Guid("f15fd0f4-5bfb-4118-8f85-e40c1325f748"), 2.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("da652f59-19d8-48bc-a197-81ed0596d660"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1.0, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("dc93cdaa-3392-47c2-846e-35e9b41547ed"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 0.5, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") },
                    { new Guid("dffe97a7-a724-4676-addc-800c1f947004"), new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), 250.0, new Guid("c90d0134-d29d-45e4-ac10-f753cd40f408") },
                    { new Guid("e5256e0b-305f-461e-8682-15987b4f300d"), new Guid("4be0635b-dff4-48fc-87d2-e8c05b5d6502"), 1.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("e5256e0b-305f-461e-8682-15987b4f300d"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 2.0, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("e9608381-4253-4f4d-b1e2-fa537e5594e0"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 0.5, new Guid("acf51f0b-a255-43ff-80f2-3411f936ff5e") },
                    { new Guid("ec15c23a-5748-42a5-b6ee-5cea71198c78"), new Guid("175f8c2e-f14b-402d-9d48-a3f9970ce194"), 35.0, new Guid("943e5a57-5f4e-4d3f-aa36-2804f3d31459") },
                    { new Guid("eebbe687-a467-4662-80bc-85059642bbc6"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 3.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("f52dba50-7832-437a-ad7e-95024fe3ec88"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 4.0, new Guid("81311dec-3196-4045-9372-3dc4e7dc2543") },
                    { new Guid("f52dba50-7832-437a-ad7e-95024fe3ec88"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 1.0, new Guid("81311dec-3196-4045-9372-3dc4e7dc2543") },
                    { new Guid("f852c5d5-3d69-4969-a460-757a59c8d159"), new Guid("8eecc05a-e77f-4dc7-b586-9b5e5c1ffc04"), 2.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("fa6e2093-48d0-42bb-9f29-5a32a309e9e2"), new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), 1.0, new Guid("b7c64215-20a5-4e61-ad06-b030ab2740fd") },
                    { new Guid("fe772d41-bfe6-4280-8dc3-f338d815b70b"), new Guid("728c4eb5-4ff4-4273-a2b2-3363c4ee442b"), 1.0, new Guid("2f048952-7c04-4d58-9509-cb94500ecb05") }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ApplicationUserId", "Comment", "CreationDate", "Rating", "RecipeId", "UpdateTimeStamp" },
                values: new object[,]
                {
                    { new Guid("0eae271e-d883-4132-ac0d-7bc1b79b625a"), "00000000-0000-0000-0000-000000000003", "Didn't taste good", new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("446da3e2-f422-4aea-bd61-125ab389287e"), "00000000-0000-0000-0000-000000000003", "Great recipe!", new DateTime(2023, 1, 11, 10, 28, 10, 292, DateTimeKind.Local).AddTicks(7620), 4, new Guid("12e1bb6f-ebf7-4157-b665-e01313e4a468"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5c5f1dae-3ae7-408a-a186-d2b9a784ea41"), "00000000-0000-0000-0000-000000000002", null, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a0fc3e04-8b78-4ad5-85f0-a525c7b978c3"), "00000000-0000-0000-0000-000000000002", "Definitely will eat this again!", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new Guid("bd4f4ee3-e085-42cf-9962-253fff6e64e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_Instructions_RecipeId",
                table: "Instructions",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_UnitId",
                table: "RecipeIngredients",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ApplicationUserId",
                table: "Recipes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CategoryId",
                table: "Recipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_DietId",
                table: "Recipes",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApplicationUserId",
                table: "Reviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");
        }

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
                name: "Instructions");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Diets");
        }
    }
}
