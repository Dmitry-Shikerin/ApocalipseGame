using UnityEngine;

namespace Sources.PresentationsInterfaces.Views
{
    public interface IView
    {
        void Hide();
        void Show();
        void SetParent(Transform parentTransform);
        void SetTransformPosition(Transform parentTransform);
        void Destroy();
    }
}