using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Data.Migrations
{
    public partial class AddDefaultAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "IsAdmin", "IsBlocked" },
                values: new object[] { Guid.NewGuid(), "admin", "9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08", true, false });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
