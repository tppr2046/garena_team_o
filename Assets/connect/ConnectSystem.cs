using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ConnectSystem : MonoBehaviour
{
    public static ConnectSystem instance = new ConnectSystem();
    // http 連線物件
    private HttpClient client = new HttpClient();
    // 連線網址(儲存)
    private readonly string url_save = "http://127.0.0.1:3000/save";
    // 連線網址(讀取)
    private readonly string url_load = "http://127.0.0.1:3000/load";

    public void Save(GameObject gameObject)
    {
        string str = SerializeGameObject(gameObject);
        SendDataToServer(str);
    }

    private string SerializeGameObject(GameObject gameObject)
    {
        SerializableGameObject serializableGameObject = new SerializableGameObject(gameObject);
        return JsonUtility.ToJson(serializableGameObject);
    }


    private async Task<string> SendDataToServer(string data)
    {
        try
        {
            // 發送 POST 請求
            HttpResponseMessage response = await client.PostAsync(url_save, new StringContent(data));
            // 確認是否成功
            response.EnsureSuccessStatusCode();
            // 讀取回應內容
            string responseBody = await response.Content.ReadAsStringAsync();
            // 回傳回應內容
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request failed: {e.Message}");
            return null;
        }
    }

    public async Task<SerializableGameObject> load()
    {
        string response = await GetDataFromServer();
        Debug.Log("response" + response);
        SerializableGameObject serializableGameObject = JsonUtility.FromJson<SerializableGameObject>(response);
        return serializableGameObject;
    }

    // 從 server 端取得資料
    private async Task<string> GetDataFromServer()
    {
        try
        {
            // 發送 GET 請求
            HttpResponseMessage response = await client.GetAsync(url_load);
            // 確認是否成功
            response.EnsureSuccessStatusCode();
            // 讀取回應內容
            string responseBody = await response.Content.ReadAsStringAsync();
            // 回傳回應內容
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request failed: {e.Message}");
            return null;
        }
    }

}
