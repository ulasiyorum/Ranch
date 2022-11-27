using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

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
        ProfileData data = new ProfileData();
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
    public static string ConvertArrayToString(int[] ar)
    {
        if (ar == null)
            return null;

        string str = "";
        for(int i=0; i<ar.Length; i++)
        {
            str += ar[i].ToString() + ",";
        }

        return str;
    }
    public static int[] ConvertIntArray(string ar)
    {
        if (ar == null || ar.Length < 1)
            return new int[0];

        string[] strArr = ar.Split(',');
        int[] array = new int[strArr.Length-1];
        for(int i=0; i<array.Length; i++)
        {
            if (int.TryParse(strArr[i],out int h))
                array[i] = int.Parse(strArr[i]);
        }

        return array;
    }
}