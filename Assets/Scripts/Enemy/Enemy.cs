﻿using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("[ Enemy Settings ]")]
    public float startHealth = 100;
    public float startSpeed = 10f;
    [HideInInspector] public float speed;
    [HideInInspector] public float health;

    [Header("[ Loot Settings ]")]
    public int lootMoney = 50;

    [Header("[ Effect Settings ]")]
    public GameObject deathEffect;

    [Header("[ Unity Settings ]")]
    public Image healthBar;
    private Quaternion starthealthBarRotate;

    private WaveSpawner waveSpawner;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
        starthealthBarRotate = healthBar.transform.rotation;
        waveSpawner = GameObject.Find("GameManager").GetComponent<WaveSpawner>();
    }

    private void Update()
    {
        healthBar.transform.parent.transform.parent.rotation = starthealthBarRotate;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / startHealth, Time.deltaTime * 10);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    private void Die()
    {
        PlayerStats.Money += lootMoney;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
