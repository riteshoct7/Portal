using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Countries] ON");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(1, N'India', N'+91', N'India', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(2, N'Canada', N'+1', N'Canada', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(3, N'Burma', N'+95', N'Burma', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(4, N'London', N'+44', N'London', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(5, N'US', N'+1', N'US', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(6, N'Australia;', N'+61', N'Australia', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(7, N'Dubai', N'+971', N'Dubai', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(8, N'Germany', N'+49', N'Germany', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(9, N'Belgium', N'+32', N'Belgium', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(10, N'Italy', N'+39', N'Italy', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(11, N'Netherlands', N'+31', N'Netherlands', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(12, N'Switzerland ', N'+41', N'Switzerland ', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(13, N'Romania', N'+40', N'Romania', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(14, N'Hungary', N'+36', N'Hungary', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(15, N'Bulgaria', N'+359', N'Bulgaria', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(16, N'Russia', N'+7', N'Russia', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(17, N'China', N'+86', N'China', 1)");
            migrationBuilder.Sql("INSERT[dbo].[Countries]([CountryId], [CountryName], [ISDCode], [Description], [Enabled]) VALUES(18, N'Japan', N'+81', N'Japan', 1)");
            migrationBuilder.Sql("SET IDENTITY_INSERT [dbo].[Countries] OFF");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
