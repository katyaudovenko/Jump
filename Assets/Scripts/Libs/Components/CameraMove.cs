using UnityEngine;

namespace Libs.Components
{
    public class CameraMove : MonoBehaviour
    {
        private const int CameraDepth = -10;
        
        [SerializeField] private float movingSpeed;
        [SerializeField] private Transform lowerBound;

        private Transform _playerTransform;
        private void Update()
        {
            if (_playerTransform != null)
            {
                var minYCamera = Camera.main.orthographicSize + lowerBound.position.y;
                var playerPosition = _playerTransform.position;
                var target = new Vector3
                {
                    x = playerPosition.x,
                    y = Mathf.Max(minYCamera, playerPosition.y),
                    z = playerPosition.z + CameraDepth
                };
                
                
                
                var cameraPosition = Vector3.Lerp(transform.position, target, movingSpeed * Time.deltaTime);
                transform.position = cameraPosition;
            }
        }

        public void SetPlayerTransform(Transform playerTransform) => 
            _playerTransform = playerTransform;
    }
}