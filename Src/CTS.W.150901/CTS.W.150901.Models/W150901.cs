using CTS.Core.Domain.Helper;
using CTS.W._150901.Models.Resources.Strings;

namespace CTS.W._150901.Models
{
    /// <summary>
    /// W150901
    /// </summary>
    public class W150901
    {
        /// <summary>
        /// Áp dụng resource
        /// </summary>
        public static void ApplyResources() {
            // Load validation rules
            AppHelper.LoadValidationRules(typeof(W150901), "CTS.W._150901.Models.ValidationRules.xml");
            // Load name resource
            AppHelper.LoadNameResources(Names.ResourceManager);
            // Load name resource
            AppHelper.LoadFormatResources(Formats.ResourceManager);
        }
    }
}
