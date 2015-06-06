﻿using Windows.ApplicationModel.Resources;

namespace Nubank.Utils
{
    public class LocalizedResources
    {
        public static LocalizedResources Instance { get { return instance; } }
        private static LocalizedResources instance = new LocalizedResources();

        private ResourceLoader resourceLoader = new ResourceLoader();

        public string ArchivedAtFormatString { get { return resourceLoader.GetString("ArchivedAtFormatString"); } }
        public string UpdatedAtFormatString { get { return resourceLoader.GetString("UpdatedAtFormatString"); } }
        public string CreatedAtFormatString { get { return resourceLoader.GetString("CreatedAtFormatString"); } }
    }
}