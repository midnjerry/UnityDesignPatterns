using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Drone : MonoBehaviour
{
    public IObjectPool<Drone> Pool { get; set; }
    public float CurrentHealth;

    [SerializeField]
    private float _maxHealth = 100.0f;

    [SerializeField]
    private float timeToSelfDestruct = 3.0f;

    private void Start()
    {
        CurrentHealth = _maxHealth;
    }

    private void OnEnable()
    {
        AttackPlayer();
        StartCoroutine(SelfDestruct());
    }

    private void OnDisable()
    {
        ResetDrone();
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeToSelfDestruct);
        TakeDamage(_maxHealth);
    }

    private void ReturnToPool()
    {
        Pool.Release(this);
    }

    private void ResetDrone()
    {
        CurrentHealth = _maxHealth;
    }

    public void AttackPlayer()
    {
        Debug.Log("Attack Player!");
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0.0f)
        {
            ReturnToPool();
        }
    }
}
