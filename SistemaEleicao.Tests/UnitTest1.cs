
using Xunit;
using SistemaEleicao.Console;

namespace SistemaEleicao.Tests;

public class CandidatoTests
{
    [Fact]
    public void DeveCadastrarCandidatoComNumeroNovo()
    {
        var eleicao = new EleicaoManager();
        var candidato = new Candidato("Ana", 10);

        bool resultado = eleicao.CadastrarCandidato(candidato);

        Assert.True(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void NaoDeveCadastrarCandidatosComMesmoNumero()
    {
        var eleicao = new EleicaoManager();

        var primeiro = new Candidato("Ana", 10);
        var segundo = new Candidato("Carlos", 10);

        eleicao.CadastrarCandidato(primeiro);
        bool resultado = eleicao.CadastrarCandidato(segundo);

        Assert.False(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void NaoDeveCriarCandidatoSemNome()
    {
        Assert.Throws<ArgumentException>(
            () => new Candidato("", 10)
        );
    }
}
