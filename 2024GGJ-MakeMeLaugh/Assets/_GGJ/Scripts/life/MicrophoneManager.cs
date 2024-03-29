using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;


public class MicrophoneManager : MonoBehaviour
{

    public  float volume;
    private AudioSource aud;
    private String device;
    public Text text;
    public float maxY = 0.25f;
    public float minY = 0.01f;

    private float ProCD;
    private float ProCDTime = 0.01f;
    private float maxTime = 4.5f;
    private float closeCD;//保护机制关闭的CD
    private float closeCDTime = 0.3f;//保护机制关闭的CD时间
    private bool isStart;
    private bool reStart;//保护机制的开启判断

    [Header("语音识别")]
    private PhraseRecognizer phraseRecognizer;
    public string[] keywords = {"哈哈","哈","HA"};
    public ConfidenceLevel confidenceLevel = ConfidenceLevel.Medium;

    public bool isHappy = false;

    public int startPostition;
    public int endPostition = 0;
    public UnityEvent delectevent;

    void Awake()
    {
        if(phraseRecognizer == null)
        {
            phraseRecognizer = new KeywordRecognizer(keywords,confidenceLevel);
            phraseRecognizer.OnPhraseRecognized += PhraseRecognizer_OnPhraseRecognized;
            phraseRecognizer.Start();
            Debug.Log("创建成功");
        }
    }
    void Start()
    {
        aud = GetComponent<AudioSource>();

        string[] devices = Microphone.devices;
        
        if(devices.Length > 0)
        {

            device = devices[0];
            Debug.Log("找到麦克风");
        }
        else
        {

            Debug.Log("NO MICROPHONE");
        }

        isStart = false;
        aud.clip = Microphone.Start(device,true,999,44100);

 
    }
    void Update()
    {   
       MicrophoneRecognition(); 
    }
/// <summary>
/// 
/// </summary>
    void MicrophoneRecognition()
    {
        volume = GetMaxVolume();
        if(Input.GetKey(KeyCode.Escape))
        {
            delectevent.Invoke();
            Application.Quit();
        }
        if((volume > minY)&&volume <= maxY)
        {
            
            if(!isStart)
            {//此处留下判断，当在ProCD外还在说话才会开始录音

                startPostition = endPostition;
                Debug.Log("Y"+startPostition);
                isStart = true;
                Debug.Log("开始录音");
            }
            
            if(isStart)
            {
                ProCD += Time.deltaTime;
                if(ProCD >= ProCDTime)
                {
                    if(ProCD <= (ProCDTime + maxTime))
                    {

                        closeCD = 0;
                        reStart = true;


                    }
                    else
                    {
                        ProCD = 0;
                        isStart = false;
                        reStart = false;
                        endPostition = Microphone.GetPosition(device);
                        Debug.Log(endPostition);
                        //呼喊结束，写个方法进行下一步 保存录音
                        SaveRecorder(startPostition,endPostition);

                        Debug.Log("停止录音");
                    }
                }
            }
            
        }
        else
        {
            //判断，断两秒不算断。开关关上
            if (reStart)
            {
                closeCD += Time.deltaTime;
                if (closeCD >= closeCDTime)
                {
                    ProCD = 0;
                    closeCD = 0;
                    isStart = false;
                    reStart = false;
                    endPostition = Microphone.GetPosition(device);
                    Debug.Log(endPostition);
                    //呼喊中断，写个方法进行下一步 保存录音
                    SaveRecorder(startPostition,endPostition);  
                    Debug.Log("停止录音");

                }
            }
 
        }

    }

/// <summary>
/// 获取当前音量，用于判断是否不出声
/// </summary>
/// <returns></returns>
    float GetMaxVolume()
    {
        float maxVolume = 0f;
        float[] volumeData = new float[128];
        int offset = Microphone.GetPosition(device) - 128 + 1;
        if (offset < 0)
        {
            return 0;
        }
        aud.clip.GetData(volumeData, offset);


 
        for (int i = 0; i < 128; i++)
        {
            float tempMax = volumeData[i];//修改音量的敏感值
            if (maxVolume < tempMax)
            {
                maxVolume = tempMax;
            }
        }
        return maxVolume;

    }
    /// <summary>
    /// 保存音频调用的方法
    /// </summary>
    public void SaveRecorder(int startPostition,int endPostition)
    {
        if (aud.clip == null)
        {
            Debug.LogError("AudioClip 为空。录制可能尚未开始。");
            return;
        }
        byte[] wavData = WavUtility.FromAudioClip(aud.clip,startPostition,endPostition);
        


    }

    private void PhraseRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {  
        isHappy = true;
        text.text = args.text + "+1";
    }
    private void OnDestroy()
    {
        if(phraseRecognizer != null)
        {
            phraseRecognizer.Dispose();
        }
    }
}
