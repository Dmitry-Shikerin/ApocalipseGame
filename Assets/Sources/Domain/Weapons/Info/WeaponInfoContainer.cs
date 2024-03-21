using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Domain.Weapons.Info
{
    [CreateAssetMenu(
        fileName = "WeaponInfoContainer", 
        menuName = "Configs/WeaponInfoContainer", 
        order = 51)]
    public class WeaponInfoContainer : ScriptableObject
    {
        [Required][SerializeField] private WeaponInfo _axeWeaponInfo;
        
        public WeaponInfo AxeWeaponInfo => _axeWeaponInfo;
    }
}