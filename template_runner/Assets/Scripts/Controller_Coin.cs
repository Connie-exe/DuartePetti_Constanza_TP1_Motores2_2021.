using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Coin : MonoBehaviour
{
    //para este código simplemente reutilicé el código de Controller_Enemy y le hice algunos cambios para que funciones con Coins
    public static float coinVelocity; //declara la velocidad de la moneda y public para que se pueda asignar desde unity
    private Rigidbody rb; //declara al rigid body del objeto al que se le asigne el script

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //llama al rigid body del enemigo
    }

    void Update()
    {
        rb.AddForce(new Vector3(-coinVelocity, 0, 0), ForceMode.Force); //la moneda se mueve hacia la izquierda con la fuerza otorgada en el script Controller_Instatior
        OutOfBounds(); //llama a OutofBounds
    }

    public void OutOfBounds()
        //eliminé la condición de que si la moneda tocaba al Player el Player desaparecía, porque ya no tenía sentido
    {
        if (this.transform.position.x <= -15) //si el objeto (moneda) vale menos o igual a -15 en la pantalla (ya no se ve)
        {
            Destroy(this.gameObject); //se destruye la moneda así deja de gastar recursos
        }
    }
}
