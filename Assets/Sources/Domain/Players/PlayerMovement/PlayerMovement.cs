using Sources.DomainInterfaces.PlayerAnimations;
using UnityEngine;

namespace Sources.Domain.PlayerMovement
{
    public class PlayerMovement : ObservableModel, IPlayerAnimationChanger
    {
        private Vector3 _direction;
        private Vector3 _position;
        private float _speed;
        private Vector3 _lookDirection;

        public Vector3 Direction
        {
            get => _direction;
            set => SetField(ref _direction, value);
        }

        public Vector3 LookDirection
        {
            get => _lookDirection;
            set => SetField(ref _lookDirection, value);
        }

        public Vector3 Position
        {
            get => _position;
            set => SetField(ref _position, value);
        }

        public float Speed
        {
            get => _speed;
            set => SetField(ref _speed, value);
        }
    }
}