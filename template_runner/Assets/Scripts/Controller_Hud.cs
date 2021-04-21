using UnityEngine;
using UnityEngine.UI; //para poder trabajar con objetos de la ui

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false; //se declara el valor del bool de gameover como false porque no se perdió todavía
    public Text distanceText; // se llama al objeto de la ui como public para asignarlo el unity
    public Text gameOverText; //idem arriba
    private float distance = 0; // se declara la distancia como float porque no e sun númeor exacto (int)
    public float rounded; //declaro un nuevo valor float para poder usarlo sin perjudicar el sistema de medición de distancia
    public float highscore = 0f;
    public Text Highscore;

    void Start()
    {
        gameOver = false; //el gameover sigue siendo false
        distance = 0; //la distancia sigue valiendo 0
        distanceText.text = distance.ToString(); //se traspasa el valor de la distancia a string para que pueda verse en el text de la ui
        gameOverText.gameObject.SetActive(false); //se desactiva el tento de gameover para que no se vea en pantalla
        /*PlayerPrefs.SetFloat("Record", 0f)*/;
        Highscore.text = "RECORD: " + PlayerPrefs.GetFloat("MaxValor", 0).ToString();
    }

    void Update()
    {
        if (gameOver) //si gameover para a ser true o si el tiempo restante es menor o igual a 0
        {
            Time.timeScale = 0; //el time.timeScae pasa a valer 0
            gameOverText.text = "Game Over \n Total Distance: " + rounded.ToString(); // se setea lo que el texto de gameover dirá y se le agrega el valor de distancia redondeado que tenía el jugador nates de perder
            gameOverText.gameObject.SetActive(true); //y se activa el texto de gameover para que se vea ne pantalla
        }
        else  //si gameover es false
        {
            distance += Time.deltaTime; //la distancia equivale a la cantidad de tiempo que pasa
            rounded = Mathf.Round(distance); //mathf.round redondea con la lógica de que si es .4 redondea para abajo y si es .5 redondea para arriba
            distanceText.text = rounded.ToString(); //se muestra en pantalla en forma de string el valor de distancia (ahora redondeado), a todo momento
        
        }
    }

    public void Record()
    {
        if (rounded > PlayerPrefs.GetFloat("MaxValor", 0))
        {
            highscore = rounded;
            PlayerPrefs.SetFloat("MaxValor", highscore);
            Highscore.text = "RECORD: " + highscore.ToString();
        }
    }
}
