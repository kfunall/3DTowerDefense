using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform targetPoint;
    PlayerStats playerStats;
    [SerializeField] int health = 100;
    [SerializeField] int moneyGain = 50;
    NavMeshAgent enemy;

    private void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        playerStats = FindObjectOfType<PlayerStats>();
    }
    private void Start()
    {
        enemy.destination = targetPoint.position;
    }
    void EndRoad()
    {
        playerStats.DecreaseLive(1);
        Destroy(gameObject, 0.25f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndPoint"))
            EndRoad();
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        playerStats.IncraseMoney(moneyGain);
        Destroy(gameObject);
    }
}