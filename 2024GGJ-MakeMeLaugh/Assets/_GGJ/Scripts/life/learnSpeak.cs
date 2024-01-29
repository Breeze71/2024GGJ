using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace V
{
    public class learnSpeak : MonoBehaviour
    {
        private string folderPath;

        private AudioSource audioSource;
        void Awake()
    {
        folderPath = Path.Combine(Application.persistentDataPath, "recordings");
    }

        public void StartLearnSpeak()
    {
        audioSource = GetComponent<AudioSource>();

        // 获取指定文件夹中的所有WAV文件
        string[] wavFiles = Directory.GetFiles(folderPath, "*.wav");

        // 检查文件夹中是否有WAV文件
        if (wavFiles.Length > 0)
        {
            // 随机选择一个WAV文件
            string randomWavFile = wavFiles[Random.Range(0, wavFiles.Length)];

            // 加载并播放选择的WAV文件
            audioSource.clip = WavUtility.ToAudioClip(randomWavFile);

            audioSource.Play();
            
        }
        else
        {
            Debug.LogWarning("No WAV files found in the specified folder.");
        }

    }



    }
}
