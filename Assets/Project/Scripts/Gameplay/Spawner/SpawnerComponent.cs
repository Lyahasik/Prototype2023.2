using System;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Gameplay.Spawner
{
    [Serializable]
    public struct SpawnerComponent
    {
        public Transform parentItems;
        public GameObject prefab;
        public List<Transform> transforms;
    }
}