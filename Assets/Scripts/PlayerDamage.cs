using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    public class PlayerDamage : MonoBehaviour
    {
        public delegate void PlayerDamageDelegate(int amount);
        public static event PlayerDamageDelegate OnPlayerDamaged;

        public delegate void PlayerKilledDelegate();
        public static event PlayerKilledDelegate OnPlayerKilled;

        [SerializeField]
        GameSettings _gameSettings;
        [SerializeField]
        PlayerStats _playerStats;

        [SerializeField]
        LayerMask _obstacleLayer;

        private void Start()
        {
            if (_gameSettings == null) return;
            SetupFromGameSettings(_gameSettings);
        }

        private void SetupFromGameSettings(GameSettings gameSettings)
        {
            _obstacleLayer = gameSettings.ObstacleLayer;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (((1<<other.gameObject.layer) & _obstacleLayer) == 0) return;

            PlayerDamaged(1);
        }

        private void PlayerDamaged(int amount)
        {
            OnPlayerDamaged?.Invoke(1);

            if (_playerStats == null) return;

            _playerStats.HP -= amount;

            if (_playerStats.HP <= 0)
            {
                OnPlayerKilled?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}