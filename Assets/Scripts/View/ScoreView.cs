using Model.Services;
using Model.Services.ServiceLocator;
using TMPro;
using UnityEngine;

namespace View
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