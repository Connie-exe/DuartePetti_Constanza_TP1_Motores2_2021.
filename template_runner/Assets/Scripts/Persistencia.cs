using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Persistencia : MonoBehaviour
{
    public static Persistencia instancia;
    public DataPersistencia data;
    string archivoDatos = "save.dat";

    private void Awake()
    {
        if (instancia == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instancia = this;
        }
        else if (instancia != this)
            Destroy(this.gameObject);

        CargarDataPersistencia();
    }

    private void LateUpdate()
    {
        if (Controller_Hud.gameOver) GuardarDataPersistencia(); //si mi juego termina el dato de la persistencia se guarda
    }

    public void GuardarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Datos guardados");
    }

    public void CargarDataPersistencia()
    {
        string filePath = Application.persistentDataPath + "/" + archivoDatos;
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(filePath))
        {
            FileStream file = File.Open(filePath, FileMode.Open);
            DataPersistencia cargado = (DataPersistencia)bf.Deserialize(file);
            data = cargado;
            file.Close();
            Debug.Log("Datos cargados");
        }
    }
}
[System.Serializable]
public class DataPersistencia
{
    public float maxDistance = 0;
    public float record = 0;
    public int vidaJugador = 0;
    public bool puertaAbierta = false;
    public Punto posicionJugador;
    public Punto posicionEnemigo;

    public DataPersistencia()
    {
        maxDistance = 0;
        record = 0;
    }
}

[System.Serializable]
public class Punto
{
    public float x;
    public float y;
    public float z;

    public Punto(Vector3 p)
    {
        x = p.x; y = p.y; z = p.z;
    }

    public Vector3 aVector()
    {
        return new Vector3(x, y, z);
    }
}
