using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private TankSO tankSO;

    [Header("Movement")]
    private TankMovement tankMovement;

    private void Awake()
    {
        tankMovement = FindObjectOfType<TankMovement>();
    }

}
