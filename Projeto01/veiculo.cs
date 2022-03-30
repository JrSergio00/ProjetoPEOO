using System;

public class Veiculo {
    private int id;
    private int chassi;
    private int anoFabricacao;
    private string cor;
    private string placa;
    private string modelo;
    private int idFabricante;
    private int idProprietario;

    public int Id{
        get => id;
        set => id = value;
    }
    public int Chassi{
        get => chassi;
        set => chassi = value;
    }
    public int AnoFabricacao{
        get => anoFabricacao;
        set => anoFabricacao = value;
    }
    public string Cor{
        get => cor;
        set => cor = value;
    }
    public string Placa{
        get => placa;
        set => placa = value;
    }
    public string Modelo{
        get => modelo;
        set => modelo = value;
    }
    public int IdFabricante{
        get => idFabricante;
        set => idFabricante = value;
    }
    public int IdProprietario{
        get => idProprietario;
        set => idProprietario = value;
    }
    public Veiculo(){ }
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
        return $"{id:00} - {modelo} - {cor} - {AnoFabricacao} - {placa} - Chassi: {chassi}";
    }
}