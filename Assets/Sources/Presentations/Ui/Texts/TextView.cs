using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.Ui.Texts;
using TMPro;
using UnityEngine;

namespace Sources.Presentations.Ui.Texts
{
    public class TextView : View, ITextView
    {
        [Required] [SerializeField] private TMP_Text _text;

        public void Set(string text) =>
            _text.text = text;
    }
}