using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Regan.AsteroidDodge {
    public class GameUI : MonoBehaviour
    {
        [SerializeField]
        PlayerStats _playerStats;
        [SerializeField]
        TextMeshProUGUI _scoreText;
        [SerializeField]
        TextMeshProUGUI _livesText;
        [SerializeField]
        GameObject _gameoverPanel;

        private void OnEnable()
        {
            PlayerDamage.OnPlayerKilled += OnPlayerKilled;
        }

        private void OnDisable()
        {
            PlayerDamage.OnPlayerKilled -= OnPlayerKilled;
        }

        private void OnPlayerKilled()
        {
            _gameoverPanel.SetActive(true);
        }

        private void Update()
        {
            if (_playerStats == null) return;

            _scoreText.text = $"score: {_playerStats.Score}";
            _livesText.text = $"lives: {_playerStats.HP}";
        }
    }
}
