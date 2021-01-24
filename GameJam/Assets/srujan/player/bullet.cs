using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float speed = 2000;
    [SerializeField] private float time = 3f;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, time);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                Destroy(gameObject);

                Debug.Log(collider.name);
            }
        }
    }
}
