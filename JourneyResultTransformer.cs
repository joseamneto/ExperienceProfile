using Project.Pipelines;
using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;
using Sitecore.Cintel.Commons;
using Sitecore.Cintel.Endpoint.Transfomers;
using Sitecore.Cintel.Reporting.Contact.JourneyOutcomeDetail;
using Sitecore.Diagnostics;
using System.Data;


namespace Project.Pipelines
{
    public class JourneyResultTransformer : IIntelResultTransformer, IResultTransformer<DataTable>
    {
        private readonly ResultSetExtender _extender;

        public JourneyResultTransformer()
        {
            this._extender = CustomClientFactory.Instance.GetResultSetExtender();
    }

        public JourneyResultTransformer(ResultSetExtender extender)
        {
            this._extender = extender;
        }

        public object Transform(ResultSet<DataTable> resultSet)
        {
            return (object)resultSet;
        }
    }
}
