using System;
using UnityEngine;

[Serializable]
public class GameData
{
    //mana, maxMana, maxJumps, daño, currency, boolHabilidades
    [SerializeField]
    private float life;
    [SerializeField]
    private float maxLife;
    
    [SerializeField]
    private float mana;
    [SerializeField]
    private float maxMana;
    
    [SerializeField]
    private int maxJumps;
    
    [SerializeField]
    private float damage;
    [SerializeField]
    private int currency;

    [SerializeField]
    private int healthPotionsCount;
    
    [SerializeField]
    private int manaPotionsCount;

    [SerializeField]
    private int scene;

    [SerializeField]
    private Vector3 savePosition;

    //Constructor
    public GameData()
    {
        life = 100f;
        maxLife = 100f;
        mana = 50f;
        maxMana = 50f;
        maxJumps = 1;
        damage = 10f;
        currency = 0;
        healthPotionsCount = 3;
        manaPotionsCount = 1;
        scene = 1;
        savePosition = Vector3.zero;
    }

    public float Life
    {
        get { return life; }
        set { life = value; }
    }

    public float MaxLife
    {
        get { return maxLife; }
        set { maxLife = value; }
    }

    public float Mana
    {
        get { return mana; }
        set { mana = value; }
    }
    
    public float MaxMana 
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    public int MaxJumps
    {
        get { return maxJumps; }
        set { maxJumps = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    
    public int Currency
    {
        get { return currency; }
        set { currency = value; }
    }

    public int HealthPotionsCount
    {
        get { return healthPotionsCount; }
        set { healthPotionsCount = value; }
    }

    public int ManaPotionsCount
    {
        get { return manaPotionsCount; }
        set { manaPotionsCount = value; }
    }

    public int Scene
    {
        get { return scene; }
        set { scene = value; }
    }

    public Vector3 SavePosition
    {
        get { return savePosition; }
        set { savePosition = value; }
    }
}