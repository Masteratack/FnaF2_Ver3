using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mod : MonoBehaviour
{
    #region Mody Dyni
    [System.Serializable]
    public class Animatronik
    {
        public string name = "Freedy";
        public bool W³¹czony = true;
        public int Prêdkoœæ = 1;
    }
    [System.Serializable]
    public class KlasaDwa
    {
        public Animatronik[] Animatroniki;
    }
    public KlasaDwa dwa;
    // Start is called before the first frame update
    void Awake()
    {
        FileInfo FILE = new FileInfo(Application.dataPath + @"\Dynia.crazy");
        if (!FILE.Exists)
        {
            return;
        }
       string data= File.ReadAllText(FILE.FullName);
        dwa = JsonUtility.FromJson<KlasaDwa>(data);
    }
    #endregion
}
