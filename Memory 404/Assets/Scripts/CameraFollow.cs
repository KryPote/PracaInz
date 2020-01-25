using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTimeX;
    public float smoothTimeY;
    private Vector2 velocity;

    private void Start()
    {
    }


    private void FixedUpdate()
    {
        var posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        var posY = 0.25f + Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y,
                       smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}