using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarkManager : MonoBehaviour
{

    //�ark Nesnelerini D�nd�rmek
    public int speed=30;
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime); //transform=d�n��t�rmek, forward=Y ekseninde �evir
    }
}
