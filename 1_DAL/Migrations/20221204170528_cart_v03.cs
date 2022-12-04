using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1_DAL.Migrations
{
    public partial class cart_v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BangQuyDoiDiem_BangQuyDoiDiem_IdVi",
                table: "BangQuyDoiDiem");

            migrationBuilder.DropForeignKey(
                name: "FK_BangQuyDoiDiem_ViDiem_ViDiemId",
                table: "BangQuyDoiDiem");

            migrationBuilder.DropIndex(
                name: "IX_BangQuyDoiDiem_ViDiemId",
                table: "BangQuyDoiDiem");

            migrationBuilder.DropColumn(
                name: "ViDiemId",
                table: "BangQuyDoiDiem");

            migrationBuilder.AddForeignKey(
                name: "FK_BangQuyDoiDiem_ViDiem_IdVi",
                table: "BangQuyDoiDiem",
                column: "IdVi",
                principalTable: "ViDiem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BangQuyDoiDiem_ViDiem_IdVi",
                table: "BangQuyDoiDiem");

            migrationBuilder.AddColumn<Guid>(
                name: "ViDiemId",
                table: "BangQuyDoiDiem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BangQuyDoiDiem_ViDiemId",
                table: "BangQuyDoiDiem",
                column: "ViDiemId");

            migrationBuilder.AddForeignKey(
                name: "FK_BangQuyDoiDiem_BangQuyDoiDiem_IdVi",
                table: "BangQuyDoiDiem",
                column: "IdVi",
                principalTable: "BangQuyDoiDiem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BangQuyDoiDiem_ViDiem_ViDiemId",
                table: "BangQuyDoiDiem",
                column: "ViDiemId",
                principalTable: "ViDiem",
                principalColumn: "Id");
        }
    }
}
