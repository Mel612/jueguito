using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;
    public Transform pies;
    public LayerMask capaSuelo;

    private Rigidbody2D cuerpo;
    private float movimiento;

    void Awake()
    {
        cuerpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movimiento = Input.GetAxisRaw("Horizontal");

        bool tocaSuelo = Physics2D.OverlapCircle(pies.position, 0.1f, capaSuelo);
        if (Input.GetKeyDown(KeyCode.Space) && tocaSuelo)
            cuerpo.linearVelocity = new Vector2(cuerpo.linearVelocity.x, fuerzaSalto);
    }

    void FixedUpdate()
    {
        cuerpo.linearVelocity = new Vector2(movimiento * velocidad, cuerpo.linearVelocity.y);
    }
}