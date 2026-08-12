using System.Net;
using Xunit;
using static RestAssured.Dsl;

namespace ContactsApp.ApiTests
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class ContactsCrudTests
    {
        private const string BaseUrl = "http://localhost:5030";

        [Fact]
        public void GetAllContacts_ReturnsOk()
        {
            Given()
                .When()
                .Get($"{BaseUrl}/contacts")
                .Then()
                .StatusCode(200);
        }

        [Fact]
        public void GetContactById_WhenNotFound_Returns404()
        {
            Given()
                .When()
                .Get($"{BaseUrl}/contacts/999999")
                .Then()
                .StatusCode(404);
        }

        [Fact]
        public void CreateContact_ThenGetById_ReturnsCreatedContact()
        {
            var newContact = new Contact
            {
                Name = "Test User",
                Phone = "9876543210",
                Email = "test.user@example.com",
                Address = "123 Test Street"
            };

            Contact created = Given()
                .Body(newContact)
                .When()
                .Post($"{BaseUrl}/contacts")
                .Then()
                .StatusCode(201)
                .And()
                .DeserializeTo<Contact>();

            Assert.True(created.Id > 0);
            Assert.Equal(newContact.Name, created.Name);

            Given()
                .When()
                .Get($"{BaseUrl}/contacts/{created.Id}")
                .Then()
                .StatusCode(200);

            // cleanup
            Given()
                .When()
                .Delete($"{BaseUrl}/contacts/{created.Id}")
                .Then()
                .StatusCode(200);
        }

        [Fact]
        public void UpdateContact_WhenExists_ReturnsUpdatedContact()
        {
            var newContact = new Contact
            {
                Name = "Update Me",
                Phone = "1111111111",
                Email = "update.me@example.com",
                Address = "Old Address"
            };

            Contact created = Given()
                .Body(newContact)
                .When()
                .Post($"{BaseUrl}/contacts")
                .Then()
                .StatusCode(201)
                .And()
                .DeserializeTo<Contact>();

            var updatedContact = new Contact
            {
                Name = "Updated Name",
                Phone = "2222222222",
                Email = "updated@example.com",
                Address = "New Address"
            };

            Contact result = Given()
                .Body(updatedContact)
                .When()
                .Put($"{BaseUrl}/contacts/{created.Id}")
                .Then()
                .StatusCode(200)
                .And()
                .DeserializeTo<Contact>();

            Assert.Equal("Updated Name", result.Name);
            Assert.Equal("New Address", result.Address);

            // cleanup
            Given()
                .When()
                .Delete($"{BaseUrl}/contacts/{created.Id}")
                .Then()
                .StatusCode(200);
        }

        [Fact]
        public void UpdateContact_WhenNotFound_Returns404()
        {
            var updatedContact = new Contact
            {
                Name = "Ghost",
                Phone = "0000000000",
                Email = "ghost@example.com",
                Address = "Nowhere"
            };

            Given()
                .Body(updatedContact)
                .When()
                .Put($"{BaseUrl}/contacts/999999")
                .Then()
                .StatusCode(404);
        }

        [Fact]
        public void DeleteContact_WhenExists_ReturnsOk()
        {
            var newContact = new Contact
            {
                Name = "Delete Me",
                Phone = "3333333333",
                Email = "delete.me@example.com",
                Address = "Temp Address"
            };

            Contact created = Given()
                .Body(newContact)
                .When()
                .Post($"{BaseUrl}/contacts")
                .Then()
                .StatusCode(201)
                .And()
                .DeserializeTo<Contact>();

            Given()
                .When()
                .Delete($"{BaseUrl}/contacts/{created.Id}")
                .Then()
                .StatusCode(200);
        }

        [Fact]
        public void DeleteContact_WhenNotFound_Returns404()
        {
            Given()
                .When()
                .Delete($"{BaseUrl}/contacts/999999")
                .Then()
                .StatusCode(404);
        }
    }
}
