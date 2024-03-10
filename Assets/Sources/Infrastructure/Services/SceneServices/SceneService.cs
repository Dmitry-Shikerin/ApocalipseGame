using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Unity.VisualScripting;

namespace Sources.Infrastructure.Services.SceneServices
{
    public class SceneService : ISceneService
    {
        private readonly List<Func<string, UniTask>> _enteringHandlers = new List<Func<string, UniTask>>();
        private readonly List<UniTask> _exitingHandlers = new List<UniTask>();

        private readonly StateMachine _stateMachine;
        private readonly IReadOnlyDictionary<string, Func<object,>>
        
        public UniTask ChangeSceneAsync(string sceneName, object payload)
        {
            
        }

        public void Disable()
        {
        }
    }
}