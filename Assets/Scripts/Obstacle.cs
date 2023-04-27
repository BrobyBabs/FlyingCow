using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    public class Obstacle : MonoBehaviour
    {
        float _speed;
        PlayerStats _playerStats;

        public void Setup(float speed, PlayerStats playerStats)
        {
            _speed = speed;
            _playerStats = playerStats;
        }

        private void Update()
        {
            transform.position += -_speed * Time.deltaTime * Vector3.forward;

            if (transform.position.z > -10) return;

            if (_playerStats)
            {
                _playerStats.Score += 1;
            }

            Destroy(gameObject);
        }
    }
}