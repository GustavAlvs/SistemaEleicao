
namespace SistemaEleicao.Console;

public class EleicaoManager
{
    private readonly List<Candidato> candidatos = new();

    public IReadOnlyList<Candidato> Candidatos => candidatos;

    public bool CadastrarCandidato(Candidato candidato)
    {
        if (candidatos.Any(c => c.Numero == candidato.Numero))
            return false;

        candidatos.Add(candidato);
        return true;
    }
}
