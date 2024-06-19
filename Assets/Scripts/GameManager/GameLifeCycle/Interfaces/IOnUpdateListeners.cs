namespace ShootEmUp
{
    public interface IOnUpdateListener : IGameStateListener
    {
        void OnUpdate();
    }
    public interface IOnFixedUpdateListener : IGameStateListener
    {
        void OnFixedUpdate();
    }
}