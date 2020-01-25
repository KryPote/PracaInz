using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Sprite[] HeartSprites;

    public Image HeartUI;

    public Player player;

    private void Start()
    {
    }

    private void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}