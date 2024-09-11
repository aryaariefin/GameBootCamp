using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerStatus
{
    public class EnvPlayer
    {
        public int Health;
        public int Ammo;
        public int Loadammo;
        public int Grenade;


        public EnvPlayer(int Health, int Ammo, int Loadammo, int Grenade)
        {
            this.Health = Health;
            this.Ammo = Ammo;
            this.Loadammo = Loadammo;
            this.Grenade = Grenade;
        }
    }
}
