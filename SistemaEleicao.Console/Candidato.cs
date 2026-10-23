
namespace SistemaEleicao.Console;

public class Candidato
{
    public string Nome { get; }
    public int Numero { get; }

    public Candidato(string nome, int numero)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatório.");

        if (numero <= 0)
            throw new ArgumentException("O número deve ser positivo.");

        Nome = nome;
        Numero = numero;
    }
}
