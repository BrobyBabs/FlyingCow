using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    [CreateAssetMenu(menuName = "Regan/AsteroidDodge/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public float AsteroidSpawnDistance { get => _obstacleSpawnDistance; private set => _obstacleSpawnDistance = value; }
        public Vector2 GridSeperation { get => _gridSeperation; private set => _gridSeperation = value; }
        public Vector2Int GridPositions { get => _gridPositions; private set => _gridPositions = value; }
        public float PlayerMovementSpeed { get => _playerMovementSpeed; private set => _playerMovementSpeed = value; }
        public float ObstacleSpeed { get => _obstacleSpeed; private set => _obstacleSpeed = value; }
        public int MaxPlayerHealth { get => _maxPlayerHealth; set => _maxPlayerHealth = value; }

        public GameObject ObstaclePrefab { get => _obstaclePrefab; private set => _obstaclePrefab = value; }
        public LayerMask ObstacleLayer { get => _obstacleLayer; private set => _obstacleLayer = value; }

        [Header("Parameters")]
        [SerializeField]
        private float _obstacleSpawnDistance = 10;
        [SerializeField]
        private Vector2 _gridSeperation = new Vector2(6, 4);
        [SerializeField]
        private Vector2Int _gridPositions = new Vector2Int(1, 1);
        [SerializeField]
        private float _playerMovementSpeed = 8;
        [SerializeField]
        private float _obstacleSpeed = 6;
        [SerializeField]
        private int _maxPlayerHealth = 3;

        [Header("References")]
        [SerializeField]
        private GameObject _obstaclePrefab;
        [SerializeField]
        private LayerMask _obstacleLayer;
    }
}