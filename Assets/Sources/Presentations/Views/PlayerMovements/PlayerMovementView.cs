using Sources.Controllers.Presenters.PlayerMovements;
using Sources.PresentationsInterfaces.Views.PlayerMovement;
using UnityEngine;

namespace Sources.Presentations.Views.PlayerMovements
{
    public class PlayerMovementView : PresentableView<PlayerMovementPresenter>,IPlayerMovementView
    {
        public void Move(Vector3 direction)
        {
            
        }
    }
}