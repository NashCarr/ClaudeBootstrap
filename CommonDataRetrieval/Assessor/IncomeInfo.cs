using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class IncomeInfo : ModelBase
    {
        public IncomeInfo()
        {
            YtdIncome = 0;
            PointsBalance = 0;
            LastYearIncome = 0;
        }

        public decimal YtdIncome { get; set; }
        public short PointsBalance { get; set; }
        public decimal LastYearIncome { get; set; }
    }
}