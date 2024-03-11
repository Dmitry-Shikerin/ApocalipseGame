using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Ui.Buttons;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Sources.Presentations.Ui.Buttons
{
    public class ButtonView : View, IButtonView
    {
        [Required][SerializeField] private Button _button;

        public void AddListener(UnityAction action) =>
            _button.onClick.AddListener(action);

        public void RemoveListener(UnityAction action) =>
            _button.onClick.AddListener(action);
    }
}