using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.App.Core;
using Sources.ControllersInterfaces.Scenes;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Services.SceneLoaderServices;
using Sources.Infrastructure.Services.SceneServices;
using Sources.InfrastructureInterfaces.Services.SceneLoaderServices;
using Sources.Presentations.Ui.App;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.AppCore
{
    public class AppCoreFactory
    {
        //TODO беда с юзингами
        public App.Core.AppCore Create()
        {
            App.Core.AppCore appCore = new GameObject(nameof(App.Core.AppCore)).AddComponent<App.Core.AppCore>();

            CurtainView curtainView = Object.Instantiate(Resources.Load<CurtainView>("Ui/CurtainView"));
            
            ProjectContext projectContext = Object.FindObjectOfType<ProjectContext>();
            
            Dictionary<string, Func<object, SceneContext, UniTask<IScene>>> sceneStates =
                new Dictionary<string, Func<object, SceneContext, UniTask<IScene>>>();
            SceneService sceneService = new SceneService(sceneStates);
            projectContext.Container.BindInterfacesAndSelfTo<SceneService>().FromInstance(sceneService).AsSingle();

            sceneStates["Gameplay"] = (payload, sceneContext) =>
                sceneContext.Container.Resolve<GameplaySceneFactory>().Create(payload);
            
            sceneService.AddBeforeSceneChangeHandler(async sceneName => 
                await projectContext.Container.Resolve<ISceneLoaderService>().LoadAsync(sceneName));
            
            appCore.Construct(sceneService);
            
            return appCore;
        }
    }
}