using System.IO.Ports;
using System.Threading;
using UnityEngine;
public class Arduino : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";

    private static void DataThread()
    {
        sp = new SerialPort("COM3", 9600); //poort en zens snelheid gelijk aan arduino
        sp.Open();

        while (true)
        {
            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200); //Delay arduino en unity gelijk
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }

    void Start()
    {
        IOThread.Start();
    }



    //vanaf hier aanpasbaar, alles bovenstaand is alleen om werkend te krijgen
    void Update() //check seriele monitor
    {
        if (incomingMsg != " ") //laat binnenkomende berichten zien in de monitor
        {
            Debug.Log(incomingMsg);
        }

        if (incomingMsg == "MNT") //magneet wordt getriggerd
        {
            //In Game Actie bij neerzetten spookje
        }
    }
}




//Uneddited version (raw version)
/*
using System.IO.Ports;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing.Text;
using Unity.VisualScripting;

public class Arduino : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    //private static string outgoingMsg = "";


    private static void DataThread()
    {
        sp = new SerialPort("COM3", 9600);
        sp.Open();

        while (true)
        {
            if (outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                outgoingMsg = "";
            }

incomingMsg = sp.ReadExisting();
Thread.Sleep(200);
        }
    }

    private void OnDestroy()
{
    IOThread.Abort();
    sp.Close();
}

void Start()
{
    IOThread.Start();
}

void Update()
{
    if (incomingMsg != " ")
    {
        Debug.Log(incomingMsg);
    }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                outgoingMsg = "0";
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                outgoingMsg = "1";
            }
    
}
}

*/