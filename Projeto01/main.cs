using System;
using System.Globalization;
using System.Threading;
class Program{

    private static Proprietario proprietarioLogin = null;
    public static void Main(){
        Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-br");

        try{
            Sistema.AbrirArquivos();
        }
        catch(Exception erro){
            Console.WriteLine(erro.Message);
        }

        Console.WriteLine("Bem vindo ao Departamento Estadual de Trânsito - Detran RN");
        int op = 0;
        int perfil = 0;
        do {
            try{
                if(perfil == 0){
                    op = 0;
                    perfil = MenuUsuario();
                }
                if(perfil == 1){
                    op = MenuAdmin();
                    switch(op){
                        case 1 : InserirFabricante(); break;
                        case 2 : ListarFabricante(); break;
                        case 3 : AtualizarFabricante(); break;
                        case 4 : ExcluirFabricante(); break;
                        case 5 : InserirVeiculo(); break;
                        case 6 : ListarVeiculos(); break;
                        case 7 : AtualizarVeiculo(); break;
                        case 8 : ExcluirVeiculo(); break;
                        case 9 : InserirProprietario(); break;
                        case 10 : ListarProprietarios(); break;
                        case 11 : AtualizarProprietario(); break;
                        case 12 : ExcluirProprietario(); break;
                        case 13 : InserirProcesso(); break;
                        case 14 : ListarProcessos(); break;
                        case 15 : AtualizarProcesso(); break;
                        case 16 : ExcluirProcesso(); break;
                        case 17 : AbrirAgenda(); break;
                        case 18 : ConsultarAgenda(); break;
                        case 99 : perfil = 0; break;
                    }
                }
                if(perfil == 2 && proprietarioLogin == null){
                    op = MenuProprietarioLogin();
                    switch(op){
                        case 1 : ProprietarioLogin(); break;
                        case 99 : perfil = 0; break;
                    }
                }
                if( perfil == 2 && proprietarioLogin != null){
                    op = MenuProprietarioLogout();
                    switch(op){
                        case 1 : ConsultarHorariosDisponiveis(); break;
                        case 2 : AgendarAtendimento(); break;
                        case 3 : ListarAtendimentos(); break;
                        case 4 : ListarVeiculosProprietario(); break;
                        case 5 : ProprietarioLogout(); break;
                        case 99 : ProprietarioLogout(); break;
                    }
                }
            }
            catch (Exception erro) {
                op= -1;
                Console.WriteLine("Erro "+ erro.Message);
            }
        }while(op != 0);

        try{
            Sistema.SalvarArquivos();
        }
        catch(Exception erro){
            Console.WriteLine(erro.Message);
        }
    }
    public static void ProprietarioLogin(){
        Console.WriteLine("========= Login do proprietário =========");
        ListarProprietarios();
        Console.WriteLine();
        Console.WriteLine("Informe o id do proprietário para logar no sistema");
        Console.WriteLine("Id: ");
        int id = int.Parse(Console.ReadLine());
        proprietarioLogin = Sistema.ListarProprietarios(id);
    }
    public static void ProprietarioLogout(){
        Console.WriteLine("========= Logout do proprietário =========");
        Console.WriteLine();
        proprietarioLogin = null;
    }
    public static void ConsultarHorariosDisponiveis(){
        Console.WriteLine("--- Consultar horários Disponíveis ---");
        foreach(Agendamento x in Sistema.ListarAgendamento(DateTime.Today))
            Console.WriteLine(x);
        Console.WriteLine("-----------------------------------------");
    }

    public static void AgendarAtendimento(){
        Console.WriteLine("----- Agendar atendimento -----");
        foreach(Agendamento x in Sistema.ListarAgendamento(DateTime.Today))
            Console.WriteLine(x);
        Console.WriteLine();
        Console.WriteLine("Informe o id do horário para agendamento:");
        int idAgendamento = int.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Agendamento referente ao processo: ");
        foreach(Processo y in Sistema.ListarProcessos(proprietarioLogin))
            Console.WriteLine(y);
        Console.WriteLine("Id do processo:");
        int idProcesso = int.Parse(Console.ReadLine());

        Agendamento z = new Agendamento{Id = idAgendamento,idProprietario = proprietarioLogin.Id, idProcesso = idProcesso};

        Sistema.AtualizarAgendamento(z);

        Console.WriteLine("----- Horário agendado -----");
    }
    public static void ListarAtendimentos(){
        Console.WriteLine("---- Listar meu atendimentos ----");
        foreach(Agendamento x in Sistema.ListarAgendamento(proprietarioLogin))
            Console.WriteLine(x);
        Console.WriteLine("-----------------------------------------");
    }
    public static void ListarVeiculosProprietario(){
        Console.WriteLine("---- Listar meus veículos ----");
        foreach(Veiculo x in   Sistema.ListarVeiculos(proprietarioLogin)){
            Fabricante f = Sistema.ListarFabricante(x.GetIdFabricante());
            Proprietario p = Sistema.ListarProprietarios(x.GetIdProprietario());
            Console.WriteLine($"{x} - {f.GetNome()} - {p.Nome}");
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }


    public static int MenuUsuario(){
        Console.WriteLine();
        Console.WriteLine("========= Escolha uma opção =========");
        Console.WriteLine("01) Entrar como administrador");
        Console.WriteLine("02) Entrar como proprietário");
        Console.WriteLine("00) Finalizar o sistema");
        Console.WriteLine("====== Digite a opção desejada ======");
        Console.Write("Opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }
    public static int MenuProprietarioLogin(){
        Console.WriteLine();
        Console.WriteLine("========= Escolha uma opção =========");
        Console.WriteLine("01) Fazer login");
        Console.WriteLine("99) Voltar");
        Console.WriteLine("00) Finalizar o sistema");
        Console.WriteLine("======= Digite a opção desejada =======");
        Console.Write("Opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }
    public static int MenuProprietarioLogout(){
        Console.WriteLine();
        Console.WriteLine("====================================");
        Console.WriteLine("Bem vindo (a), " + proprietarioLogin.Nome);
        Console.WriteLine("======== Escolha uma opção =========");
        Console.WriteLine("01) Consultar os horários disponíveis");
        Console.WriteLine("02) Agendar atendimento");
        Console.WriteLine("03) Listar meus atendimentos");
        Console.WriteLine("04) Listar meus veículos");
        Console.WriteLine("05) Logout");
        Console.WriteLine("00) Finalizar o sistema");
        Console.WriteLine("========== Digite a opção desejada ==========");
        Console.Write("Opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }

    public static int MenuAdmin(){
        Console.WriteLine("========= Escolha uma opção =========");
        Console.WriteLine(" ");
        Console.WriteLine("------------ Fabricante ------------");
        Console.WriteLine("01) Inserir um novo fabricante");
        Console.WriteLine("02) Listar os fabricantes cadastrados");
        Console.WriteLine("03) Atualizar um fabricante cadastrado");
        Console.WriteLine("04) Excluir um fabricante do sistema");
        Console.WriteLine("------------ Veículo ---------------");
        Console.WriteLine("05) Inserir um novo veículo");
        Console.WriteLine("06) Listar os veículos cadastrados");
        Console.WriteLine("07) Atualizar um veículo cadastrado");
        Console.WriteLine("08) Excluir um veículo do sistema");
        Console.WriteLine("---------- Proprietário ----------");
        Console.WriteLine("09) Inserir um novo proprietário");
        Console.WriteLine("10) Listar os proprietários cadastrados");
        Console.WriteLine("11) Atualizar um proprietário cadastrado");
        Console.WriteLine("12) Excluir um proprietário do sistema");
        Console.WriteLine("------------ Processo ------------");
        Console.WriteLine("13) Inserir um novo processo");
        Console.WriteLine("14) Listar os processos cadastrados");
        Console.WriteLine("15) Atualizar um processo cadastrado");
        Console.WriteLine("16) Excluir um processo do sistema");
        Console.WriteLine("------------- Agenda -------------");
        Console.WriteLine("17) Abrir agenda");
        Console.WriteLine("18) Consultar agenda");
        Console.WriteLine("------------ Finalizar ------------");
        Console.WriteLine("99) Voltar ao menu de usuário");
        Console.WriteLine("00) Finalizar o sistema");
        Console.WriteLine("========== Digite a opção desejada ==========");
        Console.Write("Opção: ");
        int op = int.Parse(Console.ReadLine());
        Console.WriteLine();
        return op;
    }
    public static void InserirFabricante(){
        Console.WriteLine("----- Inserir fabricante no sistema -----");
        Console.WriteLine("Informe o id");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe o nome do fabricante");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Fabricante x = new Fabricante(id, nome);
        Sistema.InserirFabricante(x);
        Console.WriteLine("----- Fabricante adicionado ao sistema -----");
        Console.WriteLine();
    }
    public static void ListarFabricante(){
        Console.WriteLine("----- Listar fabricantes do sistema -----");
        foreach(Fabricante x in Sistema.ListarFabricante())
            Console.WriteLine(x);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
    public static void AtualizarFabricante(){
        Console.WriteLine("--- Atualizar um fabricante cadastrado ---");
        Console.WriteLine("Informe o id do fabricante que será atualizado");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe o novo nome do fabricante");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Fabricante x = new Fabricante(id, nome);
        Sistema.AtualizarFabricante(x);
        Console.WriteLine("----- Fabricante atualizado no sistema -----");
        Console.WriteLine();
    }
    public static void ExcluirFabricante(){
        Console.WriteLine("----- Excluir um fabricante do sistema -----");

        foreach(Fabricante y in Sistema.ListarFabricante())
            Console.WriteLine(y);
        
        Console.WriteLine("Informe o id do fabricante que será excluído");
        Console.Write("Id: ");
        string nome = "";
        int id = int.Parse(Console.ReadLine());
        Fabricante x = new Fabricante(id, nome);
        Sistema.ExcluirFabricante(x);
        Console.WriteLine("----- Fabricante excluido do sistema -----");
        Console.WriteLine();
    }

    // Veiculos

    public static void InserirVeiculo(){

        Console.WriteLine("----- Inserir um veículo no sistema -----");
        Console.WriteLine("Informe o id");
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o chassi do veículo");
        Console.Write("Chassi: ");
        int chassi = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o ano de fabricação do veículo");
        Console.Write("Ano de fabricação: ");
        int anoFabricacao = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a cor do veículo");
        Console.Write("Cor: ");
        string cor = Console.ReadLine();

        Console.WriteLine("Informe a placa do veículo");
        Console.Write("Placa: ");
        string placa = Console.ReadLine();

        Console.WriteLine("Informe o modelo do veículo");
        Console.Write("Modelo: ");
        string modelo = Console.ReadLine();

        Console.WriteLine("Informe o id do fabricante");
        Console.WriteLine();
        foreach(Fabricante y in Sistema.ListarFabricante())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Id do fabricante: ");
        int idFabricante = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o id do propietário");
        Console.WriteLine();
        foreach(Proprietario z in Sistema.ListarProprietarios())
            Console.WriteLine(z);
        Console.WriteLine();
        Console.Write("Id do proprietário: ");
        int idProprietario = int.Parse(Console.ReadLine());

        Veiculo x = new Veiculo(id, chassi, anoFabricacao, cor, placa, modelo, idFabricante, idProprietario);
        Sistema.InserirVeiculo(x);
        Console.WriteLine("----- Veículo adicionado ao sistema -----");
        Console.WriteLine();
    }
    public static void ListarVeiculos(){
        Console.WriteLine("----- Listar veículos do sistema -----");
        foreach(Veiculo x in Sistema.ListarVeiculos()){
            Fabricante f = Sistema.ListarFabricante(x.GetIdFabricante());
            Proprietario p = Sistema.ListarProprietarios(x.GetIdProprietario());
            Console.WriteLine($"{x} - {f.GetNome()} - {p.Nome}");
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
    public static void AtualizarVeiculo(){
        Console.WriteLine("--- Atualizar um veículo cadastrado ---");
        Console.WriteLine("Informe o id do veículo que será atualizado");
        Console.WriteLine();
        foreach(Veiculo y in Sistema.ListarVeiculos())
            Console.WriteLine(y);
        Console.WriteLine(); 
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe novo número do chassi do veículo");
        Console.Write("Chassi: ");
        int chassi = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o novo ano de fabricação do veículo");
        Console.Write("Ano de fabricação: ");
        int anoFabricacao = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a nova cor do veículo");
        Console.Write("Cor: ");
        string cor = Console.ReadLine();

        Console.WriteLine("Informe a nova placa do veículo");
        Console.Write("Placa: ");
        string placa = Console.ReadLine();

        Console.WriteLine("Informe o novo modelo do veículo");
        Console.Write("Cor: ");
        string modelo = Console.ReadLine();

        Console.WriteLine("Informe o id do fabricante");
        Console.WriteLine();
        foreach(Fabricante y in Sistema.ListarFabricante())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Id do fabricante: ");
        int idFabricante = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o id do propietário");
        Console.WriteLine();
        foreach(Proprietario z in Sistema.ListarProprietarios())
            Console.WriteLine(z);
        Console.WriteLine();
        Console.Write("Id do proprietario: ");
        int idProprietario = int.Parse(Console.ReadLine());

        Veiculo x = new Veiculo(id, chassi, anoFabricacao, cor, placa, modelo, idFabricante, idProprietario);
        Sistema.AtualizarVeiculo(x);
        Console.WriteLine("----- Veículo atualizado no sistema -----");
        Console.WriteLine();
    }
    public static void ExcluirVeiculo(){
        Console.WriteLine("----- Excluir um veículo do sistema -----");

        Console.WriteLine("Informe o id do veículo que será excluído");
        foreach(Veiculo y in Sistema.ListarVeiculos())
            Console.WriteLine(y);
        Console.WriteLine();

        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());
        Veiculo x = new Veiculo(id);
        Sistema.ExcluirVeiculo(x);
        Console.WriteLine("----- Veículo excluido do sistema -----");
        Console.WriteLine();
    }

    //Propietario

    public static void InserirProprietario(){

        Console.WriteLine("----- Inserir um proprietário no sistema -----");
        Console.WriteLine("Informe o nome do proprietário");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe o cpf do proprietário (apenas números)");
        Console.Write("Cpf: ");
        string cpf = Console.ReadLine();

        Proprietario x = new Proprietario{Nome = nome, Cpf = cpf};
        Sistema.InserirProprietario(x);
        Console.WriteLine("----- Proprietário adicionado ao sistema -----");
        Console.WriteLine();
    }
    public static void ListarProprietarios(){
        Console.WriteLine("----- Listar proprietários do sistema -----");
        foreach(Proprietario x in Sistema.ListarProprietarios())
            Console.WriteLine(x);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
    public static void AtualizarProprietario(){
        Console.WriteLine("--- Atualizar um proprietário cadastrado ---");
        Console.WriteLine("Informe o id do proprietário que será atualizado");
        foreach(Proprietario y in Sistema.ListarProprietarios())
            Console.WriteLine(y);
        Console.WriteLine();

        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe novo nome do proprietário");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Informe o novo cpf do proprietário");
        Console.Write("Cpf: ");
        string cpf = Console.ReadLine();

        Proprietario x = new Proprietario{Id = id ,Nome = nome, Cpf = cpf};
        Sistema.AtualizarProprietario(x);
        Console.WriteLine("----- Proprietário atualizado no sistema -----");
        Console.WriteLine();
    }
    public static void ExcluirProprietario(){
        Console.WriteLine("----- Excluir um proprietário do sistema -----");
        Console.WriteLine("Informe o id do proprietário que será excluído");
        foreach(Proprietario y in Sistema.ListarProprietarios())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Proprietario x = new Proprietario{Id = id};
        Sistema.ExcluirPropietario(x);
        Console.WriteLine("----- Proprietário excluido do sistema -----");
        Console.WriteLine();
    }

    //Processo

    public static void InserirProcesso(){

        Console.WriteLine("----- Inserir um processo no sistema -----");
        Console.WriteLine("Informe o interessado do processo");
        foreach(Proprietario y in Sistema.ListarProprietarios())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Interessado: ");
        int idProprietario = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a descrição do processo");
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Informe o status do processo");
        Console.Write("Status: ");
        string status = Console.ReadLine();

        Console.WriteLine("Informe a data de início do processo (formato xx/xx/xxxx)");
        Console.Write("Data de início: ");
        DateTime inicio = DateTime.Parse(Console.ReadLine());

        Processo x = new Processo{IdProprietario = idProprietario, Descricao = descricao,Status = status, Inicio = inicio};
        Sistema.InserirProcesso(x);
        Console.WriteLine("----- Processo adicionado ao sistema -----");
        Console.WriteLine();
    }
    public static void ListarProcessos(){
        Console.WriteLine("----- Listar processos do sistema -----");
        foreach(Processo x in Sistema.ListarProcessos())
            Console.WriteLine(x);
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
    public static void AtualizarProcesso(){
        Console.WriteLine("--- Atualizar um processo cadastrado ---");
        Console.WriteLine("Informe o id do processo que será atualizado");
        foreach(Processo y in Sistema.ListarProcessos())
            Console.WriteLine(y);
        Console.WriteLine();

        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe o novo interessado do processo");
        foreach(Processo y in Sistema.ListarProcessos())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Interessado: ");
        int idProprietario = int.Parse(Console.ReadLine());

        Console.WriteLine("Informe a nova descrição do processo");
        Console.Write("Descrição: ");
        string descricao = Console.ReadLine();

        Console.WriteLine("Informe o novo status do processo");
        Console.Write("Status: ");
        string status = Console.ReadLine();

        Console.WriteLine("Informe a nova data de início do processo (formato xx/xx/xxxx)");
        Console.Write("Data: ");
        DateTime inicio = DateTime.Parse(Console.ReadLine());

        Processo x = new Processo{Id = id , Status=status ,Descricao = descricao, Inicio = inicio};
        Sistema.AtualizarProcesso(x);
        Console.WriteLine("----- Processo atualizado no sistema -----");
        Console.WriteLine();
    }
    public static void ExcluirProcesso(){
        Console.WriteLine("----- Excluir um processo do sistema -----");
        Console.WriteLine("Informe o id do processo que será excluído");
        foreach(Processo y in Sistema.ListarProcessos())
            Console.WriteLine(y);
        Console.WriteLine();
        Console.Write("Id: ");
        int id = int.Parse(Console.ReadLine());

        Processo x = new Processo{Id = id};
        Sistema.ExcluirProcesso(x);
        Console.WriteLine("----- Processo excluido do sistema -----");
        Console.WriteLine();
    }

    //Agendamento

    public static void AbrirAgenda(){
        Console.WriteLine("----- Abrir agenda -----");
        DateTime data = DateTime.Today;
        Console.WriteLine("Informe o dia da agenda a ser aberto <enter para hoje>");
        Console.Write("Dia: ");
        string dia = Console.ReadLine();
        if(dia != ""){
            data = DateTime.Parse(dia);
        }
        Sistema.AbrirAgenda(data);
        Console.WriteLine("----- Agenda aberta -----");
        Console.WriteLine();
    }
    public static void ConsultarAgenda(){
        Console.WriteLine("----- Consultar agenda -----");
        foreach(Agendamento x in Sistema.ListarAgendamento()){
            Proprietario p = Sistema.ListarProprietarios(x.idProprietario);
            Processo r = Sistema.ListarProcessos(x.idProcesso);
            if (p != null){
                Console.WriteLine(x + " - " + p.Nome +" - " + r.Id + " - " + r.Descricao);
            }
            else{
                Console.WriteLine(x);
            }
        }
        Console.WriteLine("-----------------------------------------");
        Console.WriteLine();
    }
}