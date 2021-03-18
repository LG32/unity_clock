using System;
using System.IO;
using UnityEngine;

public static class XLuaLoader
{
    private static string mLuaScriptsPath = XLuaLoader.GetScriptsPath();

    private static string GetScriptsPath()
    {
        return Tools.GetFolderPath(new DirectoryInfo(Application.dataPath), "LuaScripts");
    }

    public static byte[] Loader(ref string path)
    {
        if (mLuaScriptsPath == null)
            throw new Exception("没有找到LuaScripts");
        else
        {
            try
            {
                return File.ReadAllBytes(XLuaLoader.GetScriptsPath() + "/" + path + ".lua");
            }
            catch
            {
                throw new Exception("LuaScripts 目录下不存在：" + path + ".lua");
            }
        }
            
    }
}