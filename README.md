# ☕ CoffeeCrafter

**CoffeeCrafter** is a console-based coffee order management system built in C#.  
This project was created as part of an in-depth learning journey into modern C# development patterns and .NET architecture. It showcases real-world use of design patterns, asynchronous operations, dependency injection, and more.

---

## 🚀 Features

- 🧱 **Design Patterns Implemented**
  - **Factory** – Creates coffee drinks based on type
  - **Decorator** – Dynamically adds ingredients (milk, syrup, whipped cream)
  - **Strategy** – Handles customer order serving priorities (VIP vs Normal)
  - **Observer** – Notifies clients when their orders are ready
  - **DTO** – Separates order data from logic

- 🔁 **Async & Task Support**
  - Prepares drinks asynchronously using `Task` and `await`

- 🧠 **Intelligent Queue Management**
  - VIP customers are served with priority, but normal orders are guaranteed fairness (e.g., 3 VIPs → 1 Normal)

- 🧾 **Logging & Reporting**
  - Orders and events are logged to `Log.json`
  - Reports most popular drinks, average tips, total revenue, etc.

- 💸 **Tips Support**
  - Orders may include tips; reported in daily summaries

- ❌ **Order Cancellation**
  - Orders can be canceled before processing completes

- 🔧 **Dependency Injection**
  - Fully wired via `Microsoft.Extensions.DependencyInjection`

---

## 📁 Project Structure

```bash
CoffeeCrafter/
├── Beverages/             # Base drinks
├── Decorators/            # Add-ons like milk, syrup, etc.
├── Clients/               # Customer logic and subscriptions
├── OrderSystem/           # DTO + OrderService logic
├── ServingStrategies/     # VIP/Normal strategy logic
├── Factory/               # CoffeeFactory pattern
├── Loggers/               # Logger + Reports
├── Interfaces/            # Interfaces for DI and architecture
└── Program.cs             # Application entry point
```

---

## 🧪 Key Concepts Covered

| Concept                  | Applied |
|--------------------------|---------|
| OOP Principles (SOLID)   | ✅      |
| Async / Await            | ✅      |
| Multithreading (Threads) | ✅      |
| LINQ Queries             | ✅      |
| Design Patterns (5+)     | ✅      |
| Dependency Injection     | ✅      |
| IDisposable              | ✅      |
| Logging to JSON          | ✅      |

---

## 🛠️ How to Run

1. Clone the repo  
   ```bash
   git clone https://github.com/Clockwork28/CoffeeCrafter.git
   cd CoffeeCrafter
   ```

2. Build and run the project  
   ```bash
   dotnet build
   dotnet run
   ```

3. Check the output in `Log.json` for order logs and reports.

---

## 📌 Disclaimer

This project was built as a **learning and showcase tool**, but is structured in a production-like way with clean architecture and modular design.  
It can be a great **starting point** for more advanced backend systems or integration into UI-based solutions.

---

## 👤 Author

Created with ☕, 💻 and some 🧠 by Krzysztof Sumera  
