using Model.Services;
using Model.Services.ServiceLocator;
using UnityEngine;

namespace Model
{
    public class ZoneAddingScore : MonoBehaviour
    {
        [SerializeField] private int addingScore;
        [SerializeField] private bool isOneSizePlatform;
        
        private ScoreService _scoreService;
        private bool _isDoubleEnterOnPlatform;

        private void Awake() => 
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!_isDoubleEnterOnPlatform && isOneSizePlatform)
            {
                _scoreService.AddScore(addingScore);
                _isDoubleEnterOnPlatform = true;
            }
            if(!isOneSizePlatform) 
                _scoreService.AddScore(addingScore);
        }
        
    }
}