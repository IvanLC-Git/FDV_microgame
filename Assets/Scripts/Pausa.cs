using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public GameObject pausa;
    public static bool estaPausado = false;

    void Awake()
    {
        pausa = GameObject.FindWithTag("Pausa");
    }

    // Start is called before the first frame update
    void Start()
    {
        pausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(estaPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        pausa.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;
    }

    public void Continuar()
    {
        pausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void Reiniciar()
    {
        Player.SCORE = 0;
        SceneManager.LoadScene("SampleScene");
        Continuar();
    }

    public void Salir()
    {
        Application.Quit();
    }
}
