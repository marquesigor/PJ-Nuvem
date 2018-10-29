using PJNuvem.Domain.Interfaces.Arguments;
using System;

namespace PJNuvem.Domain.Arguments.ClassesProcessuais
{
    public class ClasseProcessualResponse : IResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public static explicit operator ClasseProcessualResponse(Model.ClasseProcessual model)
        {
            return new ClasseProcessualResponse()
            {
                Id = model.Id,
                Descricao = model.Descricao
            };
        }
    }
}