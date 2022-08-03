using System;
using UnityEngine;

namespace Model.PlayerComponents
{
    public class DestroyPlayer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}