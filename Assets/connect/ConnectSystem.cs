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
    private readonly string url_upload = "http://127.0.0.1:3000/upload";
    // 連線網址(讀取)
    private readonly string url_download = "http://127.0.0.1:3000/download";
    // 要儲存的物件
    public GameObject gameObject;

    public void Upload(GameObject gameObject)
    {
        Debug.Log("Upload GameObject");
        string str = serializeGameObject(gameObject);
        sendDataToServer(str);
    }

    private string serializeGameObject(GameObject gameObject)
    {
        SerializableGameObjectArray serializableGameObjectArray = new SerializableGameObjectArray(gameObject);
        string str = JsonUtility.ToJson(serializableGameObjectArray);
        Debug.Log("serializeGameObject str:" + str);
        return str;
    }


    private async Task<string> sendDataToServer(string data)
    {
        try
        {
            // 發送 POST 請求
            HttpResponseMessage response = await client.PostAsync(url_upload, new StringContent(data));
            // 確認是否成功
            response.EnsureSuccessStatusCode();
            // 讀取回應內容
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log("sendDataToServer responseBody:" + responseBody);
            // 回傳回應內容
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request failed: {e.Message}");
            return null;
        }
    }

    public async Task<SerializableGameObjectArray> Download()
    {
        Debug.Log("Download GameObject");
        // 從 server 端取得資料
        string response = await getDataFromServer();
        // 將資料轉換成物件並回傳
        return JsonUtility.FromJson<SerializableGameObjectArray>(response);
    }

    // 從 server 端取得資料
    private async Task<string> getDataFromServer()
    {
        try
        {
            // 發送 GET 請求
            HttpResponseMessage response = await client.GetAsync(url_download);
            // 確認是否成功
            response.EnsureSuccessStatusCode();
            // 讀取回應內容
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.Log("getDataFromServer responseBody:" + responseBody);
            // 回傳回應內容
            return responseBody;
        }
        catch (HttpRequestException e)
        {
            Debug.LogError($"Request failed: {e.Message}");
            return null;
        }
    }

    // 用來將物件實例化的範例
    private void createGameObject(SerializableGameObject serializableGameObject)
    {
        GameObject newGameObject;
        // 依照名稱來決定要實例化的物件
        if (serializableGameObject.name == "Cube")
        {
            newGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        }
        else if (serializableGameObject.name == "Sphere")
        {
            newGameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }
        else if (serializableGameObject.name == "Capsule")
        {
            newGameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        }
        else
        {
            newGameObject = new GameObject();
        }
        // 設定物件的位置與旋轉
        newGameObject.transform.position = serializableGameObject.position;
        newGameObject.transform.rotation = serializableGameObject.rotation;
    }

}
