using PaddlesLogic;
using ScoreLogic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Header("Player paddle settings")]
    [SerializeField] private float paddleSpeed;
    [SerializeField] private float paddleMaxY;
    [SerializeField] private float paddleMinY;
    [SerializeField] private Paddle playerPaddle;
    [Space]
    [Header("Enemy paddle settings")]
    [SerializeField] private Paddle enemyPaddle;
    [Space]
    [Header("Ball settings")]
    [SerializeField] private BallThrower ballThrower;
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private Vector2 ballStartPosition = Vector2.zero;
    [SerializeField] private float ballStartVelocity = 10f;
    [SerializeField] private float maxAngleDeviation = 30f;
    [Space]
    [Header("Score settings")]
    [SerializeField] private ScoreText playerScoreText;
    [SerializeField] private ScoreText enemyScoreText;
    [SerializeField] private int winScore = 10;
    [Space]
    [Header("Game over panels")]
    [SerializeField] private GameObject winMessage;
    [SerializeField] private GameObject loseMessage;
    [SerializeField] private GameObject gameOverScreen;
    
    public override void InstallBindings()
    {
        Container.Bind<Paddle.PaddleParameters>().FromInstance(new Paddle.PaddleParameters
        {
            MaxY = paddleMaxY,
            MinY = paddleMinY,
            Speed = paddleSpeed
        });
        Container.Bind<Paddle>().WithId(PaddleType.Player).FromInstance(playerPaddle);
        Container.Bind<Paddle>().WithId(PaddleType.Enemy).FromInstance(enemyPaddle);
        Container.Bind<BallThrower>().FromInstance(ballThrower);
        Container.Bind<BallThrower.BallThrowerParameters>().FromInstance(new BallThrower.BallThrowerParameters
        {
            StartVelocity = ballStartVelocity,
            StartPosition = ballStartPosition,
            BallRigidbody = ballRigidbody,
            MaxAngleDeviation = maxAngleDeviation
        });
        Container.Bind<ScoreText>().WithId(ScoreTextType.Player).FromInstance(playerScoreText);
        Container.Bind<ScoreText>().WithId(ScoreTextType.Enemy).FromInstance(enemyScoreText);
        Container.Bind<Score>().AsSingle();
        Container.Bind<int>().WithId("win_score").FromInstance(winScore);
        Container.Bind<GameObject>().WithId(GameOverMessageType.Win).FromInstance(winMessage);
        Container.Bind<GameObject>().WithId(GameOverMessageType.Lose).FromInstance(loseMessage);
        Container.Bind<GameObject>().WithId("game_over_screen").FromInstance(gameOverScreen);
        Container.Bind<GameOver>().AsSingle();
    }
}