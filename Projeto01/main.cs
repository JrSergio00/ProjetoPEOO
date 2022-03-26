using System;
class Program{
    public static void Main(){
        Console.WriteLine("Bem vindo ao Departamento Estadual de Trânsito - Detran RN");
        int op = 0;
        do {
            try{
                op = Menu();
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
                }
            }
            catch (Exception erro) {
                op= -1;
                Console.WriteLine("Erro "+ erro.Message);
            }
        }while(op != 0);
    }
    public static int Menu(){
        Console.WriteLine("============ Escolha uma opção ============");
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
        Console.WriteLine("------------ Proprietário ------------");
        Console.WriteLine("09) Inserir um novo proprietário");
        Console.WriteLine("10) Listar os proprietários cadastrados");
        Console.WriteLine("11) Atualizar um proprietário cadastrado");
        Console.WriteLine("12) Excluir um proprietário do sistema");
        Console.WriteLine("------------ Finalizar ------------");
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
}