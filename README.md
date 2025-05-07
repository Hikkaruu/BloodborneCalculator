# 🩸 Bloodborne Calculator

[![pl](https://img.shields.io/badge/lang-polish-red.svg)](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/README_PL.md)

A web application that allows you to:
- Check the optimal class for your build
- Explore detailed statistics of each boss
- Calculate attack rating for trick weapons and firearms
- Simulate damage dealt by each weapon's moveset against a selected boss



🔗 [Live Frontend](https://bloodborne-calculator-fpbcfydhbqb7c4ax.polandcentral-01.azurewebsites.net/)  
🔗 [Live Backend Swagger API](https://bloodborne-api-bshjg7gybcfbc0eu.polandcentral-01.azurewebsites.net/swagger/index.html)

---

## 🧭 Table of Contents

- [📖 About](#-about)
- [🛠 Tech Stack](#-tech-stack)
- [✨ Features](#-features)
- [🔐 Authorization](#-authorization)
- [🚀 Running Locally](#-running-locally)
- [🖼 Screenshots](#-screenshots)



## 📖 About

Bloodborne Calculator is a fan-made tool that helps players plan their builds, simulate weapon damage based on stats, and explore optimization options.


## 🛠 Tech Stack

- **Frontend:** Angular v19.2.0 (TypeScript, HTML, CSS)
- **Backend:** ASP.NET Core 8.0 (C#)
- **Database:** PostgreSQL
- **Authorization:** Auth0 (OAuth2 / OpenID Connect)
- **Hosting:** Microsoft Azure

## ✨ Features

- Weapons scaling calculator
- Damage simulation
- Bosses, origins, weapons info
- API documentation via Swagger
- Secure API Authorization with Auth0
- Responsive design for mobile & desktop

## 🔐 Authorization

- Login is handled via **Auth0** with secure tokens
- JWT tokens are sent in API requests to protected endpoints (POST | PUT | DELETE)
- Token is obtainable only for pre-registered accounts

## 🚀 Running Locally

### Prerequisites:
- .NET 8 SDK
- Node.js 22 & Angular CLI
- PostgreSQL
- Auth0 account

### 📁 Configuration

#### Postgresql
- Create database
  
#### Backend

- Before running the backend, create a .env file in the backend root directory with the following content
```env
# .env
DB_PASSWORD=
DB_HOST=
DB_USER=
DB_NAME=
CLIENT_ID=[Auth0 client id]
CLIENT_SECRET=[Auth 0 Client secret]
AUTHORITY=[Auth0 authority link]
AUDIENCE=[Auth0 audience link]
PRODUCTION_CORS_HOST=[Frontend link for CORS]
```
- Create Migrations and update database
```ps
dotnet ef migrations add DatabaseInit --output-dir Persistence/Migrations
dotnet ef database update
```

- Run the backend, the database will be seeded automatically.
```
cd backend
dotnet restore
dotnet run
```

#### Frontend

- Before running the frontend, create a environments folder and inside environment.ts file in frontend/src/app with the following content
```ts
// environment.ts
export const environment = {
  production: false,
  apiUrl:
    'link to backend',
};

```

- Run the frontend.
```
cd frontend
npm install
ng serve
```

## 🖼 Screenshots

### Database
![database_schema](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/database.png)

---
### Frontend

#### Home Page
![home](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_1.png)

#### Boss Page
![bosses](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_2.png)

#### Optimal Class Page
![optimal-class](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_3.png)

#### Firearms Page 
![firearms](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_6.png)

#### Firearms Selection Pop-up
![firearms-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_4.png)

#### Boss Selection Pop-up
![bosses-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_5.png)

#### Trickster Weapons Page 
![trickster-weapons](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_8.png)

#### Trickster Weapons Selection Pop-up 
![trickster-weapons-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_7.png)

#### Selected Trickster Weapon Damage Table
![trickster-weapon-damage-table](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_9.png)

---
### Backend API

#### API with Swagger Documentation

![api](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/backend_1.png)
