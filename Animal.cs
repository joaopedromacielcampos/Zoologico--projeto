// Animal
public abstract class Animal
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public string Especie { get; set; }

    public Animal(string nome, int idade, double peso, string especie)
    {
        Nome = nome;
        Idade = idade;
        Peso = peso;
        Especie = especie;
    }

    public abstract void EmitirSom();
    public abstract void Movimentar();
}
