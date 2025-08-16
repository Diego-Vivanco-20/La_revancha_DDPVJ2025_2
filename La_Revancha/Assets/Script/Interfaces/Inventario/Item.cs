using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int ID;
    public string type;
    public string descripcion;
    public Sprite icono;
    public int precio;

    [HideInInspector]
    public bool pickedUp;

    [HideInInspector]
    public bool equipado;

    [HideInInspector]
    public GameObject coleccionArmas;

    [HideInInspector]
    public GameObject arma = null;

    public bool playerArma;

    //public PlayerDataSO playerData;

    // Start is called before the first frame update
    private void Start()
    {
        coleccionArmas = GameObject.FindWithTag("Armas");
        //Debug.LogError("No se encontró un objeto con el tag 'Armas'.");
        if (coleccionArmas == null)
        {
            Debug.LogError("No se encontró un objeto con el tag 'Armas'.");
            return;
        }
        if (!playerArma)
        {
            int numArmas = coleccionArmas.transform.childCount;
            Debug.Log("Numero de Armas" + numArmas);

            for (int i = 0; i < numArmas; i++)
            {
                if (coleccionArmas.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    Debug.Log("Encontro una coincidencia");
                    arma = coleccionArmas.transform.GetChild(i).gameObject;
                }
                Debug.Log("No encontro coincidencias");

            }

        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (equipado)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                equipado = false;
            }
            if (!equipado)
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage()
    {
        if (type == "Hacha")
        {
            arma.SetActive(true);
            arma.GetComponent<Item>().equipado = true;
        }
        if (type == "Machete")
        {
            arma.SetActive(true);
            arma.GetComponent<Item>().equipado = true;
        }

        if (type == "Espada")
        {
            arma.SetActive(true);
            arma.GetComponent<Item>().equipado = true;
        }

        if (type == "Macuahuitl")
        {
            arma.SetActive(true);
            arma.GetComponent<Item>().equipado = true;
        }

    }


}
