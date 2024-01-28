using UnityEngine;
using System.IO;

public class DeleteDirectory : MonoBehaviour
{
    private string targetDirectory =Path.Combine(Application.persistentDataPath, "recordings"); // 指定目录的路径

    void Start()
    {
        DeleteDirectoryRecursive(targetDirectory);
    }

    private void DeleteDirectoryRecursive(string directoryPath)
    {
        // 检查目录是否存在
        if (Directory.Exists(directoryPath))
        {
            try
            {
                // 删除目录及其所有内容（包括子目录和文件）
                Directory.Delete(directoryPath, true);
                Debug.Log($"Directory {directoryPath} and its contents have been deleted.");
            }
            catch (System.Exception e)
            {
                Debug.LogError($"Error deleting directory: {e.Message}");
            }
        }
        else
        {
            Debug.LogWarning($"Directory does not exist: {directoryPath}");
        }
    }
}