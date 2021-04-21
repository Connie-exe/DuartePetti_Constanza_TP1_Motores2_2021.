using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //para poder usar los objetos de la ui

public class ProgressBar : MonoBehaviour
{
    public Image timeBar; //se declara una imagen de la ui
    public static float maxTime = 50f; // de declara un float porque el tiempo no es un número exacto (int) y es público así se puede modificar desde unity
    public static float timeLeft; //un float con el tiempo retante porque no es un numero exacto (int)



    void Start()
    {
        timeBar = GetComponent<Image>();// se llama al componente imagen
        timeLeft = maxTime; //al principio el tiempo restante es igual al tiempo máximo que tiene el juego
    }


    void Update()
    {
        GetCurrentFill(); //llama a gercurrentfill
    }

    public void GetCurrentFill()
    {
        if(timeLeft > 0) //si el tiempo restante es mayor a 0
        {
            timeLeft -= Time.deltaTime; //al tiempo restante se le comienza a restar el tiempo que pasa en unity
            timeBar.fillAmount = timeLeft / maxTime; // y el porcentaje de llenado de la imagen en la ui corresponde a la división entre el tiempo restante y el tiempo máximo
        }
        else //si el tiempo llega a no ser mayor a 0
        {
            Controller_Hud.gameOver = true; //la función de game over del script contoller_Hud se llama y el juego termina
        }
    }
}
