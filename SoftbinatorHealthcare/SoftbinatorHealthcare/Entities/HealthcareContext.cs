using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftbinatorHealthcare.Authentication;
using SoftbinatorHealthcare.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftbinatorHealthcare.Models
{
    public class HealthcareContext : IdentityDbContext<ApplicationUser>
    {
        public HealthcareContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorPacient> DoctorPacients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DoctorPacient>()
                .HasOne(d => d.Doctor)
                .WithMany(dp => dp.DoctorPacients)
                .HasForeignKey(di => di.DoctorID);
            modelBuilder.Entity<DoctorPacient>()
                .HasOne(p => p.Pacient)
                .WithMany(dp => dp.DoctorPacients)
                .HasForeignKey(p => p.PacientID);

            modelBuilder.Entity<Pacient>().HasData(new Pacient
            {
                PacientID = 1,
                FirstName = "Bogdan",
                LastName = "Cojocaru",
                DateOfBirth = new DateTime(1997,03,04),
                Insurance = true,
                UnderlyingConditions = "none"
            }, new Pacient 
            {
                PacientID = 2,
                FirstName = "Victor",
                LastName = "Popescu",
                DateOfBirth = new DateTime(1997, 10, 25),
                Insurance = true,
                UnderlyingConditions = "Asthma"
            }, new Pacient
            {
                PacientID = 3,
                FirstName = "Ionut",
                LastName = "Roman",
                DateOfBirth = new DateTime(1965, 02, 21),
                Insurance = false,
                UnderlyingConditions = "Diabetes"
            }, new Pacient 
            {
                PacientID = 4,
                FirstName = "Maria",
                LastName = "Fasie",
                DateOfBirth = new DateTime(1998, 01, 10),
                Insurance = true,
                UnderlyingConditions = "none"
            });
            
            modelBuilder.Entity<Disease>().HasData(new Disease
            {
                DiseaseID = 1,
                DiseaseName = "Tuberculosis",
                Symptom1 = "cough",
                Symptom2 = "fever",
                Symptom3 = "chills",
                Symptom4 = "night sweats",
                Symptom5 = "loss of apetite",
                DiseaseType = "Respiratory",
                RiskFactor = "High"
            }, new Disease
            {
                DiseaseID = 2,
                DiseaseName = "Alzheimer",
                Symptom1 = "memory problems",
                Symptom2 = "increased confusion",
                Symptom3 = "reduced concentration",
                Symptom4 = "apathy",
                Symptom5 = "personality changes",
                DiseaseType = "Mental",
                RiskFactor = "High"
            }, new Disease
            {
                DiseaseID = 3,
                DiseaseName = "Rhinovirus",
                Symptom1 = "nasal dryness or irritation",
                Symptom2 = "sore throat",
                Symptom3 = "headache",
                Symptom4 = "facial and ear pressure",
                Symptom5 = "low-grade fever",
                DiseaseType = "Viral infection",
                RiskFactor = "Low"
            }, new Disease
            {
                DiseaseID = 4,
                DiseaseName = "Conjunctivitis",
                Symptom1 = "pink or red color in the white of the eye",
                Symptom2 = "swelling of the conjunctiva",
                Symptom3 = "increased tear production",
                Symptom4 = "feeling like a foreign body is in the eye",
                Symptom5 = "urge to rub the eye",
                DiseaseType = "Infection",
                RiskFactor = "Medium"
            });

            modelBuilder.Entity<Treatment>().HasData(new Treatment
            {
                TreatmentID = 1,
                DiseaseName = "Tuberculosis",
                Medication = "Isoniazid, Rifampin, Ethambutol, Pyrazinamide",
                StartDate = new DateTime(2021, 05, 15)
            }, new Treatment
            {
                TreatmentID = 2,
                DiseaseName = "Alzheimer",
                Medication = "Cholinesterase inhibitors, Memantine",
                StartDate = new DateTime(2021, 02, 19)
            }, new Treatment
            {
                TreatmentID = 3,
                DiseaseName = "Rhinovirus",
                Medication = "nonsteroidal anti-inflammatory drugs, antihistamines, and anticholinergic nasal solutions",
                StartDate = new DateTime(2021, 03, 28)
            }, new Treatment
            {
                TreatmentID = 4,
                DiseaseName = "Conjunctivitis",
                Medication = "Bleph (sulfacetamide sodium), Moxeza (moxifloxacin), Zymar (gatifloxacin), Romycin (erythromycin)",
                StartDate = new DateTime(2021, 01, 09)
            });

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                DoctorID = 1,
                FirstName = "Mihnea",
                LastName = "Vasilescu",
                Sallary = 6000
            }, new Doctor
            {
                DoctorID = 2,
                FirstName = "Laura",
                LastName = "Hancu",
                Sallary = 9000

            }, new Doctor
            {
                DoctorID = 3,
                FirstName = "Alex",
                LastName = "Matei",
                Sallary = 11000

            }, new Doctor
            {
                DoctorID = 4,
                FirstName = "Theodor",
                LastName = "Badea",
                Sallary = 8600
            });

            modelBuilder.Entity<DoctorPacient>().HasData(new DoctorPacient
            {
                ID = 1,
                DoctorID = 1,
                PacientID = 1
            }, new DoctorPacient
            {
                ID = 2,
                DoctorID = 1,
                PacientID = 2

            }, new DoctorPacient
            {
                ID = 3,
                DoctorID = 2,
                PacientID = 2

            }, new DoctorPacient
            {
                ID = 4,
                DoctorID = 3,
                PacientID = 4
            });

        }
    }
}
