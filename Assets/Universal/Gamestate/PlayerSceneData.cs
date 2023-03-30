using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public namespace ppyLEK.Util.Save
{
    public static class PlayerSceneData
    {
        #region Save
            public static void SaveScene(Scene scene)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Application.persistentDataPath + "/data.scene";
                FileStream stream = new FileStream(path, FileMode.Create);

                PlayerData data = new PlayerData(player);

                formatter.Serialize(stream, data);
                stream.Close();
            }
            public static void SavePlayer(Player player)
            {
                BinaryFormatter formatter = new BinaryFormatter();
                string path = Application.persistentDataPath + "/data.player";
                FileStream stream = new FileStream(path, FileMode.Create);

                PlayerData data = new PlayerData(player);

                formatter.Serialize(stream, data);
                stream.Close();
            }
        #endregion

        #region Load
            public static PlayerData LoadPlayer()
            {
                string path = Application.persistentDataPath + "/data.player";
                if (File.Exists(path))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Open);

                    PlayerData data = formatter.Deserialize(stream) as PlayerData;
                    stream.Close();

                    return data;
                }
                else
                {
                    Debug.LogError("Save file not found in " + path);
                    return null;
                }   
            }
            public static SceneData LoadScene()
            {
                string path = Application.persistentDataPath + "/data.scene";
                if (File.Exists(path))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    FileStream stream = new FileStream(path, FileMode.Open);

                    PlayerData data = formatter.Deserialize(stream) as PlayerData;
                    stream.Close();

                    return data;
                }
                else
                {
                    Debug.LogError("Save file not found in " + path);
                    return null;
                }
            }
        #endregion
    }
}