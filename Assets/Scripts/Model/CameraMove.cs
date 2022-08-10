using UnityEngine;

namespace Model
{
    public class CameraMove : MonoBehaviour
    {
        private const int CameraDepth = -10;
        
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float movingSpeed;
        
        private void Update()
        {
            if (playerTransform != null)
            {
                var playerPosition = playerTransform.position;
                var target = new Vector3
                {
                    x = playerPosition.x,
                    y = Mathf.Max(0, playerPosition.y),
                    z = playerPosition.z + CameraDepth
                };
                
                var cameraPosition = Vector3.Lerp(transform.position, target, movingSpeed * Time.deltaTime);
                transform.position = cameraPosition;
            }
        }
    }
}