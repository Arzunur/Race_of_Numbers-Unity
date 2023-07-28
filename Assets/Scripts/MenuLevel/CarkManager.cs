using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarkManager : MonoBehaviour
{

    //Çark Nesnelerini Döndürmek
    public int speed=30;
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime); //transform=dönüþtürmek, forward=Y ekseninde çevir
    }
}
