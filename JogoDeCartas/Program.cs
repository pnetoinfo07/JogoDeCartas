using JogoDeCartas;

Baralho b = new Baralho(2);
Jogador j1 =new Jogador();
j1.Nome = "Paulo";
j1.Id= 1;
b.Embaralhar();
b.Embaralhar();
b.DistribuirCartas(j1);
j1.MostrarMaoJogador();
