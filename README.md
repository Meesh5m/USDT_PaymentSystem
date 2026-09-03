# USDT (TRC20) Payment Gateway API 💳⚡

An automated payment gateway Web API built with **.NET 8** that integrates with the **TRON Blockchain (TRC20)** to handle USDT payment verifications.

---

## 🛠️ Tech Stack & Features
- **Framework:** .NET 8 Web API
- **ORM:** Entity Framework Core
- **Database:** SQL Server
- **Blockchain Integration:** TronGrid API
- **API Documentation:** Swagger UI
- **Architecture:** Clean Architecture & Repository Pattern

---

## 🚀 How It Works
1. **Create Invoice:** Clients send a request to `POST /api/Payment` with the required amount.
2. **Blockchain Verification:** The system queries the TRON blockchain via TronGrid API to check if a valid transaction matching the amount and recipient wallet exists.
3. **Status Update:** Automatically updates the payment status in SQL Server (`Pending` -> `Completed`).

---

## 💻 API Endpoints
| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `POST` | `/api/Payment` | Creates a new payment invoice |
| `GET` | `/api/Payment/{id}` | Fetches payment details & status |
| `POST` | `/api/Payment/verify/{id}` | Verifies payment on TRON Blockchain |

---

## 👨‍💻 Author
Developed by **Meshari** - [LinkedIn Profile](https://www.linkedin.com)
