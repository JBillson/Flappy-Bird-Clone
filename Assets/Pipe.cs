using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float distanceFromBirdToDestroySelf;
    private Bird _bird;

    private void Awake()
    {
        _bird = FindObjectOfType<Bird>();
    }

    private void Update()
    {
        if (transform.position.x < _bird.transform.position.x - distanceFromBirdToDestroySelf)
        {
            Destroy(gameObject);
        }
    }
}