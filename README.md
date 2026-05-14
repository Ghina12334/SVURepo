# Library Management System

This console application models a small library catalog with books, magazines, and DVDs. It demonstrates core object-oriented design for the Syrian Virtual University course **TIC_IPG203_S25**: abstract contracts and base types, subtype polymorphism, encapsulated state, classic .NET events backed by a custom delegate, and static validation plus a type-level instance counter.

## How to run

- **.NET CLI:** from the `LibraryManagementSystem` project folder, run:

  ```bash
  dotnet run
  ```

- **Visual Studio 2022:** open `LibraryManagementSystem.sln`, set the startup project to **LibraryManagementSystem**, and press **F5** (or **Ctrl+F5** for run without debugging).

Target framework: **.NET 8.0** (`net8.0`), with nullable reference types and implicit usings enabled.

## OOP principles in this solution

| Principle     | File / class |
|---------------|--------------|
| Abstraction   | `ILibraryItem`, `LibraryItem` (abstract) |
| Inheritance   | `Book`, `Magazine`, `DVD` : `LibraryItem` |
| Polymorphism  | `Library.DisplayAllItems()` |
| Encapsulation | `LibraryItem` (private fields; immutable `UniqueId`; loan state via internal `MarkBorrowed` / `MarkReturned`) |
| Delegates     | `ItemBorrowedHandler` (`Delegates/LibraryDelegates.cs`) |
| Events        | `Library.OnItemBorrowed`, `Library.OnItemReturned` |
| Static        | `Validator` class; `LibraryItem.TotalItemsCreated` |

**Validation style:** `Validator.IsValidTitle`, `IsValidId`, `IsValidYear`, and `IsValidPageCount` return **`bool`**. `LibraryItem` (and `Book` for page count) **throws** `ArgumentException` with a clear message when validation fails, as required for constructor enforcement.

## Project layout

```
LibraryManagementSystem/
├── Interfaces/ILibraryItem.cs
├── Abstracts/LibraryItem.cs
├── Models/Book.cs, Magazine.cs, DVD.cs
├── Delegates/LibraryDelegates.cs
├── Services/Library.cs, Validator.cs
├── Program.cs
└── README.md
```
