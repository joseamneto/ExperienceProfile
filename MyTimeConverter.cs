using Sitecore.Cintel.Client.Transformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Pipelines
{
    public class MyTimeConverter : TimeConverter
    {
        public MyTimeConverter(Sitecore.Cintel.Client.Repository repository, Sitecore.Cintel.Client.ContextUtil contextUtil)
            : base(repository, contextUtil)
        {
        }

        public override string FormatDateTime(DateTime time)
        {
             return base.FormatDateTime(time, "MM.dd.yyyy HH:mm:ss");
        }
    }
}