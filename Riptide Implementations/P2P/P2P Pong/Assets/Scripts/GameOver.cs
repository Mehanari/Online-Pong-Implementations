using ScoreLogic;
using UnityEngine;
using Zenject;

public class GameOver
{
    private readonly GameObject _winMessage;
    private readonly GameObject _loseMessage;
    private readonly GameObject _gameOverScreen;
    private readonly Score _score;
    private readonly int _winScore;
    
    [Inject]
    private GameOver(Score score, 
        [Inject(Id = GameOverMessageType.Win)] GameObject winMessage, 
        [Inject(Id = GameOverMessageType.Lose)] GameObject loseMessage,
        [Inject(Id = "win_score")] int winScore,
        [Inject(Id = "game_over_screen")] GameObject gameOverScreen)
    {
        _score = score;
        _winMessage = winMessage;
        _loseMessage = loseMessage;
        _winScore = winScore;
        _gameOverScreen = gameOverScreen;
    }
    
    public bool IsGameOver()
    {
        if (_score.PlayerScore == _winScore)
        {
            _gameOverScreen.SetActive(true);
            _winMessage.SetActive(true);
            return true;
        }
        if (_score.EnemyScore == _winScore)
        {
            _gameOverScreen.SetActive(true);
            _loseMessage.SetActive(true);
            return true;
        }
        return false;
    }
}

public enum GameOverMessageType
{
    Win,
    Lose
}