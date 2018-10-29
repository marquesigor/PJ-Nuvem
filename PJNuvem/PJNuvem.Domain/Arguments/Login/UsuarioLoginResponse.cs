using PJNuvem.Domain.Interfaces.Arguments;

namespace PJNuvem.Domain.Arguments.Login
{
    public class UsuarioLoginResponse : IResponse
    {
        public string Nome { get; set; }
        public string Perfil { get; set; }
        public string Mensagem { get; set; }

        public static explicit operator UsuarioLoginResponse(Model.Usuario model)
        {
            return new UsuarioLoginResponse()
            {
                Nome =  model.Nome.PrimeiroNome,
                Perfil = model.Perfil.Descricao,
                Mensagem = Resources.Messages_PT_BR.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
