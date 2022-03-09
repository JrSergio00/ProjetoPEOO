using System;
using System.Collections.Generic;

class Sistema{
    private static Fabricante[] fabricantes = new Fabricante[10];
    private static int nFabricante;
    private static List<Veiculo> veiculos = new List<Veiculo>();
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
}