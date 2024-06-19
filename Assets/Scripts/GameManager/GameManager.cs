using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        private IGameState _state;

        public void ChangeState(IGameState state)
        {
            _state = state;     
            state.HandleState();       
        }
        
        public void FinishGame()
        {
            Debug.Log("Game over!");
            Time.timeScale = 0;
        }
    }
}