using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUsuario = ObterOpcaoUsuario();

           while(opcaoUsuario.ToUpper() != "X")
           {
               switch(opcaoUsuario)
               {
                   case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;        
                    case "4":
                        ExcluiSeries();
                        break;
                    case "5":
                        VisualizaSeries();
                        break;    
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();   
               }
               opcaoUsuario = ObterOpcaoUsuario();
           }
            
        }

        private static void VisualizaSeries()
        {
           Console.WriteLine("Digite o indice da série");
            int index = int.Parse(Console.ReadLine());

            object serie = repositorio.RetornaPorId(index);
            Console.WriteLine(serie);
        }

        private static void ExcluiSeries()
        {
            Console.WriteLine("Digite o indice da série");
            int index = int.Parse(Console.ReadLine());

            repositorio.Exclui(index);
        }

        private static void AtualizarSeries()
        {
            Console.WriteLine("Digite o indice da série");
            int index = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o Gênero:");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série");
            int inAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao da Série: ");
            string inDescricao = Console.ReadLine(); 

            Serie serie = new Serie(id:index,
                                    genero: (Genero)inGenero,
                                    titulo: inTitulo,
                                    descricao: inDescricao,
                                    ano: inAno);

            repositorio.Atualiza(index,serie);         

        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir:");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o Gênero:");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Série: ");
            string inTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série");
            int inAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descricao da Série: ");
            string inDescricao = Console.ReadLine(); 

            Serie serie = new Serie(id:repositorio.ProximoId(),
                                    genero: (Genero)inGenero,
                                    titulo: inTitulo,
                                    descricao: inDescricao,
                                    ano: inAno);

            repositorio.Insere(serie);    
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar: ");
            var aux = repositorio.Lista();
            if(aux.Count == 0)
            {
                Console.WriteLine("Lista vazia");
                return;
            }

            foreach(var serie in aux)
            {
                var vfalse = serie.retornaExcluido();
                if(vfalse == false){
                Console.WriteLine("#ID {0}: - {1}",serie.retornaId(),serie.retornaTitulo());
                }
            }

        }

        private static string ObterOpcaoUsuario(){

            Console.WriteLine();
            Console.WriteLine("Series:");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1 - Listar série");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
