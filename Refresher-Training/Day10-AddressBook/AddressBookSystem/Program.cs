using Microsoft.EntityFrameworkCore;
using BridgeLabz.AddressBookSystem;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ===================== AddressBooks CRUD =====================

app.MapGet("/addressbooks", async (AppDbContext db) =>
    await db.AddressBooks.ToListAsync());

app.MapGet("/addressbooks/{id}", async (int id, AppDbContext db) =>
    await db.AddressBooks.FindAsync(id)
        is AddressBookEntity book
            ? Results.Ok(book)
            : Results.NotFound($"Address Book with Id {id} not found."));

app.MapPost("/addressbooks", async (AddressBookEntity book, AppDbContext db) =>
{
    db.AddressBooks.Add(book);
    await db.SaveChangesAsync();
    return Results.Created($"/addressbooks/{book.Id}", book);
});

app.MapPut("/addressbooks/{id}", async (int id, AddressBookEntity updated, AppDbContext db) =>
{
    var book = await db.AddressBooks.FindAsync(id);
    if (book is null) return Results.NotFound($"Address Book with Id {id} not found.");

    book.Name = updated.Name;
    await db.SaveChangesAsync();
    return Results.Ok(book);
});

app.MapDelete("/addressbooks/{id}", async (int id, AppDbContext db) =>
{
    var book = await db.AddressBooks.FindAsync(id);
    if (book is null) return Results.NotFound($"Address Book with Id {id} not found.");

    db.AddressBooks.Remove(book);
    await db.SaveChangesAsync();
    return Results.Ok($"Address Book with Id {id} deleted.");
});

// ===================== Contacts CRUD =====================

app.MapGet("/contacts", async (AppDbContext db) =>
    await db.Contacts.ToListAsync());

app.MapGet("/contacts/{id}", async (int id, AppDbContext db) =>
    await db.Contacts.FindAsync(id)
        is AddressBookModel contact
            ? Results.Ok(contact)
            : Results.NotFound($"Contact with Id {id} not found."));

app.MapGet("/addressbooks/{addressBookId}/contacts", async (int addressBookId, AppDbContext db) =>
    await db.Contacts.Where(c => c.AddressBookEntityId == addressBookId).ToListAsync());

app.MapPost("/contacts", async (AddressBookModel contact, AppDbContext db) =>
{
    var bookExists = await db.AddressBooks.AnyAsync(b => b.Id == contact.AddressBookEntityId);
    if (!bookExists)
        return Results.BadRequest($"Address Book with Id {contact.AddressBookEntityId} does not exist.");

    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
    return Results.Created($"/contacts/{contact.Id}", contact);
});

app.MapPut("/contacts/{id}", async (int id, AddressBookModel updated, AppDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound($"Contact with Id {id} not found.");

    contact.FirstName = updated.FirstName;
    contact.LastName = updated.LastName;
    contact.Address = updated.Address;
    contact.City = updated.City;
    contact.State = updated.State;
    contact.Zip = updated.Zip;
    contact.PhoneNumber = updated.PhoneNumber;
    contact.Email = updated.Email;

    await db.SaveChangesAsync();
    return Results.Ok(contact);
});

app.MapDelete("/contacts/{id}", async (int id, AppDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound($"Contact with Id {id} not found.");

    db.Contacts.Remove(contact);
    await db.SaveChangesAsync();
    return Results.Ok($"Contact with Id {id} deleted.");
});

app.Run();
