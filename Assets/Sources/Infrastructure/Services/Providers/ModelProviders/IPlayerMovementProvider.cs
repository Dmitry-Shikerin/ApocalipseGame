using UnityEngine;

namespace Sources.Infrastructure.Services.Providers.ModelProviders
{
    public interface IPlayerMovementProvider
    {
        public Vector3 Position { get; }
    }
}