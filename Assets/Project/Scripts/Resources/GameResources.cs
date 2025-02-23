using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Audio;

namespace DungeonGunner {
    public class GameResources : MonoBehaviour {
        #region Singleton GameResources
        private static GameResources instance;
        public static GameResources Instance {
            get
            {
                if (instance == null) {
                    instance = Resources.Load<GameResources>("GameResources");
                }
                return instance;
            }
        }
        #endregion



        [Space(10)]
        [Header("AStar Tilemap")]


        public TileBase[] EnemyUnwalkableTileArray;
        public TileBase EnemyPreferredPathTile;



        [Space(10)]
        [Header("Audio")]


        [Tooltip("Populate with the audio mixer group")]
        public AudioMixerGroup AudioMixerGroup_Master;



        [Space(10)]
        [Header("Dungeon")]


        [Tooltip("Populate with the dungeon RoomNodeTypeListSO")]
        public RoomNodeTypeListSO RoomNodeTypeList;



        [Space(10)]
        [Header("Player")]


        [Tooltip("Populate with the player CurrentPlayerSO")]
        public CurrentPlayerSO CurrentPlayer;



        [Space(10)]
        [Header("Materials")]


        [Tooltip("Dimmed Material")]
        public Material DimmedMaterial;

        [Tooltip("Sprite-Lit-Default Material")]
        public Material LitMaterial;



        [Space(10)]
        [Header("Shaders")]


        [Tooltip("Variable-Lit Shader")]
        public Shader VariableLitShader;



        #region Validation
#if UNITY_EDITOR
        private void OnValidate() {
            HelperUtilities.ValidateCheckEnumerableValues(this, nameof(EnemyUnwalkableTileArray), EnemyUnwalkableTileArray);
            HelperUtilities.ValidateCheckNullValue(this, nameof(EnemyPreferredPathTile), EnemyPreferredPathTile);
            
            HelperUtilities.ValidateCheckNullValue(this, nameof(RoomNodeTypeList), RoomNodeTypeList);

            HelperUtilities.ValidateCheckNullValue(this, nameof(CurrentPlayer), CurrentPlayer);

            HelperUtilities.ValidateCheckNullValue(this, nameof(DimmedMaterial), DimmedMaterial);
            HelperUtilities.ValidateCheckNullValue(this, nameof(LitMaterial), LitMaterial);

            HelperUtilities.ValidateCheckNullValue(this, nameof(VariableLitShader), VariableLitShader);
        }
#endif
        #endregion
    }
}
