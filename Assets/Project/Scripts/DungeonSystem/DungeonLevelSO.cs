using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DungeonGunner
{
    [CreateAssetMenu(fileName = "DungeonLevel_", menuName = "Scriptable Objects/Dungeon/Dungeon Level")]
    public class DungeonLevelSO : ScriptableObject
    {
        [Space(10)]
        [Header("Details")]

        [Tooltip("The name of the level")]
        public string levelName;



        [Space(10)]
        [Header("Room Templates from RoomTemplateSO")]

        [Tooltip("The list of room templates to use for this level")]
        public List<RoomTemplateSO> roomTemplateList;



        [Space(10)]
        [Header("Room Node Graph from RoomNodeGraphSO")]

        [Tooltip("The list of room node graphs to use for this level")]
        public List<RoomNodeGraphSO> roomNodeGraphList;



        #region Validation
#if UNITY_EDITOR
        private void OnValidate()
        {
            HelperUtilities.ValidateCheckEmptyString(this, nameof(levelName), levelName);
            if (HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomTemplateList), roomTemplateList)) return;
            if (HelperUtilities.ValidateCheckEnumerableValues(this, nameof(roomNodeGraphList), roomNodeGraphList)) return;



            bool isCorridorEW = false;
            bool isCorridorNS = false;
            bool isEntrance = false;

            foreach (RoomTemplateSO roomTemplate in roomTemplateList)
            {
                if (roomTemplate == null) return;

                RoomNodeTypeSO roomNodeType = roomTemplate.roomNodeType;
                if (roomNodeType.isCorridorEW) isCorridorEW = true;
                if (roomNodeType.isCorridorNS) isCorridorNS = true;
                if (roomNodeType.isEntrance) isEntrance = true;
            }

            if (!isCorridorEW)
            {
                Debug.LogError($"[{GetType().Name}] {nameof(roomTemplateList)} must contain a room template with a corridorEW room node type");
            }

            if (!isCorridorNS)
            {
                Debug.LogError($"[{GetType().Name}] {nameof(roomTemplateList)} must contain a room template with a corridorNS room node type");
            }

            if (!isEntrance)
            {
                Debug.LogError($"[{GetType().Name}] {nameof(roomTemplateList)} must contain a room template with an entrance room node type");
            }

            foreach (RoomNodeGraphSO roomNodeGraph in roomNodeGraphList)
            {
                if (roomNodeGraph == null) return;

                foreach (RoomNodeSO roomNode in roomNodeGraph.roomNodeList)
                {
                    if (roomNode == null) continue;

                    RoomNodeTypeSO roomNodeType = roomNode.roomNodeType;
                    if (
                        roomNodeType.isEntrance ||
                        roomNodeType.isCorridorEW ||
                        roomNodeType.isCorridorNS ||
                        roomNodeType.isCorridor ||
                        roomNodeType.isNone
                    ) continue;

                    bool isRoomTemplateFound = false;
                    foreach (RoomTemplateSO roomTemplate in roomTemplateList)
                    {
                        if (roomTemplate == null) continue;

                        if (roomTemplate.roomNodeType == roomNodeType)
                        {
                            isRoomTemplateFound = true;
                            break;
                        }
                    }

                    if (!isRoomTemplateFound)
                    {
                        Debug.LogError($"[{GetType().Name}] {nameof(roomTemplateList)} must contain a room template with a room node type of {roomNodeType.name}");
                    }
                }
            }
        }
#endif
        #endregion
    }
}
