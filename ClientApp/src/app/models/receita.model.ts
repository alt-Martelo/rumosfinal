export interface Receita
{
  ReceitaId?: number;
  titulo: string;
  categoria: string;
  dificuldade: string;
  duracaoMinutos: number;
  descricao: string;
  ingredientes:
  {
  nome: string;
  quantidade: number;
  unidade: string;
  }[];
}
