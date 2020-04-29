using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkTest.Migrations
{
    public partial class AccountStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[sp_GetAccountsByFirstName]
                    @FirstName nvarchar(100)
                    AS
                    
                    SELECT * FROM Accounts where FirstName = @FirstName
                GO  
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DROP PROCEDURE [dbo].[sp_GetAccountsByFirstName]");
        }
    }
}
