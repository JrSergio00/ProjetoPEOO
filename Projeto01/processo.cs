using System;

public class Processo{
    public int Id {
    get; 
    set;
    }
    public int IdProprietario {
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
    public Processo(){ }
    
    public override string ToString()
    {
        return $"{Id} - Referente ao proprietário: {IdProprietario} - {Descricao} - {Status} - Inicio em: {Inicio}";
    }
}