using Sources.App.Core;
using UnityEngine;

namespace Sources.Infrastructure.Factories.AppCore
{
    public class AppCoreFactory
    {
        //TODO беда с юзингами
        public App.Core.AppCore Create()
        {
            App.Core.AppCore appCore = new GameObject(nameof(App.Core.AppCore)).AddComponent<App.Core.AppCore>();

            return appCore;
        }
    }
}