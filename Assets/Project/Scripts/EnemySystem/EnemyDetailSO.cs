using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGunner
{
    [CreateAssetMenu(fileName = "EnemyDetail_", menuName = "Scriptable Objects/Enemy/Enemy Detail")]
    public class EnemyDetailSO : ScriptableObject
    {
        [Space(10)]
        [Header("Base Enemy Detail")]


        public string enemyName;
        public GameObject prefab;

        public float chaseDistance = 50f;



        #region Validation
#if UNITY_EDITOR
        private void OnValidate()
        {
            HelperUtilities.ValidateCheckEmptyString(this, nameof(enemyName), enemyName);
            HelperUtilities.ValidateCheckNullValue(this, nameof(prefab), prefab);
            HelperUtilities.ValidateCheckPositiveValue(this, nameof(chaseDistance), chaseDistance);  
        }
#endif
        #endregion
    }
}
