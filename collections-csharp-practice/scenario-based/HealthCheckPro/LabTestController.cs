//simulates REST API endpoints for lab test operations
public class LabTestController
{
    [PublicAPI("Fetch all available lab tests")]
    public void GetLabTests() { }
    [RequiresAuth("Doctor")]
    public void AddLabTest() { }
    // Missing annotations – should be detected by HealthCheckPro
    public void DeleteLabTest() { }
}