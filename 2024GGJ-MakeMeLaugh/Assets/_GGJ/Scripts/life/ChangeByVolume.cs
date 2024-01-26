using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 可以用这个类来通过MicrophoneManager的Volume大小控制物体的大小
/// </summary>
public class ChangeByVolume : MonoBehaviour
{
    public MicrophoneManager microphoneManager;
    private float volume ;
    public int scaleSize = 1;

    void Update()
    {
        volume = microphoneManager.volume*scaleSize;//因为volume太小，所以应当乘一些值来放大
        this.gameObject.transform.localScale = new Vector3(volume,volume);
        
    }
}
