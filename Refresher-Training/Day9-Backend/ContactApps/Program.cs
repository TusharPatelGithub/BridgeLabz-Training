using Microsoft.EntityFrameworkCore;
using ContactsApp.Data;
using ContactsApp.Models;

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

app.MapGet("/contacts", async (AppDbContext db) =>
    await db.Contacts.ToListAsync());

app.MapGet("/contacts/{id}", async (int id, AppDbContext db) =>
    await db.Contacts.FindAsync(id)
        is Contact contact
            ? Results.Ok(contact)
            : Results.NotFound($"Contact with Id {id} not found."));

app.MapPost("/contacts", async (Contact contact, AppDbContext db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
    return Results.Created($"/contacts/{contact.Id}", contact);
});

app.MapPut("/contacts/{id}", async (int id, Contact updatedContact, AppDbContext db) =>
{
    var contact = await db.Contacts.FindAsync(id);
    if (contact is null) return Results.NotFound($"Contact with Id {id} not found.");

    contact.Name = updatedContact.Name;
    contact.Phone = updatedContact.Phone;
    contact.Email = updatedContact.Email;
    contact.Address = updatedContact.Address;

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
