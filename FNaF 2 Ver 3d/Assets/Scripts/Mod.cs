using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Crazy.AI;

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
    public Misje[] misje;
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
        if (data == ""||data==" "||data==null)
        {
            return;
        }
        dwa = JsonUtility.FromJson<KlasaDwa>(data);
        if (dwa.Animatroniki.Length==0)
        {
            return;
        }
        misje = FindObjectsOfType<Misje>();
        if (misje.Length==0)
        {
            return;
        }
        foreach (Animatronik item in dwa.Animatroniki)
        {
            for (int i = 0; i < misje.Length; i++)
            {
                if (item.name == misje[i].gameObject.name)
                {
                    misje[i].animatronik = item;
                }
            }
        }
    }
    #endregion
}
