public class GetEmployerJobPostingLimitRequest
{
    public Guid EmployerId { get; set; }
}

public class GetEmployerJobPostingLimitResponse
{
    public Guid EmployerId { get; set; }
    public int LimitOfJobPosting { get; set; }
} 