using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("[ Enemy Settings ]")]
    public float health = 100;
    public float speed = 10f;
    [HideInInspector] public float currentSpeed = 10f;

    [Header("[ Loot Settings ]")]
    public int lootMoney = 50;

    [Header("[ Effect Settings ]")]
    public GameObject deathEffect;

    private void Start()
    {
        currentSpeed = speed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        currentSpeed = speed * (1f - pct);
    }

    private void Die()
    {
        PlayerStats.Money += lootMoney;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
