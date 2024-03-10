using UnityEngine;

namespace Sources.Domain.PlayerMovement
{
    public class PlayerMovement : ObservableModel
    {
        private Vector3 _direction;

        public Vector3 Direction
        {
            get => _direction;
            set => SetField(ref _direction, value);
        }
    }
}