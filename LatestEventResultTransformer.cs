
using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;
using Sitecore.Cintel.Commons;
using Sitecore.Cintel.Endpoint.Transfomers;
using Sitecore.Cintel.Reporting.Contact.JourneyOutcomeDetail;
using Sitecore.Diagnostics;
using System.Data;

namespace Project.Pipelines
{
    public class LatestEventResultTransformer : IIntelResultTransformer, IResultTransformer<DataTable>
    {
        private readonly ResultSetExtender extender;

        public LatestEventResultTransformer()
        {
            this.extender = CustomClientFactory.Instance.GetResultSetExtender();
        }

        public LatestEventResultTransformer(ResultSetExtender extender)
        {
            this.extender = extender;
        }

        public object Transform(ResultSet<DataTable> resultSet)
        {
            Assert.ArgumentNotNull((object)resultSet, nameof(resultSet));
            this.extender.AddTimeWithRecency(resultSet, "EventDateTime");
            this.extender.AddLocationDisplayName(resultSet, "LatestVisitCityDisplayName", "LatestVisitRegionDisplayName", "LatestVisitCountryDisplayName", "LatestVisitLocationDisplayName");
            return (object)resultSet;
        }
    }
}