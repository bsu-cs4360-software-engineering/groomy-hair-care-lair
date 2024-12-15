# Master Document  

---

## 1. Functional Requirements

### User Account Management
- Users can create an account.
- Users can log in/authenticate.

### Customer Management
- Users can create, read, update, and delete (CRUD) customer records.

### Appointment Management
- Users can CRUD appointments.

### Notes Management
- Users can CRUD notes.

### Service Management
- Users can CRUD services.

### Invoice Management
- Users can CRUD invoices.

### Map Functionality
- Users can view a map of the local area.
- The map displays the route from the user's current location to the next appointment.

---

## 2. Non-Functional Requirements
- The software will feature a **graphical user interface (GUI)**.
- Unit tests will serve as the primary documentation for the codebase.
- The application will be **desktop-based only**.
- No payment processing functionality will be implemented.

---

## 3. Design Document

### Architecture
- The system follows a **client-server architecture**.

### Design Patterns
- Development will adhere to design patterns specified by the client.

### Key Components
- **Graphical User Interface (GUI)**: The primary interaction point for users.
- **Data Storage**: Initially using a local JSON file; alternative database solutions are under consideration.

---

## 4. System Standards / Conventions

### Programming Language
- The application will be developed in **C#**.

### Database
- Currently under development; final choice of database technology is pending.

### Directory Structure
The project uses the following directory structure:  

```plaintext
Groomy/
├── Appointments/
├── Customers/
│   ├── Customer.cs
│   ├── CustomerDBService.cs
│   └── CustomerView.cs
├── Notes/
├── Relationships/
├── Services/
├── Users/
├── Utilities/
├── Login.cs
├── Menu/
│   ├── Menu.cs
│   ├── Menu.Designer.cs
│   └── Menu.resx
├── NewUser.cs
└── Program.cs
