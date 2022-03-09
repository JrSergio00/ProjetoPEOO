using System;

class Veiculo {
    private int id;
    private int chassi;
    private DateTime AnoFabricacao;
    private string cor;
    private string placa;
    private string modelo;
    private int idFabricante;
    public Veiculo(int id, int chassi, DateTime AnoFabricacao, string cor, string placa, string modelo, int idFabricante){
        this.id = id;
        this.chassi = chassi;
        this.AnoFabricacao = AnoFabricacao;
        this.cor = cor;
        this.placa = placa;
        this.modelo = modelo;
        this.idFabricante = idFabricante;
    }
    public Veiculo(int id){
        this.id = id;
    }

    public void SetId(int id){
        this.id = id;
    }
    public int GetId(){
        return id;
    }
    public void SetChassi(int chassi){
        this.chassi = chassi;
    }
    public int GetChassi(){
        return chassi;
    }
    public void SetAno(DateTime AnoFabricacao){
        this.AnoFabricacao = AnoFabricacao;
    }
    public DateTime GetAno(){
        return AnoFabricacao;
    }
    public void SetCor(string cor){
        this.cor = cor;
    }
    public string GetCor(){
        return cor;
    }
    public void SetPlaca(string placa){
        this.placa = placa;
    }
    public string GetPlaca(){
        return placa;
    }
    public void SetModelo(string modelo){
        this.modelo = modelo;
    }
    public string GetModelo(){
        return modelo;
    }
    public void SetIdFabricante(int idFabricante){
        this.idFabricante = idFabricante;
    }
    public int GetIdFabricante(){
        return idFabricante;
    }
    
    public override string ToString()
    {
        return $"{id:00} -Fabricante: {idFabricante}- {modelo} - {AnoFabricacao:dd/MM/yyyy} - {placa} - {cor} - Chassi: {chassi}";
    }

}