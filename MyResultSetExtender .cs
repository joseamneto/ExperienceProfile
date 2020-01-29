
using Sitecore.Cintel.Client.Transformers;
using System.Data;

namespace Project.Pipelines
{

    public class MyResultSetExtender : ResultSetExtender
    {
        public MyResultSetExtender() : this(
            Sitecore.Cintel.Client.ClientFactory.Instance.GetResultSetHelper(),
            new MyTimeConverter(Sitecore.Cintel.Client.ClientFactory.Instance.GetRepository(), Sitecore.Cintel.Client.ClientFactory.Instance.GetContextUtil()),
            Sitecore.Cintel.Client.ClientFactory.Instance.GetTextConverter())
        {
        }

        public MyResultSetExtender(
          Sitecore.Cintel.Client.Transformers.ResultSetHelper resultSetHelper, TimeConverter timeConverter,
          Sitecore.Cintel.Client.Transformers.TextConverter textConverter)
          : base(resultSetHelper, CustomClientFactory.Instance.GetTimeConverter(), textConverter)
        {
        }
    }
}