using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;

namespace VisualStudioCppExtensions
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true )]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid( PackageGuidString )]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideAutoLoad( VSConstants.UICONTEXT.SolutionExistsAndFullyLoaded_string, PackageAutoLoadFlags.BackgroundLoad )]
    public sealed class GenerateFilterPackage : AsyncPackage
    {
        public const string PackageGuidString = "99d03761-6200-41ad-b2a1-638ae9e780e5";

        public GenerateFilterPackage() {}

        protected override async System.Threading.Tasks.Task InitializeAsync( CancellationToken cancellationToken, IProgress<ServiceProgressData> progress )
        {
            GenerateFilter.Initialize( this );
            await JoinableTaskFactory.SwitchToMainThreadAsync( cancellationToken );
        }
    }
}
