namespace LoanApprovalAutomation{
class AutoLoan : LoanApplication
{
    public AutoLoan(int term, double loanAmount)
        : base("Auto Loan", term, 0.09, loanAmount) { }

    public override bool ApproveLoan(Applicant applicant)
    {
        bool eligible = applicant.GetCreditScore() >= 650;
        SetApprovalStatus(eligible);
        return eligible;
    }

    public override double CalculateEMI()
    {
        double r = interestRate / 12;
        int n = term;

        return (loanAmount * r * Math.Pow(1 + r, n)) /
               (Math.Pow(1 + r, n) - 1);
    }
}
}
