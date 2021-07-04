/*
    Abstração da Lista de Series: repositorio de Series;
    Os metodos criados serão usados por quem quiser implementar esta Interface

*/

using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    //T: class de tipo generico
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorID (int id);
        void Insere (T entidade);
        void Exclui (int id);
        void Atualiza(int id, T entidade);
        int ProximoID();
        
    }
}