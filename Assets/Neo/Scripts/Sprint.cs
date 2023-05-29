using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float decreaseRate = 1f;
    public float variableValue = 5f;

    public static bool isAbleSprint = false;

    private void Update()
    {
        // Mengurangi nilai variabel seiring berjalannya waktu
        variableValue -= decreaseRate * Time.deltaTime;

        // Mengecek apakah nilai variabel telah mencapai 0 atau kurang
        if (variableValue <= 0f)
        {
            isAbleSprint = true;
            variableValue = 0f;
        }
    }
}
