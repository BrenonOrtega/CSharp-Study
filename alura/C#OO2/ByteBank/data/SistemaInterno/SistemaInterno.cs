using System;
namespace ByteBank.data.SistemaInterno
{
    public class SistemaInterno
    {
        public void Logar(IAutenticavel funcionario, string senha)
        {
            bool isAutenticado = funcionario.Senha == senha;
            string msg = isAutenticado? "Usuário autenticado!" : "Senha Incorreta";
            Console.WriteLine(msg);
        }
    }
}