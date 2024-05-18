using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void Update()
    {
       // movement();
        movementt();
    }
    public float speed;    //設公開的數度變數，可在unity中設值調整
    private void movementt()//方法
    {   //採用直接改變物件座標的方式
        //一、向右走
        if (Input.GetKey("d"))//輸入.來自鍵盤(“d”)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime*speed);
        }  //此類別.這個物件.座標系統.位移(delta向量)

        //二、向左走；依照一、的作法會發現物件飆很快，因此要乘上Time.deltaTime來延遲。
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //向上走 //可以直接使用Vector的屬性Vector2.up，就不需要new一個變數
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //向下走
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }
    private void movement()//方法
    {   //採用直接改變物件座標的方式
        //向右走
        if (Input.GetKey("d"))//輸入.來自鍵盤(“d”)
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }  //此類別.這個物件.座標系統.位置(為一個向量值x,y,z)+=這個向量

        //向左走
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        //向上走
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.position += new Vector3(0, 0, speed);
        }
        //向下走
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.position -= new Vector3(0, 0, speed);
        }

    }
}
