using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField]
        GameSettings _gameSettings;
        [SerializeField]
        PlayerStats _playerStats;

        [SerializeField]
        GameObject _obstaclePrefab;
        [SerializeField]
        float _obstacleSpawnDistance = 10;
        [SerializeField]
        Vector2 _seperation = new Vector2(2, 1);
        [SerializeField]
        Vector2Int _gridPositions = new Vector2Int(3, 3);
        [SerializeField]
        int _maxAsteroidAmount = 5;
        [SerializeField]
        float _spawnChance = 0.1f;
        [SerializeField]
        float _obstacleSpeed = 6;

        private void Start()
        {
            if (_gameSettings == null) return;

            SetupFromGameSettings(_gameSettings);
        }

        private void Update()
        {
            HandleRandomSpawn();
        }

        private void SetupFromGameSettings(GameSettings gameSettings)
        {
            _seperation = gameSettings.GridSeperation;
            _gridPositions = gameSettings.GridPositions;
            _obstacleSpeed = gameSettings.ObstacleSpeed;
            _obstacleSpawnDistance = gameSettings.AsteroidSpawnDistance;
        }

        private void HandleRandomSpawn()
        {
            float randomValue = Random.value;

            if (randomValue > _spawnChance * Time.deltaTime) return;

            SpawnObstacle();
        }

        private void SpawnObstacle()
        {
            Vector2Int spawnPos = new Vector2Int(Random.Range(-_gridPositions.x, _gridPositions.x + 1), Random.Range(-_gridPositions.y, _gridPositions.y + 1));

            GameObject gameObject = Instantiate(_obstaclePrefab);

            gameObject.transform.position = new Vector3(spawnPos.x * _seperation.x, spawnPos.y * _seperation.y, _obstacleSpawnDistance);

            Obstacle obstacle = gameObject.GetComponent<Obstacle>();

            if (obstacle == null) return;

            obstacle.Setup(_obstacleSpeed, _playerStats);
        }
    }
}