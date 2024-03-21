using Sources.DomainInterfaces.Items.Weapons.Info;
using UnityEngine;

namespace Sources.Domain.Weapons.Info
{
    [CreateAssetMenu(fileName = "WeaponInfo", menuName = "Configs/WeaponInfo", order = 51)]
    public class WeaponInfo : ScriptableObject, IWeaponInfo
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _attackSpeed;


        public int Damage => _damage;
        public float AttackSpeed => _attackSpeed;
    }
}