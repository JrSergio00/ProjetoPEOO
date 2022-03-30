using System;

public class Fabricante {
    private int id;
    private string nome;
    public int Id{
        get => id;
        set =>  id = value;
    }
    public string Nome{
        get => nome;
        set =>  nome = value;
    }
    public Fabricante(){ }
    public Fabricante(int id, string nome){
        this.id = id;
        this.nome = nome;
    }
    public void SetId(int id){
        this.id = id;
    }
    public int GetId(){
        return id;
    }
    public void SetNome(string nome){
        this.nome = nome;
    }
    public string GetNome(){
        return nome;
    }
    public override string ToString()
    {
        return $"{id} - {nome}";
    }

}