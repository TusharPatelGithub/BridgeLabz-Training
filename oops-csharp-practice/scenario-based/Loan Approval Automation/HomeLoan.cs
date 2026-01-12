namespace LoanApprovalAutomation{
class HomeLoan : LoanApplication
{
    public HomeLoan(int term, double loanAmount)
        : base("Home Loan", term, 0.07, loanAmount) { }

    public override bool ApproveLoan(Applicant applicant)
    {
        bool eligible =
            applicant.GetCreditScore() >= 700 &&
            applicant.GetIncome() >= 50000;

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