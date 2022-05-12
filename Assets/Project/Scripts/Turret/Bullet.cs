using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject impactEffect;
    [SerializeField] float speed = 70f;
    [SerializeField] float explosionRadius = 0f;
    [SerializeField] int damage = 50;
    Transform target;

    public void Seek(Transform targetPoint)
    {
        target = targetPoint;
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        MoveBullet();
    }
    void MoveBullet()
    {
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    private void HitTarget()
    {
        GameObject effectInstance = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);
        if (explosionRadius > 0f)
            Explode();
        else
            Damage(target);
        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitObject in hitObjects)
        {
            if (hitObject.CompareTag("Enemy"))
                Damage(hitObject.transform);
        }
    }
    void Damage(Transform enemy)
    {
        EnemyController e = enemy.GetComponent<EnemyController>();
        if (e != null)
            e.TakeDamage(damage);
    }
}