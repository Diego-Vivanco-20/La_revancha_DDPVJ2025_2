using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public PlayerDataSO playerData;
    //public int armas = 3;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PortalN1" && playerData.recuerdos >= 3)
        {
            SceneManager.LoadScene(2);
        }
        if(other.tag == "PortalN2" && playerData.recuerdos == 3)
        {
            SceneManager.LoadScene(3);
        }
    }
}
