# Master Document

## 1. Functional Requirements
- **User Account Management**
  - Users can create an account.
  - Users can log in/authenticate.
  
- **Customer Management**
  - Users can create, read, update, and delete (CRUD) customer records.

- **Appointment Management**
  - Users can CRUD appointments.

- **Notes Management**
  - Users can CRUD notes.

- **Service Management**
  - Users can CRUD services.

- **Invoice Management**
  - Users can CRUD invoices.

- **Map Functionality**
  - Users can see a map of the local area.
  - The map shows a path from their current location to the next appointment.

- **Payment Processing**
  - Users can "Take Payments" (no actual payment processor involved; this will be simulated).

## 2. Non-Functional Requirements
- The software will be GUI-based.
- Unit testing will serve as the primary source of documentation.
- The application can be either desktop-based or web-based, depending on the group; web-based groups will be responsible for their own hosting.

## 3. Design Document
- **Architecture:** Client-server based software.
- **Design Patterns:** Following design patterns set forth by the client.
- **Key Components:**
  - The GUI, which users will interact with primarily.
- **Data Storage:** Currently using a local JSON file (database details are still under consideration).

## 4. System Standards / Conventions
- **Programming Language:** C#.
- **Database:** In development; specific database technology has not yet been decided.
- **Directory Structure:** Under development; to be determined.
- **Naming Conventions:** Camel case naming convention will be used for classes, methods, constants, variables, etc.

## 5. Quick Start for Developers
- As of now, no API has been implemented.
- **Setup Steps:** 
  - Developers should ensure they have the Visual Studio 2022 enviroment installed and configured.
- **Common Commands/Workflows:**
  - Developers should refer to unit tests for understanding functionality.
- **Resources:**
  - Additional documentation and resources will be provided as the project progresses.
