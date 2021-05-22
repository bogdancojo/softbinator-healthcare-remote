using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftbinatorHealthcare.Migrations
{
    public partial class SoftbinatorHealthcareMig1EntitiesHealthcareContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(nullable: true),
                    Symptom1 = table.Column<string>(nullable: true),
                    Symptom2 = table.Column<string>(nullable: true),
                    Symptom3 = table.Column<string>(nullable: true),
                    Symptom4 = table.Column<string>(nullable: true),
                    Symptom5 = table.Column<string>(nullable: true),
                    DiseaseType = table.Column<string>(nullable: true),
                    RiskFactor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseID);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Sallary = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorID);
                });

            migrationBuilder.CreateTable(
                name: "Pacients",
                columns: table => new
                {
                    PacientID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Insurance = table.Column<bool>(nullable: false),
                    UnderlyingConditions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacients", x => x.PacientID);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    TreatmentID = table.Column<long>(nullable: false),
                    DiseaseName = table.Column<string>(nullable: true),
                    Medication = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_Treatments_Diseases_TreatmentID",
                        column: x => x.TreatmentID,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPacients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorID = table.Column<long>(nullable: false),
                    PacientID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPacients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DoctorPacients_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPacients_Pacients_PacientID",
                        column: x => x.PacientID,
                        principalTable: "Pacients",
                        principalColumn: "PacientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "DiseaseID", "DiseaseName", "DiseaseType", "RiskFactor", "Symptom1", "Symptom2", "Symptom3", "Symptom4", "Symptom5" },
                values: new object[,]
                {
                    { 1L, "Tuberculosis", "Respiratory", "High", "cough", "fever", "chills", "night sweats", "loss of apetite" },
                    { 2L, "Alzheimer", "Mental", "High", "memory problems", "increased confusion", "reduced concentration", "apathy", "personality changes" },
                    { 3L, "Rhinovirus", "Viral infection", "Low", "nasal dryness or irritation", "sore throat", "headache", "facial and ear pressure", "low-grade fever" },
                    { 4L, "Conjunctivitis", "Infection", "Medium", "pink or red color in the white of the eye", "swelling of the conjunctiva", "increased tear production", "feeling like a foreign body is in the eye", "urge to rub the eye" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorID", "FirstName", "LastName", "Sallary" },
                values: new object[,]
                {
                    { 1L, "Mihnea", "Vasilescu", 6000L },
                    { 2L, "Laura", "Hancu", 9000L },
                    { 3L, "Alex", "Matei", 11000L },
                    { 4L, "Theodor", "Badea", 8600L }
                });

            migrationBuilder.InsertData(
                table: "Pacients",
                columns: new[] { "PacientID", "DateOfBirth", "FirstName", "Insurance", "LastName", "UnderlyingConditions" },
                values: new object[,]
                {
                    { 1L, new DateTime(1997, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan", true, "Cojocaru", "none" },
                    { 2L, new DateTime(1997, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor", true, "Popescu", "Asthma" },
                    { 3L, new DateTime(1965, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut", false, "Roman", "Diabetes" },
                    { 4L, new DateTime(1998, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maria", true, "Fasie", "none" }
                });

            migrationBuilder.InsertData(
                table: "DoctorPacients",
                columns: new[] { "ID", "DoctorID", "PacientID" },
                values: new object[,]
                {
                    { 1, 1L, 1L },
                    { 2, 1L, 2L },
                    { 3, 2L, 2L },
                    { 4, 3L, 4L }
                });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "TreatmentID", "DiseaseName", "Medication", "StartDate" },
                values: new object[,]
                {
                    { 1L, "Tuberculosis", "Isoniazid, Rifampin, Ethambutol, Pyrazinamide", new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Alzheimer", "Cholinesterase inhibitors, Memantine", new DateTime(2021, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "Rhinovirus", "nonsteroidal anti-inflammatory drugs, antihistamines, and anticholinergic nasal solutions", new DateTime(2021, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4L, "Conjunctivitis", "Bleph (sulfacetamide sodium), Moxeza (moxifloxacin), Zymar (gatifloxacin), Romycin (erythromycin)", new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPacients_DoctorID",
                table: "DoctorPacients",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPacients_PacientID",
                table: "DoctorPacients",
                column: "PacientID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPacients");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Pacients");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}
