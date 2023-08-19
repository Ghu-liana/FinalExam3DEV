using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class Controller_movement : MonoBehaviour
{
    // FOR CONTROLS
    public float speed;
    private float amountToMove;
    public SerialPort sp = new SerialPort("COM3", 9600);

    
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1; // if this is higher Unity might freeze trying to read the Serial Port

        

    }

    void Update()
    {
        amountToMove = speed * Time.deltaTime;
        int x = sp.ReadByte();

        if (sp.IsOpen)
        {
            try
            {
                if (x == 1)
                {
                    transform.Translate(Vector3.left * amountToMove, Space.World);  // could be key to first person movement to make it turn around itself
                }
                if (x == 2)
                {
                    transform.Translate(Vector3.right * amountToMove, Space.World);
                }
                if(x == 3)
                {
                    transform.Translate(Vector3.back * amountToMove, Space.World);
                }
                if(x == 4)
                {
                    transform.Translate(Vector3.forward * amountToMove, Space.World);
                }
                //print(sp.ReadByte());
            }
            catch (System.Exception)
            {

                
            }
        }
    }

    

    //void MoveObject(int Direction)
    //{
    //    if(x == 1)
    //    {
    //        transform.Translate(Vector3.left * amountToMove, Space.World);  
    //    }
    //    if(x == 2)
    //    {
    //        transform.Translate(Vector3.right * amountToMove, Space.World);
    //    }
    //}
}
