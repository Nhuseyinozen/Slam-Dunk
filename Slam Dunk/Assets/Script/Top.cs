using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioSource Topsesi;

    private void OnTriggerEnter(Collider other)
    {
        Topsesi.Play();

        if (other.CompareTag("Basket"))
        {

            gameManager.basket(transform.position);


        }
        else if (other.CompareTag("YereDustu"))
        {
            gameManager.kaybettiniz();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Topsesi.Play();
    }



}
