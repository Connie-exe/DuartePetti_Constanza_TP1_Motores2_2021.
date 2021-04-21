using System.Collections.Generic;
using UnityEngine;

public class Controller_Instantiator : MonoBehaviour
{
    public List<GameObject> enemies; //genera un lista de enemigos de forma public para poder asignarlos en unity
    public GameObject instantiatePos; //se declara la posicion inicial del instantiatepos, public así se puede hacer desde unity y se usa al mismo object para todas las funciones del instantiator
    public GameObject instantiatePos2;
    public GameObject coins;
    public float respawningTimer2;
    //para instantiatePos2, coins y respawningTimer2 utilicé la misma lógica que para el spawn de los enemigos
    public float respawningTimer; //se declara el tiempo para respawnear float porque puede no ser un numero exacto (int) y public así se puede cambiar desde unity
    private float time = 0; //se declara el tiempo float porque el tiempo nunca es exacto

    void Start()
    {
        Controller_Enemy.enemyVelocity = 2; //se setea la velocidad del enemigo (valor del script Controller_Enemy)
    }

    void Update()
    {
        SpawnEnemies(); //llama a SpawnEnemies
        ChangeVelocity(); //llama a ChangeVelocity
        SpawnCoins(); //llama a SpawnCoins
    }

    private void ChangeVelocity()
    {
        time += Time.deltaTime; //el tiempo aumenta según el tiempo que transcurre en unity
        Controller_Enemy.enemyVelocity = Mathf.SmoothStep(1f, 15f, time / 45f); //la velocidad del enemigo varía según el Mathf.SmoothStep que hace que varíe desde el valor de inicio (1f) al valor de fin (15f) con "la velocidad" a la que lo hará (time/45f)
    } //el smoothstep crea una apariencia natural al movimiento del personaje (todo trabajo de unity WOW!)

    private void SpawnEnemies()
    {
        respawningTimer -= Time.deltaTime; //el repawningTimer comienza en 0 y se le resta el time.deltatime

        if (respawningTimer <= 0) //si el repawningTimer vale menos o igual que 0
        {
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], instantiatePos.transform); //se llama a un enemigo random entre 0 el númeor máximo de la lista y se lo coloca en la posición del intantiatePos
            respawningTimer = UnityEngine.Random.Range(2, 6); //se iguala el repawningtimer a un numero random en tre 2 y 5 (6) para que otra vez se pueda comenzar a restar el time.deltatime
        }
        //de esta forma los enemigos varían y pueden esta o muy pegados entre sí o muy separados WOW!
    }

    public void SpawnCoins()
    {
        respawningTimer2 -= Time.deltaTime; //el repawningTimer2 comienza en 0 y se le resta el time.deltatime

        if (respawningTimer2 <= 0) //si el repawningTimer2 vale menos o igual que 0
        {
            Instantiate(coins, instantiatePos2.transform); //se llama a la moneda en sí porque ya no se trabaja con una lista se lo coloca en la posición del intantiatePos
            respawningTimer2 = UnityEngine.Random.Range(3, 10); //se iguala el repawningtimer a un numero random en tre 2 y 5 (6) para que otra vez se pueda comenzar a restar el time.deltatime
        }
    }


}
