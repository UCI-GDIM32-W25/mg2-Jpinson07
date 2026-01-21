using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float resetPositionX = -12.1f;
    public float startPositionX = 0f; // or 12.1f for Ground B

    private void Start()
    {
        transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}