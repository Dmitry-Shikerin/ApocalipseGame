using UnityEngine;

namespace Sources.Domain.PlayerMovement
{
    public class PlayerMovement : ObservableModel
    {
        private Vector3 _direction;
        private Vector3 _position;

        public Vector3 Direction
        {
            get => _direction;
            set => SetField(ref _direction, value);
        }

        public Vector3 Position
        {
            get => _position;
            set => SetField(ref _position, value);
        }
    }
}