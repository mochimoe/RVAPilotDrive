using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManagerBackup : MonoBehaviour
{
    // Script reference
    private HealthBar healthBar;

    [System.Serializable]
    public class SpawnItem 
    {
        public Transform parent;
        public GameObject[] items;
        public float spawnTime;
        public Transform[] spawnPosition;
    }

    public SpawnItem spawnItem;

    private float countDown;

    // komponen penggunaan powerup
    public GameObject plane;
    public int maxStack = 2;
    private int stackNow;

    // komponen untuk mencegah spawn overlap
    private int prevSpawnPosition;
    private int newPosition;

    // komponen pengontrol spawn aktif atau tidak
    public bool canSpawn;
    
    private void Start() {
        healthBar = GameObject.FindObjectOfType<HealthBar>();

        countDown = spawnItem.spawnTime;
    }

    private void Update() {
        if(canSpawn)
        {
            countDown -= Time.deltaTime;

            if(countDown <= 0)
            {
                preventOverlap();

                countDown = spawnItem.spawnTime;
            }
        }
    }

    // prevent spawn from overlap
    private void preventOverlap()
    {
        do
        {
            newPosition = Random.Range(0, spawnItem.spawnPosition.Length);
        } while (prevSpawnPosition == newPosition);

        int positionItem = Random.Range(0, spawnItem.items.Length);

        Instantiate(spawnItem.items[positionItem], spawnItem.spawnPosition[newPosition].position, 
                    Quaternion.identity, spawnItem.parent);
    }

    // invulnerable powerup
    public void invulnerable(string tagName)
    {
        plane.gameObject.tag = tagName;
    }

    // Heal powerup
    public void heal(int healAmount)
    {
        if(healthBar.health + healAmount > 100)
        {
            healthBar.SetHealth(100f);
        }
        else
        {
            healthBar.GainHealth((float)healAmount);
        }
    }

    // check status stack powerup
    public bool getStackStatus()
    {
        if(stackNow != maxStack)
        {
            return true;
        }

        return false;
    }

    // set stack powerup
    public void setStack(int stack)
    {
        stackNow += stack;
    }
}
