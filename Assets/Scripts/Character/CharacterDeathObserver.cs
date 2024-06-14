namespace ShootEmUp
{
    public class CharacterDeathObserver : MonoBehaviour // redo w/ DI next homework
    {
        [SerializeField] private CharacterController _character;
        [SerializeField] private GameManager _gameManager;

        private void OnEnable()
        {
            _character.OnCharacterDeath += this.OnCharacterDeath;
        }
        private void OnDisable()
        {
            _character.OnCharacterDeath -= this.OnCharacterDeath;
        }

        public void OnCharacterDeath()
        {
            _gameManager.FinishGame();
        }
    }
}