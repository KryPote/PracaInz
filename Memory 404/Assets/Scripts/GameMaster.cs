using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int nuts;
    public Text Text;

    private void Update()
    {
        Text.text = "" + nuts;
    }
}