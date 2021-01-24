using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2000;
    [SerializeField] private float time = 3f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed);
        Destroy(gameObject, time);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
