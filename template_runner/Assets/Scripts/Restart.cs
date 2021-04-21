using UnityEngine;
using UnityEngine.SceneManagement; //para poder llamar a escenas de unity

public class Restart : MonoBehaviour
{
    void Update()
    {
        GetInput(); //llama a getinput
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.R)) //si se presiona la tecla r
        {
            Time.timeScale = 1; ///el cronómetro pasa a 1
            SceneManager.LoadScene(0); //se carga nuevamente la escena
        }
    }
}
 