using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI; //para poder usar los elementos de la ui


public class GameManager : MonoBehaviour
{
    public int currentGold = 0; //se inicializa currentgold para almacenar la cantidad de monedas 
    public Text Points; //se declara el text public para poder asignar la ui desde unity

    void Start()
    {
        Points.text = "POINTS: " + currentGold; //se inicializa el texto con el valor default de currentgold
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void AddGold()
    {
        currentGold++;//se agrega 1 al valor de currentgold
        Points.text = "POINTS: " + currentGold; //se actualiza el valor de currentgold y se muestra en el text de la ui
    }
 
}
