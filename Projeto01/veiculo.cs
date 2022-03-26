using System;

class Veiculo {
    private int id;
    private int chassi;
    private int AnoFabricacao;
    private string cor;
    private string placa;
    private string modelo;
    private int idFabricante;
    private int idProprietario;
    public Veiculo(int id, int chassi, int AnoFabricacao, string cor, string placa, string modelo, int idFabricante, int idProprietario){
        this.id = id;
        this.chassi = chassi;
        this.AnoFabricacao = AnoFabricacao;
        this.cor = cor;
        this.placa = placa;
        this.modelo = modelo;
        this.idFabricante = idFabricante;
        this.idProprietario = idProprietario;
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
    public void SetAno(int AnoFabricacao){
        this.AnoFabricacao = AnoFabricacao;
    }
    public int GetAno(){
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
    public void SetIdProprietario(int idProprietario){
        this.idProprietario = idProprietario;
    }
    public int GetIdProprietario(){
        return idProprietario;
    }
    
    public override string ToString()
    {
        return $"{id:00} - {modelo} - {cor} - {AnoFabricacao} - {placa} - Chassi: {chassi} - Propietário: {idProprietario} - Fabricante: {idFabricante} ";
    }

}