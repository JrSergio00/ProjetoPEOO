using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

class Sistema{
    private static Fabricante[] fabricantes = new Fabricante[10];
    private static int nFabricante;
    private static List<Veiculo> veiculos = new List<Veiculo>();
    private static List<Proprietario> proprietarios = new List<Proprietario>();
    private static List<Processo> processos = new List<Processo>();
    private static List<Agendamento> agendamentos = new List<Agendamento>();
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

    //Processo
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

    public static List<Processo> ListarProcessos(Proprietario proprietario){
        List<Processo> z = new List<Processo>();
        foreach(Processo x in processos)
            if(x.IdProprietario == proprietario.Id)
            z.Add(x);
        return processos;
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

    // Agendamento

    public static void InserirAgendamento(Agendamento x) {
        int id = 0;
        foreach(Agendamento aux in agendamentos)
            if(aux.Id > id) id = aux.Id;
        x.Id = id + 1;
        
        agendamentos.Add(x);
    }
    public static List<Agendamento> ListarAgendamento(){
        return agendamentos;
    }
    public static Agendamento ListarAgendamento(int id){
        foreach(Agendamento x in agendamentos)
            if (x.Id == id) return x;
        return null;
    }

    public static List<Agendamento> ListarAgendamento(Proprietario proprietario){
        List<Agendamento> z = new List<Agendamento>();

        foreach(Agendamento x in agendamentos)
            if(x.idProprietario == proprietario.Id)
                z.Add(x);
        return z;
    }
    public static List<Agendamento> ListarAgendamento(DateTime data){
        List<Agendamento> z = new List<Agendamento>();
        foreach(Agendamento x in agendamentos)
            if(x.idProprietario == 0 && x.Data.Date == data.Date)
            z.Add(x);
        return z;
    }

    public static void AtualizarAgendamento(Agendamento x){
        Agendamento y = ListarAgendamento(x.Id);
        if (y != null){
            //y.Data = x.Data;
            y.idProcesso = x.idProcesso;
            y.idProprietario = x.idProprietario;
        }
    }
    public static void ExcluirAgendamento(Agendamento x){
        Agendamento y = ListarAgendamento(x.Id);
        if (y != null){
            agendamentos.Remove(y);
        }
    }
    public static void AbrirAgenda(DateTime Data){
        int[] horarios = {8, 9, 10, 11, 14, 15, 16};
        DateTime hoje = Data.Date;
        foreach (int h in horarios){
            TimeSpan atendimento = new TimeSpan(0, h, 0 ,0);
            Agendamento x = new Agendamento {Data = hoje + atendimento};
            InserirAgendamento(x);
        }
    }
    public static void AbrirArquivos(){
        Arquivo<Fabricante[]> f1 = new Arquivo<Fabricante[]>();
        fabricantes = f1.Abrir("./fabricantes.xml");
        nFabricante = fabricantes.Length;

        Arquivo<List<Veiculo>> f2 = new Arquivo<List<Veiculo>>();
        veiculos = f2.Abrir("./veiculos.xml");

        Arquivo<List<Proprietario>> f3 = new Arquivo<List<Proprietario>>();
        proprietarios = f3.Abrir("./proprietarios.xml");

        Arquivo<List<Processo>> f4 = new Arquivo<List<Processo>>();
        processos = f4.Abrir("./processos.xml");

        Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
        agendamentos = f5.Abrir("./agendamentos.xml");

    }
    public static void SalvarArquivos(){
        Arquivo<Fabricante[]> f1 = new Arquivo<Fabricante[]>{};
        f1.Salvar("./fabricantes.xml", ListarFabricante());

        Arquivo<List<Veiculo>> f2 = new Arquivo<List<Veiculo>>();
        f2.Salvar("./veiculos.xml", veiculos);

        Arquivo<List<Proprietario>> f3 = new Arquivo<List<Proprietario>>();
        f3.Salvar("./proprietarios.xml", proprietarios);

        Arquivo<List<Processo>> f4 = new Arquivo<List<Processo>>();
        f4.Salvar("./processos.xml", processos);

        Arquivo<List<Agendamento>> f5 = new Arquivo<List<Agendamento>>();
        f5.Salvar("./agendamentos.xml", agendamentos);

    }
}