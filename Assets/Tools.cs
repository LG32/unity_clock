using System.Collections.Generic;
using System.IO;

public static class Tools
{
    public static string GetFolderPath(DirectoryInfo rootFolder, string targetFolderName)
    {
        var queue = new Queue<DirectoryInfo>();
        queue.Enqueue(rootFolder);
        DirectoryInfo p;

        while (queue.Count > 0)
        {
            p = queue.Dequeue();
            foreach (var item in p.GetDirectories())
            {
                if (item.Name == targetFolderName)
                    return item.FullName;
                else
                    queue.Enqueue(item);
            }
        }
        return null;
    }
}