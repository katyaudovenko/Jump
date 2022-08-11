﻿using UnityEngine;

namespace Model
{
    public class CameraMove : MonoBehaviour
    {
        private const int CameraDepth = -10;
        
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float movingSpeed;
        [SerializeField] private Transform lowerBound;
        
        private void Update()
        {
            if (playerTransform != null)
            {
                var minYCamera = Camera.main.orthographicSize + lowerBound.position.y;
                var playerPosition = playerTransform.position;
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
    }
}