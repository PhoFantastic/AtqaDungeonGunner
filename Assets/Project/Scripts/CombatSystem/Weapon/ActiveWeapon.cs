using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGunner {
    [DisallowMultipleComponent]
    #region Requirement Components
    [RequireComponent(typeof(ActiveWeaponEvent))]
    #endregion
    public class ActiveWeapon : MonoBehaviour {
        [SerializeField] private SpriteRenderer weaponSpriteRenderer;
        [SerializeField] private PolygonCollider2D weaponPolygonCollider2D;
        [SerializeField] private Transform weaponShootPointTransform;
        [SerializeField] private Transform weaponEffectPointTransform;

        private ActiveWeaponEvent activeWeaponEvent;
        private Weapon currentWeapon;



        private void Awake() {
            activeWeaponEvent = GetComponent<ActiveWeaponEvent>();
        }



        private void OnEnable() {
            activeWeaponEvent.OnSetActiveWeapon += ActiveWeaponEvent_OnSetActiveWeapon;
        }



        private void OnDisable() {
            activeWeaponEvent.OnSetActiveWeapon -= ActiveWeaponEvent_OnSetActiveWeapon;
        }



        private void ActiveWeaponEvent_OnSetActiveWeapon(ActiveWeaponEvent sender, OnSetActiveWeaponArgs args) {
            SetWeapon(args.weapon);
        }



        private void SetWeapon(Weapon weapon) {
            currentWeapon = weapon;

            weaponSpriteRenderer.sprite = currentWeapon.weaponDetail.sprite;

            if (weaponPolygonCollider2D != null && weaponSpriteRenderer.sprite != null) {
                List<Vector2> pointList = new List<Vector2>();
                weaponSpriteRenderer.sprite.GetPhysicsShape(0, pointList);

                weaponPolygonCollider2D.SetPath(0, pointList.ToArray());
            }

            weaponShootPointTransform.localPosition = currentWeapon.weaponDetail.shootPosition;
        }



        public AmmoDetailSO GetAmmoDetail() {
            return currentWeapon.weaponDetail.ammoDetail;
        }



        public Weapon GetCurrentWeapon() {
            return currentWeapon;
        }



        public Vector3 GetShootPosition() {
            return weaponShootPointTransform.position;
        }



        public Vector3 GetEffectPosition() {
            return weaponEffectPointTransform.position;
        }



        public void RemoveCurrentWeapon() {
            currentWeapon = null;
        }



        #region Validation
#if UNITY_EDITOR
        private void OnValidate() {
            HelperUtilities.ValidateCheckNullValue(this, nameof(weaponSpriteRenderer), weaponSpriteRenderer);
            HelperUtilities.ValidateCheckNullValue(this, nameof(weaponPolygonCollider2D), weaponPolygonCollider2D);
            HelperUtilities.ValidateCheckNullValue(this, nameof(weaponShootPointTransform), weaponShootPointTransform);
            HelperUtilities.ValidateCheckNullValue(this, nameof(weaponEffectPointTransform), weaponEffectPointTransform);
        }
#endif
        #endregion
    }
}
