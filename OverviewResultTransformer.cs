
using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;
using Sitecore.Cintel.Commons;
using Sitecore.Cintel.Endpoint.Transfomers;
using Sitecore.Cintel.Reporting.Contact.JourneyOutcomeDetail;
using Sitecore.Diagnostics;
using System.Data;

namespace Project.Pipelines
{
    public class OverviewResultTransformer : IIntelResultTransformer, IResultTransformer<DataTable>
    {
        private readonly ResultSetExtender extender;

        public OverviewResultTransformer()
        {
            this.extender = CustomClientFactory.Instance.GetResultSetExtender();
        }

        public OverviewResultTransformer(ResultSetExtender extender)
        {
            this.extender = extender;
        }

        public object Transform(ResultSet<DataTable> resultSet)
        {
            Assert.ArgumentNotNull((object)resultSet, nameof(resultSet));
            string sourceColumnName = "LatestVisitStartDateTime";
            this.extender.AddRecency(resultSet, sourceColumnName);
            this.extender.AddFormattedTime(resultSet, sourceColumnName, "FormattedTime", "T");
            this.extender.AddFormattedTime(resultSet, sourceColumnName, "FormattedDate", "MM dd yyyy");
            this.extender.AddDuration(resultSet, "AverageVisitDuration", "AverageVisit");
            this.extender.AddLocationDisplayName(resultSet, "LatestVisitCityDisplayName", "LatestVisitRegionDisplayName", "LatestVisitCountryDisplayName", "LatestVisitLocationDisplayName");
            return (object)resultSet;
        }
    }
}