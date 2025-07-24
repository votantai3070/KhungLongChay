using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float leftBound = -10f;

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        transform.position += Vector3.left * GameManager.instance.GetGameSpeed() * Time.deltaTime;
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
