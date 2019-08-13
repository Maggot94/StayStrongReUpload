using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tienda : MonoBehaviour
{
    public void tienda()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Tienda");
    }

}
