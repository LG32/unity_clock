using System;
using UnityEngine;
using XLua;

public class clock : MonoBehaviour
{
    private const float
        DegreesPerHour = 30f,
        
        DegreesPerMinute = 6f,
        
        DegressPerSecond = 6f;

    public Transform hoursTransform;

    public Transform minutesTransform;

    public Transform secondsTransform;

    private LuaEnv _mLuaEnv = null;
    
    // Start is called before the first frame update
    private void Start()
    {
       _mLuaEnv = new LuaEnv();
       UpdateLua();
    }
   
    // Update is called once per frame
    public void Update()
    {
        var time = DateTime.Now;

        var hour = time.Hour;

        var second = time.Second;

        var minutes = time.Minute;

        hoursTransform.localRotation =
                Quaternion.Euler(0f, hour* DegreesPerHour, 0f);

        secondsTransform.localRotation =
                Quaternion.Euler(0f, second* DegressPerSecond, 0f);

        minutesTransform.localRotation =
                Quaternion.Euler(0f, minutes* DegreesPerMinute, 0f);

        Debug.Log(DateTime.Now.Hour);
    }

    private void OnGUI()
    {
        if (GUILayout.Button("按钮1"));
        {
            var luaTable = _mLuaEnv.Global.Get<ITest>("test");
            var renderer = gameObject.GetComponent<Renderer>();
            luaTable.onClick(renderer);
        }
        if (GUILayout.Button("更新Lua"))
        {
            UpdateLua();
        }
    }

    private void UpdateLua()
    {
        _mLuaEnv?.Dispose();
        _mLuaEnv = new LuaEnv();
        _mLuaEnv.AddLoader(XLuaLoader.Loader);
        _mLuaEnv.DoString("require main");
    }
}

[CSharpCallLua]
public interface ITest
{
    void onClick(Renderer renderer);
}
