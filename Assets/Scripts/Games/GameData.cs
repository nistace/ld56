using System;
using System.Collections.Generic;
using UnityEngine;

namespace LD56
{
    [Serializable]
    public class GameData
    {
        public static GameData Data { get; set; }

        [SerializeField] protected GameplayCameraController camera;

        public IReadOnlyList<CreatureController> PlayerCreatures { get; private set; }
        public GameplayCameraController Camera => camera;

        public void Initialize(CreatureController[] creatures)
        {
            PlayerCreatures = creatures;
        }
    }
}
