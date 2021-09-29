[System.Serializable]
public class Aeroportos
{
    public string estado;
    public string iata;
}

[System.Serializable]
public class AeroportosRoot
{
    public Aeroportos[] aeroportos;
}