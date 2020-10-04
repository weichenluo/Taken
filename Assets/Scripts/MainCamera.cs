using UnityEngine;

public class MainCamera : MonoBehaviour {
    public Transform player;
    private Vector3 offset = new Vector3(-7f, -18f, 0f);
    private float speed = 1f;

    private void LateUpdate()

    {
        Vector3 temp = player.position - offset;
        Vector3 temp2 = Vector3.Lerp(transform.position, temp, speed);

        transform.position = temp2;

        transform.LookAt(player);

    }
}
