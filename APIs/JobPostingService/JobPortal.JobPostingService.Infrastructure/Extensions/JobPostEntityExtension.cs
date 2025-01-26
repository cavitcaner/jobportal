using JobPortal.JobPostingService.Application.DTOs.Elasticsearch;

public static class JobPostEntityExtension
{
    public static void CalculateJobPoint(this JobPostElasticModel entity, List<string> hateWordList)
    {
        double score = 5.0;
        if (string.IsNullOrEmpty(entity.WorkingMethod))
            score -= 1.0;
        if (string.IsNullOrEmpty(entity.Position))
            score -= 1.0;

        if (entity.Benefits == null || !entity.Benefits.Any())
            score -= 1.0;

        if (!string.IsNullOrEmpty(entity.Description) && hateWordList.Any(word => entity.Description.Contains(word)))
            score -= 2.0;

        entity.JobPoint = (short)Math.Max(0, score);
    }
}