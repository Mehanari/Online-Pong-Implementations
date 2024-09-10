using Zenject;

namespace ScoreLogic
{
    public class Score
    {
        private readonly ScoreText _playerScoreText;
        private readonly ScoreText _enemyScoreText;

        public int PlayerScore { get; private set; }

        public int EnemyScore { get; private set; }

        [Inject]
        public Score([Inject(Id = ScoreTextType.Player)] ScoreText playerScoreText, 
            [Inject(Id = ScoreTextType.Enemy)] ScoreText enemyScoreText)
        {
            _playerScoreText = playerScoreText;
            _enemyScoreText = enemyScoreText;
        }
    
        public void IncrementPlayerScore()
        {
            PlayerScore++;
            _playerScoreText.SetScore(PlayerScore);
        }
    
        public void IncrementEnemyScore()
        {
            EnemyScore++;
            _enemyScoreText.SetScore(EnemyScore);
        }
    }
}