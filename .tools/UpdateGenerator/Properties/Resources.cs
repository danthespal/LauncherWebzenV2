using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Update.Maker.Properties
{
    [DebuggerNonUserCode]
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [CompilerGenerated]
    internal class Resources
    {
        private static ResourceManager resourceMan;
        private static CultureInfo resourceCulture;

        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (Update.Maker.Properties.Resources.resourceMan == null)
                    Update.Maker.Properties.Resources.resourceMan = new ResourceManager("Update.Maker.Properties.Resources", typeof (Update.Maker.Properties.Resources).Assembly);
                return Update.Maker.Properties.Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get => Update.Maker.Properties.Resources.resourceCulture;
            set => Update.Maker.Properties.Resources.resourceCulture = value;
        }
    }
}
