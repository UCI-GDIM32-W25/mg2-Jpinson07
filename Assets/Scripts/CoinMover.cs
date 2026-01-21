using UnityEngine;

public class CoinMover : MonoBehaviour
{
    public float speed = 3f;
    public float destroyX = -15f;   // Far left of the camera

    void Update()
    {
        // Move left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Destroy when off-screen
        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}

