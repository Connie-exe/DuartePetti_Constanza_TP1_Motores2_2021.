using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb; //llama al rigid body al que se le asigne el script en este caso el jugador
    public float jumpForce = 10; //public para poder asignar el valor de la fuerza desde unity según la conveniencia y float porque puede no ser exacto (int)
    private float initialSize; //float porque puede no ser exacto (int) y private porque solo la utilizaremos en visual
    private int i = 0; // int porque e sun valor exacto y private porque solo la utilizaremos en visual 
    private bool floored; // private porque solo la utilizaremos en visual y bool porque puede estar o no en el suelo, no las doas cosas, este caso

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //llama al rigid body del jugador
        initialSize = rb.transform.localScale.y; //define el tamaño en y que tiene (el largo)
    }

    void Update()
    {
        GetInput(); //llama a getinput 
    }

    private void GetInput()
    {
        Jump(); //llama a jump 
        Duck(); //llama a duck 
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W)) //si se presiona w
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //la posición en del jugador cambia en y con el valor de la fuerza que se le otorgó
            }
        }
    }

    private void Duck()
    {
        if (floored) //si está en el suelo
        {
            if (Input.GetKey(KeyCode.S)) //si apreta la tecla s
            {
                if (i == 0) //si i es igual a 0
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z); //el tamaño del jugador cambia en y (se hace más corto)
                    i++; //i aumenta en 1
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize) //si el tamaño del jugador es diferente al inicial
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z); //el jugador vuelve a su tamaño inicial en y
                    i = 0; // i vuelve a valer 0
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S)) //si se presiona la tecla s y no está tocando el suelo
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse); //se resta la fuerza de salto del jugador así vuelve a su posición inicial
            }
        }
    }

    public void OnCollisionEnter(Collision collision) //si el objeto del script colisiona con...
    {
        if (collision.gameObject.CompareTag("Enemy")) // si colisiona con un objeto de etiqueta enemy
        {
            Destroy(this.gameObject); //obejto (jugador) de destruye
            Controller_Hud.gameOver = true; //se llama a Controller.gameover y se lo cambia a true
        }

        if (collision.gameObject.CompareTag("Floor")) //si el objeto (jugador) colisiona con el objeto de etiqueta floor
        {
            floored = true; //el bool de floored pasa a ser true
        }

        if(collision.gameObject.CompareTag("Bubble")) //si el objeto (jugador) colisiona con el objeto de etiqueta bubble
        {
            //if (ProgressBar.timeLeft <= ProgressBar.maxTime)
            {
                ProgressBar.timeLeft = ProgressBar.timeLeft + 10f; //a la progressbar se le agrega 10f, haciendo que dure más
            }
            Destroy(collision.gameObject); //luego de collisionar el objeto con el que se hace collision se destruye

        }
        if (collision.gameObject.CompareTag("Coin")) //si el objeto (jugador) colisiona con el objeto de etiqueta coin
        {
            {
                FindObjectOfType<GameManager>().AddGold(); //se llama a la función AddGold del GameManager
            }
            Destroy(collision.gameObject); //luego de collisionar el objeto con el que se hace collision se destruye

        }
    }

    private void OnCollisionExit(Collision collision) //cuando se sale de la colision...
    {
        if (collision.gameObject.CompareTag("Floor")) //si el objeto (jugador) deja de colisionar con el objeto de etiqueta floor
        {
            floored = false; // el bool floor pasa a ser false
        }
    }
}
