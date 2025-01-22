using UnityEngine;

public class InfiniteScrolling : MonoBehaviour
{
    public float speed;
    public float resetPositionY;
    public float endPositionY;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y <= endPositionY)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = resetPositionY;
            transform.position = newPosition;
        }
    }
}
