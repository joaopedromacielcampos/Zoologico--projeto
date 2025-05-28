// Zelador
public class Zelador : Funcionario, ICuidador
{
    public Zelador(string nome, int idade)
        : base(nome, idade, "Zelador")
    {
    }

    public override void Trabalhar()
    {
        Console.WriteLine($"{Nome} está cuidando da manutenção dos habitats.");
    }

    public void CuidarHabitat(Animal animal)
    {
        Console.WriteLine($"{Nome} cuidou do habitat do animal {animal.Nome}.");
    }

    public void AlimentarAnimal(Animal animal)
    {
        Console.WriteLine($"{Nome} alimentou o animal {animal.Nome}.");
    }
}
