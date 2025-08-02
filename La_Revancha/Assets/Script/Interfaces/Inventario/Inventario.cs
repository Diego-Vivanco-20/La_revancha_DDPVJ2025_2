using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    private bool activarInventario;
    public GameObject inventario;
    private int numSlots;
    private int activarSlots;
    private GameObject[] slot;
    public GameObject slotHolder;

    // Start is called before the first frame update
    void Start()
    {
        numSlots = slotHolder.transform.childCount;
        slot = new GameObject[numSlots];

        for (int i = 0; i < numSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().vacio = true;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activarInventario = !activarInventario;

        }
        if (activarInventario)
        {
            inventario.SetActive(true);
            //pausar();

            /*Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;*/

        }
        else
        {
            inventario.SetActive(false);
            //Reanudar();
            /*Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/
        }
    }

    public void pausar()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Reanudar()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.ID, item.type, item.descripcion, item.icono);
        }

    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescripcion, Sprite itemIcono)
    {
        for (int i = 0; i < numSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().vacio)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().descripcion = itemDescripcion;
                slot[i].GetComponent<Slot>().icono = itemIcono;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);


                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().vacio = false;
                return;

            }

        }
    }
}
