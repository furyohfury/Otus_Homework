namespace GameLifeCycle
{
    public interface IOnUpdateListener : IGameStateListener
    {
        void OnUpdate(float deltaTime);
    }
    public interface IOnFixedUpdateListener : IGameStateListener
    {
        void OnFixedUpdate(float deltaTime);
    }
}