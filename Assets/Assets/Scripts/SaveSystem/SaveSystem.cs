using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static BinaryFormatter bf = new BinaryFormatter();
    static string saveFile = Application.persistentDataPath + "/gameData.crop";
    public static void Save()
    {
        FileStream fs = new FileStream(saveFile,
                                       FileMode.OpenOrCreate,
                                       FileAccess.ReadWrite,
                                       FileShare.ReadWrite);
        ProfileData data = new ProfileData(Profile.Balance,Profile.ExtraCrop,Profile.RegrowFaster,Profile.PriceList,Profile.Crop.ID);
        if (File.Exists(saveFile))
        {
            bf.Serialize(fs, data);
            fs.Close();
        }
        else
        {
            fs = new FileStream(saveFile, FileMode.Create);
            bf.Serialize(fs, data);
            fs.Close();
        }
    }
    public static ProfileData Load()
    {
        FileStream fs = new FileStream(saveFile,
                                   FileMode.OpenOrCreate,
                                   FileAccess.ReadWrite,
                                   FileShare.ReadWrite);
        if (File.Exists(saveFile))
        {
            ProfileData data = bf.Deserialize(fs) as ProfileData;
            fs.Close();
            return data;
        }
        else
        {
            return null;
        }
    }

    public static bool FileExists()
    {
        return File.Exists(saveFile);
    }
}