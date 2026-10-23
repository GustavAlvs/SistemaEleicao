
namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> candidatos = new();
    private readonly HashSet<string> eleitores = new();
    private readonly HashSet<string> eleitoresQueVotaram = new();
    private readonly Dictionary<int, int> votos = new();

    public IReadOnlyList<Candidato> Candidatos => candidatos;

    public int VotosBrancos { get; private set; }
    public int VotosNulos { get; private set; }

    public bool CadastrarCandidato(Candidato candidato)
    {
        if (candidatos.Any(c => c.Numero == candidato.Numero))
            return false;

        candidatos.Add(candidato);
        votos[candidato.Numero] = 0;
        return true;
    }

    public bool RegistrarEleitor(string identificador)
    {
        if (string.IsNullOrWhiteSpace(identificador))
            return false;

        return eleitores.Add(identificador.Trim());
    }

    public bool RegistrarVoto(string identificador, int numeroCandidato)
    {
        identificador = identificador?.Trim() ?? "";

        if (!eleitores.Contains(identificador))
            return false;

        if (!eleitoresQueVotaram.Add(identificador))
            return false;

        if (numeroCandidato == 0)
        {
            VotosBrancos++;
        }
        else if (votos.ContainsKey(numeroCandidato))
        {
            votos[numeroCandidato]++;
        }
        else
        {
            VotosNulos++;
        }

        return true;
    }

    public int ObterVotosCandidato(int numeroCandidato)
    {
        return votos.TryGetValue(numeroCandidato, out int total)
            ? total
            : 0;
    }
}
