using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject cam; //la cámara en public para poder asignarla en unity
    private float length, startPos; //el largo y la posicion  float porque no son numeros exactos (int) y private porque solo los utilizaremos en visual
    public float parallaxEffect; //public para poder asignarlo ne unity y float porque no es un excato (int)

    void Start()
    {
        startPos = transform.position.x; //toma la posicion inicial del fondo
        length = GetComponent<SpriteRenderer>().bounds.size.x; //busca el sprite del fondo .bounds.size.x va a darnos el tamaño de x o el largo en x
    }

    void Update()
    {
        if (Controller_Hud.gameOver == false) //si aún no se ha perdido el juego (según los parámetros de la función Controller_Hud.gameOver
        {
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z); //a la posicion x del fondo le resta el parallaxeffect correspondiente
            if (transform.localPosition.x < -20) //si la posición del fondo es menor a -20
            {
                transform.localPosition = new Vector3(20, transform.localPosition.y, transform.localPosition.z); //la posicion x se tranforma a la posicion de inicio de uno de los fondos (porque todos miden 20 en x)
            }
        }
        else //en caso contrario
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z); //el fondo de quedará en la posición en la que el jugador perdió
        }
    }
}
