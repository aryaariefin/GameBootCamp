using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyStatus
{
    public class EnvEnemy
    {
        public int Health;
        public string Name;
        
        public EnvEnemy(int Health, string Name)
        {
            this.Health = Health;
            this.Name = Name;
        }
    }
}

