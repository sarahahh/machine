using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float velocidad;
    public float FuerzaSalto;
    public LayerMask CapaSuelo;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;

    private bool Miraderecha = true;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }
    bool Tocapiso()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f,CapaSuelo);
        return raycastHit.collider != null; 
    }
    void Procesarsaltos()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Tocapiso())
        {
            //fuerza vertical al personaje
            rigidbody.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);

        }
    }
    void Procesarmovimientos()
    {
        //Logica de movimientos
        float Horizontal = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(Horizontal * velocidad, rigidbody.velocity.y);
        GestionarOrientacion(Horizontal);
    }
    // Update is called once per frame
    void Update()
    {
        Procesarmovimientos();
        Procesarsaltos();
    }

    void GestionarOrientacion(float Horizontal)
    {
        if((Miraderecha==true && Horizontal<0 ) || (Miraderecha==false && Horizontal>0))
        {
            Miraderecha = !Miraderecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
        //Si se cumple la condicion se ejecutara el codigo de volteado

    }
}
