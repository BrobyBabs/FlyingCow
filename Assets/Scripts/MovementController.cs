using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Socket.Quobject.SocketIoClientDotNet.Client;

namespace Regan.AsteroidDodge
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField]
        GameSettings _gameSettings;

        [SerializeField]
        Transform _playerTransform;

        [SerializeField]
        Vector2 _seperation = new Vector2(2, 1);
        [SerializeField]
        Vector2Int _gridPositions = new Vector2Int(3, 3);
        Vector2Int _movementTarget = new();


        [SerializeField]
        float _movementSpeed = 10;

        private QSocket socket;

        private void Start()
        {
            if (_gameSettings == null) return;
            SetupFromGameSettings(_gameSettings);
            ConnectSocket();
        }

        private void ConnectSocket()
        {
            socket = IO.Socket("https://teachablemachine.withgoogle.com/models/OY4Y4GoA9/");

            socket.On("connect", () =>
            {
                Debug.Log("Connected to server.");
            });

            socket.On("teachable-predictions", (data) =>
            {
                string message = data.ToString();
                Debug.Log("Received: " + message);

                // Process the data and move the player
                if (message.Contains("Left"))
                {
                    AddMovementVector(Vector2Int.left);
                }
                else if (message.Contains("Right"))
                {
                    AddMovementVector(Vector2Int.right);
                }
                else if (message.Contains("Jump"))
                {
                    AddMovementVector(Vector2Int.up);
                }
                else if (message.Contains("Slide"))
                {
                    AddMovementVector(Vector2Int.down);
                }
            });
        }

        private void SetupFromGameSettings(GameSettings gameSettings)
        {
            _seperation = gameSettings.GridSeperation;
            _gridPositions = gameSettings.GridPositions;
            _movementSpeed = gameSettings.PlayerMovementSpeed;
        }

        private void Update()
        {
            if (_playerTransform == null) return;

            UpdateMovement();
        }

        private void UpdateMovement()
        {
            Vector3 playerPosition = _playerTransform.position;

            playerPosition.x = Mathf.Lerp(playerPosition.x, _movementTarget.x * _seperation.x, _movementSpeed * Time.deltaTime);
            playerPosition.y = Mathf.Lerp(playerPosition.y, _movementTarget.y * _seperation.y, _movementSpeed * Time.deltaTime);

            _playerTransform.position = playerPosition;
        }

        private void AddMovementVector(Vector2Int vector)
        {
            _movementTarget.x = Mathf.Clamp(_movementTarget.x + vector.x, -_gridPositions.x, _gridPositions.x);
            _movementTarget.y = Mathf.Clamp(_movementTarget.y + vector.y, -_gridPositions.y, _gridPositions.y);
        }
    }
}
