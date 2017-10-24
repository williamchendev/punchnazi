using System;
using UnityEngine;

[Serializable]
public class TextData {

    [SerializeField] private int length;
	[SerializeField] private string[] data1;
    [SerializeField] private string[] data2;
    [SerializeField] private string[] data3;
    [SerializeField] private string[] data4;
    [SerializeField] private string[] data5;
    [SerializeField] private string[] data6;
    [SerializeField] private string[] data7;
    [SerializeField] private string[] data8;
    [SerializeField] private string[] data9;
    [SerializeField] private string[] data10;
    [SerializeField] private string[] data11;
    [SerializeField] private string[] data12;
    [SerializeField] private string[] data13;
    [SerializeField] private string[] data14;
    [SerializeField] private string[] data15;
    [SerializeField] private string[] data16;
    [SerializeField] private string[] data17;
    [SerializeField] private string[] data18;
    [SerializeField] private string[] data19;
    [SerializeField] private string[] data20;
    [SerializeField] private string[] data21;
    [SerializeField] private string[] data22;
    [SerializeField] private string[] data23;
    [SerializeField] private string[] data24;
    [SerializeField] private string[] data25;
    [SerializeField] private string[] data26;
    [SerializeField] private string[] data27;
    [SerializeField] private string[] data28;
    [SerializeField] private string[] data29;
    [SerializeField] private string[] data30;

    public void writeData(string[][] load){
        length = load.Length;
        if (length > 30){
            length = 30;
        }

        int num = 0;
        if (num < length){
            data1 = load[0];
            num++;
        }
        if (num < length){
            data2 = load[1];
            num++;
        }
        if (num < length){
            data3 = load[2];
            num++;
        }
        if (num < length){
            data4 = load[3];
            num++;
        }
        if (num < length){
            data5 = load[4];
            num++;
        }
        if (num < length){
            data6 = load[5];
            num++;
        }
        if (num < length){
            data7 = load[6];
            num++;
        }
        if (num < length){
            data8 = load[7];
            num++;
        }
        if (num < length){
            data9 = load[8];
            num++;
        }
        if (num < length){
            data10 = load[9];
            num++;
        }

        if (num < length){
            data11 = load[10];
            num++;
        }
        if (num < length){
            data12 = load[11];
            num++;
        }
        if (num < length){
            data13 = load[12];
            num++;
        }
        if (num < length){
            data14 = load[13];
            num++;
        }
        if (num < length){
            data15 = load[14];
            num++;
        }
        if (num < length){
            data16 = load[15];
            num++;
        }
        if (num < length){
            data17 = load[16];
            num++;
        }
        if (num < length){
            data18 = load[17];
            num++;
        }
        if (num < length){
            data19 = load[18];
            num++;
        }
        if (num < length){
            data20 = load[19];
            num++;
        }

        if (num < length){
            data21 = load[20];
            num++;
        }
        if (num < length){
            data22 = load[21];
            num++;
        }
        if (num < length){
            data23 = load[22];
            num++;
        }
        if (num < length){
            data24 = load[23];
            num++;
        }
        if (num < length){
            data25 = load[24];
            num++;
        }
        if (num < length){
            data26 = load[25];
            num++;
        }
        if (num < length){
            data27 = load[26];
            num++;
        }
        if (num < length){
            data28 = load[27];
            num++;
        }
        if (num < length){
            data29 = load[28];
            num++;
        }
        if (num < length){
            data30 = load[29];
            num++;
        }
    }

    public string[][] readData(){
        string[][] data = new string[length][];
        int num = 0;
        if (num < length){
            data[0] = data1;
            num++;
        }
        if (num < length){
            data[1] = data2;
            num++;
        }
        if (num < length){
            data[2] = data3;
            num++;
        }
        if (num < length){
            data[3] = data4;
            num++;
        }
        if (num < length){
            data[4] = data5;
            num++;
        }
        if (num < length){
            data[5] = data6;
            num++;
        }
        if (num < length){
            data[6] = data7;
            num++;
        }
        if (num < length){
            data[7] = data8;
            num++;
        }
        if (num < length){
            data[8] = data9;
            num++;
        }
        if (num < length){
            data[9] = data10;
            num++;
        }

        if (num < length){
            data[10] = data11;
            num++;
        }
        if (num < length){
            data[11] = data12;
            num++;
        }
        if (num < length){
            data[12] = data13;
            num++;
        }
        if (num < length){
            data[13] = data14;
            num++;
        }
        if (num < length){
            data[14] = data15;
            num++;
        }
        if (num < length){
            data[15] = data16;
            num++;
        }
        if (num < length){
            data[16] = data17;
            num++;
        }
        if (num < length){
            data[17] = data18;
            num++;
        }
        if (num < length){
            data[18] = data19;
            num++;
        }
        if (num < length){
            data[19] = data20;
            num++;
        }

        if (num < length){
            data[20] = data21;
            num++;
        }
        if (num < length){
            data[21] = data22;
            num++;
        }
        if (num < length){
            data[22] = data23;
            num++;
        }
        if (num < length){
            data[23] = data24;
            num++;
        }
        if (num < length){
            data[24] = data25;
            num++;
        }
        if (num < length){
            data[25] = data26;
            num++;
        }
        if (num < length){
            data[26] = data27;
            num++;
        }
        if (num < length){
            data[27] = data28;
            num++;
        }
        if (num < length){
            data[28] = data29;
            num++;
        }
        if (num < length){
            data[29] = data30;
            num++;
        }

        return data;
    }
}
