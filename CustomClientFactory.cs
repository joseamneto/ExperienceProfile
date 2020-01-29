using Sitecore.Cintel.Client;
using Sitecore.Cintel.Client.Transformers;

namespace Project.Pipelines
{
    public class CustomClientFactory : ClientFactory
    {
        public new static CustomClientFactory Instance { get; set; } = new CustomClientFactory();

        public new ResultSetExtender GetResultSetExtender()
        {
            return new ResultSetExtender(this.GetResultSetHelper(), this.GetTimeConverter(), this.GetTextConverter());
        }
        public new TimeConverter GetTimeConverter()
        {
            return new MyTimeConverter(this.GetRepository(), this.GetContextUtil());
        }
    }
}