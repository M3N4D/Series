using System;
using DIO.Series;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        
        static void Main(string[] args)
        {   
            //Console.Clear();
            string opcaoUsuario = ObterOpcaoUsuario();  
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();;
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "L":
                        Console.Clear();
                        break;
                    default:
                    throw new ArgumentOutOfRangeException();             
                }       
                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorID(indiceSerie);
            Console.WriteLine (serie); //imprime o metodo ToString da Class Serie
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série a Excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Gênero entre as Opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(
                id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

                repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Genero entre as Opcoes acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoID(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada !!!\n");
                Console.Write("Pressione <Enter> para regressar .......\n");
                Console.ReadLine();
                Console.Clear();
                //ObterOpcaoUsuario();
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaexcluido();
                Console.WriteLine("#ID {0}: ----- {1}  {2}", serie.retornaId(), serie.retornaTitulo(), 
                (excluido ? "   *Excluido*" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("========================================================");
            Console.WriteLine("=     XPTO Séries --------- A Sua Casa de Séries!!!!   =");
            Console.WriteLine("=     Tenha as Melhores Séries Ao Seu Dispor !!!!      =");
            Console.WriteLine("=     Insere a Opção Desejada:                         =");

            Console.WriteLine("=     1 ------------- Listar Séries                    =");
            Console.WriteLine("=     2 ------------- Inserir Nova Série               =");
            Console.WriteLine("=     3 ------------- Actualizar Série                 =");
            Console.WriteLine("=     4 ------------- Excluir Série                    =");
            Console.WriteLine("=     5 ------------- Visualizar Série                 =");
            Console.WriteLine("=     L ------------- Limpar Tela                      =");
            Console.WriteLine("=     X ------------- Sair                             =");
            Console.WriteLine("========================================================");
            Console.Write("Opção Desejada: ");
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
