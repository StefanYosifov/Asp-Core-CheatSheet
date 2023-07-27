namespace _Project_CheatSheet.Features.Statistics.Interfaces
{
    using Models;

    public interface IStatisticsService
    {
        public StatisticsModel GetAllStatistics();

        public StatisticsCourseModel GetStatisticsCourse();
    }
}