using System;
using Infrastructure.Services;

namespace Modules.Score
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