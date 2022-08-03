using CrmEarlyBound;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using System;

namespace Odx.Dataverse.Demo.Plugins
{
    public class DemoPlugin : PluginBase
    {
        public DemoPlugin(string unsecureConfiguration, string secureConfiguration)
            : base(typeof(DemoPlugin))
        {

        }

        protected override void ExecuteCdsPlugin(ILocalPluginContext localPluginContext)
        {
            if (localPluginContext == null)
            {
                throw new ArgumentNullException(nameof(localPluginContext));
            }

            var context = localPluginContext.PluginExecutionContext;

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                var entity = ((Entity)context.InputParameters["Target"]).ToEntity<pg_demo>();

                if(entity != null)
                {
                    entity.pg_json = JsonConvert.SerializeObject(entity);
             
                }
            }      
        }
    }
}
