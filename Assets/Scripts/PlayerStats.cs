using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Regan.AsteroidDodge
{
    [CreateAssetMenu(menuName = "Regan/AsteroidDodge/PlayerStats")]
    public class PlayerStats : ScriptableObject
    {
        public int HP { get => _HP; set => _HP = value; }
        public int Score { get => _score; set => _score = value; }

        private int _HP;
        private int _score;
    }
}