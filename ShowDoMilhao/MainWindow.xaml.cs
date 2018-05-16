using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShowDoMilhao
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public Jogador Jogador;
        public List<Pergunta> Perguntas;
        public int IDPerguntaAtual;

        public MainWindow()
        {
            Perguntas = new List<Pergunta>();
            InitializeComponent();
            IDPerguntaAtual = 0;

            var pergunta10 = new Pergunta
            {
                Enunciado = "Qual a sigla de Quilômentro?",
                Resposta1 = "QM",
                Resposta2 = "KK",
                Resposta3 = "MK",
                Resposta4 = "KM",
                Resposta5 = "QMT",
                RespostaCorreta = 4
            };
            var pergunta9 = new Pergunta
            {
                Enunciado = "Quantos dias tem um ano bissexto?",
                Resposta1 = "366",
                Resposta2 = "320",
                Resposta3 = "364",
                Resposta4 = "365",
                Resposta5 = "401",
                RespostaCorreta = 1
            };
            var pergunta8 = new Pergunta
            {
                Enunciado = "qual esporte não é praticado na grama?",
                Resposta1 = "Futebol",
                Resposta2 = "Golf",
                Resposta3 = "Baseball",
                Resposta4 = "Volei",
                Resposta5 = "Basquete",
                RespostaCorreta = 5
            };
            var pergunta1 = new Pergunta
            {
                Enunciado = "Em qual lugar o comunismo deu certo?",
                Resposta1 = "Brasil",
                Resposta2 = "Russia",
                Resposta3 = "Venezuela",
                Resposta4 = "EUA",
                Resposta5 = "Comunismo não funciona",
                RespostaCorreta = 5
            };
            var pergunta2 = new Pergunta
            {
                Enunciado = "Qual é o nome dado ao segundo lugar numa competição",
                Resposta1 = "último",
                Resposta2 = "quase camperão",
                Resposta3 = "vice campeão",
                Resposta4 = "segundo campeão",
                Resposta5 = "campeão em segundo lugar",
                RespostaCorreta = 3
            };
            var pergunta3 = new Pergunta
            {
                Enunciado = "Qual é o estado físico do vidro?",
                Resposta1 = "Liquido",
                Resposta2 = "Sólido",
                Resposta3 = "Gasoso",
                Resposta4 = "Plasma",
                Resposta5 = "Nenhuma das alternativas",
                RespostaCorreta = 1
            };

            var pergunta4 = new Pergunta
            {
                Enunciado = "Qual maior orgão do corpo humano",
                Resposta1 = "Cabeça",
                Resposta2 = "Perna",
                Resposta3 = "Pele",
                Resposta4 = "Cérebro",
                Resposta5 = "intestino",
                RespostaCorreta = 3
            };

            var pergunta5 = new Pergunta
            {
                Enunciado = "Quantos ossos possui o corpo humano?",
                Resposta1 = "208",
                Resposta2 = "320",
                Resposta3 = "98",
                Resposta4 = "45",
                Resposta5 = "206",
                RespostaCorreta = 5
            };
            var pergunta6 = new Pergunta
            {
                Enunciado = "Quanto tempo a luz solar demora para chegar à terra?",
                Resposta1 = "2 minutos e 30 segundos",
                Resposta2 = "5 minutos e 40 segundos",
                Resposta3 = "1 minuto",
                Resposta4 = "8 minutos e 20 segundos",
                Resposta5 = "10 minutos e 35 segundos",
                RespostaCorreta = 4
            };
            var pergunta7 = new Pergunta
            {
                Enunciado = "Qual foi o placar de Brasil e Alemanha na copa de 2014? ",
                Resposta1 = "Alemanha 4 X Brasil 5",
                Resposta2 = "Alemanha 7 X Brasil 1",
                Resposta3 = "Alemanha 7 X Brasil 10",
                Resposta4 = "Alemanha 0 X Brasil 5",
                Resposta5 = "Alemanha 7 X Brasil 0",
                RespostaCorreta = 2
            };

            Perguntas.Add(pergunta1);
            Perguntas.Add(pergunta2);
            Perguntas.Add(pergunta3);
            Perguntas.Add(pergunta4);
            Perguntas.Add(pergunta5);
            Perguntas.Add(pergunta6);
            Perguntas.Add(pergunta7);
            Perguntas.Add(pergunta8);
            Perguntas.Add(pergunta9);
            Perguntas.Add(pergunta10);
        }

        private void MostrarPergunta(Pergunta pergunta)
        {
            LabelPontuacao.Content = "Pontuação " + Jogador.Pontuacao;
            TextBlockEnunciado.Text = pergunta.Enunciado;
            RadioButtonResposta1.Content = pergunta.Resposta1;
            RadioButtonResposta2.Content = pergunta.Resposta2;
            RadioButtonResposta3.Content = pergunta.Resposta3;
            RadioButtonResposta4.Content = pergunta.Resposta4;
            RadioButtonResposta5.Content = pergunta.Resposta5;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nome = TextBoxNomeJogador.Text;
            this.Jogador = new Jogador(nome, 0);
            GridTelaAbertura.Visibility = Visibility.Hidden;
            GridTelaPergunta.Visibility = Visibility.Visible;

            LabelNomeJogador.Content = 
                this.Jogador.Nome 
                + " jogando";

            MostrarPergunta(Perguntas[0]);

            Console.WriteLine(this.Jogador.Nome);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Checar se a resposta está correta
            var perguntaAtual = Perguntas[IDPerguntaAtual];
            var respostaPergunta = perguntaAtual.RespostaCorreta;

            int respostaSelecionada = 0;

            if(RadioButtonResposta1.IsChecked.Value) respostaSelecionada = 1;
            else if(RadioButtonResposta2.IsChecked.Value) respostaSelecionada = 2;
            else if(RadioButtonResposta3.IsChecked.Value) respostaSelecionada = 3;
            else if(RadioButtonResposta4.IsChecked.Value) respostaSelecionada = 4;
            else if(RadioButtonResposta5.IsChecked.Value) respostaSelecionada = 5;        

            if(respostaSelecionada == respostaPergunta)
            {
                Jogador.Pontuacao = Jogador.Pontuacao + 10;
            }
            else
            {
                MostrarFinal();
            }

            IDPerguntaAtual = IDPerguntaAtual + 1;

            if(IDPerguntaAtual < Perguntas.Count)
            {
                MostrarPergunta(Perguntas[IDPerguntaAtual]);
            }
            else
            {
                MostrarFinal();
            }
        }

        private void MostrarFinal()
        {
            GridTelaPergunta.Visibility = Visibility.Hidden;
            GridTelaFinal.Visibility = Visibility.Visible;

            TextBlockFinal.Text =
                "O jogo acabou!\n A sua pontuação foi: " +
                Jogador.Pontuacao +
                " pontos!";
        }
    }

    public class Pergunta
    {
        public string Enunciado;
        public string Resposta1;
        public string Resposta2;
        public string Resposta3;
        public string Resposta4;
        public string Resposta5;
        public int RespostaCorreta;
    }
}
