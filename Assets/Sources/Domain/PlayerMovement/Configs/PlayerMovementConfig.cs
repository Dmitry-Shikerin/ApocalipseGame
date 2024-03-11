using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Domain.PlayerMovement.Configs
{
    [CreateAssetMenu(menuName = "Configs/Movement", fileName = "PlayerMovementConfig", order = 51)]
    public class PlayerMovementConfig : ScriptableObject
    {
        [Title("Movement")]
        [SerializeField][Range(0.5f, 1f)] private float _walkSpeed = 0.7f;
        [SerializeField][Range(0.01f, 0.06f)] private float _speedAddingMovementSpeed = 0.01f;

        [Title("Rotate")]
        [SerializeField][Range(0.01f, 0.06f)] private float _maxRadianceDeltaLookDirection = 0.05f;
        [SerializeField][Range(0.01f, 0.06f)] private float _maxMagnitudeDeltaLookDirection = 0.01f;

        public float WalkSpeed => _walkSpeed;
        public float SpeedAddingMovementSpeed => _speedAddingMovementSpeed;

        public float MaxRadianceDeltaLookDirection => _maxRadianceDeltaLookDirection;
        public float MAxMagnitudeDeltaLookDirection => _maxMagnitudeDeltaLookDirection;
    }
}