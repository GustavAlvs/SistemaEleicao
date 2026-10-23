
using SistemaEleicao.Console;

var eleicao = new EleicaoManager();
bool executando = true;

while (executando)
{
    Console.WriteLine("\n=== SISTEMA DE ELEIÇÃO ===");
    Console.WriteLine("1 - Cadastrar candidato");
    Console.WriteLine("2 - Registrar eleitor");
    Console.WriteLine("3 - Votar");
    Console.WriteLine("4 - Apurar votos");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome do candidato: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Número do candidato: ");

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                try
                {
                    var candidato = new Candidato(nome, numero);

                    if (eleicao.CadastrarCandidato(candidato))
                        Console.WriteLine("Candidato cadastrado!");
                    else
                        Console.WriteLine("Esse número já está cadastrado.");
                }
                catch (ArgumentException erro)
                {
                    Console.WriteLine(erro.Message);
                }
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
            break;

        case "2":
            Console.Write("Título/CPF simulado: ");
            string identificador = Console.ReadLine() ?? "";

            if (eleicao.RegistrarEleitor(identificador))
                Console.WriteLine("Eleitor registrado!");
            else
                Console.WriteLine("Identificador vazio ou já cadastrado.");
            break;

        case "3":
            Console.Write("Título/CPF simulado: ");
            string eleitor = Console.ReadLine() ?? "";

            Console.WriteLine("Digite o número do candidato.");
            Console.WriteLine("Digite 0 para voto em branco.");
            Console.Write("Voto: ");

            if (int.TryParse(Console.ReadLine(), out int voto))
            {
                if (eleicao.RegistrarVoto(eleitor, voto))
                    Console.WriteLine("Voto registrado!");
                else
                    Console.WriteLine("Eleitor não cadastrado ou já votou.");
            }
            else
            {
                Console.WriteLine("Voto inválido.");
            }
            break;

        case "4":
            Console.WriteLine("\n=== APURAÇÃO ===");

            foreach (var candidato in eleicao.Candidatos)
            {
                Console.WriteLine(
                    $"{candidato.Numero} - {candidato.Nome}: " +
                    $"{eleicao.ObterVotosCandidato(candidato.Numero)} voto(s)"
                );
            }

            Console.WriteLine($"Votos brancos: {eleicao.VotosBrancos}");
            Console.WriteLine($"Votos nulos: {eleicao.VotosNulos}");

            if (eleicao.Candidatos.Count > 0)
            {
                int maiorTotal = eleicao.Candidatos.Max(c =>
                    eleicao.ObterVotosCandidato(c.Numero));

                var vencedores = eleicao.Candidatos
                    .Where(c => eleicao.ObterVotosCandidato(c.Numero) == maiorTotal)
                    .ToList();

                if (maiorTotal == 0)
                    Console.WriteLine("Ainda não há votos válidos para candidatos.");
                else if (vencedores.Count > 1)
                    Console.WriteLine("Resultado empatado entre os candidatos.");
                else
                    Console.WriteLine($"Vencedor: {vencedores[0].Nome}");
            }
            else
            {
                Console.WriteLine("Nenhum candidato cadastrado.");
            }
            break;

        case "0":
            executando = false;
            Console.WriteLine("Sistema encerrado.");
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}
