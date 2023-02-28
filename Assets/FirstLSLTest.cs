using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using LSL;
using LSL4Unity.Utils;
using HCIUD.HoloLSL;

public class FirstLSLTest : AFloatOutlet
{
    [Header("Synchronized Transform")]
    [SerializeField]
    private Transform _cube;


    public override List<string> ChannelNames
    {
        get { return new List<string>(new string[] { "x", "y", "z" }); }
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Debug.Log("Try to connect LSL: " + LSL.LSL.library_version());
        Debug.Log(outlet.ToString());
        //Reset();
    }

    // Update is called once per frame
    protected override bool BuildSample()
    {
        Debug.Log(outlet.ToString());
        //var values = Camera.main.transform.position;
        //var values = transform.position;
        
        if(GlobalReferences.instance != null)
        {
            //var values = _cube.position;
            //var values = GlobalReferences.instance._localPlayer.transform.position;
            var values = transform.position;
            //Debug.Log(values);
            sample[0] = values.x;
            sample[1] = values.y;
            sample[2] = values.z;
        }      

        return true;
    }
}
