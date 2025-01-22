using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GasItem"))
        {
            gameManager.Gas += gameManager.gasItemUp;
            gameManager.UpdateGasText();
            Destroy(collision.gameObject);
        }
    }
}
