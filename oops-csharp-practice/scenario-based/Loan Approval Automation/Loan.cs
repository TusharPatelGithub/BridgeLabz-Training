using System;
namespace LoanApprovalAutomation{

class Loan
{
    static void Main()
    {
        Applicant applicant = new Applicant(
            "Tushar Patel",
            720,
            60000,
            500000
        );

        LoanApplication loan = new HomeLoan(240, applicant.GetLoanAmount());

        if (loan.ApproveLoan(applicant))
        {
            Console.WriteLine("Loan Approved!");
            Console.WriteLine("Monthly EMI: " + loan.CalculateEMI());
        }
        else
        {
            Console.WriteLine("Loan Rejected!");
        }
    }
}
}