using UnityEngine;

public class Spikes : MonoBehaviour
{
    public Player player;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.Damage(1);
            StartCoroutine(player.Knockback(0.002f, 1, player.transform.position));
        }
    }
}