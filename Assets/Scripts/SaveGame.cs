using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    const string savedSceneKey = "savedLevel";
    const string defaultScene = "Murder Scene";

    DirectoryInfo saveFolder { get { return new DirectoryInfo(Application.persistentDataPath); } }
    FileInfo saveFile { get { return new FileInfo(savePath); } }
    string savePath { get { return System.IO.Path.Combine(Application.persistentDataPath, FILE_NAME); } }

    const string FILE_NAME = "Game State";

    public bool loadOnStart;

    public DoorsInteraction bedroomDoor;
    public InsideDoorInteraction bathroomDoor;

    public Transform player;

    public AddToEvidenceScript evidenceList;

    private void Start()
    {
        if (loadOnStart) DeserializeInfo();
    }

    public void CleanSerializedInfo()
    {
        if (saveFile.Exists)
        {
            saveFile.Delete();
            PlayerPrefs.DeleteKey(savedSceneKey);
        }
    }

    public void SerializeInfo()
    {
        SerialTemplet savedGame = new SerialTemplet();

        savedGame.playerPosX = player.transform.position.x;
        savedGame.playerPosY = player.transform.position.y;
        savedGame.playerPosZ = player.transform.position.z;

        savedGame.playerRotX = player.transform.rotation.x;
        savedGame.playerRotY = player.transform.rotation.y;
        savedGame.playerRotZ = player.transform.rotation.z;
        savedGame.playerRotW = player.transform.rotation.w;

        savedGame.evidenceList = new string[evidenceList.evidenceList.Length];
        for (int i=0;i<evidenceList.evidenceList.Length;i++)
        {
            savedGame.evidenceList[i] = evidenceList.evidenceList[i];
        }

        if (!saveFolder.Exists) saveFolder.Create();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, savedGame);
        file.Close();

        SaveCurrentScene();
    }

    public void DeserializeInfo()
    {
        if (saveFile.Exists)
        {
            print("file exists");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = saveFile.Open(FileMode.Open);

            SerialTemplet loadedGame = (SerialTemplet)bf.Deserialize(file);
            file.Close();

            player.transform.position = new Vector3(loadedGame.playerPosX, loadedGame.playerPosY, loadedGame.playerPosZ);

            player.transform.rotation = new Quaternion(loadedGame.playerRotX, loadedGame.playerRotY, loadedGame.playerRotZ, loadedGame.playerRotW);

            evidenceList.evidenceList = new string[loadedGame.evidenceList.Length];
            for (int i = 0; i < loadedGame.evidenceList.Length; i++)
            {
                evidenceList.evidenceList[i] = loadedGame.evidenceList[i];
            }
        }
    }

    public void LoadSavedScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString(savedSceneKey, defaultScene));
    }

    void SaveCurrentScene()
    {
        PlayerPrefs.SetString(savedSceneKey, SceneManager.GetActiveScene().name);
    }
}
