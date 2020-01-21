using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int nuts;
    public Text Text;

    void Update()
    {
        Text.text = (""+nuts);
    }

}
