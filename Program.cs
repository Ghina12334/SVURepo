using LibraryManagementSystem.Abstracts;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem;

/// <summary>
/// Entry point: exercises abstraction, inheritance, polymorphism, encapsulation, events, and static members.
/// </summary>
internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("=== Library Management System — OOP demonstration ===");
        Console.WriteLine();

        var library = new Library();

        library.OnItemBorrowed += (_, message) =>
        {
            Console.WriteLine($"[EVENT: Borrowed] {message}");
        };

        library.OnItemReturned += (_, message) =>
        {
            Console.WriteLine($"[EVENT: Returned] {message}");
        };

        var book1 = new Book("Clean Code", "B001", 2008, "Robert C. Martin", 464, "Software");
        var book2 = new Book("Design Patterns", "B002", 1994, "Gang of Four", 395, "Software");
        var mag1 = new Magazine("National Geographic", "M001", 2023, 245, "NatGeo Partners");
        var mag2 = new Magazine("Scientific American", "M002", 2022, 327, "Springer Nature");
        var dvd1 = new DVD("Inception", "D001", 2010, "Christopher Nolan", 148);
        var dvd2 = new DVD("The Matrix", "D002", 1999, "Wachowskis", 136);

        library.AddItem(book1);
        library.AddItem(book2);
        library.AddItem(mag1);
        library.AddItem(mag2);
        library.AddItem(dvd1);
        library.AddItem(dvd2);

        library.DisplayAllItems();

        Console.WriteLine("--- Borrow (events should fire) ---");
        library.BorrowItem("B001");
        library.BorrowItem("D001");
        Console.WriteLine();

        Console.WriteLine("--- Return with late fees (type-specific rules) ---");
        Console.WriteLine("Returning Book B001, 5 days late (expected fee: $2.50 at $0.50/day)...");
        library.ReturnItem("B001", daysLate: 5);

        Console.WriteLine("Returning DVD D001, 10 days late (expected fee: $13.00 = 7×$1 + 3×$2)...");
        library.ReturnItem("D001", daysLate: 10);
        Console.WriteLine();

        Console.WriteLine("--- Validator: invalid publication year ---");
        try
        {
            _ = new Book("Bad Year Book", "B999", 3000, "No One", 100, "Fiction");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Caught expected error: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("--- Encapsulation note (UniqueId is immutable after construction) ---");
        Console.WriteLine("See commented line in Program.cs: assigning to UniqueId does not compile.");
        // book1.UniqueId = "HACK"; // Compile error — UniqueId is read-only (encapsulation)

        Console.WriteLine();
        Console.WriteLine($"Total LibraryItem instances created: {LibraryItem.TotalItemsCreated}");
        Console.WriteLine("=== Demo complete ===");
    }
}
