using System;
using System.Collections.Generic;

class Sistema{
    private static Fabricante[] fabricantes = new Fabricante[10];
    private static int nFabricante;
    private static List<Veiculo> veiculos = new List<Veiculo>();
    private static List<Proprietario> proprietarios = new List<Proprietario>();
    private static List<Processo> processos = new List<Processo>();
    public static void InserirFabricante(Fabricante x) {
        if (nFabricante == fabricantes.Length){
            Array.Resize(ref fabricantes, 2 * fabricantes.Length);
        }
        fabricantes[nFabricante] = x;
        nFabricante ++;
    }
    public static Fabricante[] ListarFabricante(){
        Fabricante[] aux = new Fabricante[nFabricante];
        Array.Copy(fabricantes, aux, nFabricante);
        return aux;
    }
    public static Fabricante ListarFabricante(int id){
        foreach(Fabricante x in fabricantes)
            if (x != null && x.GetId() == id) return x;
        return null;
    }
    public static void AtualizarFabricante(Fabricante x){
        Fabricante aux = ListarFabricante(x.GetId());
        if (aux != null)
            aux.SetNome(x.GetNome());
    }
    public static void ExcluirFabricante(Fabricante x){
        int y = IndiceFabricante(x.GetId());
        if (y != -1){
            for(int i = y; i < nFabricante - 1; i++)
                fabricantes[i] = fabricantes[i+1];
            nFabricante--;
        }
    }
    private static int IndiceFabricante(int id) {    
        for(int i = 0; i < nFabricante; i++) {
        Fabricante x = fabricantes[i];
        if (x.GetId() == id) return i;
        }
        return -1;
    }

    // Veiculos
    public static void InserirVeiculo(Veiculo x) {
        veiculos.Add(x);
    }
    public static List<Veiculo> ListarVeiculos(){
        return veiculos;
    }
    public static List<Veiculo> ListarVeiculos(Proprietario proprietario){
        List<Veiculo> z = new List<Veiculo>();
        foreach(Veiculo x in veiculos)
            if(x.GetIdProprietario() == proprietario.Id)
            z.Add(x);
        return veiculos;
    }
    public static Veiculo ListarVeiculos(int id){
        foreach(Veiculo x in veiculos)
            if (x.GetId() == id) return x;
        return null;
    }
    public static void AtualizarVeiculo(Veiculo x){
        Veiculo y = ListarVeiculos(x.GetId());
        if (y != null){
            y.SetModelo(x.GetModelo());
            y.SetAno(x.GetAno());
            y.SetPlaca(x.GetPlaca());
            y.SetCor(x.GetCor());
            y.SetChassi(x.GetChassi());
            y.SetIdFabricante(x.GetIdFabricante());
        }
    }
    public static void ExcluirVeiculo(Veiculo x){
        Veiculo y = ListarVeiculos(x.GetId());
        if (y != null){
            veiculos.Remove(y);
        }
    }

    // Propietario

    public static void InserirProprietario(Proprietario x) {
        int id = 0;
        foreach(Proprietario aux in proprietarios)
            if(aux.Id > id) id = aux.Id;
        x.Id = id + 1;
        
        proprietarios.Add(x);
    }
    public static List<Proprietario> ListarProprietarios(){
        return proprietarios;
    }
    public static Proprietario ListarProprietarios(int id){
        foreach(Proprietario x in proprietarios)
            if (x.Id == id) return x;
        return null;
    }
    public static void AtualizarProprietario(Proprietario x){
        Proprietario y = ListarProprietarios(x.Id);
        if (y != null){
            y.Nome = x.Nome;
            y.Cpf = x.Cpf;
        }
    }
    public static void ExcluirPropietario(Proprietario x){
        Proprietario y = ListarProprietarios(x.Id);
        if (y != null){
            proprietarios.Remove(y);
        }
    }

    // Processo

    public static void InserirProcesso(Processo x) {
        int id = 0;
        foreach(Processo aux in processos)
            if(aux.Id > id) id = aux.Id;
        x.Id = id + 1;
        
        processos.Add(x);
    }
    public static List<Processo> ListarProcessos(){
        return processos;
    }
    public static Processo ListarProcessos(int id){
        foreach(Processo x in processos)
            if (x.Id == id) return x;
        return null;
    }
    public static void AtualizarProcesso(Processo x){
        Processo y = ListarProcessos(x.Id);
        if (y != null){
            y.Descricao = x.Descricao;
            y.Status = x.Status;
            y.Inicio = x.Inicio;
        }
    }
    public static void ExcluirProcesso(Processo x){
        Processo y = ListarProcessos(x.Id);
        if (y != null){
            processos.Remove(y);
        }
    }
}