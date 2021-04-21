using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity; //declara la velocidad del enemigo y public para que se pueda asignar desde unity
    private Rigidbody rb; //declara al rigid body del objeto al que se le asigne el script

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //llama al rigid body del enemigo
    }

    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force); //el enemigo se mueve hacia la izquierda con la fuerza otorgada en el script Controller_Instatior
        OutOfBounds(); //llama a OutofBounds
    }

    public void OutOfBounds()
    {
        if (this.transform.position.x <= -15) //si el objeto (enemigo) vale menos o igual a -15 en la pantalla (ya no se ve)
        {
            Destroy(this.gameObject); //se destruye el enemigo así deja de gastar recursos
        }
        if(Controller_Hud.gameOver) //si la función de gameover dle script Controller_Hud es true
        {
            Destroy(this.gameObject); //se destruye el objeto al que se le fue asignado el script (en este caso al enemigo)
        }
    }
}
