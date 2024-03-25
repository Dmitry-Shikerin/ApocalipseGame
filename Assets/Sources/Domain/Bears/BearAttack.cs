namespace Sources.Domain.Bears
{
    public class BearAttack
    {

        public float Damage { get; set; } = 2;
        
        public float Attack()
        {
            return Damage;
        }
    }
}