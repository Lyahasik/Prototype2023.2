using System;
using UnityEngine;

namespace Prototype.Gameplay.Movement
{
    [Serializable]
    public struct MovementComponent
    {
        public CharacterController characterController;
        public float speed;
    }
}