using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
        menuName = "Tanques",
        fileName = "Tank_"

 )]


public class TankSO : ScriptableObject
{
    [SerializeField] private GameObject WhichTank;
    [SerializeField] private float life;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float resistance;

    public float GetLife()
    {
        return life;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetResistance()
    {
        return resistance;
    }
    

}
