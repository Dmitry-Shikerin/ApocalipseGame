using Sources.App.Core;
using Sources.Infrastructure.Factories.AppCore;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    private AppCore _appCore;

    private void Awake()
    {
        _appCore = FindObjectOfType<AppCore>() ?? new AppCoreFactory().Create();
    }
}
