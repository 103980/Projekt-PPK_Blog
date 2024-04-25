using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class AddingNormalizedSuperUsernameandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e1a5577-a544-46c6-a5a4-1a96e1e72f57",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "365c394f-48d2-459e-8936-38c113a46e75", "SUPERADMIN@BLOG.COM", "SUPERADMIN@BLOG.COM", "AQAAAAIAAYagAAAAEPV7boUENFk17xnNWRSh2jWFIRDlN58BcsoZQRgA/SK4aVOUBnui3pYcRjOgJvugnA==", "1a1bcd43-5f19-4edf-a997-104c87cf6d37" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e1a5577-a544-46c6-a5a4-1a96e1e72f57",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "846a4adf-3414-48f9-ab74-ac17b517702c", null, null, "AQAAAAIAAYagAAAAEEonLocu1BQit+r54aFxqfKL7KsTb/py9c18p3d6ssaFtsGyIStxnAPI2TbGWzGSoA==", "70114c26-4ac5-42d4-8ae9-26e84382afa7" });
        }
    }
}
