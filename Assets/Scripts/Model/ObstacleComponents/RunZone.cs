using Model.PlayerComponents;
using UnityEngine;

namespace Model.ObstacleComponents
{
    public class RunZone : MonoBehaviour
    {
        private PlayerRun _runComponent;
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _runComponent = collision.gameObject.GetComponent<PlayerRun>();
            _runComponent.Run();
        }
    }
}