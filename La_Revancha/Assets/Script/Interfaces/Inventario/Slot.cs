using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;

    public int ID;
    public string type;
    public string descripcion;
    public bool vacio;
    public Sprite icono;
    public int precio;

    public Transform slotIconogameObject;

    // Start is called before the first frame update
    void Start()
    {
        slotIconogameObject = transform.GetChild(0);
    }

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icono;
    }

    public void useItem()
    {
        item.GetComponent<Item>().ItemUsage();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnPointerClick(PointerEventData pointerEvent)
    {
        useItem();

    }

}
