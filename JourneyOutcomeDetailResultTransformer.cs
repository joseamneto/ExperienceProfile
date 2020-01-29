// Decompiled with JetBrains decompiler
// Type: Sitecore.Cintel.Client.Transformers.Contact.JourneyOutcomeDetailResultTransformer
// Assembly: Sitecore.Cintel.Client, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B605AFEA-BF47-494F-803A-41DC965DE653
// Assembly location: C:\Users\Win10\Desktop\Sitecore.Cintel.Client.dll

using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;
using Sitecore.Cintel.Commons;
using Sitecore.Cintel.Endpoint.Transfomers;
using Sitecore.Cintel.Reporting.Contact.JourneyOutcomeDetail;
using Sitecore.Diagnostics;
using System.Data;

namespace Project.Pipelines
{
    public class JourneyOutcomeDetailResultTransformer : IIntelResultTransformer, IResultTransformer<DataTable>
    {
        private readonly ResultSetExtender resultSetExtender;

        public JourneyOutcomeDetailResultTransformer()
        {
            this.resultSetExtender = CustomClientFactory.Instance.GetResultSetExtender();
        }

        public JourneyOutcomeDetailResultTransformer(ResultSetExtender extender)
        {
            this.resultSetExtender = extender;

        }

        public object Transform(ResultSet<DataTable> resultSet)
        {
            Assert.ArgumentNotNull((object)resultSet, nameof(resultSet));
            this.resultSetExtender.AddTimeWithRecency(resultSet, ((object)Schema.OutcomeDateTime).ToString());
            this.resultSetExtender.AddDuration(resultSet, ((object)Schema.InteractionDuration).ToString(), "TimeOnPage");
            return (object)resultSet;
        }


    }
}
