using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    [SerializeField] private GameManager _GameManager;
   


    IEnumerator Start() // potab�y�tme spriten�n text s�resini saniyede 1 azalt�r.
    {
        Sure.text = BaslangicSuresi.ToString();

        while (true)
        {
            yield return new WaitForSeconds(1f); // belirledi�imiz s�re boyunca i�lem yapar.
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();
            if (BaslangicSuresi == 0)
            {
                gameObject.SetActive(false); // potob�y�tme sprit�n� pasifle�tirir.
                break;
            }

        }
    }





    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        
        _GameManager.potabuyutme();
    }
}
