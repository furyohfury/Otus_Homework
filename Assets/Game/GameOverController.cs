namespace Game
{
    public sealed class GameOverController : IInitializable, IDisposable
    {
        private GamePipelineRunner _gamePipelineRunner;
        private GameObject _gameOverScreen;
        private TMP_Text _playerText;

        public GameOverController(GamePipelineRunner gamePipelineRunner, GameObject gameOverScreen, TMP_Text playerText)
        {
            _gamePipelineRunner = gamePipelineRunner;
            _gameOverScreen = gameOverScreen;
            _playerText = playerText;
        }

        public void Initialize()
        {
            _gamePipelineRunner.OnNoHeroesLeft += GameOver;
        }

        public void GameOver(Player player)
        {
            _gameOverScreen.SetActive(true);
            _playerText.text = $"{player.ToString()} won!";
        }

        public void Dispose()
        {
            _gamePipelineRunner -= GameOver;
        }
    }
}