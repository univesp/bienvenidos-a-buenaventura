[System.Serializable]
public class Dialogos
{
    public string nomePersonagem;
    public bool jogadorFala;
    public bool animacaoTroca;
    public string expressao;
    public string[] fala;
}

[System.Serializable]
public class DialogoRoot
{
    public Dialogos[] dialogo;
}