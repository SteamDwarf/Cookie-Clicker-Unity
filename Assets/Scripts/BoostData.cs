using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[System.Serializable]
public class CountBoostData
{
    public string name;
    public float count;
    public float power;

    public CountBoostData(string name, float count, float power)
    {
        this.name = name;
        this.count = count;
        this.power = power;
    }
}