using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace Serialize
{
    [System.Serializable]
    public class PlayerData
    {
        public string nickName;
        public int level;
        public bool isDie;
        public string[] items;
    }


    public class PlayerControlTest : MonoBehaviour
    {
        public PlayerData playerData;

        //����ȭ - ��������
        [ContextMenu("To Json Data")]
        void SavePlayerDataToJson()
        {
            string jsonData = JsonUtility.ToJson(playerData, true);
            string path = Path.Combine(Application.dataPath, "PlayerData.json");
            File.WriteAllText(path, jsonData);
        }

        //������ȭ - ���Ϸε�
        [ContextMenu("From Json Data")]
        void LoadPlayerDataFromJson()
        {
            string path = Path.Combine(Application.dataPath, "PlayerData.json");
            string jsonData = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }

    }

}


