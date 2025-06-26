# ATM Banking System

## Project Overview
Developed a *console-based ATM system* for managing user accounts, transactions, and dynamic customer statuses. The system supports:
- *Deposits*
- *Withdrawals with tiered fees*
- *Balance inquiries*
- *Fund transfers*
- *Automatic monthly interest bonuses*

Users can *automatically transition* between **Standard**, **Premium**, and **Platinum** statuses based on their withdrawal activity over time.

## Design Patterns Used
- **Command Pattern** – Handles transaction encapsulation and command execution.
- **Observer Pattern** – Provides real-time bank updates for executed commands.
- **Singleton Pattern** – Centralizes transaction logging.
- **Decorator Pattern** – Adds monthly interest bonuses to accounts.
- **Strategy Pattern** – Calculates dynamic fees based on withdrawal amounts.
- **State Pattern** – Manages user status transitions based on withdrawal history.
- **Factory Pattern** – Abstracts user creation.
