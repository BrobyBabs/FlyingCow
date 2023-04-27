using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        GameSettings _gameSettings;
        [SerializeField]
        PlayerStats _playerStats;
        [SerializeField]
        int _maxHealth;

        int _currentHealth;

        private void Start()
        {
            SetupFromGameSettings(_gameSettings);
            ResetStats();
        }

        private void ResetStats()
        {
            if (_playerStats == null) return;

            _playerStats.HP = _maxHealth;
            _playerStats.Score = 0;
        }

        private void SetupFromGameSettings(GameSettings gameSettings)
        {
            if (gameSettings == null) return;


            _maxHealth = gameSettings.MaxPlayerHealth;
        }
    }
}