using UnityEngine;

public class FeetJump : MonoBehaviour
{
    public JoseController joseController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        joseController.puedoSaltar = true;
        //Debug.Log("Toco el suelo");
    }

    private void OnTriggerExit(Collider other)
    {
        joseController.puedoSaltar=false;
        Debug.Log("No estoy tocando el suelo");
    }
}
