using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _gameOverScore = -100;

    public int Score { get; private set; }

    [Inject(Id = "Score")]
    private GameObject _scoreGO;

    [Inject(Id = "Result")]
    private GameObject _resultGO;

    [Inject(Id = "GameOverMenu")]
    private GameObject _gameOverMenu;

    [Inject]
    private PauseManager _pauseManager;

    [Inject]
    private MusicManager _musicManager;

    private TMP_Text _scoreValue;
    private TMP_Text _resultValue;
    private Dictionary<CubeNumber, int> _scoreRewardTable;


    private void Start()
    {
        _scoreRewardTable = new Dictionary<CubeNumber, int>
        {
            { CubeNumber.Two, 20},
            { CubeNumber.Four, 30 },
            { CubeNumber.Eight, 40 },
            { CubeNumber.Sixteen, 50 },
            { CubeNumber.ThirtyTwo, 60 },
            { CubeNumber.SixtyFour, 70 },
            { CubeNumber.OneTwentyEight, 80 }
        };
        _scoreValue = _scoreGO.GetComponent<TMP_Text>();
        _resultValue = _resultGO.GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        CubeCollision.OnCubeMerge += CubeMergeReward;
    }

    private void OnDisable()
    {
        CubeCollision.OnCubeMerge -= CubeMergeReward;
    }

    public void ChangeScore(int value)
    {
        Score += value;
        _scoreValue.text = $"Score: {Score}";

        string resultText = null;

        if (Score <= _gameOverScore)
        {
            _musicManager.PlayBooMusic();
            resultText = "You Lose";
        }
        else if (_scoreRewardTable.TryGetValue(CubeNumber.SixtyFour, out int scoreReward) && value >= scoreReward)
        {
            _musicManager.PlayHoorayMusic();
            resultText = $"You Score:\n{Score}";
        }

        if (!string.IsNullOrEmpty(resultText))
        {
            _pauseManager.PauseGame(true);
            _resultValue.text = resultText;
            _gameOverMenu.SetActive(true);
        }
    }

    private void CubeMergeReward(CubeNumber cubeType)
    {
        ChangeScore(_scoreRewardTable[cubeType]);
    }
}
