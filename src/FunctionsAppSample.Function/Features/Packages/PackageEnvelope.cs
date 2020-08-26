using FunctionsAppSample.Function.Domain;

namespace FunctionsAppSample.Function.Features.Packages
{
    public class PackageEnvelope
    {
        public PackageEnvelope(Package package)
        {
            Package = package;
        }

        public Package Package { get; }
    }
}
