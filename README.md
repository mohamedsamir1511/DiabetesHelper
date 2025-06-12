# 🩺 DiabetesHelper - Web App for Diabetes Patients

## 📌 Overview
**DiabetesHelper** is a web application built with ASP.NET Core MVC to help diabetes patients monitor and manage their blood sugar levels.  
It allows users (patients and doctors) to register, log in, track readings, and view insightful statistics and charts.

---

## 🚀 Features

- 👥 User Registration & Login (Patients / Doctors)  
- 🩸 Add and view blood glucose readings  
- 📊 Dashboard with:  
  - Last reading details  
  - Min / Max / Avg readings  
  - Last 7 readings line chart  
- 🔔 Smart alerts (Coming Soon)  
- 🧠 Doctor-patient connection (Coming Soon)

---

## 🛠 Tech Stack

**Frontend (Views):** ASP.NET Core MVC (Razor)  
**Backend:** C# (.NET Core)  
**Database:** Entity Framework Core + SQL Server  
**Authentication:** Session-based auth  
**Charts:** Chart.js

---

## 📸 Screenshots

*(Optional: Add screenshots of the Dashboard or Login/Register pages)*

---

## ⚙️ Getting Started

### 1. Clone the repo

```
git clone https://github.com/your-username/DiabetesHelper.git  
cd DiabetesHelper
```

### 2. Setup the database

- Update `appsettings.json` with your SQL Server connection string.
- Run EF Core migrations:

```
dotnet ef database update
```

### 3. Run the app

```
dotnet run
```

Then open in your browser:  
`https://localhost:5001`

---

## 👨‍⚕️ User Roles

- **Patient:** Add/view blood sugar readings, view charts  
- **Doctor** *(Coming soon):* View patient data, give advice

---

## ✍️ Author

**Mohamed Samir**  
📧 mohamedsamir151120@gmail.com  
[LinkedIn](https://www.linkedin.com/in/mohamedsamirf15)  
[GitHub](https://github.com/mohamedsamir1511)

---

## 📌 Future Plans

- 🔗 Connect patients with doctors  
- 💊 Medication reminders  
- 📱 Mobile-friendly version  
- 📈 Smart analytics + insights
