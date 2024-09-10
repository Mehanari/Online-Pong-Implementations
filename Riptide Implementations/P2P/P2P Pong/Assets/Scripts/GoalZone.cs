using ScoreLogic;
using UnityEngine;
using Zenject;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private GoalZoneType goalZoneType;
    
    private const string BallTag = "Ball";
    
    private BallThrower _ballThrower;
    private GameOver _gameOver;
    private Score _score;
    
    [Inject]
    private void Init(BallThrower ballThrower, Score score, GameOver gameOver)
    {
        _ballThrower = ballThrower;
        _score = score;
        _gameOver = gameOver;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(BallTag)) return;
        if (goalZoneType == GoalZoneType.Player)
        {
            _score.IncrementEnemyScore();
        }
        else
        {
            _score.IncrementPlayerScore();
        }

        if (_gameOver.IsGameOver()) return;
        _ballThrower.ThrowBall();
    }
}

public enum GoalZoneType
{
    Player,
    Enemy
}