using System;
using System.Collections.Generic;

List<Animal> animais = new List<Animal>();
List<Funcionario> funcionarios = new List<Funcionario>();

bool executando = true;

while (executando)
{
    Console.WriteLine("\n--- MENU PRINCIPAL ---");
    Console.WriteLine("1. Cadastrar Animal");
    Console.WriteLine("2. Cadastrar Funcionário");
    Console.WriteLine("3. Interação Animal-Funcionário");
    Console.WriteLine("4. Listar Animais");
    Console.WriteLine("5. Listar Funcionários");
    Console.WriteLine("6. Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();
    Console.WriteLine();

    switch (opcao)
    {
        case "1": CadastrarAnimal(); break;
        case "2": CadastrarFuncionario(); break;
        case "3": Interagir(); break;
        case "4": ListarAnimais(); break;
        case "5": ListarFuncionarios(); break;
        case "6":
            executando = false;
            Console.WriteLine("Encerrando o sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

void CadastrarAnimal()
{
    Console.Write("Tipo de Animal (Mamifero, Ave, Reptil): ");
    string? tipo = Console.ReadLine()?.ToLower();

    Console.Write("Nome: ");
    string? nome = Console.ReadLine();

    Console.Write("Idade: ");
    if (!int.TryParse(Console.ReadLine(), out int idade)) { Console.WriteLine("Idade inválida."); return; }

    Console.Write("Peso: ");
    if (!double.TryParse(Console.ReadLine(), out double peso)) { Console.WriteLine("Peso inválido."); return; }

    Console.Write("Espécie: ");
    string? especie = Console.ReadLine();

    Animal? animal = tipo switch
    {
        "mamifero" => new Mamifero(nome!, idade, peso, especie!),
        "ave" => new Ave(nome!, idade, peso, especie!),
        "reptil" => new Reptil(nome!, idade, peso, especie!),
        _ => null
    };

    if (animal != null)
    {
        animais.Add(animal);
        Console.WriteLine($"Animal cadastrado com sucesso: {animal.Nome}, Idade: {animal.Idade}, Peso: {animal.Peso}kg, Espécie: {animal.Especie}.");
    }
    else
    {
        Console.WriteLine("Tipo de animal inválido.");
    }
}

void CadastrarFuncionario()
{
    Console.Write("Tipo de Funcionário (Veterinario, Zelador): ");
    string? tipo = Console.ReadLine()?.ToLower();

    Console.Write("Nome: ");
    string? nome = Console.ReadLine();

    Console.Write("Idade: ");
    if (!int.TryParse(Console.ReadLine(), out int idade)) { Console.WriteLine("Idade inválida."); return; }

    Funcionario? funcionario = tipo switch
    {
        "veterinario" => new Veterinario(nome!, idade),
        "zelador" => new Zelador(nome!, idade),
        _ => null
    };

    if (funcionario != null)
    {
        funcionarios.Add(funcionario);
        Console.WriteLine($"Funcionário cadastrado com sucesso: {funcionario.Nome}, Idade: {funcionario.Idade}, Cargo: {funcionario.Cargo}.");
    }
    else
    {
        Console.WriteLine("Tipo de funcionário inválido.");
    }
}

void Interagir()
{
    if (animais.Count == 0 || funcionarios.Count == 0)
    {
        Console.WriteLine("É necessário ter pelo menos um animal e um funcionário cadastrados.");
        return;
    }

    Console.WriteLine("Animais:");
    for (int i = 0; i < animais.Count; i++)
        Console.WriteLine($"{i}. {animais[i].Nome} - {animais[i].GetType().Name}");

    Console.Write("Escolha o índice do animal: ");
    if (!int.TryParse(Console.ReadLine(), out int idxAnimal) || idxAnimal < 0 || idxAnimal >= animais.Count)
    {
        Console.WriteLine("Índice inválido.");
        return;
    }

    Animal animal = animais[idxAnimal];

    Console.WriteLine("Funcionários:");
    for (int i = 0; i < funcionarios.Count; i++)
        Console.WriteLine($"{i}. {funcionarios[i].Nome} - {funcionarios[i].Cargo}");

    Console.Write("Escolha o índice do funcionário: ");
    if (!int.TryParse(Console.ReadLine(), out int idxFunc) || idxFunc < 0 || idxFunc >= funcionarios.Count)
    {
        Console.WriteLine("Índice inválido.");
        return;
    }

    Funcionario funcionario = funcionarios[idxFunc];

    Console.WriteLine();
    funcionario.Trabalhar();

    if (funcionario is Veterinario vet)
    {
        vet.ConsultarAnimal(animal);
        vet.RealizarTratamento(animal);
    }
    else if (funcionario is Zelador zel)
    {
        zel.AlimentarAnimal(animal);
        zel.CuidarHabitat(animal);
    }
}

void ListarAnimais()
{
    if (animais.Count == 0)
        Console.WriteLine("Nenhum animal cadastrado.");
    else
    {
        Console.WriteLine("Animais cadastrados:");
        foreach (var animal in animais)
            Console.WriteLine($"{animal.Nome} - {animal.Especie} - {animal.GetType().Name}");
    }
}

void ListarFuncionarios()
{
    if (funcionarios.Count == 0)
        Console.WriteLine("Nenhum funcionário cadastrado.");
    else
    {
        Console.WriteLine("Funcionários cadastrados:");
        foreach (var func in funcionarios)
            Console.WriteLine($"{func.Nome} - {func.Cargo}");
    }
}
