
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
    
    [Fact]
    public void DeveCadastrarEleitor()
    {
        var eleicao = new EleicaoManager();

        Assert.True(eleicao.RegistrarEleitor("12345"));
    }

    [Fact]
    public void NaoDeveCadastrarEleitorDuplicado()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("12345");

        Assert.False(eleicao.RegistrarEleitor("12345"));
    }

    [Fact]
    public void NaoDevePermitirDoisVotosDoMesmoEleitor()
    {
        var eleicao = new EleicaoManager();
        eleicao.CadastrarCandidato(new Candidato("Ana", 10));
        eleicao.RegistrarEleitor("12345");

        Assert.True(eleicao.RegistrarVoto("12345", 10));
        Assert.False(eleicao.RegistrarVoto("12345", 10));
        Assert.Equal(1, eleicao.ObterVotosCandidato(10));
    }

    [Fact]
    public void DeveContabilizarVotoEmCandidatoInexistenteComoNulo()
    {
        var eleicao = new EleicaoManager();
        eleicao.RegistrarEleitor("12345");

        Assert.True(eleicao.RegistrarVoto("12345", 99));
        Assert.Equal(1, eleicao.VotosNulos);
    }

    [Fact]
    public void DeveContabilizarVotoEmBranco()
    {
        var eleicao = new EleicaoManager();
        eleicao.RegistrarEleitor("12345");

        Assert.True(eleicao.RegistrarVoto("12345", 0));
        Assert.Equal(1, eleicao.VotosBrancos);
    }
}
