// Veterinario
public class Veterinario : Funcionario, ITratamentoAnimal
{
    public Veterinario(string nome, int idade)
        : base(nome, idade, "Veterinário")
    {
    }

    public override void Trabalhar()
    {
        Console.WriteLine($"{Nome} está realizando atendimentos veterinários.");
    }

    public void RealizarTratamento(Animal animal)
    {
        Console.WriteLine($"{Nome} realizou tratamento em {animal.Nome}.");
    }

    public void ConsultarAnimal(Animal animal)
    {
        Console.WriteLine($"{Nome} consultou o animal {animal.Nome}.");
    }
}
