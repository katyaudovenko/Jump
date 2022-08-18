using System;
using Model.Services.ServiceLocator;

namespace Model.Services
{
    public class ScoreService : IService
    {
        public event Action OnScoreChanged;

        public int Score { get; private set; }
        
        public void AddScore(int score)
        {
            Score += score;
            OnScoreChanged?.Invoke();
        }
    }
}