using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Enemies;
using Sources.Presentations.Ui.Images;
using Sources.PresentationsInterfaces.Ui.Images;
using Sources.PresentationsInterfaces.Views;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views
{
    public class HealthUi : PresentableView<HealthUiPresenter>, IHealthUi
    {
        [Required] [SerializeField] private ImageView _healthView;

        public IImageView HealthView => _healthView;
    }
}