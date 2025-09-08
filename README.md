MedBock 🚑📅
<img width="420" alt="MedBock" src="https://github.com/user-attachments/assets/8ad81bad-a1af-4ee5-a7fc-ae7b021349a5" />

A lightweight ASP.NET Core MVC Medical Appointment Booking platform. Patients find doctors by discipline, book appointments with automatic device/resource reservation, and the system prevents double-bookings for both doctors and equipment. Roles: Patient, Doctor, Admin.

Key features ✨

Role-based access: Patient / Doctor / Admin.

Browse disciplines and doctors, view availability.

Book appointments with atomic reservation of required devices/resources.

Doctor schedule view & cancellation flow.

Admin panel for users, disciplines and devices.

Tech stack 🛠️

ASP.NET Core MVC (C#)

Entity Framework Core

SQL Server (LocalDB / Express)

Frontend: HTML, CSS, JavaScript

Quick start ▶️

Clone:

git clone <repo-url>
cd MedBock


Configure appsettings.json connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=MedBockDb;Trusted_Connection=True;"
}


Apply migrations & run:

dotnet ef database update
dotnet run
open https://localhost:5001
