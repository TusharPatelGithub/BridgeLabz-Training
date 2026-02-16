using System.ComponentModel.DataAnnotations;

class Book
{
    [Range(100,999)]
    public int BookId{get; set;}

    [Required]
    [RegularExpression(@"^[A-Za-z ]{3,}$",
    ErrorMessage="Title must contains only string and minimum 3 character")]
    public string Title{get; set;}

    [Required]
    [RegularExpression(@"^[A-Za-z ]{3,}$",
    ErrorMessage="Author must contains only string and minimum 3 charcter")]
    public string Author{get; set;}

    [Required]
    [RegularExpression(@"^\d{3}-\d{4}-\d{4}$",
    ErrorMessage = "Number must be in format 123-4567-8910")]
    public string ISBN{get; set;}

    [Required]
    public string Category{get; set;}

    [Range(0,int.MaxValue,
    ErrorMessage="Number must be greater than or equal to 0")]
    public int AvailaibleCopies{get; set;}

    public Book(int BookId,string Title,string Author,string ISBN, string Category,int AvailaibleCopies)
    {
        this.BookId=BookId;
        this.Title=Title;
        this.Author=Author;
        this.ISBN=ISBN;
        this.Category=Category;
        this.AvailaibleCopies=AvailaibleCopies;
    }
}