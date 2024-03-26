using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vectores : MonoBehaviour
{
    class Vector3
    {
        float x, y, z;
        public float Magnitud()
        {
            float Step1 = (this.x * this.x) + (this.y * this.y) + (this.z * this.z);
            double Step2 = Mathf.Sqrt(Step1);
            float Step3 = (float)Step2;
            return Step3;
        }
        public Vector3 Normalizar()
        {
            Vector3 r = new Vector3(0, 0, 0);

            float Step1 = (this.x * this.x) + (this.y * this.y) + (this.z * this.z);
            double Step2 = Mathf.Sqrt(Step1);
            float Step3 = (float)Step2;

            r.x = this.x / Step3;
            r.y = this.y / Step3;
            r.z = this.z / Step3;

            return r;
        }
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Vector3 operator +(Vector3 V1, Vector3 V2)
        {
            Vector3 R = new Vector3(0, 0, 0);
            R.x = V1.x + V2.x;
            R.y = V1.y + V2.y;
            R.z = V1.z + V2.z;
            return R;
        }
        public static Vector3 operator -(Vector3 V1, Vector3 V2)
        {
            Vector3 R = new Vector3(0, 0, 0);
            R.x = V1.x - V2.x;
            R.y = V1.y - V2.y;
            R.z = V1.z - V2.z;
            return R;
        }
        public static Vector3 operator *(Vector3 V1, float k)
        {
            Vector3 R = new Vector3(0, 0, 0);
            R.x = V1.x * k;
            R.y = V1.y * k;
            R.z = V1.z * k;
            return R;
        }
        public static Vector3 operator /(Vector3 V1, Vector3 V2)
        {
            Vector3 R = new Vector3(0, 0, 0);

            R.x = (V1.y * V2.z) - (V1.z * V2.y);
            R.y = (V1.z * V2.x) - (V1.x * V2.z);
            R.z = (V1.x * V2.y) - (V1.y * V2.x);

            return R;
        }
        public static float operator *(Vector3 V1, Vector3 V2)
        {
            float R;

            R = (V1.x * V2.x) + (V1.y * V2.y) + (V1.z * V2.z);

            return R;
        }
        public static float operator ^(Vector3 V1, Vector3 V2)
        {
            float R;

            float N1 = V1 * V2;
            float N2 = V1.Magnitud();
            float N3 = V2.Magnitud();
            float N4 = N1 / (N2 * N3);

            double RTemp = (Mathf.Acos(N4) * 180) / Mathf.PI;
            R = (float)RTemp;

            Debug.Log("El angulo entre vectores es: " + R);

            return R;
        }
        public static bool operator ==(Vector3 V1, Vector3 V2)
        {
            bool R = true;

            if (V1.x == V2.x && V1.y == V2.y && V1.z == V2.z)
            {
                R = true;
            }
            else
            {
                R = false;
            }

            return R;
        }
        public static bool operator !=(Vector3 V1, Vector3 V2)
        {
            bool R = false;

            if (V1.x != V2.x || V1.y != V2.y || V1.z != V2.z)
            {
                R = false;
            }
            else
            {
                R = true;
            }
            return R;

        }
    }
    class Vector2
    {
        float x, y;
        public float Magnitud()
        {
            float Step1 = (this.x * this.x) + (this.y * this.y);
            double Step2 = Mathf.Sqrt(Step1);
            float Step3 = (float)Step2;
            Debug.Log(Step3);
            return Step3;
        }
        public Vector2 Normalizar()
        {
            Vector2 r = new Vector2(0, 0);

            float Step1 = (this.x * this.x) + (this.y * this.y);
            double Step2 = Mathf.Sqrt(Step1);
            float Step3 = (float)Step2;

            r.x = this.x / Step3;
            r.y = this.y / Step3;

            return r;
        }
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 operator +(Vector2 V1, Vector2 V2)
        {
            Vector2 R = new Vector2(0, 0);
            R.x = V1.x + V2.x;
            R.y = V1.y + V2.y;
            return R;
        }
        public static Vector2 operator -(Vector2 V1, Vector2 V2)
        {
            Vector2 R = new Vector2(0, 0);
            R.x = V1.x - V2.x;
            R.y = V1.y - V2.y;
            return R;
        }
        public static Vector2 operator *(Vector2 V1, float k)
        {
            Vector2 R = new Vector2(0, 0);
            R.x = V1.x * k;
            R.y = V1.y * k;
            return R;
        }
        public static bool operator ==(Vector2 V1, Vector2 V2)
        {
            bool R = true;

            if (V1.x == V2.x && V1.y == V2.y)
            {
                R = true;
            }
            else
            {
                R = false;
            }

            return R;
        }
        public static bool operator !=(Vector2 V1, Vector2 V2)
        {
            bool R = false;

            if (V1.x != V2.x || V1.y != V2.y)
            {
                R = false;
            }
            else
            {
                R = true;
            }
            return R;

        }
        public static float operator /(Vector2 V1, Vector2 V2)
        {
            float R;

            R = (V1.x * V2.y) - (V1.y * V2.x);

            return R;
        }
        public static float operator *(Vector2 V1, Vector2 V2)
        {
            float R;

            R = (V1.x * V2.x) + (V1.y * V2.y);

            return R;
        }
        public static float operator ^(Vector2 V1, Vector2 V2)
        {
            float R;

            float N1 = V1 * V2;
            float N2 = V1.Magnitud();
            float N3 = V2.Magnitud();
            float N4 = N1 / (N2 * N3);

            double RTemp = (Mathf.Acos(N4) * 180) / Mathf.PI;
            R = (float)RTemp;

            Debug.Log("El angulo entre vectores es: " + R);

            return R;
        }
    }
    void Start()
    {
        //   VECTOR3 ZONELAB
        Debug.Log("-----------VECTOR3 ZONELAB------------B");

        Vector3 a, b, c, w, v, e;

        float k = 5;

        a = new Vector3(5, 6, 7);
        b = new Vector3(2, 5, 4);

        c = a + b;
        w = a - b;
        v = a * k;

        e = v.Normalizar();

        if (a == b)
        {
            Debug.Log("a y b son iguales.");
        }
        else
        {
            Debug.Log("a y b son diferentes.");
        }

        Vector3 R1 = a / b;  //El operador " / " halla el Producto Cruz

        float R2 = a * b;    //El operador " * " halla el Producto Punto

        float R3 = a ^ b;    //El operador " ^ " halla el Ángulo Entre Dos Vectores

        // VECTOR2 ZONELAB
        Debug.Log("-----------VECTOR2 ZONELAB------------");

        Vector2 z, x, y, i, j, l;

        z = new Vector2(2, 7);
        x = new Vector2(5, 0);

        y = z + x;
        i = z - x;
        j = z * k;

        l = j.Normalizar();

        if (z == x)
        {
            Debug.Log("z y x son iguales.");
        }
        else
        {
            Debug.Log("z y x son diferente.");
        }

        float R4 = z / x;

        float R5 = z * x;

        float R6 = z ^ x;
    }
}