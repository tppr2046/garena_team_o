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
    public float speed;    //�]���}���ƫ��ܼơA�i�bunity���]�Ƚվ�
    private void movementt()//��k
    {   //�ĥΪ������ܪ���y�Ъ��覡
        //�@�B�V�k��
        if (Input.GetKey("d"))//��J.�Ӧ���L(��d��)
        {
            this.gameObject.transform.Translate(Vector3.right * Time.deltaTime*speed);
        }  //�����O.�o�Ӫ���.�y�Шt��.�첾(delta�V�q)

        //�G�B�V�����F�̷Ӥ@�B���@�k�|�o�{�����t�ܧ֡A�]���n���WTime.deltaTime�ө���C
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        //�V�W�� //�i�H�����ϥ�Vector���ݩ�Vector2.up�A�N���ݭnnew�@���ܼ�
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        //�V�U��
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }
    private void movement()//��k
    {   //�ĥΪ������ܪ���y�Ъ��覡
        //�V�k��
        if (Input.GetKey("d"))//��J.�Ӧ���L(��d��)
        {
            this.gameObject.transform.position += new Vector3(speed, 0, 0);
        }  //�����O.�o�Ӫ���.�y�Шt��.��m(���@�ӦV�q��x,y,z)+=�o�ӦV�q

        //�V����
        if (Input.GetKey("a"))
        {
            this.gameObject.transform.position -= new Vector3(speed, 0, 0);
        }
        //�V�W��
        if (Input.GetKey("w"))
        {
            this.gameObject.transform.position += new Vector3(0, 0, speed);
        }
        //�V�U��
        if (Input.GetKey("s"))
        {
            this.gameObject.transform.position -= new Vector3(0, 0, speed);
        }

    }
}
