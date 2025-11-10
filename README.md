# Ticket Vendor Machine

A WinForms-based ticket vending kiosk that lets passengers choose destinations, pay by card/cash/QR wallet, and prints barcode tickets. The solution follows a simple layered architecture (UI → BLL → DAL) and persists data to SQL Server as defined in `TicketVendorDBquery.sql`.

## Solution Layout

| Path | Description |
| --- | --- |
| `TicketingSystem/UI` | Windows Forms kiosk UI (startup project). |
| `TicketingSystem/BLL` | Business logic coordinating ticket sales and validation. |
| `TicketingSystem/DAL` | Data access layer that executes SQL against `TicketVendorDB`. |
| `TicketVendorDBquery.sql` | Schema + seed data used to create the database. |
| `docs/ticket_vendor_diagrams.md` | Mermaid diagrams (use cases, activity, sequence, state, class, architecture, deployment). |

## Prerequisites

- Windows with Visual Studio 2019/2022 and the **.NET desktop development** workload.
- .NET Framework 4.7.2 developer pack.
- SQL Server (LocalDB, Express, or a full instance) plus a tool to run SQL scripts (e.g., SQL Server Management Studio).

## Database Setup

1. Launch SSMS (or your SQL client) and connect to the target SQL Server instance.
2. Run `TicketVendorDBquery.sql`. This creates the `TicketVendorDB` database, `Destinations`, `Payments`, `Tickets` tables, and seed destinations (Ben Thanh Station, Opera House, Thu Duc).
3. Verify you can query `Destinations` to confirm the seed data is present.

> **Note:** Only the provided SQL script should be used. The DAL no longer attempts to auto-create the database, so a missing connection string or schema will surface as an application error.

## Application Configuration

1. Open `TicketingSystem/UI/App.config`.
2. Update the `TicketVendorDB` connection string so `Server=` points to your SQL Server instance (examples: `Server=(localdb)\MSSQLLocalDB;`, `Server=.\SQLEXPRESS;`).
3. Keep `Initial Catalog=TicketVendorDB` unless you renamed the database in the previous step.

## Build & Run

1. Open `TicketingSystem/TicketingSystem.sln` in Visual Studio.
2. Restore NuGet packages (EntityFramework 6.5.1, etc.) when prompted.
3. Right-click the **UI** project → **Set as StartUp Project**.
4. Build the solution (Ctrl+Shift+B). Resolve any compile errors before continuing.
5. Press F5 to launch the kiosk UI. The happy path is: select language → choose destination → select payment method → simulate payment → ticket barcode is generated and stored.

## Key Components & Flow

- **UI Layer (WinForms):** Contains multilingual forms such as `SelectDestinationForm`, `CardInsertForm`, and payment/receipt screens.
- **Business Logic (`TicketBLL`):** Validates fares, orchestrates payment capture, and issues barcodes.
- **Data Layer (`TicketDAL`):** Executes CRUD operations against `Destinations`, `Payments`, and `Tickets` using the connection string above.

## Documentation & Diagrams

Open `docs/ticket_vendor_diagrams.md` to view or copy the Mermaid source for:
- Use case model + textual descriptions.
- Passenger journey and inter-system activity diagrams.
- Sequence, state, class, architecture, and deployment views.

Render the diagrams via VS Code Markdown preview, [mermaid.live](https://mermaid.live), or any Mermaid-compatible renderer if you need PNG/SVG exports.

## Troubleshooting

- **`Connection string 'TicketVendorDB' is missing`** – ensure the entry exists in `TicketingSystem/UI/App.config` and that the `App.config` is copied to `UI.exe.config` on build.
- **`Login failed or database not found`** – verify the SQL Server instance name and confirm `TicketVendorDB` was created by `TicketVendorDBquery.sql`.
- **Seed data missing** – re-run `TicketVendorDBquery.sql` or insert rows into `Destinations` so fares appear in the UI dropdowns.
