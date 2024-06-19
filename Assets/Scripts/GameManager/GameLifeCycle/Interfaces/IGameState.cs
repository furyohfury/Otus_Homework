public interface IGameState
{
    void HandleState(IEnumerable<IGameStateListerner> listeners);
}