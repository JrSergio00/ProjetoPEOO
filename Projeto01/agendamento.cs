using System;

public class Agendamento{
    public int Id {
    get; 
    set;
    }
    public DateTime Data {
    get;
    set;
    }
    public int idProprietario {
    get;
    set;
    }
    public int idProcesso {
    get;
    set;
    }
    public override string ToString() {
        string s = $"{Id} {Data:dd/MM/yyyy HH:mm}";
        if(idProprietario == 0){
            s += " - Disponível";
        }
        return s;
    }
}