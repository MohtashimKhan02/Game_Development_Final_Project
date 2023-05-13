using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.Xml;

public class SaveManager : MonoBehaviour
{
    public void SetGameData(Save save)
    {
        GameManager.instance.pesos = save.pesos;
        GameManager.instance.experience = save.experience;
        GameManager.instance.weapon.SetWeaponLevel(save.WeaponLevel);
        GameManager.instance.player.rage = (float)save.rage;    
    }

    
    public void SaveGame()
    {
        Save save = new Save
        {
            pesos = GameManager.instance.pesos,
            experience = GameManager.instance.experience,
            WeaponLevel = GameManager.instance.weapon.weaponLevel,
            rage = (int)GameManager.instance.player.rage
        };

        string path = Application.dataPath + "/SaveData.json";

        string jsonStr = JsonMapper.ToJson(save);

        StreamWriter sw = new StreamWriter(path);
        sw.Write(jsonStr);
        sw.Close();

        Debug.Log("Saves");
        //GameManager.instance.UIManager.ShowText("",)
        //GameManager.instance.ShowText("Game Saved Successfully", 40, Color.white, transform.position + new Vector3(0, 0.18f, 0), Vector3.zero, showTime);
    }


    public void SaveGame(Save save)
    {
        string path = Application.dataPath + "/SaveData.json";
        string jsonStr = JsonMapper.ToJson(save);

        StreamWriter sw = new StreamWriter(path);
        sw.Write(jsonStr);
        sw.Close();

        Debug.Log("Saves");
    }

    
    public void LoadGame()
    {
        string path = Application.dataPath + "/SaveData.json";

        if (File.Exists(path))
        {
            //1
            StreamReader sr = new StreamReader(path);

            //2. 
            string jsonStr = sr.ReadToEnd();
            sr.Close();

            //3.
            Save save = JsonMapper.ToObject<Save>(jsonStr);
            SetGameData(save);

            Debug.Log("Game Loaded");
        }
        else
        {
            NewGame();
            LoadGame();
        }
    }

    
    public void NewGame()
    {
        Save save = new Save
        {
            pesos = 0,
            experience = 0,
            WeaponLevel = 0,
            rage = 0
        };
        SaveGame(save);
    }
}