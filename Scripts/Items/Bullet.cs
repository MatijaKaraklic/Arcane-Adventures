using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifetime = 10f;

    private Rigidbody2D rigidbody;
    private SpriteRenderer sr;
    private BoxCollider2D collider;
    [SerializeField] private ParticleSystem explosion_particles;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        explosion_particles.Stop();
    }

    public void Shoot(Vector3 dir)
    {
        rigidbody.velocity = dir * speed;
        Destroy(gameObject, maxLifetime);
    }

    private void DestroyBullet()
    {
        explosion_particles.Play();
        Destroy(rigidbody); Destroy(sr); Destroy(collider);
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == States.WALL_TAG) DestroyBullet();
    }
}
