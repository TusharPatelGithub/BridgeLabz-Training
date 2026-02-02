using System.Collections.Generic;
public class EngagementService
{
    //register creator
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }
    //count weeks where likes >= threshold
    public Dictionary<string, int> GetTopPostCounts(
        List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();
        foreach (var creator in records)
        {
            int count = 0;
            foreach (double likes in creator.WeeklyLikes)
            {
                if (likes >= likeThreshold)
                    count++;
            }
            if (count > 0)
                result.Add(creator.CreatorName, count);
        }
        return result;
    }
    //calculate average likes
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;
        foreach (var creator in CreatorStats.EngagementBoard)
        {
            foreach (double likes in creator.WeeklyLikes)
            {
                totalLikes += likes;
                totalWeeks++;
            }
        }
        if (totalWeeks == 0)
            return 0;
        return totalLikes / totalWeeks;
    }
}
