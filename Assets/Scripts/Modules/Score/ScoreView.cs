using Infrastructure.Services;
using TMPro;
using UnityEngine;

namespace Modules.Score
{
    public class ScoreView : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;

        private ScoreService _scoreService;

        private void Awake()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
        }

        private void OnEnable() => 
            _scoreService.OnScoreChanged += UpdateScore;

        private void OnDisable() => 
            _scoreService.OnScoreChanged -= UpdateScore;

        private void UpdateScore() => 
            _scoreText.text = _scoreService.Score.ToString();
    }
}