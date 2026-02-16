using System.ComponentModel.DataAnnotations;

class Member
{
    [Range(10,99)]
    public int MemberId{get; set;}

    [Required]
    [RegularExpression(@"^[A-Za-z ]+$",
    ErrorMessage="Must be character word")]
    public string MemberName{get; set;}

    [Required]
    [EmailAddress(ErrorMessage ="Invalid error message: ")]
    public string Email {get; set;}

    [Required]
    [RegularExpression(@"^[6-9]\d{9}$",
    ErrorMessage ="Enter the 10 digit mobile number: ")]
    public string Number{get; set;}
    
    public Member(int MemberId,string MemberName,string Email,string Number)
    {
        this.MemberId=MemberId;
        this.MemberName=MemberName;
        this.Email=Email;
        this.Number=Number;
    }
}