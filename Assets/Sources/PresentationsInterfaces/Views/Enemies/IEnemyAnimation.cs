namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyAnimation
    {
        void PlayIdle();
        void PlayMove();
        void PlayAttack();
        void PlayTakeDamage();
        void PlayDie();
    }
}