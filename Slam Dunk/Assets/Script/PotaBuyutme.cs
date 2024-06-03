using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PotaBuyutme : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Sure;
    [SerializeField] private int BaslangicSuresi;
    [SerializeField] private GameManager _GameManager;
   


    IEnumerator Start() // potabüyütme spritenýn text süresini saniyede 1 azaltýr.
    {
        Sure.text = BaslangicSuresi.ToString();

        while (true)
        {
            yield return new WaitForSeconds(1f); // belirlediðimiz süre boyunca iþlem yapar.
            BaslangicSuresi--;
            Sure.text = BaslangicSuresi.ToString();
            if (BaslangicSuresi == 0)
            {
                gameObject.SetActive(false); // potobüyütme spritýný pasifleþtirir.
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
