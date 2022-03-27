using System;

class Processo{
    public int Id {
    get; 
    set;
    }
    public string Descricao {
    get;
    set;
    }
    public string Status {
    get;
    set;
    }
    public DateTime Inicio {
    get;
    set;
    }
    public override string ToString()
    {
        return $"{Id} - {Descricao} - {Status} - Inicio em: {Inicio}";
    }
}