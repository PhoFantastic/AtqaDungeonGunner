using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGunner
{
    [CreateAssetMenu(fileName = "CurrentPlayer_", menuName = "Scriptable Objects/Player/Current Player")]
    public class CurrentPlayerSO : ScriptableObject
    {
        public PlayerDetailSO playerDetail;
        public string playerName;


    }
}
