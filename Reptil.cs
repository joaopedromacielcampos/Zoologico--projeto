// Reptil
public class Reptil : Animal
{
    public Reptil(string nome, int idade, double peso, string especie)
        : base(nome, idade, peso, especie)
    {
    }

    public override void EmitirSom()
    {
        Console.WriteLine($"{Nome} está fazendo som de réptil.");
    }

    public override void Movimentar()
    {
        Console.WriteLine($"{Nome} está rastejando.");
    }

    public void Rastejar()
    {
        Console.WriteLine($"{Nome} está rastejando lentamente.");
    }
}
