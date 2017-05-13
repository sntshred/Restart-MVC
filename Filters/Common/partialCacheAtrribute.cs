using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;


namespace Filters.Common
{
    public class partialCacheAtrribute:OutputCacheAttribute
    {

        public partialCacheAtrribute(string cacheprofilename)
        {
            OutputCacheSettingsSection outputCacheSettingsSection = (OutputCacheSettingsSection)WebConfigurationManager.GetSection("system.web/caching/outputCacheSettings");
            OutputCacheProfile outputCacheProfile = outputCacheSettingsSection.OutputCacheProfiles[cacheprofilename];
            Duration = outputCacheProfile.Duration;
            VaryByParam = outputCacheProfile.VaryByParam;
        }

    }
}