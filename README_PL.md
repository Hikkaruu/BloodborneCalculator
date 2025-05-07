# 🩸 Bloodborne Calculator

[![pl](https://img.shields.io/badge/lang-english-red.svg)](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/README.md)

Aplikacja webowa pozwalająca na:
- Wybieraniu optymalnej klasy w zależności od buildu
- Przegląd bossów oraz ich statystyk
- Obliczanie ataku broni
- Symulacja zadanych obrażeń dla dowolnej broni przeciwko dowolnemu bossowi

🔗 [Hostowany Frontend](https://bloodborne-calculator-fpbcfydhbqb7c4ax.polandcentral-01.azurewebsites.net/)  
🔗 [Hostowany Backend Swagger API](https://bloodborne-api-bshjg7gybcfbc0eu.polandcentral-01.azurewebsites.net/swagger/index.html)

---

## 🧭 Spis treści

- [📖 O Projekcie](#-o-projekcie)
- [🛠 Technologie](#-technologie)
- [✨ Funkcje](#-funkcje)
- [🔐 Autoryzacja](#-autoryzacja)
- [🚀 Uruchamianie Lokalne](#-uruchamianie-lokalne)
- [🖼 Zrzuty Ekranu](#-zrzuty-ekranu)


## 📖 O Projekcie

Bloodborne Calculator to fanowski projekt, który pomaga w planowaniu buildów, symuluje obrażenia broni oraz pozwala na optymalizację statystyk


## 🛠 Technologie

- **Frontend:** Angular v19.2.0 (TypeScript, HTML, CSS)
- **Backend:** ASP.NET Core 8.0 (C#)
- **Baza Danych:** PostgreSQL
- **Autoryzacja:** Auth0 (OAuth2 / OpenID Connect)
- **Hosting:** Microsoft Azure

## ✨ Funkcje

- Kalkulator skalowania statystyk broni
- Symulacja obrażeń
- Informacje o bossach, klasach oraz broniach
- Dokumentacja API Swagger
- Autoryzacja API poprzez Auth0
- Responsywny design

## 🔐 Autoryzacja

- Logowanie obsługiwane przez Auth0 z użyciem tokenów
- Tokeny JWT są wysyłane w żądaniach do chronionych endpointów (POST | PUT | DELETE)
- Token możliwy do uzyskania tylko dla wcześniej zarejestrowanych kont

## 🚀 Uruchamianie Lokalne

### Prerequisites:
- .NET 8 SDK
- Node.js 22 & Angular CLI
- PostgreSQL
- Konto Auth0

### 📁 Konfiguracja

#### Postgresql
- Utwórz bazę danych
  
#### Backend

- Przed uruchomieniem backendu, utwórz plik .env w katalogu głównym backendu z następującą zawartością:
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
- Utwórz migrację i zaktualizuj bazę danych:
```ps
dotnet ef migrations add DatabaseInit --output-dir Persistence/Migrations
dotnet ef database update
```

- Uruchom backend – baza danych zostanie automatycznie zapełniona przykładowymi danymi (seed):
```
cd backend
dotnet restore
dotnet run
```

#### Frontend

- Przed uruchomieniem frontendu utwórz folder environments oraz plik environment.ts w frontend/src/app o następującej treści:
```ts
// environment.ts
export const environment = {
  production: false,
  apiUrl:
    'link to backend',
};

```

- Uruchom frontend:
```
cd frontend
npm install
ng serve
```

## 🖼 Zrzuty Ekranu

### Baza danych
![database_schema](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/database.png)

---
### Frontend

#### Strona domowa
![home](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_1.png)

#### Strona Boss
![bosses](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_2.png)

#### Strona optymalnej klasy
![optimal-class](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_3.png)

#### Strona obliczania obrażeń broni palnej
![firearms](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_6.png)

#### Wybór broni palnej
![firearms-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_4.png)

#### Wybór bossa
![bosses-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_5.png)

#### Strona obliczania obrażeń broni
![trickster-weapons](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_8.png)

#### Wybór broni
![trickster-weapons-popup](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_7.png)

#### Tablica obrażen dla wybranej broni
![trickster-weapon-damage-table](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/frontend_9.png)

---
### Backend API

#### API z dokumentacją Swagger 

![api](https://github.com/Hikkaruu/BloodborneCalculator/blob/main/readmeimg/backend_1.png)
