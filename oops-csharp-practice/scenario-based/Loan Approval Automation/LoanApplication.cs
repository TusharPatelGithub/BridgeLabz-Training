namespace LoanApprovalAutomation{
abstract class LoanApplication : IApprovable
{
    protected string loanType;
    protected int term; // months
    protected double interestRate;
    protected double loanAmount;

    private bool approved; // internal control only

    protected LoanApplication(string loanType, int term, double interestRate, double loanAmount)
    {
        this.loanType = loanType;
        this.term = term;
        this.interestRate = interestRate;
        this.loanAmount = loanAmount;
    }

    protected void SetApprovalStatus(bool status)
    {
        approved = status;
    }

    public bool IsApproved()
    {
        return approved;
    }

    public abstract bool ApproveLoan(Applicant applicant);
    public abstract double CalculateEMI();
}
}