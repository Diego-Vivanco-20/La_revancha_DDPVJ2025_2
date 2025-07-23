using Unity.VisualScripting;
using UnityEngine;

public class JoseController : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaSalto = 8.0f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;
    public bool atacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        puedoSaltar=false;
        
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;

    }

    void FixedUpdate()
    {
        if (!atacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;

            //rb.SetVelocity(transform.forward * impulsoGolpe);
        }
    }
    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !atacando)
        {
            anim.SetTrigger("golpear");
            atacando = true;
        }

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (puedoSaltar)
        {
            if (!atacando)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    anim.SetBool("salte", true);
                    rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    anim.SetBool("agachado", true);
                    velocidadMovimiento = velocidadAgachado;
                }
                else
                {
                    anim.SetBool("agachado", false);
                    velocidadMovimiento = velocidadInicial;
                }
            }

            anim.SetBool("tocaSuelo", true);
        }
        else
        {
            EstoyCayendo();

        }
    }

    public void EstoyCayendo()
    {
        anim.SetBool("tocaSuelo", false);
        anim.SetBool("salte", false);
    }
    
    public void DejoDeGolpear()
    {
        atacando=false;
        anim.SetBool("tocaSuelo", true);  // Forzar animación de blend tree
        Debug.Log("tocaSuelo" + puedoSaltar);
        //avanzoSolo = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo=true;
    }

    public void DejoAvanzar()
    {
        avanzoSolo = false;
    }
    
}
