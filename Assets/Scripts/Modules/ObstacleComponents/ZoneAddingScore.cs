using Infrastructure.Services;
using Libs.Components;
using Modules.Score;
using UnityEngine;

namespace Modules.ObstacleComponents
{
    public class ZoneAddingScore : MonoBehaviour
    {
        [SerializeField] private int addingScore;
        [SerializeField] private int maximumScore;
        
        private ScoreService _scoreService;
        private CollisionComponent _collisionComponent;
        
        private int _platformScore;

        private void Awake()
        {
            _scoreService = ServiceLocator.Instance.GetService<ScoreService>();
            _collisionComponent = GetComponent<CollisionComponent>();
        }

        private void OnEnable()
        {
            _platformScore = 0;

            _collisionComponent.OnCollisionEnter += CollisionEnter;
        }

        private void OnDisable() => _collisionComponent.OnCollisionEnter -= CollisionEnter;

        private void CollisionEnter(Collision2D collision2D)
        {
            _platformScore++;
            
            if (_platformScore <= maximumScore) 
                _scoreService.AddScore(addingScore);
        }
    }
}