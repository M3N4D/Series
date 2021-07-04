/*
Classe para gerar o Id -----> classe abstracta.
Todas as classes que herdarem dela irão ter um ID
*/

namespace DIO.Series.Classes
{
    public abstract class EntidadeBase
    {
        public int Id {get; protected set;}
    }
}