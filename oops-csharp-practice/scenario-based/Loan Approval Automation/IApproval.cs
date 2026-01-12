namespace LoanApprovalAutomation{
interface IApprovable
{
    bool ApproveLoan(Applicant applicant);
    double CalculateEMI();
}
}