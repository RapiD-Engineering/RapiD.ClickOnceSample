using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapiD.ClickOnceSample
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string publishedVersion;

        public MainViewModel()
        {
            publishedVersion = GetDeploymentVersion();
        }

        public string GetDeploymentVersion()
        {
            //https://learn.microsoft.com/en-us/visualstudio/deployment/access-clickonce-deployment-properties-dotnet?view=vs-2022

            return Environment.GetEnvironmentVariable("ClickOnce_CurrentVersion");

        }
    }
}
