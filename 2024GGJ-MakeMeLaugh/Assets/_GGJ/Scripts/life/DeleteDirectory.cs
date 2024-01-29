using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class DeleteDirectory : MonoBehaviour
{
    private string targetDirectory ;

    void Awake()
    {
        targetDirectory = Path.Combine(Application.persistentDataPath, "recordings");
    }

    public void DeleteDirectoryRecursive()
    {
        
        // 检查目录是否存在
        if (Directory.Exists(targetDirectory))
        {
            try
            {
                // 删除目录及其所有内容（包括子目录和文件）
                Directory.Delete(targetDirectory, true);
                Debug.Log($"Directory {targetDirectory} and its contents have been deleted.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error deleting directory: {e.Message}");
            }
        }
        else
        {
            Debug.LogWarning($"Directory does not exist: {targetDirectory}");
        }
    }
}