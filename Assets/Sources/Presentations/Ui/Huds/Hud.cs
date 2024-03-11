using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Forms.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Ui.Huds
{
    public class Hud : View
    {
        [Required][SerializeField] private HudFormView _hudForm;
        [Required][SerializeField] private PauseFormView _pauseForm;

        public HudFormView HudForm => _hudForm;
        public PauseFormView PauseForm => _pauseForm;
    }
}