using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Repository.Context;
using Repository.Interfaces;
using Repository.Services;
using Business.Interfaces;
using Business.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAddressBookRepository, AddressBookRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAddressBookService, AddressBookService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ===================== AddressBooks CRUD =====================

app.MapGet("/addressbooks", async (IAddressBookService service) =>
    await service.GetAllAsync());

app.MapGet("/addressbooks/{id}", async (int id, IAddressBookService service) =>
    await service.GetByIdAsync(id)
        is AddressBookEntity book
            ? Results.Ok(book)
            : Results.NotFound($"Address Book with Id {id} not found."));

app.MapPost("/addressbooks", async (AddressBookEntity book, IAddressBookService service) =>
{
    var created = await service.CreateAsync(book);
    return Results.Created($"/addressbooks/{created.Id}", created);
});

app.MapPut("/addressbooks/{id}", async (int id, AddressBookEntity updated, IAddressBookService service) =>
{
    var book = await service.UpdateAsync(id, updated);
    return book is not null
        ? Results.Ok(book)
        : Results.NotFound($"Address Book with Id {id} not found.");
});

app.MapDelete("/addressbooks/{id}", async (int id, IAddressBookService service) =>
{
    var deleted = await service.DeleteAsync(id);
    return deleted
        ? Results.Ok($"Address Book with Id {id} deleted.")
        : Results.NotFound($"Address Book with Id {id} not found.");
});

// ===================== Contacts CRUD =====================

app.MapGet("/contacts", async (IContactService service) =>
    await service.GetAllAsync());

app.MapGet("/contacts/{id}", async (int id, IContactService service) =>
    await service.GetByIdAsync(id)
        is AddressBookModel contact
            ? Results.Ok(contact)
            : Results.NotFound($"Contact with Id {id} not found."));

app.MapGet("/addressbooks/{addressBookId}/contacts", async (int addressBookId, IContactService service) =>
    await service.GetByAddressBookIdAsync(addressBookId));

app.MapPost("/contacts", async (AddressBookModel contact, IContactService service) =>
{
    var (created, error) = await service.CreateAsync(contact);
    if (error is not null) return Results.BadRequest(error);
    return Results.Created($"/contacts/{created!.Id}", created);
});

app.MapPut("/contacts/{id}", async (int id, AddressBookModel updated, IContactService service) =>
{
    var contact = await service.UpdateAsync(id, updated);
    return contact is not null
        ? Results.Ok(contact)
        : Results.NotFound($"Contact with Id {id} not found.");
});

app.MapDelete("/contacts/{id}", async (int id, IContactService service) =>
{
    var deleted = await service.DeleteAsync(id);
    return deleted
        ? Results.Ok($"Contact with Id {id} deleted.")
        : Results.NotFound($"Contact with Id {id} not found.");
});

app.Run();
